---
external help file: Microsoft.Azure.Commands.DataMigration.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datamigration/New-AzureRmDataMigrationSelectedDB
schema: 2.0.0
---

# New-AzureRmDataMigrationSelectedDB

## SYNOPSIS
Creates a database input object that contains information about source and target databases for migration.

## SYNTAX

### MigrateSqlServerSqlDb (Default)
```
New-AzureRmDataMigrationSelectedDB -Name <String> -TargetDatabaseName <String> [-MigrateSqlServerSqlDb]
 [-MakeSourceDbReadOnly] [-TableMap <System.Collections.Generic.IDictionary`2[System.String,System.String]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### MigrateSqlServerSqlDbMi
```
New-AzureRmDataMigrationSelectedDB -Name <String> -TargetDatabaseName <String> [-MigrateSqlServerSqlDbMi]
 [-BackupFileShare <FileShare>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzureRmDataMigrationSelectedDB cmdlet creates a database info object that contains information about source and target databases, as well as the table mappings, for migration. This cmdlet can be used as a parameter with the New-AzureRmDataMigrationTask cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmDataMigrationSelectedDB -MigrateSqlServerSqlDb -Name "HR" -TargetDatabaseName "HR_PSTEST" -TableMap $tableMap

Name TargetDatabaseName MakeSourceDbReadOnly TableMap
---- ------------------ -------------------- --------
HR   HR_PSTEST                         False {[HR.COUNTRIES, HR.COUNTRIES]}
```

### Example 2
```
PS C:\> New-AzureRmDataMigrationSelectedDB -MigrateSqlServerSqlDbMi -Name "HR" -TargetDatabaseName "HR_PSTEST" -BackupFileShare $backupFileShare

Name RestoreDatabaseName BackupFileShare
---- ------------------- ---------------
HR   HRTest              Microsoft.Azure.Management.DataMigration.Models.FileShare
```

## PARAMETERS

### -BackupFileShare
File share where the source server database files for this database should be backed up.
Use this setting to override file share information for each database.
Use fully qualified domain name for the server.

```yaml
Type: FileShare
Parameter Sets: MigrateSqlServerSqlDbMi
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MakeSourceDbReadOnly
Set Database to readonly before migration

```yaml
Type: SwitchParameter
Parameter Sets: MigrateSqlServerSqlDb
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrateSqlServerSqlDb
Set migration type to SQL Server to SQL DB Migration.

```yaml
Type: SwitchParameter
Parameter Sets: MigrateSqlServerSqlDb
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrateSqlServerSqlDbMi
Set migration type to SQL Server to SQL DB MI Migration.

```yaml
Type: SwitchParameter
Parameter Sets: MigrateSqlServerSqlDbMi
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the source database.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableMap
mapping of source to target tables

```yaml
Type: System.Collections.Generic.IDictionary`2[System.String,System.String]
Parameter Sets: MigrateSqlServerSqlDb
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDatabaseName
The name of the target database.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Management.DataMigration.Models.FileShare

## OUTPUTS

### Microsoft.Azure.Management.DataMigration.Models.MigrateSqlServerSqlDbDatabaseInput

## NOTES

## RELATED LINKS

