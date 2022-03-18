---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/update-azsqldatabaselongtermretentionbackup
schema: 2.0.0
---

# Update-AzSqlDatabaseLongTermRetentionBackup

## SYNOPSIS
Updates a long term retention backup.

## SYNTAX

### UpdateBackupDefault (Default)
```
Update-AzSqlDatabaseLongTermRetentionBackup [-Location] <String> [-ServerName] <String>
 [-DatabaseName] <String> [-BackupName] <String> [-ResourceGroupName <String>]
 [-BackupStorageRedundancy <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateBackupByResourceId
```
Update-AzSqlDatabaseLongTermRetentionBackup [-ResourceId] <String> [-BackupStorageRedundancy <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByInputObjectSet
```
Update-AzSqlDatabaseLongTermRetentionBackup [-BackupStorageRedundancy <String>]
 [-InputObject] <AzureSqlDatabaseLongTermRetentionBackupModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of a long term retention backup.
  

## EXAMPLES

### Example 1: Update Backup Storage Redundancy of a long term retention backup.
```powershell
Update-AzSqlDatabaseLongTermRetentionBackup -Location southeastasia -ServerName ayang-stage-seas -DatabaseName ltr3 -BackupName 'e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000' -ResourceGroupName testrg -BackupStorageRedundancy Geo
```

```output
BackupExpirationTime             : 3/19/2021 1:33:52 AM
BackupName                       : e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000
BackupTime                       : 2/17/2021 1:33:52 AM
DatabaseName                     : ltr3
DatabaseDeletionTime             : 3/16/2021 6:28:11 AM
Location                         : southeastasia
ResourceId                       : /subscriptions/01c4ec88-e179-44f7-9eb0-e9719a5087ab/resourceGroups/testrg/providers/Microsoft.Sql/locations/southeastasia/longTermRetentionServers/ayang-stage-seas/longTermRetentionDatabases/ltr3/longTermRetentionBackups/e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000
ServerName                       : ayang-stage-seas
ServerCreateTime                 : 4/22/2020 9:58:33 PM
ResourceGroupName                : testrg
BackupStorageRedundancy			 : Geo
```

This command sets the Backup Storage Redundancy of the specified backup using location and Resource Group, Server, Database, and Backup names.  

### Example 2: Update Backup Storage Redundancy of a long term retention backup (using Resource Id).
```powershell
Update-AzSqlDatabaseLongTermRetentionBackup -ResourceId '/subscriptions/01c4ec88-e179-44f7-9eb0-e9719a5087ab/resourceGroups/testrg/providers/Microsoft.Sql/locations/southeastasia/longTermRetentionServers/ayang-stage-seas/longTermRetentionDatabases/ltr3/longTermRetentionBackups/e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000' -BackupStorageRedundancy Geo
```

```output
BackupExpirationTime             : 3/19/2021 1:33:52 AM
BackupName                       : e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000
BackupTime                       : 2/17/2021 1:33:52 AM
DatabaseName                     : ltr3
DatabaseDeletionTime             : 3/16/2021 6:28:11 AM
Location                         : southeastasia
ResourceId                       : /subscriptions/01c4ec88-e179-44f7-9eb0-e9719a5087ab/resourceGroups/testrg/providers/Microsoft.Sql/locations/southeastasia/longTermRetentionServers/ayang-stage-seas/longTermRetentionDatabases/ltr3/longTermRetentionBackups/e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000
ServerName                       : ayang-stage-seas
ServerCreateTime                 : 4/22/2020 9:58:33 PM
ResourceGroupName                : testrg
BackupStorageRedundancy			 : Geo
```

This command sets the Backup Storage Redundancy of the specified backup using a backup Resource Id. 

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -BackupName
The name of the backup.

```yaml
Type: System.String
Parameter Sets: UpdateBackupDefault
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -BackupStorageRedundancy
The Backup storage redundancy used to store backups for the SQL Database.
Options are: Local, Zone and Geo.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Local, Zone, Geo

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The name of the Azure SQL Database the backup is from.

```yaml
Type: System.String
Parameter Sets: UpdateBackupDefault
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Database Long Term Retention Backup object to update.

```yaml
Type: Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel
Parameter Sets: UpdateByInputObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the backup's source server.

```yaml
Type: System.String
Parameter Sets: UpdateBackupDefault
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateBackupDefault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Resource ID of the Database Long Term Retention Backup to remove.

```yaml
Type: System.String
Parameter Sets: UpdateBackupByResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
The name of the Azure SQL Server the backup is under.

```yaml
Type: System.String
Parameter Sets: UpdateBackupDefault
Aliases:

Required: True
Position: 1
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel

## NOTES

## RELATED LINKS

[Get-AzSqlDatabaseLongTermRetentionBackup](./Get-AzSqlDatabaseLongTermRetentionBackup.md)

[Copy-AzSqlDatabaseLongTermRetentionBackup](./Copy-AzSqlDatabaseLongTermRetentionBackup.md)

[Remove-AzSqlDatabaseLongTermRetentionBackup](./Remove-AzSqlDatabaseLongTermRetentionBackup.md)

[Get-AzSqlDatabaseBackupLongTermRetentionPolicy](./Get-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[Set-AzSqlDatabaseBackupLongTermRetentionPolicy](./Set-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)