---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/update-azsqldatabaselongtermretentionbackupaccesstier
schema: 2.0.0
---

# Update-AzSqlDatabaseLongTermRetentionBackupAccessTier

## SYNOPSIS
Updates a long term retention backup access tier.

## SYNTAX

### UpdateBackupDefault (Default)
```
Update-AzSqlDatabaseLongTermRetentionBackupAccessTier [-Location] <String> [-ServerName] <String>
 [-DatabaseName] <String> [-BackupName] <String> [-ResourceGroupName <String>]
 [-BackupStorageAccessTier <String>] [-OperationMode <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByInputObjectSet
```
Update-AzSqlDatabaseLongTermRetentionBackupAccessTier [-BackupStorageAccessTier <String>] [-OperationMode <String>]
 [-InputObject] <AzureSqlDatabaseLongTermRetentionBackupModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of a long term retention backup.
  

## EXAMPLES

### Example 1: Update Backup Storage Access Tier of a long term retention backup from Hot to Archive.
```powershell
Update-AzSqlDatabaseLongTermRetentionBackupAccessTier -Location southeastasia -ServerName serverName -DatabaseName databaseName -BackupName 'e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000;Hot' -ResourceGroupName resourceGroup -BackupStorageAccessTier Archive -OperationMode Move
```

```output
LongTermRetentionServers         : serverName
ServerCreateTime                 : 10/20/2017 6:28:11 AM
LongTermRetentionDatabases       : databaseName
DatabaseDeletionTime             : 10/20/2023 6:28:11 AM
BackupTime                       : 10/20/2022 6:28:11 AM
BackupExpirationTime             :
BackupStorageRedundancy          : Geo
ResourceGroupName                : resourceGroup
```

This command sets the Backup Storage Redundancy of the specified backup using location and Resource Group, Server, Database, and Backup names.  

### Example 2: Update Backup Storage Access Tier of a long term retention backup from Archive to Hot.
```powershell
Update-AzSqlDatabaseLongTermRetentionBackupAccessTier -Location southeastasia -ServerName serverName -DatabaseName databaseName -BackupName 'e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000;Hot' -ResourceGroupName resourceGroup -BackupStorageAccessTier Hot -OperationMode Copy
```

```output
LongTermRetentionServers         : serverName
ServerCreateTime                 : 10/20/2017 6:28:11 AM
LongTermRetentionDatabases       : databaseName
DatabaseDeletionTime             : 10/20/2023 6:28:11 AM
BackupTime                       : 10/20/2022 6:28:11 AM
BackupExpirationTime             :
BackupStorageRedundancy          : Geo
ResourceGroupName                : resourceGroup
```

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

### -ServerName
The name of the Azure SQL Server where the database under.

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

### -BackupStorageAccessTier
The Backup storage access tie of a backup for the SQL Database.
Options are: Archive, Hot

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Archive, Hot

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationMode
The Operation Mode of a backup for the SQL Database.
Options are: Move, Copy

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Move, Copy

Required: True
Position: 5
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

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)