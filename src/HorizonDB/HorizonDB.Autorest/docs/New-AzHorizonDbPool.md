---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/new-azhorizondbpool
schema: 2.0.0
---

# New-AzHorizonDbPool

## SYNOPSIS
Create a new HorizonDB pool or replaces an existing pool, including its node allocation, compute model, high-availability configuration, or associated parameter group.
nodeCount and highAvailability.mode are required and have no service defaults.
nodeCount must be 1 through 16.
Disabled is valid only when nodeCount is 1.
AnyZone and ZoneRedundant are valid only when nodeCount is 2 through 16.
AnyZone permits same-zone or cross-zone placement, while ZoneRedundant requires nodes to be allocated across availability zones.
Node allocation and high-availability reconfiguration are atomic: if all requested nodes or the required zonal topology cannot be provisioned, the long-running operation fails and the previous resource state is preserved.
A pool name must differ from its parent cluster name because the Cluster-scoped ReadWrite Endpoint is named after the Cluster and the Pool-scoped ReadOnly Endpoint is named after the Pool; the service rejects a request whose names would collide.
Creating a pool also create exactly one service-managed Pool-scoped ReadOnly Endpoint representing that Pool and its network boundary.
The Endpoint's associatedResourceId identifies the Pool, and the Endpoint cannot outlive or be deleted independently from it.
When the first pool is created, the service automatically designates it to host the cluster's read-write node when an eligible node is available.
A Cluster must contain at least one Pool before a private endpoint connection can be created or approved.
This API version supports at most one pool per cluster; an attempt to create another pool is rejected with 409 Conflict.
parameterGroup is optional during creation.
When omitted during creation, the service applies the default parameter group compatible with the parent cluster's PostgreSQL version.
When parameterGroup is supplied, parameterGroupResourceId and applyMethod are required.
When creating a new pool in this API version, a supplied parameterGroupResourceId must identify the corresponding default parameter group; a customer-created parameter group is rejected.
When replacing an existing pool, the request can switch its association in either direction between the corresponding default parameter group and a customer-created parameter group.
applyMethod controls when dynamic parameter changes become effective.
Static parameter changes always require a customer-initiated Restart; Stop followed by Start and scheduled maintenance do not apply pending changes.
Subtype-specific compute constraints are validated before the resource is changed.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ComputeModelComputeGeneration <Int32>] [-ComputeModelComputeProcessor <String>]
 [-ComputeModelVCore <Int32>] [-HighAvailabilityMode <String>] [-NodeCount <Int32>]
 [-ParameterGroupApplyMethod <String>] [-ParameterGroupResourceId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityClusterExpanded
```
New-AzHorizonDbPool -ClusterInputObject <IHorizonDbIdentity> -Name <String>
 [-ComputeModelComputeGeneration <Int32>] [-ComputeModelComputeProcessor <String>]
 [-ComputeModelVCore <Int32>] [-HighAvailabilityMode <String>] [-NodeCount <Int32>]
 [-ParameterGroupApplyMethod <String>] [-ParameterGroupResourceId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new HorizonDB pool or replaces an existing pool, including its node allocation, compute model, high-availability configuration, or associated parameter group.
nodeCount and highAvailability.mode are required and have no service defaults.
nodeCount must be 1 through 16.
Disabled is valid only when nodeCount is 1.
AnyZone and ZoneRedundant are valid only when nodeCount is 2 through 16.
AnyZone permits same-zone or cross-zone placement, while ZoneRedundant requires nodes to be allocated across availability zones.
Node allocation and high-availability reconfiguration are atomic: if all requested nodes or the required zonal topology cannot be provisioned, the long-running operation fails and the previous resource state is preserved.
A pool name must differ from its parent cluster name because the Cluster-scoped ReadWrite Endpoint is named after the Cluster and the Pool-scoped ReadOnly Endpoint is named after the Pool; the service rejects a request whose names would collide.
Creating a pool also create exactly one service-managed Pool-scoped ReadOnly Endpoint representing that Pool and its network boundary.
The Endpoint's associatedResourceId identifies the Pool, and the Endpoint cannot outlive or be deleted independently from it.
When the first pool is created, the service automatically designates it to host the cluster's read-write node when an eligible node is available.
A Cluster must contain at least one Pool before a private endpoint connection can be created or approved.
This API version supports at most one pool per cluster; an attempt to create another pool is rejected with 409 Conflict.
parameterGroup is optional during creation.
When omitted during creation, the service applies the default parameter group compatible with the parent cluster's PostgreSQL version.
When parameterGroup is supplied, parameterGroupResourceId and applyMethod are required.
When creating a new pool in this API version, a supplied parameterGroupResourceId must identify the corresponding default parameter group; a customer-created parameter group is rejected.
When replacing an existing pool, the request can switch its association in either direction between the corresponding default parameter group and a customer-created parameter group.
applyMethod controls when dynamic parameter changes become effective.
Static parameter changes always require a customer-initiated Restart; Stop followed by Start and scheduled maintenance do not apply pending changes.
Subtype-specific compute constraints are validated before the resource is changed.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

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

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: CreateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModelComputeGeneration
The compute generation for the compute model.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModelComputeProcessor
The processor type for the compute model.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModelVCore
The number of vCores.
Allowed values are 1 through 192.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
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

### -HighAvailabilityMode
The high-availability mode.
Disabled is required when nodeCount is 1.
AnyZone or ZoneRedundant is required when nodeCount is 2 through 16.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HorizonDB pool.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeCount
The required number of nodes to allocate and assign to the pool.
Allowed values are 1 through 16.
To deallocate runtime compute without changing the configured node count, stop the pool.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
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

### -ParameterGroupApplyMethod
Determines when dynamic parameter changes from the associated parameter group become effective.
Static parameter changes always require a customer-initiated pool Restart, regardless of this value.
Stop followed by Start and scheduled maintenance do not apply pending parameter changes.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterGroupResourceId
The Azure resource ID of the associated parameter group.
When the parameter group is supplied during initial pool creation in this API version, the ID must identify the corresponding Microsoft.HorizonDb/locations/parameterGroups resource.
For an existing pool, PUT can specify either the corresponding default group or a customer-created Microsoft.HorizonDb/parameterGroups resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IPool

## NOTES

## RELATED LINKS

