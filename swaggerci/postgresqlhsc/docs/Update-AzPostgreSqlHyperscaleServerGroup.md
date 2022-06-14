---
external help file:
Module Name: Az.PostgreSqlHyperscale
online version: https://docs.microsoft.com/en-us/powershell/module/az.postgresqlhyperscale/update-azpostgresqlhyperscaleservergroup
schema: 2.0.0
---

# Update-AzPostgreSqlHyperscaleServerGroup

## SYNOPSIS
Updates an existing server group.
The request body can contain one to many of the properties present in the normal server group definition.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPostgreSqlHyperscaleServerGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AdministratorLoginPassword <SecureString>] [-AvailabilityZone <String>] [-BackupRetentionDay <Int32>]
 [-CitusVersion <CitusVersion>] [-EnableShardsOnCoordinator] [-Location <String>]
 [-MaintenanceWindowCustomWindow <String>] [-MaintenanceWindowDayOfWeek <Int32>]
 [-MaintenanceWindowStartHour <Int32>] [-MaintenanceWindowStartMinute <Int32>]
 [-PostgresqlVersion <PostgreSqlVersion>] [-ServerRoleGroup <IServerRoleGroup[]>]
 [-StandbyAvailabilityZone <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPostgreSqlHyperscaleServerGroup -InputObject <IPostgreSqlHyperscaleIdentity>
 [-AdministratorLoginPassword <SecureString>] [-AvailabilityZone <String>] [-BackupRetentionDay <Int32>]
 [-CitusVersion <CitusVersion>] [-EnableShardsOnCoordinator] [-Location <String>]
 [-MaintenanceWindowCustomWindow <String>] [-MaintenanceWindowDayOfWeek <Int32>]
 [-MaintenanceWindowStartHour <Int32>] [-MaintenanceWindowStartMinute <Int32>]
 [-PostgresqlVersion <PostgreSqlVersion>] [-ServerRoleGroup <IServerRoleGroup[]>]
 [-StandbyAvailabilityZone <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing server group.
The request body can contain one to many of the properties present in the normal server group definition.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Models.IPostgreSqlHyperscaleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location the resource resides in.

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
Parameter Sets: UpdateExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Application-specific metadata in the form of key-value pairs.

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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Models.IPostgreSqlHyperscaleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlHyperscale.Models.Api20201005Privatepreview.IServerGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IPostgreSqlHyperscaleIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: The name of the server group configuration.
  - `[FirewallRuleName <String>]`: The name of the server group firewall rule.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RoleName <String>]`: The name of the server group role name.
  - `[ServerGroupName <String>]`: The name of the server group.
  - `[ServerName <String>]`: The name of the server.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

SERVERROLEGROUP <IServerRoleGroup[]>: The list of server role groups.
  - `[EnableHa <Boolean?>]`: If high availability is enabled or not for the server.
  - `[ServerEdition <ServerEdition?>]`: The edition of a server (default: GeneralPurpose).
  - `[StorageQuotaInMb <Int64?>]`: The storage of a server in MB (max: 2097152 = 2TiB).
  - `[VCore <Int64?>]`: The vCores count of a server (max: 64).
  - `[Name <String>]`: The name of the server role group.
  - `[Role <ServerRole?>]`: The role of servers in the server role group.
  - `[ServerCount <Int32?>]`: The number of servers in the server role group.

## RELATED LINKS

