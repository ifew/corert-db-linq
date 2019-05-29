# Example C# .NET Core 3 (and 2.2) Runtime (CoreRT) with connect MySQL via Linq (linq2db)

## WARNING

This example result "not supported on this platform", and I will wait for support

```bash
Unhandled Exception: System.TypeInitializationException: A type initializer threw an exception. To determine which type, inspect the InnerException's StackTrace property. ---> System.TypeInitializationException: A type initializer threw an exception. To determine which type, inspect the InnerException's StackTrace property. ---> System.PlatformNotSupportedException: Operation is not supported on this platform.
   at System.Reflection.Runtime.Assemblies.RuntimeAssembly.get_CodeBase() + 0x20
   at LinqToDB.DataProvider.Sybase.SybaseTools.DetectProviderName() + 0x2a
   at LinqToDB.DataProvider.Sybase.SybaseTools.get_DetectedProviderName() + 0x24
   at LinqToDB.DataProvider.Sybase.SybaseTools..cctor() + 0x191
   at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0xd5

   --- End of inner exception stack trace ---
   at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0x198
   at System.Runtime.CompilerServices.ClassConstructorRunner.CheckStaticClassConstructionReturnNonGCStaticBase(StaticClassConstructionContext*, IntPtr) + 0x9
   at LinqToDB.Data.DataConnection..cctor() + 0x14b
   at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0xd5

   --- End of inner exception stack trace ---
   at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0x198
   at System.Runtime.CompilerServices.ClassConstructorRunner.CheckStaticClassConstructionReturnNonGCStaticBase(StaticClassConstructionContext*, IntPtr) + 0x9
   at Member.Program.Main(String[]) + 0x31
   at corert-db!<BaseAddress>+0xc99403

```

## Preparing

1. Import Database from database.sql
2. Add Environment Variable named "DB_CONNECTION" as value "Server=localhost;Port=3306;Uid=root;Pwd=1234;Database=lab;CharSet=utf8;ConvertZeroDateTime=True;"

ps. If you not want to use Environment Variable, can add config to "configDB" on line 20

## Test

Test Normal App
```bash
$ bin/Release/netcoreapp3.0/osx-x64/corert-db
```

Test Native App
```bash
$ bin/Release/netcoreapp3.0/osx-x64/native/corert-db
```

ps. Should to change ```netcoreapp3.0``` and ```osx-x64``` depend on your config

## Command for compile
```bash
$ sh run.sh [Runtime]
```

Example for MacOS
```bash
$ sh run.sh osx-64
```

Example for Linux
```bash
$ sh run.sh linux-64
```

## System Require for Linux

- `sudo apt-get install clang-3.9`
- `sudo apt-get install libunwind-dev`
- `sudo apt-get install libcurl4-openssl-dev`
- `sudo apt-get install zlib1g-dev`
- `sudo apt-get install libkrb5-dev`
- `export CppCompilerAndLinker=clang-3.9`
