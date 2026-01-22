---
external help file:
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
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -BackupName <String> -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -BackupName <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the results of a long retention backup operation for a server.

## EXAMPLES

### Example 1: Get all LTR backups for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name              : ltr-backup-annual-2024
ServerName        : myPostgreSqlServer
ResourceGroupName : myResourceGroup
BackupType        : Full
CompletedTime     : 2024-01-15T10:30:00Z
RetentionEndTime  : 2031-01-15T10:30:00Z
SizeInBytes       : 5368709120
RetentionPeriod   : P7Y

Name              : ltr-backup-monthly-202401
ServerName        : myPostgreSqlServer
ResourceGroupName : myResourceGroup
BackupType        : Full
CompletedTime     : 2024-01-01T02:00:00Z
RetentionEndTime  : 2029-01-01T02:00:00Z
SizeInBytes       : 4294967296
RetentionPeriod   : P5Y
```

Retrieves all Long Term Retention backups for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific LTR backup
```powershell
Get-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -BackupInstanceName "compliance-backup-2024"
```

```output
Name              : compliance-backup-2024
ServerName        : prod-postgresql-01
ResourceGroupName : production-rg
BackupType        : Full
CompletedTime     : 2024-01-20T02:00:00Z
RetentionEndTime  : 2034-01-20T02:00:00Z
SizeInBytes       : 8589934592
RetentionPeriod   : P10Y
```

Retrieves details for a specific Long Term Retention backup.

## PARAMETERS

### -BackupName
The name of the backup.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityFlexibleServer
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

