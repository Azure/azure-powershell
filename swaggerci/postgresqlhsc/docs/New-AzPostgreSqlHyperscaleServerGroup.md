---
external help file:
Module Name: Az.PostgreSqlHyperscale
online version: https://docs.microsoft.com/en-us/powershell/module/az.postgresqlhyperscale/new-azpostgresqlhyperscaleservergroup
schema: 2.0.0
---

# New-AzPostgreSqlHyperscaleServerGroup

## SYNOPSIS
Creates a new server group with servers.

## SYNTAX

```
New-AzPostgreSqlHyperscaleServerGroup -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AdministratorLogin <String>] [-AdministratorLoginPassword <SecureString>]
 [-AvailabilityZone <String>] [-BackupRetentionDay <Int32>] [-CitusVersion <CitusVersion>]
 [-CreateMode <CreateMode>] [-DelegatedSubnetArgumentSubnetArmResourceId <String>] [-EnableMx]
 [-EnableShardsOnCoordinator] [-EnableZf] [-MaintenanceWindowCustomWindow <String>]
 [-MaintenanceWindowDayOfWeek <Int32>] [-MaintenanceWindowStartHour <Int32>]
 [-MaintenanceWindowStartMinute <Int32>] [-PointInTimeUtc <DateTime>] [-PostgresqlVersion <PostgreSqlVersion>]
 [-PrivateDnsZoneArgumentPrivateDnsZoneArmResourceId <String>] [-ServerRoleGroup <IServerRoleGroup[]>]
 [-SourceLocation <String>] [-SourceResourceGroupName <String>] [-SourceServerGroupName <String>]
 [-SourceSubscriptionId <String>] [-StandbyAvailabilityZone <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new server group with servers.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AdministratorLogin
The administrator's login name of servers in server group.
Can only be specified when the server is being created (and is required for creation).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdministratorLoginPassword
The password of the administrator login.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -AvailabilityZone
Availability Zone information of the server group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupRetentionDay
The backup retention days for server group.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CitusVersion
The Citus version of server group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Support.CitusVersion
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateMode
The mode to create a new server group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Support.CreateMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DelegatedSubnetArgumentSubnetArmResourceId
delegated subnet arm resource id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableMx
If Citus MX is enabled or not for the server group.

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

### -EnableShardsOnCoordinator
If shards on coordinator is enabled or not for the server group.

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

### -EnableZf
If ZFS compression is enabled or not for the server group.

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
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowCustomWindow
indicates whether custom window is enabled or disabled

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowDayOfWeek
day of week for maintenance window

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowStartHour
start hour for maintenance window

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowStartMinute
start minute for maintenance window

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the server group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServerGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PointInTimeUtc
Restore point creation time (ISO8601 format), specifying the time to restore from.
It's required when 'createMode' is 'PointInTimeRestore'

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PostgresqlVersion
The PostgreSQL version of server group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Support.PostgreSqlVersion
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateDnsZoneArgumentPrivateDnsZoneArmResourceId
private dns zone arm resource id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerRoleGroup
The list of server role groups.
To construct, see NOTES section for SERVERROLEGROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Models.Api20201005Privatepreview.IServerRoleGroup[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceLocation
The source server group location to restore from.
It's required when 'createMode' is 'PointInTimeRestore' or 'ReadReplica'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceGroupName
The source resource group name to restore from.
It's required when 'createMode' is 'PointInTimeRestore' or 'ReadReplica'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceServerGroupName
The source server group name to restore from.
It's required when 'createMode' is 'PointInTimeRestore' or 'ReadReplica'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSubscriptionId
The source subscription id to restore from.
It's required when 'createMode' is 'PointInTimeRestore' or 'ReadReplica'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StandbyAvailabilityZone
Standby Availability Zone information of the server group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Models.Api20201005Privatepreview.IServerGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


SERVERROLEGROUP <IServerRoleGroup[]>: The list of server role groups.
  - `[EnableHa <Boolean?>]`: If high availability is enabled or not for the server.
  - `[ServerEdition <ServerEdition?>]`: The edition of a server (default: GeneralPurpose).
  - `[StorageQuotaInMb <Int64?>]`: The storage of a server in MB (max: 2097152 = 2TiB).
  - `[VCore <Int64?>]`: The vCores count of a server (max: 64).
  - `[Name <String>]`: The name of the server role group.
  - `[Role <ServerRole?>]`: The role of servers in the server role group.
  - `[ServerCount <Int32?>]`: The number of servers in the server role group.

## RELATED LINKS

