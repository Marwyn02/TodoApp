# TodoApp

NOTES: Don't try and build the solution just yet. The code is incomplete and won't compile until you added the missing elements later.


Packages: (Notes: Install the packages first before building the solution.)
   -  SQLite-net-pcl
   -  SQLitePCLRaw.provider.dynamic_cdecl


# Todo / MauiProgram.cs

This file contains the directory path for the local database in computer.

```
string dbPath = FileAccessHelper.GetLocalFilePath("THIS IS YOUR DATABASE NAME");
```

In the code, the "THIS IS YOUR DATABASE NAME" is what your database name. ex. " database.db ". 

It's up to you what you want to name it. But it must have the extension of: db, sqlite, or any database extension you're using.
