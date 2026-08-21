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

### Example 1: List all backups in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
Name                           BackupType           CompletedTime             Source
----                           ----------           -------------             ------
backup_639145838028276096      Full                 3/22/2026 3:03:23 AM      Automatic
backup_639146702636854494      Full                 3/23/2026 3:04:24 AM      Automatic
example-on-demand-backup-01    Customer On-Demand   5/23/2026 9:36:13 PM      Customer Initiated
backup_639149035518395681      Full                 3/24/2026 7:52:32 PM      Automatic
backup_639149900283518862      Full                 3/25/2026 7:53:49 PM      Automatic
example-on-demand-backup-02    Customer On-Demand   3/25/2026 9:36:13 PM      Customer Initiated
```

Lists all automatic and on demand backups in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get one backup in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -BackupName example-on-demand-backup-02
```

```output
Name                           BackupType           CompletedTime             Source
----                           ----------           -------------             ------
example-on-demand-backup-02    Customer On-Demand   5/23/2026 9:36:13 PM      Customer Initiated
```

Gets one automatic and on demand backup in an Azure Database for PostgreSQL flexible server with backup name, server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

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

