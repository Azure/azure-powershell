---
external help file: Microsoft.Azure.Commands.DataMigration.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datamigration/New-AzureRmDataMigrationProject
schema: 2.0.0
---

# New-AzureRmDataMigrationSelectedDB

## SYNOPSIS
Creates a database input object that contains information about source and target databases for migration.

## SYNTAX

### SqlServerSqlDbMigration (Default)
```
New-AzureRmDataMigrationSelectedDB -Name <String> -TargetDatabaseName <String> [-MakeSourceDbReadOnly]
 [-TableMap <System.Collections.Generic.IDictionary`2[System.String,System.String]>]
 [-DefaultProfile <IAzureContextContainer>]
```

### SqlServerSqlDbMiMigration
```
New-AzureRmDataMigrationSelectedDB -Name <String> -TargetDatabaseName <String> [-BackupFileShare <FileShare>]
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The New-AzureRmDataMigrationSelectedDB cmdlet creates a database info object that contains information about source and target databases, as well as the table mappings, for migration. This cmdlet can be used as a parameter with the New-AzureRmDataMigrationTask cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmDataMigrationSelectedDB -Name "HR" -RestoreDatabaseName "HR_PSTEST" -BackupFileShare $backupFileShare
```

## PARAMETERS

### -BackupFileShare
File share where the source server database files for this database should be backed up.
Use this setting to override file share information for each database.
Use fully qualified domain name for the server.

```yaml
Type: FileShare
Parameter Sets: SqlServerSqlDbMiParameterSet
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
Parameter Sets: SqlServerSqlDbParameterSet
Aliases: 

Required: False
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
Parameter Sets: SqlServerSqlDbParameterSet
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

## INPUTS

### Microsoft.Azure.Management.DataMigration.Models.FileShare


## OUTPUTS

### Microsoft.Azure.Management.DataMigration.Models.MigrateSqlServerSqlDbDatabaseInput


## NOTES

## RELATED LINKS

