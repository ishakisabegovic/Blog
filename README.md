# Blog

This project consists of web api using ASP.Net Core 6.0

## Requirements

Database: SQL Server (SQL Server, graphical tool -> Microsoft SQL Server Management Studio) 

IDE : Visual Studio

## Application setup and launch

1. Clone Repository

2. Rebuild the solution to download all nuget packages that are included

3. Set the connection string in appsettings.json by your requirements

4.  In the PackageManagerConsole switch to the .Infrastructure project and write the command


```csharp
EntityFrameworkCore\Update-Database

```
