***(THIS PROJECT IS DEPRECATED, ALL DEVELOPMENT IN THIS GITHUB ORGANIZATION HAS CEASED; FUTURE UPDATES WILL BE PUBLISHED OFFICIALLY ON http://methodox.io/ or on my personal website: https://www.totalimagine.com/)***

(This documentation is still work-in-progress)

[![YouTube Link](Documentation/YouTube%20Video%20Link%20Image.png)](https://www.youtube.com/watch?v=z-GBAwwtFpQ&t=575s)

# Notes

* (Development, Proposal) Notice the whole concept will be re-developed in Qt for cross-platform support. As a redesign and in accordance with new KMD specification, we will drop support for unreasonable names, drop support for file meta, and maybe use simple (master) Path/Name based database scheme instead of using a real database. And there will be no need for a "repository". It's purely text-based, file-system based, name-based, convention-based non-intrusive minimal-application-specific data. ¶The whole abstraction should be re-designed and current Somewhere should go deprecated with Somewhere-CLI extracted as a standalone option.
* (Todo, Urgent, Scenario) VLC can't even do something as simple as "rename" files. That's a bit ridiculous given its (underlying) tremendous power. Evidently Somewhere is a great interface to solve such lame problems.

# Overview

Welcome to **Somewhere**, a simple program that enables you to tag your files in a designated "**Home folder**". it's my best wish that this tool can come handy to you!

**Features**

1. (Code Design) Free, open source, dedicated (in terms of scope), cross-platform, SQLite based, almost 0 dependency (except *SQLite*, *YAML*, **CSV**, *.Net Core Runtime* and if Windows version is used, *WPF*, *NTFSReader*, *Markdig.WPF* and *WindowsAPICodePack*);
3. (Implementation Design) Non-intrusive, File system friendly (existing FS based meta-layer), designed for custom files and decent interoperability with existing hierarchical structure;
4. (Repository Design) Heavily documented including methodology;
6. (Market Design) Cutting Edge technology, C#.Net Core/Standard based, last for another 100 years, will migrate to .Net Core 3.0 when it comes out;
7. (UI Design) Dark mode, B/W color scheme, custom color scheme configuration (will be available in the future);
8. Comments are files!
3. Journals: Active version control! Not super optimized yet, but it works!
2. Exhaustive Functional Units: import Tiddly Wiki json and CSV exports.
2. (Concept Design) **Item** based, **first-class tags**, (custom, attemptive) **theory backed**;
	* Absolutely self contained;
	* Long and expressive item names as you like - even something like this (notice each line is **real**):

```
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********"
This is /my file/ in Somewhere so I should be able to do <anything> I want with it \including "!!!!????**********".txt
```

However, names like that is *not really recommended* - you should name your file whatever way you wish but keep it **succinct and meaningful** so you can easily find it.

**Who should use it**

(I will change the tone below when I get a chance, doesn't sound very cool)

This app is absolutely intended for **personal use**; By design it's not tested for inter-network usage, e.g. between enterprise shared drives. Sharing files on network drive might be OK but it's definitely not intended for *multi-user simultaneously editing*. The key use case is for **heterogeneous file management** - (which is defined as) the more diverse the files, the more specific the file, the better this system can work. If you have tens of thousands of photos for very specific circumstances then you are OK or even better just stick with **regular folders**, but if you have a few thousand pictures that you refer to regularly and each contains a very different **subject** (much like my own Pinterest boards - which is deficient despite the variety because Pinterest's board based management approach is absolutely arcane - but well it's functional because "there is no better (I.e. tag based) solutions yet" (for me)), then this system will be much more efficient. Besides, you can mix the two as mentioned below.

1. Those who have been bothered by note and file organization
2. Those who enjoy tags in other platforms
3. Those who want to explore new ways to organize their documents 
4. Those who are really into *extreme organization* yet find a custom database too much for the purpose of daily uses
5. Developers should all use this
6. Serious everyone who have kept very diverse information on their computer and always had trouble retrieving and backup those data
7. This is NOT for those who never bothered organizing files or giving proper names to files - unless they are seeking a change
8. Those who do not trust cloud and specialize in local file management with sophisticated multi-disk backup plans

**How to Install It**

1. Download the corresponding version of zip file for your computer and unzip it;
2. Add application folder to environment PATH;
3. Run `somewhere` or `sw` to see help;
4. Have fun tagging!
5. Optionally, if you are using Somewhere Desktop, you can set default program for openning `Home.somewhere` files as the **SomewhereDesktop.exe**
6. For Somewhere Desktop, [vc++2015](https://www.microsoft.com/en-ca/download/details.aspx?id=48145) redistributable is also needed.

Optional Download: It's recommended for CLI to be used with [Cmder](https://cmder.net) (better for Unicode display, nicer colors and better overall experience); Notice Cmder is available on Windows only.

To get the latest nightly build for **Win_x64** (which contains commits from all branches), use this [link](https://utoronto-my.sharepoint.com/:f:/r/personal/ttt_zhang_mail_utoronto_ca/Documents/Somewhere-latest?csf=1&e=1TYD33).

# Treatments

> An effective software is not just a **tool**, it's also a **method**. A good software should enable people to **think differently**.

(This section will be moved to *Somewhere - A Concept Design* article on my portfolio)

## Definitions

0. (Field Attribute) **Name**: an identifying string for a particular item.
1. (Object) **Item**: Anything that contains information or data, this corresponds to a **"File"** entry in the `File` table, however in practice, and as in most operating system, "Files" can also denote "Folders", so "item" is used to avoid confusion.
	* Folders are names (path) with trailing seperator;
	* Files are just files;
	* Knowledge are notes doesn't have a name;
	* Notes have Contents
	* Bookmark are notes that contains an url address
2. (Object) Physical Folder: a folder is a file.... and item...
3. (Object) Virtual Note:
4. (File Meta) Remark: 
5. (Object) Repository/Home: each Somewhere home is a repository, managed by SQLite database, contains all tagging information.

## Terminology

1. **TBFS**: Tab based file system
2. **SD**: Stands for "Somewhere Desktop", it's a GUI interface Windows desktop window application, WPF based. 
3. **SW**: Stands for "Somewhere", Specifically refers to Someowhere's CLI interface application.
4. **SA**: Stands for "Somewhere App" in general, mostly refers to the concept of Somewhere - I.e. tag based file management. 

## Concepts

1. Strictly item based - not for managing tags (just like bookmark ninja). Operations are focused around specific items. All commands in generally universally apply to all those items.
2. Tag with efficiency: tagging is only so useful when we spend less time organizing stuff and more easily receive stuff, when it's much faster to assign (as mentioned above) multiple tags than deciding which single folder to put something - a proper command line interface is one step, but it's subject to typos - an efficient GUI (like Bookmark Ninja) is thus especially important .
3. Let me put it this way: there are at least N (N>3) ways to tag a file while there is only one way to put it under a folder - you can see the limit of traditional hierarchical based systems. This applies both in terms of organization and retrieval.
4. Virtual file/note/resource: in the command only notes are supported. Files that exist directly (and only) in database are called "virtual files", in terms of the contents it contains - if it contains text file, it's "virtual note", otherwise for binary it's terms "virtual resource". Filenames are required to be unique among all managed files, no matter whether it's virtual or not. (idea) "Virtual file as resource".. bookmark ninja as notes, OneNote....Evernote...... (virtual note are those that content is not null, including resources and temperaty editing results in UI)
5. `Home.Somewhere`: The idea of using a dedicated home folder for managing all the files originated in MULTITUDE, and is partially inspired by Git which have the idea of a root repository folder - but in this case we are **flattenning files** by exploiting the capability of underlying disk FS.
6. **Flat Physical FS**: I used to have layers of layers of folder structures, making sure **each layer is semantically meaningful**, but then that introduces a lot of management burder, then I discovered that by flattening this structure, and sacrifce "meaning" at root folder, (screenshot of current home disk root folder for D drive), with folder at second level, it actually makes things much easier... with tags, it's even better...
7. (Best practice)**Best possible match filename**: semantics without limit of underlying FS file length
8. Central managed filename: inside database, a mapping...
9.  Expect 10k-100k files: for personal data (as defined in [MULTITUDE](#)), for theoratical limit of NTFS FS system for single folder....efficiency...
10. Tracking/Managed files: By adding files to DB, just like adding files to repository like when using git, we *conscisouly manage each file* and decide which files participate in the system.
11. Intention: Wrapper around sqlite with dedicated interface for specialized oprations; I used to do this for my personal portfolio and while during work at OTPP, partly manually, and found that quite effective, though with proper tools the **scale** can grow.
12. Non-intrusive meta layer: easier maintainence, works well with other editors...
13. Personal data (see def in [MULTITUDE](#)), original data.... scheme should suffice.... Personal FS, not for network and collboration purpose... Data driven definitions...tool driven management...
14. Workflow design: .... download/archive, name, tag, retrieve...
15. Git friendly....Embeeded simple revision control....
16. Support for lightweight developer-oriented parts for easier Web and desktop GUI and direct C# API access of files.... (inspired by Fossil version control.....)
17. SQLite: Fast and efficient, see [proper use](https://www.sqlite.org/whentouse.html)
18. Multi-solution: dedicated single folder for each subject matter, e.g. how I used tiddly wiki... (screenshot?)
19. (deprecated)Master-slave copy: ...
20. (deprecated)Never touch physical files directly: to avoid erroenous file errors from programmer's fault..... something like master-slave copy and building a meta layer.... except virtual notes and text files we don't allow direct content modification from our side.... (lesson from MULTITUDE....)
21. Simple + focused....
22. No tag shall exist without an item? Or maybe we do want to pre-allocate tags
23. （Experimental; Feature） Flat notes/tags and knowledge subsystem (**kw**): don't assume a context, e.g. "chapter 1" doesn't make sense - how to avoid redundancy? - Indexed knowledge point document Workflow, along with *annotated knowledge points* (must be succint/specific to differentiate from documents, or even wikipedia): extract knowledge at *bit level*.
	* Operators: up, down, filter (scope and scroll details), import (multi line list, assign tags)
	* Use `\`\`two tilts\`\`` with functional expression for math equations - but devising DSL is a dangerous thing because you risk never having an implementation, so just use LaTex instead.
	* Knowledge operation command names: `ki` (import), `Ku`, `kd`, `kc` (knowledge **condense** into a copy a text file, under one name, can work for multiple tags in which case no best heading can be deduced directly)
	* Knowledge Link: knowledge item is linked by a either: item name (case sensitive), item ID (starting with # sign), tags list (start with t:), or a more general **search filter** (everything-lile, pending reference definition) (find: filter strings separated by space and quotes)
19. Reflection on Hierarchical Structure: some might mistakenly think hierarchical structures are thus not useful or even bad - however hierarchical structures are indeed very powerful structures for organizing knowledge for trees are very efficient for searching purpose. However the biggest issue as we shall identify here, is trees are good only for relatively static data, e.g. English dictionary with thumb index - the reorganization cost is high - but that's exactly the case for personal data. Also it might occur that trees are better to model topological features (e.g. shapes of words or animals) rather than semantically features (which doesn't have solid forms).
20. Everything: unambiguous, folder and file names can be utilized, not intended for organizing, very specific; XYPlorer: not pure, temporary for work sessions is good, limited capacity due to mechanism (click and drag) - again, only suitable for sessional work not permanent organization.
1. Physical (File) Name: File must exist and must be managed by Somewhere. This name for max efficiency depends on its database presence. We require only a max of'#DDDDDDDD' (database item ID) size of characters (when it's not unique). Notice a file's ID is guaranteed to be unique throughout **Somewhere repository lifetime**.
3. (Reflection note) Key motivation: we find it perfectly fine for the purpose of managing personal data using a SQLite database as a back store for all tagging information or even with actual data contents, but manually editing data tables are not very efficient (even with the help of SQLite DB Browser it can still be less than optimal), and manually dealing with tabular cells is not that keyboard efficient as well. Instead of devising a completely new scheme, nowadays I value more data operability and wish to create a tool that augments existings infrastructure instead of creating new things, thus a very well-defined customized SQLite database with pre-defined table formats are used to manage those files.
    * Later during the development, and partly inspired by some discussion with Author of Bookmark ninja, I realized this tool can also accomodating note taking purpose, with better integration with file linking (compared with and inspired by limitation of TiddlyWiki) - all we need is MD, and this can promote better data interopreability. In this case Tiddly Wiki becomes more of a plain indexed note tool. I do recognize this change of usage is mostly due to the limit of my phone's operating power, otherwise Tiddly wiki is very good for self-contained plain text notes.
4. Homogenous Container: as proposed in MULTITUDE (theory treatment pending summary on detailed proposed knowledge management framework differentiating between tags and folders and how to properly use them).
0. Repository/Home: each Somewhere home is a repository, managed by SQLite database
1. (Observation) Non original、non personal item s are usually not worth and not need for very specialized organization, for instance Steam games installation folder - you don't really care how large it is and how many files are there because you don't interact with it directly anyway. Another example might be Audible book local audio files - simple folders suffice for the purpose of organizing those. However soon enough when we are dealing with **custom information**, originality comes into play, this includes custom categorization system which is in effect a Knowledge system even if we are dealing with items whose raw contents are not directly issued by us, for instance organizing news digest - even though we don't wrote news ourselves the organized structure represents our knskle. In this case a tag based system can help. I know this discussion is a bit abstract 
2. Hierarchical Home Protocol (Multi-Home management)
1. Indexed notes as homogeneous containers for a given subject matter (e.g. Project Hephaestus design and Project Nine design) instead of many separate items.
2. The best way to use knowledge is like using Universal Diary, and tags.
3. Why not clicking and dragging and autocompleting all that fancy stuff? Like Zapier or Elyse? I used TiddlyWiki, it too heavy and not efficient.
4. Everything going on in our mind is called a thought, there are two kinds of thoughts in terms of utility: useless and useful ones. 
    * An idea is a single stated thought in human language. An idea is useless.
    * To turn an idea into a useful thought, it can either: get a name and become an information with a title (the same title which can also contain oteht information), get tags and become knowledge, or get a structure and become structired data measure. 
    * Every note starts as idea, then it gradually grow and when it gets a title it becomes a complete note. Then it may become a title in its own regard.
2. Knowledge system: offline wiki (that offline wiki app link from wikipedia) is not enough but a must. (Around 40Gb base knowledge local reference)
3. (Differentiation) Category system when used for well-defined subjects and intend to cover only variety if very useful especially for product catalog and first-time uesr navigation.
	* Idea from: Canava Computer changed their website from new modern verion back to old classical version in favour of easier categorical browsing instead of flat list browsing experience.

## Questions

1. What's wrong with Fiddly Wiki again? Tags not easy to manage (mostly due to slow?) Tags are first class tiddlers are very cool concepts.
    * When tags gets some size (a few dozens), impossible to use tag manager, very inefficient. Not tag oriented workflow. But we'll supported. That's it.

## References

1. (Pending) OTPP work reflection article (especially duirng writing documentation): see my portfolio article...
2. Nayuki article (link...): a confirmation of need and practical value, a survey of strategies
3. MULTITUDE article (link...): single home folder inspiration
4. XYPlorer: Virtual files and tags and multiple tabs and favorites, minitrees - too much! But it shows scale and framework. It inspired the idea of build TBFS on top of mata layer (e.g. XYPlorer uses text files to book keep various things).
5. Bookmark Ninja: Major inspiration with hands on experience with 8000+ bookmarks of webpages with over 1700 tags, very helpful ideas during communicating with the developer (name?).
6. (Anti) TagSpace: very slow, super-uneasy interface; But inspired name-based scheme, practiced for a while but the limitation is obvious
	* Screenshot of personal fodler for software installers with partial implementation of that scheme manually...
7. (Anti) Tabble: Java based, database based, super slow, non-self-contained, too much a scope, service based
8. Git: well everyone knows it and loves it
9. RoboOS: Flattened FS inspiration
10. (Anti)tagxfs: good [reading](http://tagxfs.sourceforge.net), some excerts of points..., too long a name, the scheme is not flexible, the underlying architecture/structure is not obvious, no **GUI support is not good** (even for efficient typers, GUI when utilized properly can provide much more information at a glance, so a proper GUI should be provided as a complement)
11. Everything (voidtools): inspired the name for Somewhere.
12. [Markdown](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)
13. [Additional Markdown features](https://github.com/Kryptos-FR/markdig.wpf)
14. [Using Hierarchical Folders and Tags for File Management](https://pdfs.semanticscholar.org/2214/c72fc6bdc42f435eb29240e9fc6930133539.pdf)
15. Also this article though less specific, is informative: https://zapier.com/blog/how-to-use-tags-and-labels/

# Usage Guide

## Special Caution Against Filename

Let's face it: filenames are tricky. It's especially so due to underlying operating system's filesystem limits. Ideally we can name our file everything we want as is the case in Somewhere when your file is managed by the repository AND resides directly inside Home folder, but in reality, it's a bit more comlicated.

To start with, below are the several absolute facts you must remember when dealing with your filenames:

1. Somewhere impost hard limit on the physical length of actual filename to not contain any of the Linux and Windows special characters, specifically, for Linux: ; for Windows;
2. On regular filesystems, there is a physical distinction between **file** and **folder** (even on Linux), however in Somewhere there is no such distinction - the only difference between a file and a folder and a file inside folder is indicated in its name;
3. Somewhere integrates and plays well with ordinary hierarchical file systems (HFS) and guarantee (even if bugs exist) all normal HFS operations should work as expected, e.g. `mv file folder/file` or `mv file folder\file` should both move the file to the target folder (within Home directory);

With above said, 

1. Filename must be either unique or null (for safe add and remove operations, and for compatibility with file system), though length limit is removed (for meaningful description for notes). And as such meaningful filename is encouraged (if not required). For practical (and safe) reasons, files are never actually physically deleted - they are instead marked with suffix `_deleted` at the very end of filename (and disable the extension).

To avoid confusion, above convention is governed by following rules:

1. All special characters can only be used as item name part, and the folder path (if present) part of the item name must follow whatever OS requirements;
2. As soon as your item name contains any of the OS reserved characters, it can no longer reside inside a subfolder or outside home, it must be managed inside home directory;
3. All virtual items, i.e. notes and knowledge, are not affected by those rules.

## Tricks

1. You can add custom attributes to any file/item by using `mt` (meta) command; Some meta names are used by the system already, including: ... - however if you know what those means and where those are used you are **encouraged** to make modifications to them directly; No extra keyword is reserved but more may be used by the system in the future, if you want to be absolutely sure your custom meta attributes are not used by the system, just don't start it with an upper case letter - e.g. all system meta attributes start with Upper case letters.
	* Rule: once defined, you cannot "unset" a meta attribute - if you no longer need it then just set its value to empty; The system may or may not in the future clean up such empty meta attributes.
2. You can enter **chords** in Status Tab command line by appending "\n" to each command;
3. Configuration keys prefixed with `<Anything you like>` + `.` (actually everything that has a any *special symbol* including space excluding colons in it will never be used as SW configuration keys) is reserved for personal use. You can exploit this to set arbitary custom repository level properties by using `cf` (configuration) command and create your own (configuration) properties: e.g. `cf My.Birthday 1995/03/05`, this will be saved in your repository and will not be touched by SW. There is no limit what you can save.
4. (Markdown syntax shortcuts) When editing notes in Notebook Tab, you can select the texts you wish to apply formats then just type in Markdown format symbols to automatically apply brackets and bold and italic etc. Currently it supports: `` *_`'"([{ ``
5. For time related notes, try tag it with date in this format: `yyyy-MM-dd` e.g. `2019-08-31`; Specialized sorting and related features might be implemented.
6. Want to give a tag some more meaning? Create a note with the same name (spaces allowed) as tag, and write your story either in the content or remark for that note. This will also work with Knowledge system in the future, and is the preferred way to define relationships for tags - if any. For instance, at the stage if gathering ideas, one of the tag was called "ProjctHehastus", and a note with same name exists, I.e. "Project Hephaestus".
7. Try add `_HomeBackground.png/jpg` and see what happens to your Home background. Better color adjustment is expected in *future release* (not a promise).
8. To add many items (that are not considered same tags otherwise you could just `add *`) to the repository semi-automatically (TL;DR create a bat file for all items): 1) open command line inside repository folder; 2) run `sw status`, copy the new items lines of output result; 3) Paste the lines into Notepad++ and replace (regular expression) `^\[New\] (.*)$` with `sw add "$1" ""`; 4) Remove unwanted items and add needed tags in the second quote; 5) Double check for typos, then save as a `.bat` inside repository file and double click to execute.

## Best Practices

1. Tag name convention: per convention of other existing tag based systems, I found this a good starting point: 1) comma or space seperated thus no comma or space in name, 2) lower case, case insensitive 3)
	* Do note by design any characters are allowed in tags in the underlying databse, but command line and gui interface enforce no comma and no space policy
2. No folder unless and homogenous container (not enforced): .... folders can still be directly added as an "item"
3. Try to be specific and consistent with naming, give meaningful and simple to remember tag names, avoid plurals
4. Virtual Notes supports full-text (potentially indexed) content search. For regular files this is not supported (to avoid development need and overlapping with external existing tools e.g. grep etc.)
5. Advanced importing will be provided ,however it's recommended you do not use that if you want a cleaner repository - importing existing hierarchies will only mess up efficient knowledge organization and the better way is to keep the hierarchy, then gradually migrate new contents to Somewheres framework. When the time comes, you can just perform the `flatten` operation on selected folders to eliminate hierarchical structures.
6. File names: I promised you should have all the freedom to name your files (items) whatever you like, but there are some rules
	* An item name shouldn't start like a root path, i.e. `C:` on windows, and `/` on linux, this applies no matter what OS you are using, e.g. `/My Note on Designing a New Cloth/` is not a good item name for notes; If you shall name your item like that, it will behave like a file in some part of the system, specifically....
	* An item name shouldn't end like a folder path, i.e. `\` on windows, and `/` on linux, this applies no matter what OS you are using, e.g. `My Note on Environment Governing\` is not a good item name for notes; If you shall name your item like that, it will behave like a folder in some part of the system, specifically....
	* An item CAN contain folder seperators however, e.g. `On the relation between man and nature/how bread is made out of wheet` is a good name for an article/note, and I will guarantee that even though it looks very suspicious to an actual file (e.g. `Writings/On the relation between man and nature/how bread is made out of wheet.pdf`), it is actually identified as a note
1. Avoid using tags like this: `c#_snippet_wpf`, instead do it like this: `c#, snippet, wpf` - it's 2 spaces more typing but this is more generic and less confusing and better filtered.
    * You might be temping to use "visual_studio_faq" and "marvelous_designer_faq"...
    * However I will consider "software_library" a  solid tag because it differentiates from "library", but "c#_library" should really become "C#, software_library"
2. Start with a knowledge, then either grow it into a note, or do something else. Don't keep everything scattered.
3. A repository, during consolidation, should be used only for one type of files (e.g. pdf); During creation, it can be subject based. (Pending further definition)
	* Thus we have: pure note repositories; Instead of mixing things together (even if we can). THis can aid in problems like University/Textbook delima.

## Case Studies

1. (General Tagging) Think about how you would like to (be able to) access it: "ECE, Formula" vs "ECE_Formula"
2. (Knowledge Tag System) Think about how you would like to ask questions - technically speaking, a proper **filename is also by itself a tag** (e.g. "a handbook of practical structures" -> "practical structures"), knowledge points should be **infitestimal small** and **self-contained** and at the same time contain **all other relevant knowledge**. So a proper knowledge point should have only: (plaintext) content, (plaintext) tags - wihtout any indirection. All other heavilifting should be done by the system, e.g. the system shall keep a "tag table" (a tag by itself) which contains all current tags, and this system should detect rather than interfere with normal file tag system (i.e. the main Somewhere application itself). And of course, *tags as either words or phrases, should be tagged on as well*. If everything can be treated as a tag, then tags can have two levels, according to its abstraction level - either up or down, and sentences, being the most specific ones, are on the bottomest level.
	* For a particular piece of isolated idea, e.g. "University project - ground-based locationing system implementation", which we didn't have a record before for "university" related "project ideas": it seems it can be categorized either under a knowledge, or as a collective note (which is probably what I will do when only plain files are available without knowledge system). A better and newer approach is to put it somewhere is University SQLite database and tag it - i.e. just like Virutal Notes. However when given any thoughts, the idea on this project can quickly expand (into a complete piece of note in itself) (see attachment) and thus not worth putting under knowledge under first place - or better, it was a knowledge, then it becomes an idea/concept, later maybe it can grow into a whole subject by itself.

## Questions

1. Should I still use folders? Certainly. E.g. Musics put together in one folder (i.e. by **subject**), by **type** and **project**, or as mentioned above: use folders as **homogenous containers** - but flatted under parent/home folder.
2. I have *30+* Miku png images under *MyPicture/Anime/Miku*, what should I do? Eat it. Not, tag **the whole folder** directly, and **don't** tag individual files (unless some specific ones have special importance) - just let them go wild in there and keep the content growing. Or **zip it** and **tag the compressed file**.
3. I have 30+ software icon assets in *MyPictures/Graphical Assets/Icons*, what should I do? This case is slightly different because it may have need for **future reference**. You have two options: 1) As above; 2) There is something *seriously worong* with how you organize those images - *"Icons"*? Seriously? Does it mean anything? A *file/note/item* should never be categorized udner a **type description alone**: the categorization should always conform to its **content and meaning** instead. The same applies to specific **application domains** - and those simply cannot be appropriately addressed by hierarchical file systems. Use at least **two tags** (one is "icon", the other indicates its actual content - but in the case of simple application icons, you can probably avoid a secondary tag and instead use a **proper icon file name** (don't use "Icon 1.png", "Icon 2.png" etc.) instead. However **two-tag scheme** can work for things more sophisticated e.g. a digital painting) for **each of the files** in this folder, and throw that folder away. *Semantics matter*.
4. Why not as a VS code extension? JS?
5. Proper workflow: give a folder a beaituful name; never look at it.
6. What will happen if I put an emoji in my filename?
7. How to handle name collision: really should give a descriptive name, much like you would to webpage bookmarks (show a screenshot), SW will automatically clamp file name size to 64 characters (with extension, handled transparently) and keep full name only in database. For updating tags one can also use ID directly (physical file with name with same numerical value first, then we check ID, for tag and untag command)

## Somewhere Desktop (Windows) Introduction

For non-keyboard users, and for usual dedicated workspace, a GUI (Graphical User Interface) is provided - well one cannot deny GUI can be sometimes more efficient in some things than CLI (Command-line Interface). In below discussion, we will call Somewhere Desktop "SD". Also I use the word **Tab** to refer to a whole page of UI interface, while **Panel** for some area inside a particular page. In actual code, I sometimes use "Panel" to refer to tabs directly - well tabs are just some larger panels - but I will correct all those for consistency.

The interface of SD is divided into following panels, serving both GUI oriented and some CLI-like purpose:

1. **Inventory Tab**: Holds list view and provides searching and filtering and preview of all managed items.
2. **Notebook Tab**: Specialized area for note editing, available only for note items.
3. **Knowledge Tab**: Specialized area for knowledge navigation; still under development.
4. **Status Tab**: Equivalent to `status` command in CLI.
	* A simple non-interactive shell is available in Status panel for commands input and result display for commands we don't plan to support in GUI (e.g. config and add folder) in the short term or never.
5. **NTFSSearch Tab**
6. **Logs Tab**: Equivalent to `logs` command in CLI - which is not provided in CLI 😉, this is to keep CLI commands list cleaner.
7. **Settings Tab**: View for current settings.

For Inventory Panel (A screenshot with layout annotation shall be provided when it's settled): 

* Left Pane (DockPanel):
	- Top: Name search, type (suffix) dropdown filter
	- Main Area: List of (managed) files - just name + type suffix (round button icon)
* Right Pane:
	- Top: Filter tag flow list; tag search area, autosave check box (if checked all text preview editing will be saved when selected file is changed - consider deprecating this function, always use external editor, otherwise a copy will be saved for the text file in "content" field, which also makes it a "virtual note"), "Edit Tag" tag manager pop up button; All tags scroll panel flow list
	- Middle: File preview and inforpanel
		+ Left: Dedicated Preview area (for texts it also support editing), in the future this is also for embedded web browser
		+ Right: Info and meta area: name, tag, meta edit; For name edit it will automatically rename underlying file using FS filename comliant format, this is done transparently)
	- Bottom: Actions Buttons Panel
		+ Basic: (Row 1) Import (Files, add as copy), Import as Folder (add folder, cut whole folder), Export, (Save), (Edit/Clear) | (Row 2) Physical (make virtual notes a physical file), Create, Open, New (Home)
		+ Advanced Mode: Divide, Merge (in), "Status" Pop up (shows difference between mangaed and unmanaged physical files), Sync, Branch
* Bottom Row: Stat & Help row

# Developement Notes

## Design Principal

Keywords: Minimal UI, Functional, Data Driven, Text based.

1. Tags field are plain text box, for autocompletion pupup is used. No small tag button with even smaller cancel button is provided. So it's simple and less error prone, and plain enough to ensure data operability with CLI and GUI.
2. No fancy features, strictly necessary. Arguments are positional.
3. CLI driven, GUI is just a client.  
4. Don't change data contract, i.e. data table definitions, for the next 10 years. This helps confine scope and reliability.
5. Late optimization: simple and needed functions first with absolutely necessary ingredients, take the most straightforward and framework specific ways of doing things to reduce code, prefer code clarity over complex local optimization (for room for future usable features)
    * This is due to need for functional usage rather than specialized optimal operations due to time limit and limited maintainence time.
    * Things that can be optimized: 1) Instead of ObservableCollection for Items list, we can use plain string and repopulate only file name when update Items view 
6. GUI (I.e. Somewhere Desktop) is a front end, a client of Somewhere (library), no matter how fancy and how many content related features it supports. This requires us to focus on CLI.
7. Target **Item count** *5000-10000*: for any reasonable treatment of a given **subject**, 5000 items worth of content is the least expected. One *shouldn't feel slowed down* by the software when dealing with such size. I would target 10000 files per repository, because that's when during my experience with Bookmark Ninja (I.e. organize website bookmarks with tags), things start to become less efficient - around *1000-3000* tags per repository seems reasonable enough, more than that one can become less familiar or existing tags and it's better to *start a new repository for remotely related subjects*.
Minimal UI, Functional, Data Driven, Text based.

## Design Notes

1. Reagrding the (large) size of new SD executable package: I would consider a minimal size an essential for usability, but due to below reasons I decided to keep it like this, and no more (e.g. Chromium will not be added in near feature)
	* SW already have almost all functions SD has
	* SD is already a desktop application
	* With the addition of libVLC it can be really useful for Multi-media files
2. Notice for journaling of notes, it's intended to save full instead of diff, this way it doesn't depend on GUID or ID for a note item (so the File table for database can be clean - though this is a design choice rather than something necessary, we could add an extra column so everything is a bit more complicated including how we handle deleting stuff), and the Journals can be more generic and serve as a sort of "meta" layer. If so desired, we could devise a seperate routine for condensing the commit history table by calculating and replacing **full** with **diff** contents. Supposedly current mechanism is sufficient for knowledge management.

## Roadmap and Next Steps

A functional and effective application may not just end here, I have several simple ammendities to make this software a bit more useful:

1. When focusing on NTFS and Windows, we can enable direct tracking of file movement of underlying FS, just like XYplorer did and keep track of things seamlessly everytime we hit `sync` or `update`; For linux I am not aware of a journal based FS so this will not work
1. Auto-Discovery (Theory backed): 
	* Intelligent tag text files (enforced) by vocabulary list in **auto tag list (pink)** (seperated from user tag)
	* Inteligent tag image files (pink auto tags)
	* This is to support original MULTITUDE's inspiration plan and Airi interface (now in Somewhere)
2. Emoji text support
3. Embedded browser and wbesite bookmark
4. Meta-based dedicated note (called "remark") section
5. Feature Requests (Usability): Simple embedded revision control (full file based, like google drive)
	* Add whole file version revision, either simply natively, or using git. Per file based, require message.
	* \[Design Decision\] Consider deprecating, for simple and effective revision, we just play well with Home folder `.git` repository by automatically ignore it
	* The most we can do, and we shall limit to only, full size revision (without diff whatsoever) and the user shall use it only fully aware what she's doing - and use this not for VERSION control, but for revision purpose - i.e. keeping active copies of both items - and for this purpose, we shall define a **swapping operation** and use this instead of version control, but variation control.???! What's the use case of that?
	* Notice some sort of revision control is absolutely necessary - because for non-file based items e.g. notes we cann't ust git for version control, and that will be a large part of SW.
6. ASP.Net Core Server Web client for viewr and navigation purpose (or Single page app, allowing static hosting, JS based)
	* Front Page: search, (edit, import, export)
	* View Page (dedicated for items and item types)
	* REST API (rename etc...)
7. **Add and Move with a Style** with embedded scripts (Cross Platform friendly, Lua?) in a loop inside a resource file, or at least basic regular expression (search and replace syntax) + tag (filter and name reference)  support.
8. Test support for linux and mac for CLI.
9. Enable embedding as an option (disabled, "Content" dedicated to text notes)
10. Add support for compression and archiving
11. Allow absolute paths arbitary item reference; Fully support sub-repository mechanism as an item (i.e. distinct from SM, integrated as part of reportisotyr mechanism, and allows more coherent information-knowledge-note-tag(as subject/terminology)-repostiroy(as whole treatment) pattern; Currently experimented inside My.All)

**Stretch Goals**

MULTITUDE might never get a chance to continue development, so some of its goals may be carried to Somewhere. However if such shall be implemented I will guarantee seperate executable packages, allowing opting out.

1. (Use case) music and video library, random play.
2. (Pending conception) Photo organization, random slide show (I.e. original MULTITUDE's inspiration mode)

## Software Components

1. SQLite Handling Layer: .Net Core
2. **Somewhere Application** (Library, Command Line): 
	* Commands (also as library functions): 
		- ✓: add, rm, mv (intelligent; if existing then physically move), mvt, rmt, delete (tag based, files), purge (clean up marked `_delete`), new (home), sync (discover physically renamed and update managed file names; if managed file is deleted, then issue warning); 
		- ☆: create, tag, untag
		- ⓘ: status, files, tags, read, log, find ("search", shorter), help
	* UI Interface: see *"Somewhere Desktop (Windows) Introduction"* section above
3. (Deprecated) GUI Desktop Application (WPF)
	* I think I can make it more efficient just with command line, maybe a website though (End remark: I would do it in CLI, especially since we are going to do auto-complete tag and tweak with some ReadKey() level code - but CLI's support for UNICODE display is arcane and code won't be clean if we do that, so WPF/ASP.Net is better option)
	* The only problem is with **auto-completion**, only if we can solve that - capture tabs in interactive mode?
4. (Pending) ASP.Net Core Viewer
5. SM: Somewhere Manager/Home Explorer (Pending a cute animal name)
	* Find all files
	* A path to **Hierarchical Home Protocol**
1. Knowledge subsystem's function can be used just like IT tag filtering, but the dedicsted interface provides slight advantage for exploring and learning about existing homes rather than overwhelmed by the show-all tab list of IT. In that case, the tags in Knowledge subsystem have a different mechanism of presenting themselves, e.g. one clicks one, then gradually learns about more. In essence, this is also Topic Discovery for humans. We shall implement this feature much later though, when I get a decent setup of example repository.
    * UI: The key to this UI is compactness - we want each knowledge to be as small as possible, with a focus on tags; We wish people to even abuse this aspect as it should be: anything small fragments gets recorded, and tagged, as it should be - the purpose is after all, to tag information items.
        * The intention is that it feels just like Tiddly Wiki, but more focused and lightweight and database based - lightweight is necessary for efficiency, and it should contain as little information as possible - it cannot be a text file because that's too heavy, it cannot be a formatted text content because that's not efficient, it must be database based with each row representing one single information item so the significance is proper. 
    * UI: On the left there will be a search tags area, Up region, current region and Down region. On the right there will be a tags textbox, a content textbox, a remark textbox, and a toggle button for preview mode, and a button for create new knowledge. There is also another button named "Promote" which opens a dialog window for adding names to knowledge with a quote string: "Everything starts as a simple knowledge, then it grows into a note, then it gets some tangible forms. In the end it's significant enough as its own subject and becomes a new repository."
2. Knowledge Tab implementation: 1) Up region shows all tags only 2) down region shows all available tags and then all knowledge items 3) click on anything in down region will select and preview in current. Actually this function is exactly like what IT currently does with its type filter and tags, so let's remove this panel and instead work on IT and make sure its tag filtering works really well and make a note in Usage regarding this potential application and its theory.

Notice to compile and link SomewhereStandard and SQLite we need to uncheck **Prefer 32-bit** for SomewhereDesktop project.

## Design (CLI Focused, Remove GUI completely - "I hate clicking") (also promotes a more purer experience and enhanced memory capacity, also GUI is I herently a bad and easily abused feature/design by many software developers and is not inherently efficient, even for monitoring purpose? Maybe j should write an article on "when to use GUI - a software development choice", and definitely don't consider users, but purely from the perspective and efficiency of tools) And to be a bit more opinionated - windows has put a great deal of shit into its anti-human GUI and make people stupid (just check out Excels and Office suite with its strange nonintuitove and non standard keyboard shortcuts.) - A great console app (like vim) can be very great, and especially better if it combines some GUI elements (e.g. Unicode support and helpful hints).)

1. FileSystemWatcher: when running as dedicated console app, this monitors changes
2. NTFS reader: supports and replaces Everything - thank you free software
3. ConsoleX: tab completion with advanced customization (position and lambdas); Useful CLI information (later development after GUI is drafted)
4. (Windows only) Shell (Windows Explorer) integration for editing Item information (tags and notes)

# Comprehensive Commands Reference

Below is generated directly from the application by issuing `sw doc` command. All commands are **case-insensitive**.

```
Available Commands: 
	add - Add a file to home.
	create - Create a virtual file (virtual text note).
	doc - Generate documentation of Somewhere program.
	files - Show a list of all files.
	find - Find with (or without) action.
	help - Show available commands and general usage help. Use `help commandname` to see more.
	mv - Rename file.
	mvt - Move Tags, renames specified tag.
	new - Create a new Somewhere home at current home directory.
	rm - Remove a file from Home directory, deletes the file both physically and from database.
	rmt - Removes a tag.
	status - Displays the state of the Home directory and the staging area.
	tag - Tag a specified file.
	tags - Show all tags currently exist.
	ui - Run desktop version of Somewhere.
	untag - Untag a file.

add - Add a file to home.
	Options:
		filename - name of file; use * to add all in current directory
		tags(Optional) - tags for the file
create - Create a virtual file (virtual text note).
	Options:
		filename - name for the virtual file, must be unique among all managed files
		content - initial content for the virtual file
		tags - comma delimited list of tags in double quotes; any character except commas and double quotes are allowed.
doc - Generate documentation of Somewhere program.
	Options:
		path - path for the generated file.
files - Show a list of all files.
	Use command line arguments for more advanced display setup.
	Options:
		pageitemcount(Optional) - number of items to show each time
		datefilter(Optional) - a formatted string filtering items with a given entry date; valid formats: specific date string, recent (10 days)
find - Find with (or without) action.
	Find with filename, tags and extra information, and optionally perform an action with find results.
	Options:
		searchtype (either `name` or `tag`) - indicates search type; more will be added
		searchstring - for `name`, use part of file name to search; for `tag`, use comma delimited list of tags to search
		action (either `show` or `open`)(Optional) - optional action to perform on search results; default `show`; more will be added
help - Show available commands and general usage help. Use `help commandname` to see more.
	Options:
		commandname(Optional) - name of command
mv - Rename file.
	If the file doesn't exist on disk or in database then will issue a warning instead of doing anything.
	Options:
		filename - name of file
		newfilename - new name of file
mvt - Move Tags, renames specified tag.
	If source tag doesn't exist in database then will issue a warning instead of doing anything. If the target tag name already exist, then this action will merge the two tags.
	Options:
		sourcetag - old name for the tag
		targettag - new name for the tag
new - Create a new Somewhere home at current home directory.
rm - Remove a file from Home directory, deletes the file both physically and from database.
	If the file doesn't exist on disk or in database then will issue a warning instead of doing anything.
	Options:
		filename - name of file
		-f(Optional) - force physical deletion instead of mark as "_deleted"
rmt - Removes a tag.
	This command deletes the tag from the database, there is no going back.
	Options:
		tags - comma delimited list of tags in double quotes
status - Displays the state of the Home directory and the staging area.
	Shows which files have been staged, which haven't, and which files aren't being tracked by Somewhere. Notice only the files in current directory are checked, we don't go through children folders. We also don't check folders. The (reasons) last two points are made clear in design document.
tag - Tag a specified file.
	Tags are case-insensitive and will be stored in lower case; Though allowed, it's recommended tags don't contain spaces. Use underscore "_" to connect words. Spaces immediately before and after comma delimiters are trimmed. Commas are not allowed in tags, otherwise any character is allowed. If specified file doesn't exist on disk or in database then will issue a warning instead of doing anything.
	Options:
		filename - name of file
		tags - comma delimited list of tags in double quotes; any character except commas and double quotes are allowed; double quotes will be replaced by underscore if entered.
tags - Show all tags currently exist.
	The displayed result will be a plain alphanumerically ordered list of tag names, along with ID and tag usage count.
ui - Run desktop version of Somewhere.
untag - Untag a file.
	Options:
		filename - name of file
		tags - comma delimited list of tags in double quotes; any character except commas and double quotes are allowed; if the file doesn't have a specified tag then the tag is not effected
```

## Inventory Tab Preview Commands

Certain preview actions are available. Below texts can be generated by typing `doc` command into the Preview action textbox.

```
Available commands: doc, help, pause, play, set, unset.

doc - Output all available commands into a text file.
	Options:
		filename(Optional) - name of the file to dump details

help - Show available preview actions.
	Options:
		command(Optional) - name of the command to show details

pause - Pause or continue currenly playing video.

play - Play a new or continue play/pause a video.
	Options:
		url(Optional) - an url to play

set - Set or Show available quick settings and current settings.
	Options:
		setting(Optional) - the setting to set

unset - Unset or Show available quick settings and current settings.
	Options:
		setting(Optional) - the setting to unset
```

# Somewhere Desktop Shortcuts

The list of shortcuts are also available using `F12` button inside Somewhere Desktop app.

```
# Mouse Operations

1. `Double Click` on **Invetory panel** list view item can open it using default system program.
2. Double Click on file:
3. Right click on file:
4. Right click on home: 
5. (Planned) Win32 on filename and new button for file and folder win33 context menu
6. (Desktop, Feature) Allow going back history using **backspace** button (notice for mouse with 5 buttons, it's automatically supported to go back)
7. (Desktop, Feature) Allow `Shift+LMB` when clicking hyperlinks in preview browser to create a "bookmark" note

# Window

* `F11`  Maximize Somewhere Desktop window
* `F12`  Show Shortcuts
* `` Ctrl+\` ``: Hide Somewhere Desktop window 
* `ESC`:  Hide Somewhere Desktop window (same as `` Ctrl+\` ``)
* `Up` arrow key: In Status Tab command input box can summon previous entered commands

# Notes

* `Ctrl+S`: Save note (Note contens will also be automatically saved when closing window and minimizing window)
* `LeftShift+Tab`: Change focus from note content textbox to note tags textbox

# Panels

* `Ctrl+1`: Show Inventory Tab
* `Ctrl+2`: Show Notebook Tab
* `Ctrl+3`: Show Status Tab
* `Ctrl+4`: Show Knowledge Tab
* `Ctrl+5`: Show NTFSSearch Tab
* `Ctrl+6`: Show Logs Tab
* `Ctrl+7`: Show Settings Tab

# Commands

* `F1`: Open Somewhere Home repository
* `F2`: Go to Notebook panel and create new note
* `F3`: Go to Inventory panel and search
* `F4`: Advanced Actions (Divide, Merge (in), Diff (status popup), Sync, Branch)
* `F5`: Refresh Inventory
* `F6`: Tag Editor Popup (Addition + Rename + Remove) - Search select from list and enter in textbox
* `F9`: Open command prompt window
```

# Developer Doc (In Progress)

(Pending: Add detailed examples on interoperability)

To extend and define custom functions, open solution in VS, and create a new project by .....Add reference....

Example (see Examples solution folder for real and simplified examples):

1. An ASP.Net core website (see ASPNETCoreExample)

## Underlying SQLite Table Schemes

Database schemas: the idea of adding tags to physics file resources is quite simple. In fact cefore creating this application I am already doing it at work manually for documents, reading materials, test data, and misc resource files - that's much slower,  but the advantage of having a database for this purpose is very superior, by avoiding the limits of underlying OS FS, I gain the ability to annotate files (notably name length limit, hierarchical structure, and no meta data available) like never before and this enables much easier later retrieval.

In summary, those tables:

1. **Tag**: ID (Always incremental, unique), Name (Tags are first-class objects)
2. **File (item)**: ID (Always incremental, unique), Name (Name and or path; Nott-nullable), Content (Blob), Meta (YAML: Size, MD5, Remark), EntryDate - for physical file, physical folder, virtual file (note and resource)
3. **FileTag**: FileID, TagID
4. **Journal**: *DateTime*, *Event* (include relevant updated item IDs/Names and all details), *Type*; This table serves mosltly reference purpose and doesn't affect core functionality, but can be exploited.
3. **Configuration**: *Key*, *Value*, *Type*, *Comment*
4. (Future; Deprecated) Rule (A,B,C) - Deprecated, defined by internal referencing relationship as indicated by names and tags, per Knolwedge Subsystem, see design notes on knolwedge subsystem (or maybr article on it)
5. (Future; Deprecated) Hierarchy (A/B/C) - Same as above, can be deduced directly from knowledge subsystem
6. (Future) Revision: FileID, RevisionID, Content, RevisionTime

# (Temporary) License

Before Somewhere reach a *stable release*, i.e. release version **V0.5.0** or **250** commits - whichever comes first, you are ONLY allowed to download, compile and read the code. Released binary files are always free to be used in anyway you see fit but you are responsible to be aware of any future changes - except no redistribution of source and binary files are allowed until further notice.

When the concept and documentation for Somewhere is mature I will relax the license terms and provide a truly free license.

# Trouble Shooting for Compilation

1. Some unit test are "manual", this is intentional😉;
2. You need to publish **Somewhere**, **SomewhereStandard** and **SW** projects to target platform (**Portable** configuration won't work) before you can debug **SomewhereDesktop**.
