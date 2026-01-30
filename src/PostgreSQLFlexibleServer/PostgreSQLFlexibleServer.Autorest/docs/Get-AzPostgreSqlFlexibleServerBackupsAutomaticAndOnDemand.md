---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverbackupsautomaticandondemand
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand

## SYNOPSIS
Gets information of an on demand backup, given its name.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -BackupName <String> -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -BackupName <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information of an on demand backup, given its name.

## EXAMPLES

### Example 1: Get all backups for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name              : backup-20240115-103000
ServerName        : myPostgreSqlServer
ResourceGroupName : myResourceGroup
BackupType        : Full
CompletedTime     : 2024-01-15T10:30:00Z
RetentionEndTime  : 2024-02-14T10:30:00Z
SizeInBytes       : 1073741824

Name              : backup-20240114-103000
ServerName        : myPostgreSqlServer
ResourceGroupName : myResourceGroup
BackupType        : Full
CompletedTime     : 2024-01-14T10:30:00Z
RetentionEndTime  : 2024-02-13T10:30:00Z
SizeInBytes       : 1048576000
```

Retrieves all available backups for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific backup by name
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -BackupName "backup-20240120-140000"
```

```output
Name              : backup-20240120-140000
ServerName        : prod-postgresql-01
ResourceGroupName : production-rg
BackupType        : Full
CompletedTime     : 2024-01-20T14:00:00Z
RetentionEndTime  : 2024-02-19T14:00:00Z
SizeInBytes       : 2147483648
GeoRedundant      : True
```

Retrieves details for a specific backup by name.

## PARAMETERS

### -BackupName
Name of the backup.

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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupAutomaticAndOnDemand

## NOTES

## RELATED LINKS

