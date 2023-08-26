---
external help file:
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationsqlserverschema
schema: 2.0.0
---

# New-AzDataMigrationSqlServerSchema

## SYNOPSIS
Migrate Sql Server Schema from the source Sql Servers to the target Azure Sql Servers.

## SYNTAX

### ConfigFile (Default)
```
New-AzDataMigrationSqlServerSchema -ConfigFilePath <String> [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CommandLine
```
New-AzDataMigrationSqlServerSchema -Action <String> -SourceConnectionString <String>
 -TargetConnectionString <String> [-InputScriptFilePath <String>] [-OutputFolder <String>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Migrate Sql Server Schema from the source Sql Servers to the target Azure Sql Servers.

## EXAMPLES

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

## PARAMETERS

### -Action
Required.
Select one schema migration action.
The valid values are: MigrateSchema, GenerateScript, DeploySchema.
MigrateSchema is to migrate the database objects to Azure SQL Database target.
GenerateScript is to generate an editable TSQL schema script that can be used to run on the target to deploy the objects.
DeploySchema is to run the TSQL script generated from -GenerateScript action on the target to deploy the objects.

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigFilePath
Path of the ConfigFile

```yaml
Type: System.String
Parameter Sets: ConfigFile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputScriptFilePath
Optional.
Location of an editable TSQL schema script.
Use this parameter only with DeploySchema Action.

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputFolder
Optional.
Default: %LocalAppData%/Microsoft/SqlSchemaMigrations) Folder where logs will be written and the generated TSQL schema script by GenerateScript Action.

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceConnectionString
Required.
Connection string for the source SQL instance, using the formal connection string format.

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetConnectionString
Required.
Connection string for the target SQL instance, using the formal connection string format.

```yaml
Type: System.String
Parameter Sets: CommandLine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

## RELATED LINKS

