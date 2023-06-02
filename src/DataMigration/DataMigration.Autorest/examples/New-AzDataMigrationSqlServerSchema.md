### Example 1: Run Migrate database objects from the source SQL Server to the target Azure SQL Database using Parameters
```powershell
New-AzDataMigrationSqlServerSchema -Action "MigrateSchema" -SourceConnectionString "Server=;Initial Catalog=;User ID=;Password=" -TargetConnectionString "Server=;Initial Catalog=;User ID=;Password=" 
```

```output
Starting schema migration...

Total number of object collected: 35
Total elapsed time: 00:00:08.8905823
DDL triggers: 4
Full text catalogs: 2
Plan guides: 2
Roles: 1
Schemas: 5
Stored procedures: 5
Tables: 10
User defined functions: 4
Users: 2

The number of scripted objects: 55
Progress: 100%
Total elapsed time: 00:00:39.9983180

The number of deployed script batches: 110/110
Progress: 100%
Total elapsed time: 00:00:05.6789103
```

This command runs Run SqlServerSchema Migrations on given SQL Server using the connection string.

### Example 2: Run Generate TSQL schema script from the source SQL Server using Parameters
```powershell
New-AzDataMigrationSqlServerSchema -Action "GenerateScript" -SourceConnectionString "Server=;Initial Catalog=;User ID=;Password=" -TargetConnectionString "Server=;Initial Catalog=;User ID=;Password=" -OutputFolder "C:\OutputFolder"
```

```output
Starting schema script generation...

Total number of object collected: 35
Total elapsed time: 00:00:07.3789860
DDL triggers: 4
Full text catalogs: 2
Plan guides: 2
Roles: 1
Schemas: 5
Stored procedures: 5
Tables: 10
User defined functions: 4
Users: 2

The number of scripted objects: 55
Progress: 100%
Total elapsed time: 00:00:40.9745837
```

This command runs Run Generate TSQL schema script on given SQL Server using the connection string.

### Example 3: Run Deploy TSQL script to the target Azure SQL Database using Parameters
```powershell
New-AzDataMigrationSqlServerSchema -Action "DeploySchema" -SourceConnectionString "Server=;Initial Catalog=;User ID=;Password=" -TargetConnectionString "Server=;Initial Catalog=;User ID=;Password=" -InputScriptFilePath "C:\OutputFolder\script.sql"
```

```output
Starting schema deployment...

The number of deployed script batches: 110/110
Progress: 100%
Total elapsed time: 00:00:05.7519257
```

This command runs Deploy TSQL script to the target Azure SQL Database on given SQL Server using the connection string.

### Example 4: Run Migrate database objects from the source SQL Server to the target Azure SQL Database using ConfigFile
```powershell
New-AzDataMigrationSqlServerSchema -ConfigFilePath "C:\configfile.json"
```

```output
configfile.json example:
{
  "Action": "GenerateScript",
  "sourceConnectionString": "Server=;Initial Catalog=;User ID=;Password=",
  "targetConnectionString": "Server=;Initial Catalog=;User ID=;Password=",
  "inputScriptFilePath": "C:\OutputFolder\script.sql",
  "outputFolder": "C:\OutputFolder\script.sql"
}

Starting schema deployment...

The number of deployed script batches: 110/110
Progress: 100%
Total elapsed time: 00:00:05.7519257
```

This command runs Run SqlServerSchema Command from the source Sql Servers to the target Azure Sql Servers using config file.