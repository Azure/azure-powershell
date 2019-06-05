---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/set-azvmss
schema: 2.0.0
---

# Set-AzVmss

## SYNOPSIS
Create or update a VM scale set.

## SYNTAX

### Update1 (Default)
```
Set-AzVmss -ResourceGroupName <String> -SubscriptionId <String> -VMScaleSetName <String>
 [-VirtualMachineScaleSet <IVirtualMachineScaleSet>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzVmss -ResourceGroupName <String> -SubscriptionId <String> -VMScaleSetName <String> -Location <String>
 [-AutomaticOSUpgrade] [-DisableAutoRollback] [-DoNotRunExtensionsOnOverprovisionedVm]
 [-IdentityId <IVirtualMachineScaleSetIdentityUserAssignedIdentities>] [-IdentityType <ResourceIdentityType>]
 [-MaxBatchInstancePercent <Int32>] [-MaxUnhealthyInstancePercent <Int32>]
 [-MaxUnhealthyUpgradedInstancePercent <Int32>] [-Overprovision] [-PauseTimeBetweenBatches <String>]
 [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-PlatformFaultDomainCount <Int32>] [-ProximityPlacementGroupId <String>] [-SinglePlacementGroup]
 [-SkuCapacity <Int64>] [-SkuName <String>] [-SkuTier <String>] [-Tag <IResourceTags>] [-UltraSsdEnabled]
 [-UpgradePolicyMode <UpgradeMode>] [-VirtualMachineProfile <IVirtualMachineScaleSetVMProfile>]
 [-Zone <String[]>] [-ZoneBalance] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Set-AzVmss -InputObject <IComputeIdentity> -Location <String> [-AutomaticOSUpgrade] [-DisableAutoRollback]
 [-DoNotRunExtensionsOnOverprovisionedVm]
 [-IdentityId <IVirtualMachineScaleSetIdentityUserAssignedIdentities>] [-IdentityType <ResourceIdentityType>]
 [-MaxBatchInstancePercent <Int32>] [-MaxUnhealthyInstancePercent <Int32>]
 [-MaxUnhealthyUpgradedInstancePercent <Int32>] [-Overprovision] [-PauseTimeBetweenBatches <String>]
 [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-PlatformFaultDomainCount <Int32>] [-ProximityPlacementGroupId <String>] [-SinglePlacementGroup]
 [-SkuCapacity <Int64>] [-SkuName <String>] [-SkuTier <String>] [-Tag <IResourceTags>] [-UltraSsdEnabled]
 [-UpgradePolicyMode <UpgradeMode>] [-VirtualMachineProfile <IVirtualMachineScaleSetVMProfile>]
 [-Zone <String[]>] [-ZoneBalance] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity1
```
Set-AzVmss -InputObject <IComputeIdentity> [-VirtualMachineScaleSet <IVirtualMachineScaleSet>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a VM scale set.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutomaticOSUpgrade
Indicates whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the OS image becomes available.
Default value is false.
If this is set to true for Windows based scale sets, recommendation is to set [enableAutomaticUpdates](https://docs.microsoft.com/dotnet/api/microsoft.azure.management.compute.models.windowsconfiguration.enableautomaticupdatesview=azure-dotnet) to false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DisableAutoRollback
Whether OS image rollback feature should be disabled.
Default value is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DoNotRunExtensionsOnOverprovisionedVm
When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept.
This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityId
The list of user identities associated with the virtual machine scale set.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetIdentityUserAssignedIdentities
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases: UserAssignedIdentity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityType
The type of identity used for the virtual machine scale set.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities.
The type 'None' will remove any identities from the virtual machine scale set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ResourceIdentityType
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: UpdateViaIdentityExpanded1, UpdateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxBatchInstancePercent
The maximum percent of total virtual machine instances that will be upgraded simultaneously by the rolling upgrade in one batch.
As this is a maximum, unhealthy instances in previous or future batches can cause the percentage of instances in a batch to decrease to ensure higher reliability.
The default value for this parameter is 20%.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxUnhealthyInstancePercent
The maximum percentage of the total virtual machine instances in the scale set that can be simultaneously unhealthy, either as a result of being upgraded, or by being found in an unhealthy state by the virtual machine health checks before the rolling upgrade aborts.
This constraint will be checked prior to starting any batch.
The default value for this parameter is 20%.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxUnhealthyUpgradedInstancePercent
The maximum percentage of upgraded virtual machine instances that can be found to be in an unhealthy state.
This check will happen after each batch is upgraded.
If this percentage is ever exceeded, the rolling update aborts.
The default value for this parameter is 20%.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Overprovision
Specifies whether the Virtual Machine Scale Set should be overprovisioned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PauseTimeBetweenBatches
The wait time between completing the update for all virtual machines in one batch and starting the next batch.
The time duration should be specified in ISO 8601 format.
The default value is 0 seconds (PT0S).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanName
The plan ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanProduct
Specifies the product of the image from the marketplace.
This is the same value as Offer under the imageReference element.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPromotionCode
The promotion code.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPublisher
The publisher ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlatformFaultDomainCount
Fault Domain count for each placement group.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProximityPlacementGroupId
Resource Id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SinglePlacementGroup
When true this limits the scale set to a single placement group, of max size 100 virtual machines.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuCapacity
Specifies the number of virtual machines in the scale set.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The sku name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
Specifies the tier of virtual machines in a scale set.<br /><br /> Possible Values:<br /><br /> **Standard**<br /><br /> **Basic**

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20170330.IResourceTags
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UltraSsdEnabled
The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS.
Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases: EnableUltraSSD

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UpgradePolicyMode
Specifies the mode of an upgrade to virtual machines in the scale set.<br /><br /> Possible values are:<br /><br /> **Manual** - You control the application of updates to virtual machines in the scale set.
You do this by using the manualUpgrade action.<br /><br /> **Automatic** - All virtual machines in the scale set are automatically updated at the same time.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.UpgradeMode
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualMachineProfile
The virtual machine profile.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSetVMProfile
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualMachineScaleSet
Describes a Virtual Machine Scale Set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet
Parameter Sets: Update1, UpdateViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -VMScaleSetName
The name of the VM scale set to create or update.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Zone
The virtual machine scale set zones.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ZoneBalance
Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet

## ALIASES

## RELATED LINKS

