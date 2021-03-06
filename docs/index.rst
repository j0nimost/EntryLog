﻿========
EntryLog
========

A small class library that allows one to write logs to files.

Startup
=======
Get this package from [Nuget](https://www.nuget.org/packages). Use the search term 'EntryLog' and install it.

Alternatively, from your ``dotnet`` console paste the following:

``dotnet add package EntryLog``

Implementation
==============

In your .Net Core application service add the following;

``


services.AddEntryLog();
``
This will default all your logs where your application is running from.

You can also specify where you want your logs to be locate by adding the Uri path as shown below.

``


services.AddEntryLog(new Uri(@"C:\Archive"));
``

You can now add Dependency Injection as you would do in the class contructor.

``
private readonly IEntryLog entryLog;

public Worker(IEntryLog entryLog)
{
    this.entryLog = entryLog;
}

``

To write logs you have three main logging instances;
- Log Warnings
- Log Audits
- Log Errors

In addition. all instances include 2 options;

* Write to default Folders(According to instance)

``this.entryLog.LogError("Vamanose");``

* Write to custom Folders

``this.entryLog.LogError("Octane", "APEX Legends");``

Contribution
============
Feel free to Fork and Contribute. You can also give suggestions through the issues tab.

Author
======

John Nyingi