---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/update-azhorizondbpool
schema: 2.0.0
---

# Update-AzHorizonDbPool

## SYNOPSIS
Update an existing HorizonDB pool, including its node allocation, selected compute model properties, compute model type, high-availability configuration, or associated parameter group.
Omitted nodeCount and highAvailability.mode values preserve their existing values; the service recursively merges the PATCH before atomically validating the effective tuple.
nodeCount, when supplied, must be 1 through 16.
Disabled is valid only when the effective nodeCount is 1.
AnyZone and ZoneRedundant are valid only when the effective nodeCount is 2 through 16.
Therefore, crossing between those node-count ranges requires nodeCount and highAvailability.mode to be changed together.
AnyZone permits same-zone or cross-zone placement.
Changing from AnyZone to ZoneRedundant may allocate a replacement node in another availability zone and replace a read-only node, disconnecting connections to the replaced node.
If all requested nodes or the required zonal topology cannot be provisioned, the long-running operation fails and the previous resource state is preserved.
To deallocate runtime compute without changing the configured nodeCount, use the Pool stop action.
When parameterGroup is supplied, both parameterGroupResourceId and applyMethod are required.
The pool can switch its association in either direction between the corresponding default parameter group and a customer-created parameter group.
applyMethod controls when dynamic parameter changes become effective.
Static parameter changes always require a customer-initiated Restart; Stop followed by Start and scheduled maintenance do not apply pending changes.
Subtype-specific compute constraints are validated against the recursively merged configuration.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ComputeModelComputeGeneration <Int32>] [-ComputeModelComputeProcessor <String>]
 [-ComputeModelType <String>] [-ComputeModelVCore <Int32>] [-HighAvailabilityMode <String>]
 [-NodeCount <Int32>] [-ParameterGroupApplyMethod <String>] [-ParameterGroupResourceId <String>]
 [-ScheduledMaintenanceManagementType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityClusterExpanded
```
Update-AzHorizonDbPool -ClusterInputObject <IHorizonDbIdentity> -Name <String>
 [-ComputeModelComputeGeneration <Int32>] [-ComputeModelComputeProcessor <String>]
 [-ComputeModelType <String>] [-ComputeModelVCore <Int32>] [-HighAvailabilityMode <String>]
 [-NodeCount <Int32>] [-ParameterGroupApplyMethod <String>] [-ParameterGroupResourceId <String>]
 [-ScheduledMaintenanceManagementType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHorizonDbPool -InputObject <IHorizonDbIdentity> [-ComputeModelComputeGeneration <Int32>]
 [-ComputeModelComputeProcessor <String>] [-ComputeModelType <String>] [-ComputeModelVCore <Int32>]
 [-HighAvailabilityMode <String>] [-NodeCount <Int32>] [-ParameterGroupApplyMethod <String>]
 [-ParameterGroupResourceId <String>] [-ScheduledMaintenanceManagementType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzHorizonDbPool -ClusterName <String> -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update an existing HorizonDB pool, including its node allocation, selected compute model properties, compute model type, high-availability configuration, or associated parameter group.
Omitted nodeCount and highAvailability.mode values preserve their existing values; the service recursively merges the PATCH before atomically validating the effective tuple.
nodeCount, when supplied, must be 1 through 16.
Disabled is valid only when the effective nodeCount is 1.
AnyZone and ZoneRedundant are valid only when the effective nodeCount is 2 through 16.
Therefore, crossing between those node-count ranges requires nodeCount and highAvailability.mode to be changed together.
AnyZone permits same-zone or cross-zone placement.
Changing from AnyZone to ZoneRedundant may allocate a replacement node in another availability zone and replace a read-only node, disconnecting connections to the replaced node.
If all requested nodes or the required zonal topology cannot be provisioned, the long-running operation fails and the previous resource state is preserved.
To deallocate runtime compute without changing the configured nodeCount, use the Pool stop action.
When parameterGroup is supplied, both parameterGroupResourceId and applyMethod are required.
The pool can switch its association in either direction between the corresponding default parameter group and a customer-created parameter group.
applyMethod controls when dynamic parameter changes become effective.
Static parameter changes always require a customer-initiated Restart; Stop followed by Start and scheduled maintenance do not apply pending changes.
Subtype-specific compute constraints are validated against the recursively merged configuration.

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
Parameter Sets: UpdateViaIdentityClusterExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModelComputeGeneration
The compute generation for the compute model.
Omission preserves the current compute generation.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModelComputeProcessor
The processor type for the compute model.
Omission preserves the current processor type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModelType
The compute model type.
Omit this property to retain the current type.
Resubmitting the current type succeeds as an idempotent no-op.
To change the type, supply all common properties and all properties required by the target type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModelVCore
The number of provisioned vCores.
Allowed values are 1 through 192.
This property applies only to a Provisioned compute model.
Omission preserves the current value.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
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
Omission preserves the current mode before the service validates it with the effective nodeCount.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: PoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeCount
The number of nodes to allocate and assign to the pool.
Allowed values are 1 through 16.
Omission preserves the current configured value.
To deallocate runtime compute without changing the configured node count, stop the pool.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterGroupResourceId
The Azure resource ID of the corresponding default or customer-created parameter group to associate with the existing pool.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduledMaintenanceManagementType
Specifies whether scheduled maintenance is managed by the system or by the user.
When scheduledMaintenance is supplied, this property is required by the service.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

