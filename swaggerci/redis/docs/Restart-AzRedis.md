---
external help file:
Module Name: Az.Redis
online version: https://docs.microsoft.com/en-us/powershell/module/az.redis/restart-azredis
schema: 2.0.0
---

# Restart-AzRedis

## SYNOPSIS
Reboot specified Redis node(s).
This operation requires write permission to the cache resource.
There can be potential data loss.

## SYNTAX

### ForceRebootExpanded (Default)
```
Restart-AzRedis -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Port <Int32[]>]
 [-RebootType <RebootType>] [-ShardId <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ForceReboot
```
Restart-AzRedis -Name <String> -ResourceGroupName <String> -Parameter <IRedisRebootParameters>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ForceRebootViaIdentity
```
Restart-AzRedis -InputObject <IRedisIdentity> -Parameter <IRedisRebootParameters> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ForceRebootViaIdentityExpanded
```
Restart-AzRedis -InputObject <IRedisIdentity> [-Port <Int32[]>] [-RebootType <RebootType>] [-ShardId <Int32>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reboot specified Redis node(s).
This operation requires write permission to the cache resource.
There can be potential data loss.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.IRedisIdentity
Parameter Sets: ForceRebootViaIdentity, ForceRebootViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Redis cache.

```yaml
Type: System.String
Parameter Sets: ForceReboot, ForceRebootExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Specifies which Redis node(s) to reboot.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.Api20210601.IRedisRebootParameters
Parameter Sets: ForceReboot, ForceRebootViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Port
A list of redis instances to reboot, specified by per-instance SSL ports or non-SSL ports.

```yaml
Type: System.Int32[]
Parameter Sets: ForceRebootExpanded, ForceRebootViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RebootType
Which Redis node(s) to reboot.
Depending on this value data loss is possible.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Support.RebootType
Parameter Sets: ForceRebootExpanded, ForceRebootViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ForceReboot, ForceRebootExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShardId
If clustering is enabled, the ID of the shard to be rebooted.

```yaml
Type: System.Int32
Parameter Sets: ForceRebootExpanded, ForceRebootViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: ForceReboot, ForceRebootExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.Api20210601.IRedisRebootParameters

### Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.IRedisIdentity

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IRedisIdentity>: Identity Parameter
  - `[CacheName <String>]`: The name of the Redis cache.
  - `[Default <DefaultName?>]`: Default string modeled as parameter for auto generation to work correctly.
  - `[Id <String>]`: Resource identity path
  - `[LinkedServerName <String>]`: The name of the linked server that is being added to the Redis cache.
  - `[Location <String>]`: The location at which operation was triggered
  - `[Name <String>]`: The name of the Redis cache.
  - `[OperationId <String>]`: The ID of asynchronous operation
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RuleName <String>]`: The name of the firewall rule.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

PARAMETER <IRedisRebootParameters>: Specifies which Redis node(s) to reboot.
  - `[Port <Int32[]>]`: A list of redis instances to reboot, specified by per-instance SSL ports or non-SSL ports.
  - `[RebootType <RebootType?>]`: Which Redis node(s) to reboot. Depending on this value data loss is possible.
  - `[ShardId <Int32?>]`: If clustering is enabled, the ID of the shard to be rebooted.

## RELATED LINKS

