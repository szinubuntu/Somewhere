﻿using StringHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Somewhere
{
    /// <summary>
    /// An in-memory representation of repository for `dump` command;
    /// Utilizes data from `Journal` table;
    /// Virtual Repository simulates all operations in journal and creates
    /// a state that mimic effects to database from input commits at a given time
    /// </summary>
    internal class VirtualRepository
    {
        #region Private Types
        /// <summary>
        /// A very generic and simple representation of all information we 
        /// care about for an item (per current implementation)
        /// </summary>
        private class Item
        {
            public string Name { get; set; }
            public string Tags { get; set; }
            public string Content { get; set; }
            /// <summary>
            /// Used for providing extra communicative information to the user, not data content
            /// </summary>
            public string Remark { get; set; }
        }
        #endregion

        #region Private Properties
        private List<Item> Items { get; set; } = new List<Item>();
        #endregion

        #region Types
        /// <summary>
        /// The format for dumping state of virtual repository
        /// </summary>
        public enum DumpFormat
        {
            /// <summary>
            /// Dump into portable csv
            /// </summary>
            CSV,
            /// <summary>
            /// Dump into a plain HTML report
            /// </summary>
            Report,
            /// <summary>
            /// Dump into a SQLite database
            /// </summary>
            SQLite
        }
        #endregion

        #region Methods
        /// <summary>
        /// Pass-through a sequence of commits and update states accordingly
        /// </summary>
        public void PassThrough(IEnumerable<JournalRow> commits)
        {
            // Initialize a state representing unique items
            Dictionary<string, Item> items = new Dictionary<string, Item>();
            // Simulate through commit history
            foreach (var commit in commits)
            {
                // Skip irrelevant entries
                if (commit.JournalType == JournalType.Log) continue;
                // Simulate state per operation type
                var commitEvent = commit.JournalEvent;
                switch (commitEvent.Operation)
                {
                    case JournalEvent.CommitOperation.CreateNote:
                        items.Add(commitEvent.Target, new Item() { Name = commitEvent.Target });    // Assum only success operations are recorded as commit journal entry
                        break;
                    case JournalEvent.CommitOperation.AddFile:
                        items.Add(commitEvent.Target, new Item() { Name = commitEvent.Target });    // Assum only success operations are recorded as commit journal entry
                        break;
                    case JournalEvent.CommitOperation.DeleteFile:
                        items.Remove(commitEvent.Target);   // Assume it exists
                        break;
                    case JournalEvent.CommitOperation.ChangeItemName:
                        items[commitEvent.Target].Name = commitEvent.UpdateValue;    // Assume it exists and there is no name conflict due to natural order of commit journal records
                        break;
                    case JournalEvent.CommitOperation.ChangeItemTags:
                        items[commitEvent.Target].Tags = commitEvent.UpdateValue;    // Assume it exists
                        break;
                    case JournalEvent.CommitOperation.DeleteTag:
                        foreach (var item in items)
                        {
                            List<string> oldTags = item.Value.Tags.SplitTags().ToList();
                            if (oldTags.Contains(commitEvent.Target))
                                item.Value.Tags = oldTags.Except(new string[] { commitEvent.Target }).JoinTags();
                        }
                        break;
                    case JournalEvent.CommitOperation.RenameTag:
                        foreach (var item in items)
                        {
                            List<string> oldTags = item.Value.Tags.SplitTags().ToList();
                            if (oldTags.Contains(commitEvent.Target))
                                item.Value.Tags = oldTags
                                    .Except(new string[] { commitEvent.Target })
                                    .Union(new string[] { commitEvent.UpdateValue })
                                    .JoinTags();
                        }
                        break;
                    case JournalEvent.CommitOperation.ChangeItemContent:
                        if (commitEvent.ValueFormat == JournalEvent.UpdateValueFormat.Difference)
                            throw new ArgumentException("Difference based content commit journal is not supported yet.");
                        items[commitEvent.Target].Content = commitEvent.UpdateValue;    // Assume it exists
                        break;
                    default:
                        // Silently skip un-implemented simulation operations
                        continue;
                }
            }
            Items = items.Values.ToList();
        }
        /// <summary>
        /// Pass-through a sequence of commits and track one particular file;
        /// The output for this tracking will be a sequence of updates to that particular file
        /// </summary>
        /// <param name="targetFilename">Can be any particular name the file ever taken</param>
        public void PassThrough(List<JournalRow> commits, string targetFilename)
        {
            HashSet<string> usedNames = new HashSet<string>();
            usedNames.Add(targetFilename);
            List<JournalRow> relevantCommits = new List<JournalRow>();
            // Go through each commit once in reverse order to collect all potential names
            foreach (var commit in commits.Reverse<JournalRow>())
            {
                var commitEvent = commit.JournalEvent;
                // Skip irrelevant entries
                if (commit.JournalType == JournalType.Log)
                    // Skip this commit event
                    continue;
                // Even if the commit's target name is not targetFilename, it may still refer to the same file
                else if (!usedNames.Contains(commitEvent.Target))
                {
                    switch (commitEvent.Operation)
                    {
                        // If there is a change name event, then the target can still be relevant
                        case JournalEvent.CommitOperation.ChangeItemName:
                            if (usedNames.Contains(commitEvent.UpdateValue))
                            {
                                // Record this as a used name
                                usedNames.Add(commitEvent.Target);
                                relevantCommits.Add(commit);
                                break;
                            }
                            else
                                // Skip this commit event
                                continue;
                        case JournalEvent.CommitOperation.ChangeItemTags:
                        case JournalEvent.CommitOperation.ChangeItemContent:
                        case JournalEvent.CommitOperation.DeleteTag:
                        case JournalEvent.CommitOperation.RenameTag:
                        case JournalEvent.CommitOperation.CreateNote:
                        case JournalEvent.CommitOperation.AddFile:
                        case JournalEvent.CommitOperation.DeleteFile:
                        default:
                            // Skip this commit event
                            continue;
                    }
                }
                // Commit contains the target filename
                else
                    relevantCommits.Add(commit);
            }
            // Go through each commit again to simulate changes in normal order
            int stepSequence = 1;
            foreach (var commit in relevantCommits.Reverse<JournalRow>())
            {
                // Initialize new item by referring to an earlier version
                Item newItem = new Item()
                {
                    Name = $"(Step: {stepSequence})" + Regex.Replace(Items.LastOrDefault()?.Name ?? string.Empty, "\\(Step: .*?\\)(.*?)", "$1"), // Give it a name to show stages of changes throughout lifetime
                    Tags = Items.LastOrDefault()?.Tags,
                    Content = Items.LastOrDefault()?.Content
                };
                // Handle this commit event
                var commitEvent = commit.JournalEvent;
                switch (commitEvent.Operation)
                {
                    case JournalEvent.CommitOperation.CreateNote:
                        newItem.Name = $"(Step: {stepSequence})" + commitEvent.Target;  // Use note name
                        newItem.Remark = "New";  // Indicate the note has been created at this step
                        break;
                    case JournalEvent.CommitOperation.AddFile:
                        newItem.Name = $"(Step: {stepSequence})" + commitEvent.Target;  // Use file name
                        newItem.Remark = "New";  // Indicate the file has been created at this step
                        break;
                    case JournalEvent.CommitOperation.DeleteFile:
                        newItem.Remark = "Deleted";    // Indicate the file has been deleted at this step
                        break;
                    case JournalEvent.CommitOperation.ChangeItemName:
                        newItem.Name = $"(Step: {stepSequence})" + commitEvent.UpdateValue;  // Use updated file name
                        newItem.Remark = "Name change";  // Indicate name change at this step
                        break;
                    case JournalEvent.CommitOperation.ChangeItemTags:
                        newItem.Tags = commitEvent.UpdateValue; // Use updated tags
                        newItem.Remark = "Tag change";  // Indicate tag change at this step
                        break;
                    case JournalEvent.CommitOperation.ChangeItemContent:
                        newItem.Content = commitEvent.UpdateValue;    // Use updated file content
                        newItem.Remark = "Content change";  // Indicate content change at this step
                        break;
                    case JournalEvent.CommitOperation.RenameTag:
                        newItem.Tags = newItem.Tags.SplitTags()
                            .Except(new string[] { commitEvent.Target })
                            .Union(new string[] { commitEvent.UpdateValue })
                            .JoinTags();
                        newItem.Remark = "Tag change";  // Indicate tag change at this step
                        break;
                    case JournalEvent.CommitOperation.DeleteTag:
                        newItem.Tags = newItem.Tags.SplitTags()
                            .Except(new string[] { commitEvent.Target })
                            .JoinTags();
                        newItem.Remark = "Tag change";  // Indicate tag change at this step
                        break;
                    default:
                        break;
                }
                // Record sequence of changes
                Items.Add(newItem);
                // Increment
                stepSequence++;
            }
        }
        /// <summary>
        /// Dump current state of virtual repository into specified format at given location
        /// </summary>
        public void Dump(DumpFormat format, string location)
        {
            string EscapeCSV(string field)
            {
                if (field != null && field.Contains(','))
                {
                    if (field.Contains('"'))
                        field.Replace("\"", "\"\"");
                    field = $"\"{field}\"";
                }
                return field ?? string.Empty;
            }

            switch (format)
            {
                case DumpFormat.CSV:
                    using (StreamWriter writer = new StreamWriter(location))
                    {
                        Csv.CsvWriter.Write(writer, 
                            new string[] { "Name", "Tags", "Content", "Remark" }, 
                            Items.Select(i => new string[] { EscapeCSV(i.Name), EscapeCSV(i.Tags), EscapeCSV(i.Content), EscapeCSV(i.Remark) }));
                    }
                    break;
                case DumpFormat.Report:
                    throw new NotImplementedException();
                case DumpFormat.SQLite:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException($"Invalid format: {format}.");
            }
        }
        #endregion
    }
}
