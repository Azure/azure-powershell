---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverbackupslongtermretention
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention

## SYNOPSIS
Gets the results of a long retention backup operation for a server.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -BackupName <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -BackupName <String> -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the results of a long retention backup operation for a server.

## EXAMPLES

### Example 1: List all long-term retention backups for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "myresourcegroup" -ServerName "myserver"
```

```output
Name                        Status      CreatedTime               ExpiryTime                SizeInBytes
----                        ------      -----------               ----------                -----------
ltr_backup_20240101_monthly Completed   2024-01-01T02:00:00.000Z  2025-01-01T02:00:00.000Z  2147483648
ltr_backup_20240115_weekly  Completed   2024-01-15T02:00:00.000Z  2024-04-15T02:00:00.000Z  2147483648
ltr_backup_20240120_daily   InProgress  2024-01-20T02:00:00.000Z  2024-02-20T02:00:00.000Z  -
```

Lists all long-term retention backup operations for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific long-term retention backup by name
```powershell
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "myresourcegroup" -ServerName "myserver" -BackupName "ltr_backup_20240101_monthly"
```

```output
Name                        Status    CreatedTime               ExpiryTime                SizeInBytes RetentionPolicy
----                        ------    -----------               ----------                ----------- ---------------
ltr_backup_20240101_monthly Completed 2024-01-01T02:00:00.000Z  2025-01-01T02:00:00.000Z  2147483648  Monthly
```

Gets information about the specific long-term retention backup named 'ltr_backup_20240101_monthly'.

## PARAMETERS

### -BackupName
The name of the backup.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityFlexibleServer, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentityFlexibleServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The name of the server.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionOperation

## NOTES

## RELATED LINKS
