---
external help file: Az.DataMigration-help.xml
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationloginsmigration
schema: 2.0.0
---

# New-AzDataMigrationLoginsMigration

## SYNOPSIS
Migrate logins from the source Sql Servers to the target Azure Sql Servers.

## SYNTAX

### ConfigFile (Default)
```
New-AzDataMigrationLoginsMigration -ConfigFilePath <String> [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CommandLine
```
New-AzDataMigrationLoginsMigration -SourceSqlConnectionString <String[]> -TargetSqlConnectionString <String>
 [-CSVFilePath <String>] [-ListOfLogin <String[]>] [-OutputFolder <String>] [-AADDomainName <String>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Migrate logins from the source Sql Servers to the target Azure Sql Servers.

## EXAMPLES

### Example 1: Run Migrate logins from the source Sql Servers to the target Azure Sql Servers using Parameters
```powershell
New-AzDataMigrationLoginsMigration -SourceSqlConnectionString "data source=servername;user id=userid;password=;initial catalog=master;TrustServerCertificate=True" -TargetSqlConnectionString "data source=servername;user id=userid;password=;initial catalog=master;TrustServerCertificate=True" -CSVFilePath "C:\CSVFile" -ListOfLogin "loginname1" "loginname2" -OutputFolder "C:\OutputFolder" -AADDomainName "AADDomainName"
```

```output
Starting Logins migration...
Starting server roles migration...
Starting user-login mappings...
Starting server role mappings...
Restoring permissions for logins...
Restoring permissions for server roles...
Login migration process complete.
```

This command runs Run SKU Recommendation on given SQL Server using the connection string.

### Example 2: Run Migrate logins from the source Sql Servers to the target Azure Sql Servers using config file
```powershell
New-AzDataMigrationLoginsMigration -ConfigFilePath "C:\Users\user\document\config.json"
```

```output
Starting Logins migration...
Starting server roles migration...
Starting user-login mappings...
Starting server role mappings...
Restoring permissions for logins...
Restoring permissions for server roles...
Login migration process complete.
```

This command runs Run Migrate logins from the source Sql Servers to the target Azure Sql Servers using config file.

## PARAMETERS

### -AADDomainName
Optional.
Required if Windows logins are included in the list of logins to be migrated.
(Default: empty string).

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

### -CSVFilePath
Optional.
Location of CSV file of logins.
Use only one parameter between this and listOfLogin.

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

### -ListOfLogin
Optional.
List of logins in string format.
If large number of logins need to be migrated, use CSV file option.

```yaml
Type: System.String[]
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
Default: %LocalAppData%/Microsoft/SqlLoginMigrations) Folder where logs will be written.

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

### -SourceSqlConnectionString
Required.
Connection string(s) for the source SQL instance(s), using the formal connection string format.

```yaml
Type: System.String[]
Parameter Sets: CommandLine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSqlConnectionString
Required.
Connection string(s) for the target SQL instance(s), using the formal connection string format.

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

## RELATED LINKS
