---
external help file: Az.ComputeFleet-help.xml
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/new-azcomputefleet
schema: 2.0.0
---

# New-AzComputeFleet

## SYNOPSIS
Create a Fleet

## SYNTAX

### CreateExpanded (Default)
```
New-AzComputeFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-AdditionalLocationProfile <ILocationProfile[]>] [-AdditionalVirtualMachineCapabilityHibernationEnabled]
 [-AdditionalVirtualMachineCapabilityUltraSsdEnabled] [-CapacityType <String>]
 [-ComputeProfileBaseVirtualMachineProfile <IBaseVirtualMachineProfile>]
 [-ComputeProfileComputeApiVersion <String>] [-ComputeProfilePlatformFaultDomainCount <Int32>]
 [-EnableSystemAssignedIdentity] [-Mode <String>] [-PlanName <String>] [-PlanProduct <String>]
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

### CreateViaJsonFilePath
```
New-AzComputeFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzComputeFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Fleet

## EXAMPLES

### Example 1: Create a Compute Fleet in Launch mode with a VNet and managed disks
```powershell
$resourceGroupName = "myResourceGroup"
$location = "eastus"
$fleetName = "fleet1"
$vmNamePrefix = "fleet1prefix"
$adminPassword = ConvertTo-SecureString "YourPassword123!" -AsPlainText -Force

$subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet1"
$nsgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Network/networkSecurityGroups/nsg"

# Build IPConfiguration
$ipConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration]::new()
$ipConfig.Name = "nic-ipConfig"
$ipConfig.Primary = $true
$ipConfig.SubnetId = $subnetId
$ipConfig.PublicIPAddressConfigurationName = "nic-publicip"
$ipConfig.IdleTimeoutInMinute = 15

# Build NIC Configuration
$nicConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration]::new()
$nicConfig.Name = "nic"
$nicConfig.Primary = $true
$nicConfig.EnableAcceleratedNetworking = $false
$nicConfig.NetworkSecurityGroupId = $nsgId
$nicConfig.IPConfiguration = @($ipConfig)

# Build StorageProfile
$storageProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile]::new()
$storageProfile.ImageReferencePublisher = "canonical"
$storageProfile.ImageReferenceOffer = "ubuntu-24_04-lts"
$storageProfile.ImageReferenceSku = "server"
$storageProfile.ImageReferenceVersion = "latest"
$storageProfile.OSDiskCreateOption = "fromImage"
$storageProfile.OSDiskCaching = "ReadWrite"
$storageProfile.OSDiskOstype = "Linux"
$storageProfile.ManagedDiskStorageAccountType = "Premium_LRS"

# Build OSProfile
$osProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfile]::new()
$osProfile.AdminUsername = "azureUser"
$osProfile.ComputerNamePrefix = $fleetName
$osProfile.AdminPassword = $adminPassword

# Build BaseVirtualMachineProfile
$baseVMProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile]::new()
$baseVMProfile.StorageProfile = $storageProfile
$baseVMProfile.OSProfile = $osProfile
$baseVMProfile.NetworkProfileNetworkApiVersion = "2020-11-01"
$baseVMProfile.NetworkProfileNetworkInterfaceConfiguration = @($nicConfig)
$baseVMProfile.SecurityProfileSecurityType = "TrustedLaunch"
$baseVMProfile.UefiSettingSecureBootEnabled = $true
$baseVMProfile.UefiSettingVTpmEnabled = $false
$baseVMProfile.LicenseType = "None"

# Build VM Sizes Profile
$vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
$vmSize1.Name = "Standard_D2s_v3"
$vmSize2 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
$vmSize2.Name = "Standard_D8s_v3"
$vmSizesProfile = @($vmSize1, $vmSize2)

New-AzComputeFleet -Name $fleetName `
    -ResourceGroupName $resourceGroupName `
    -Location $location `
    -Mode "Launch" `
    -VMNamePrefix $vmNamePrefix `
    -VMSizesProfile $vmSizesProfile `
    -ComputeProfileBaseVirtualMachineProfile $baseVMProfile `
    -ComputeProfileComputeApiVersion "2024-11-01" `
    -RegularPriorityProfileCapacity 5 `
    -RegularPriorityProfileMinCapacity 0 `
    -RegularPriorityProfileAllocationStrategy "LowestPrice"
```

```output
Name    Location    ProvisioningState
----    --------    -----------------
fleet1  eastus      Succeeded
```

Creates a Compute Fleet named "fleet1" in Launch mode with a VM name prefix, using Ubuntu 24.04 LTS with TrustedLaunch security, Premium managed disks, and a regular priority profile targeting 5 VMs with LowestPrice allocation strategy. The fleet is configured with a network interface connected to an existing VNet subnet and NSG.

### Example 2: Create a Compute Fleet with Spot VMs using a JSON file
```powershell
New-AzComputeFleet -Name "spotfleet1" -ResourceGroupName "myResourceGroup" -JsonFilePath "C:\fleet-config.json"
```

```output
Name        Location    ProvisioningState
----        --------    -----------------
spotfleet1  eastus      Succeeded
```

Creates a Compute Fleet using a JSON configuration file that contains the full fleet specification including compute profile, VM sizes, and priority settings. This approach is useful for complex configurations or when reusing fleet definitions across deployments.

## PARAMETERS

### -AdditionalLocationProfile
The list of location profiles.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
Mode of the Fleet.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### -SpotPriorityProfileAllocationStrategy
Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet

## NOTES

## RELATED LINKS
