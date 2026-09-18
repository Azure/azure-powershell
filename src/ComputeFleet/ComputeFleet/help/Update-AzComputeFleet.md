---
external help file: Az.ComputeFleet-help.xml
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/update-azcomputefleet
schema: 2.0.0
---

# Update-AzComputeFleet

## SYNOPSIS
Update a Fleet

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzComputeFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AdditionalLocationProfile <ILocationProfile[]>] [-AdditionalVirtualMachineCapabilityHibernationEnabled]
 [-AdditionalVirtualMachineCapabilityUltraSsdEnabled] [-CapacityType <String>]
 [-ComputeProfileBaseVirtualMachineProfile <IBaseVirtualMachineProfile>]
 [-ComputeProfileComputeApiVersion <String>] [-ComputeProfilePlatformFaultDomainCount <Int32>]
 [-EnableSystemAssignedIdentity <Boolean>] [-Mode <String>] [-PlanName <String>] [-PlanProduct <String>]
 [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-PlanVersion <String>]
 [-RegularPriorityProfileAllocationStrategy <String>] [-RegularPriorityProfileCapacity <Int32>]
 [-RegularPriorityProfileMinCapacity <Int32>] [-SpotPriorityProfileAllocationStrategy <String>]
 [-SpotPriorityProfileCapacity <Int32>] [-SpotPriorityProfileEvictionPolicy <String>]
 [-SpotPriorityProfileMaintain] [-SpotPriorityProfileMaxPricePerVM <Single>]
 [-SpotPriorityProfileMinCapacity <Int32>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-VMAttribute <IVMAttributes>] [-VMNamePrefix <String>] [-VMSizesProfile <IVMSizeProfile[]>]
 [-Zone <String[]>] [-ZoneAllocationPolicyDistributionStrategy <String>]
 [-ZoneAllocationPolicyZonePreference <IZonePreference[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzComputeFleet -InputObject <IComputeFleetIdentity> [-AdditionalLocationProfile <ILocationProfile[]>]
 [-AdditionalVirtualMachineCapabilityHibernationEnabled] [-AdditionalVirtualMachineCapabilityUltraSsdEnabled]
 [-CapacityType <String>] [-ComputeProfileBaseVirtualMachineProfile <IBaseVirtualMachineProfile>]
 [-ComputeProfileComputeApiVersion <String>] [-ComputeProfilePlatformFaultDomainCount <Int32>]
 [-EnableSystemAssignedIdentity <Boolean>] [-Mode <String>] [-PlanName <String>] [-PlanProduct <String>]
 [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-PlanVersion <String>]
 [-RegularPriorityProfileAllocationStrategy <String>] [-RegularPriorityProfileCapacity <Int32>]
 [-RegularPriorityProfileMinCapacity <Int32>] [-SpotPriorityProfileAllocationStrategy <String>]
 [-SpotPriorityProfileCapacity <Int32>] [-SpotPriorityProfileEvictionPolicy <String>]
 [-SpotPriorityProfileMaintain] [-SpotPriorityProfileMaxPricePerVM <Single>]
 [-SpotPriorityProfileMinCapacity <Int32>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-VMAttribute <IVMAttributes>] [-VMNamePrefix <String>] [-VMSizesProfile <IVMSizeProfile[]>]
 [-Zone <String[]>] [-ZoneAllocationPolicyDistributionStrategy <String>]
 [-ZoneAllocationPolicyZonePreference <IZonePreference[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a Fleet

## EXAMPLES

### Example 1: Update tags on a Compute Fleet using Update
```powershell
Update-AzComputeFleet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001" `
    -Tag @{ EnableVMManagementPolicy = "true"; environment = "staging" } | Select-Object Name, Tag, ProvisioningState
```

```output
Name              : fleet5-001
Tag               : {
                      "EnableVMManagementPolicy": "true",
                      "environment": "staging"
                    }
ProvisioningState : Succeeded
```

Updates the tags on a Managed mode Compute Fleet. The `Update-AzComputeFleet` cmdlet performs a read-modify-write operation — it fetches the existing fleet, merges only the properties you specify, and PUTs the result back. This means unspecified properties retain their existing values.

### Example 2: Update Spot capacity via pipeline input
```powershell
Get-AzComputeFleet -Name "fleet5-001" -ResourceGroupName "MY-FLEET-RG-001" | Update-AzComputeFleet `
    -SpotPriorityProfileCapacity 8 | Select-Object Name, SpotPriorityProfileCapacity, ProvisioningState
```

```output
Name                        : fleet5-001
SpotPriorityProfileCapacity : 8
ProvisioningState           : Succeeded
```

Retrieves an existing Compute Fleet and pipes it to `Update-AzComputeFleet` using the `-InputObject` parameter set. Only the Spot priority capacity is changed; all other properties are preserved from the existing fleet. Note that `computeProfile` is immutable and cannot be changed after fleet creation.

## PARAMETERS

### -AdditionalLocationProfile
The list of location profiles.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdditionalVirtualMachineCapabilityHibernationEnabled
The flag that enables or disables hibernation capability on the VM.

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

### -AdditionalVirtualMachineCapabilityUltraSsdEnabled
The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS.Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.

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

### -CapacityType
Specifies capacity type for Fleet Regular and Spot priority profiles.capacityType is an immutable property.
Once set during Fleet creation, it cannot be updated.Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.

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

### -ComputeProfileBaseVirtualMachineProfile
Base Virtual Machine Profile Properties to be specified according to "specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile"

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeProfileComputeApiVersion
Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.The default value will be the latest supported computeApiVersion by Compute Fleet.

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

### -ComputeProfilePlatformFaultDomainCount
Specifies the number of fault domains to use when creating the underlying VMSS.A fault domain is a logical group of hardware within an Azure datacenter.VMs in the same fault domain share a common power source and network switch.If not specified, defaults to 1, which represents "Max Spreading" (using as many fault domains as possible).This property cannot be updated.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Mode
Mode of the Fleet.

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

### -Name
The name of the Compute Fleet

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: FleetName

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

### -PlanName
A user defined name of the 3rd Party Artifact that is being procured.

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

### -PlanProduct
The 3rd Party artifact that is being procured.
E.g.
NewRelic.
Product maps to the OfferID specified for the artifact at the time of Data Market onboarding.

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

### -PlanPromotionCode
A publisher provided promotion code as provisioned in Data Market for the said product/artifact.

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

### -PlanPublisher
The publisher of the 3rd Party Artifact that is being bought.
E.g.
NewRelic

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

### -PlanVersion
The version of the desired product/artifact.

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

### -RegularPriorityProfileAllocationStrategy
Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.

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

### -RegularPriorityProfileCapacity
Total capacity to achieve.
It is currently in terms of number of VMs.

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

### -RegularPriorityProfileMinCapacity
Minimum capacity to achieve which cannot be updated.
If we will not be able to "guarantee" minimum capacity, we will reject the request in the sync path itself.

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

### -SpotPriorityProfileAllocationStrategy
Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.

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

### -SpotPriorityProfileCapacity
Total capacity to achieve.
It is currently in terms of number of VMs.

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

### -SpotPriorityProfileEvictionPolicy
Eviction Policy to follow when evicting Spot VMs.

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

### -SpotPriorityProfileMaintain
Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint) in order to achieve the desired capacity.Maintain is enabled by default.

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

### -SpotPriorityProfileMaxPricePerVM
Price per hour of each Spot VM will never exceed this.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpotPriorityProfileMinCapacity
Minimum capacity to achieve which cannot be updated.
If we will not be able to "guarantee" minimum capacity, we will reject the request in the sync path itself.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMAttribute
Attribute based Fleet.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMNamePrefix
VirtualMachine prefix to be used for the virtual machines launched by Fleet.
Can be used only with Launch mode.

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

### -VMSizesProfile
List of VM sizes supported for Compute Fleet

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
Zones in which the Compute Fleet is available

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneAllocationPolicyDistributionStrategy
Distribution strategy used for zone allocation policy.

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

### -ZoneAllocationPolicyZonePreference
Zone preferences, required when zone distribution strategy is Prioritized.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet

## NOTES

## RELATED LINKS
