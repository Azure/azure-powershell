---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Get-AzureRmSqlDatabaseLongTermRetentionBackup

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### LocationName (Default)
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-LocationName] <String> [-OnlyLatestPerDatabase]
 [[-DatabaseState] <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ServerName
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-LocationName] <String> [-ServerName] <String>
 [-OnlyLatestPerDatabase] [[-DatabaseState] <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DatabaseName
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-LocationName] <String> [-ServerName] <String>
 [-DatabaseName] <String> [-OnlyLatestPerDatabase] [[-DatabaseState] <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BackupName
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-LocationName] <String> [-ServerName] <String>
 [-DatabaseName] <String> [-BackupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### GetBackupByResourceId
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-LocationName] <String> [-BackupName] <String>
 [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetBackupsByResourceId
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-LocationName] <String> [-OnlyLatestPerDatabase]
 [[-DatabaseState] <String>] [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### GetBackupByInputObject
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-BackupName] <String> [-InputObject] <AzureSqlDatabaseModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetBackupsByInputObject
```
Get-AzureRmSqlDatabaseLongTermRetentionBackup [-OnlyLatestPerDatabase] [[-DatabaseState] <String>]
 [-InputObject] <AzureSqlDatabaseModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -BackupName
The name of the backup.

```yaml
Type: String
Parameter Sets: BackupName, GetBackupByResourceId, GetBackupByInputObject
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseName
The name of the Azure SQL Database the backup is from.

```yaml
Type: String
Parameter Sets: DatabaseName, BackupName
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseState
The state of the database whose backups you want to find, Alive, Deleted, or All.
Defaults to All

```yaml
Type: String
Parameter Sets: LocationName, ServerName, DatabaseName, GetBackupsByResourceId, GetBackupsByInputObject
Aliases:
Accepted values: All, Deleted, Live

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -InputObject
The Database object to get backups for.

```yaml
Type: AzureSqlDatabaseModel
Parameter Sets: GetBackupByInputObject, GetBackupsByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocationName
The location the backups are in.

```yaml
Type: String
Parameter Sets: LocationName, ServerName, DatabaseName, BackupName, GetBackupByResourceId, GetBackupsByResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OnlyLatestPerDatabase
Whether or not to only get the latest backup per database.
Defaults to false.

```yaml
Type: SwitchParameter
Parameter Sets: LocationName, ServerName, DatabaseName, GetBackupsByResourceId, GetBackupsByInputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Database Resource ID to get backups for.

```yaml
Type: String
Parameter Sets: GetBackupByResourceId, GetBackupsByResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServerName
The name of the Azure SQL Server the backups are under.

```yaml
Type: String
Parameter Sets: ServerName, DatabaseName, BackupName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Management.Automation.SwitchParameter
Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
