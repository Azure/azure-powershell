---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: CE32F620-8DB2-4004-8012-F1C4AA235B60
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azvmssconfig
schema: 2.0.0
---

# New-AzVmssConfig

## SYNOPSIS
Creates a VMSS configuration object.

## SYNTAX

### DefaultParameterSet (Default)
```
New-AzVmssConfig [[-Overprovision] <Boolean>] [[-Location] <String>] [-EdgeZone <String>] [[-Tag] <Hashtable>]
 [[-SkuName] <String>] [[-SkuTier] <String>] [[-SkuCapacity] <Int32>] [[-UpgradePolicyMode] <UpgradeMode>]
 [[-OsProfile] <VirtualMachineScaleSetOSProfile>] [[-StorageProfile] <VirtualMachineScaleSetStorageProfile>]
 [[-NetworkInterfaceConfiguration] <VirtualMachineScaleSetNetworkConfiguration[]>]
 [[-Extension] <PSVirtualMachineScaleSetExtension[]>] [-SkipExtensionsOnOverprovisionedVMs]
 [-SinglePlacementGroup <Boolean>] [-ZoneBalance] [-PlatformFaultDomainCount <Int32>] [-Zone <String[]>]
 [-PlanName <String>] [-PlanPublisher <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>]
 [-RollingUpgradePolicy <RollingUpgradePolicy>] [-EnableAutomaticRepair] [-AutomaticRepairGracePeriod <String>]
 [-EnableAutomaticOSUpgrade] [-DisableAutoRollback <Boolean>] [-EnableUltraSSD] [-HealthProbeId <String>]
 [-BootDiagnostic <BootDiagnostics>] [-LicenseType <String>] [-Priority <String>] [-EnableSpotRestore]
 [-SpotRestoreTimeout <String>] [-EvictionPolicy <String>] [-MaxPrice <Double>] [-TerminateScheduledEvents]
 [-TerminateScheduledEventNotBeforeTimeoutInMinutes <Int32>] [-ProximityPlacementGroupId <String>]
 [-ScaleInPolicy <String[]>] [-EncryptionAtHost] [-OrchestrationMode <String>]
 [-CapacityReservationGroupId <String>] [-UserData <String>] [-AutomaticRepairAction <String>]
 [-BaseRegularPriorityCount <Int32>] [-RegularPriorityPercentage <Int32>] [-ImageReferenceId <String>]
 [-SharedGalleryImageId <String>] [-OSImageScheduledEventEnabled]
 [-OSImageScheduledEventNotBeforeTimeoutInMinutes <String>] [-SecurityType <String>] [-EnableVtpm <Boolean>]
 [-EnableSecureBoot <Boolean>] [-SkuProfileVmSize <String[]>] [-SkuProfileAllocationStrategy <String>]
 [-EnableResilientVMCreate] [-EnableResilientVMDelete] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExplicitIdentityParameterSet
```
New-AzVmssConfig [[-Overprovision] <Boolean>] [[-Location] <String>] [-EdgeZone <String>] [[-Tag] <Hashtable>]
 [[-SkuName] <String>] [[-SkuTier] <String>] [[-SkuCapacity] <Int32>] [[-UpgradePolicyMode] <UpgradeMode>]
 [[-OsProfile] <VirtualMachineScaleSetOSProfile>] [[-StorageProfile] <VirtualMachineScaleSetStorageProfile>]
 [[-NetworkInterfaceConfiguration] <VirtualMachineScaleSetNetworkConfiguration[]>]
 [[-Extension] <PSVirtualMachineScaleSetExtension[]>] [-SkipExtensionsOnOverprovisionedVMs]
 [-SinglePlacementGroup <Boolean>] [-ZoneBalance] [-PlatformFaultDomainCount <Int32>] [-Zone <String[]>]
 [-PlanName <String>] [-PlanPublisher <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>]
 [-RollingUpgradePolicy <RollingUpgradePolicy>] [-EnableAutomaticRepair] [-AutomaticRepairGracePeriod <String>]
 [-EnableAutomaticOSUpgrade] [-DisableAutoRollback <Boolean>] [-EnableUltraSSD] [-HealthProbeId <String>]
 [-BootDiagnostic <BootDiagnostics>] [-LicenseType <String>] [-Priority <String>] [-EnableSpotRestore]
 [-SpotRestoreTimeout <String>] [-EvictionPolicy <String>] [-MaxPrice <Double>] [-TerminateScheduledEvents]
 [-TerminateScheduledEventNotBeforeTimeoutInMinutes <Int32>] [-ProximityPlacementGroupId <String>]
 [-ScaleInPolicy <String[]>] -IdentityType <ResourceIdentityType> [-IdentityId <String[]>] [-EncryptionAtHost]
 [-OrchestrationMode <String>] [-CapacityReservationGroupId <String>] [-UserData <String>]
 [-AutomaticRepairAction <String>] [-BaseRegularPriorityCount <Int32>] [-RegularPriorityPercentage <Int32>]
 [-ImageReferenceId <String>] [-SharedGalleryImageId <String>] [-OSImageScheduledEventEnabled]
 [-OSImageScheduledEventNotBeforeTimeoutInMinutes <String>] [-SecurityType <String>] [-EnableVtpm <Boolean>]
 [-EnableSecureBoot <Boolean>] [-SkuProfileVmSize <String[]>] [-SkuProfileAllocationStrategy <String>]
 [-EnableResilientVMCreate] [-EnableResilientVMDelete] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVmssConfig** cmdlet creates a configurable local Virtual Manager Scale Set (VMSS)
object. <br>

Use the following cmdlets to configure the VMSS object:
- **[Add-AzVmssNetworkInterfaceConfiguration](https://learn.microsoft.com/en-us/powershell/module/az.compute/add-azvmssnetworkinterfaceconfiguration)** to set the network profile.<br>
- **[Set-AzVmssOsProfile](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmssosprofile)** to set the OS profile. <br>
- **[Set-AzVmssStorageProfile](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmssstorageprofile)** to set the storage profile.<br>
- **[Get-AzComputeResourceSku](https://learn.microsoft.com/en-us/powershell/module/az.compute/get-azcomputeresourcesku)** can also be used to find out available virtual machine sizes for your subscription and region.<br><br>

See other cmdlets for virtual machine scale set [here](https://learn.microsoft.com/en-us/powershell/module/az.compute/#vm-scale-sets).<br>
<br>
See [Quickstart: Create a virtual machine scale set with Azure PowerShell](https://learn.microsoft.com/en-us/azure/virtual-machine-scale-sets/quick-create-powershell) for tutorial.

## EXAMPLES

### Example 1: Create a VMSS configuration object
```powershell
$VMSS = New-AzVmssConfig -Location $Loc -SkuCapacity 2 -SkuName "Standard_A0" -UpgradePolicyMode "Automatic" -NetworkInterfaceConfiguration $NetCfg `
            | Add-AzVmssNetworkInterfaceConfiguration -Name "Test" -Primary $True -IPConfiguration $IPCfg `
            | Set-AzVmssOsProfile -ComputerNamePrefix "Test" -AdminUsername $adminUsername -AdminPassword $AdminPassword `
            | Set-AzVmssStorageProfile -Name "Test" -OsDiskCreateOption "FromImage" -OsDiskCaching "None" `
            -ImageReferenceOffer $ImgRef.Offer -ImageReferenceSku $ImgRef.Skus -ImageReferenceVersion $ImgRef.Version `
            -ImageReferencePublisher $ImgRef.PublisherName -VhdContainer $VHDContainer `
            | Add-AzVmssAdditionalUnattendContent -ComponentName  $AUCComponentName -Content  $AUCContent -PassName  $AUCPassName -SettingName  $AUCSetting;

New-AzVmss -ResourceGroupName $RGName -Name $VMSSName -VirtualMachineScaleSet $VMSS;
```

This example creates a VMSS configuration object. The first command uses the
**New-AzVmssConfig** cmdlet to create a VMSS configuration object and stores the result in the
variable named $VMSS. The second command uses the **New-AzVmss** cmdlet to create a VMSS that
uses the VMSS configuration object created in the first command.

### Example 2

Creates a VMSS configuration object. (autogenerated)

<!-- Aladdin Generated Example -->


```powershell
New-AzVmssConfig -Location <String> -Overprovision $false -SkuCapacity 2 -SkuName 'Standard_A0' -SecurityType "Standard" -Tag @{key0="value0";key1=$null;key2="value2"} -UpgradePolicyMode Automatic;
```

### Example 3

Creates a VMSS configuration object. (autogenerated)

<!-- Aladdin Generated Example -->


```powershell
New-AzVmssConfig -Location <String> -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode Automatic -IdentityType SystemAssigned -SecurityType "Standard";
```

### Example 4: Create a VMSS with the OS Image Scheduled Events enabled
```powershell
$publisher = "MicrosoftWindowsServer";
$offer = "WindowsServer";
$imgSku = "2019-Datacenter";
$version = "latest";
$vmssName = 'vmss' + $rgname;
$vmssSku = "Standard_D2s_v3";
$vmssname = "vmss" + $rgname;
$domainNameLabel = "d" + $rgname;
$securityTypeStnd = "Standard";
$username = <Username>;
$securePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force;

$credential = New-Object System.Management.Automation.PSCredential ($username, $securePassword);

# SRP
$stoname = 'sto' + $rgname;
$stotype = 'Standard_GRS';
New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
$stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;

# NRP
$subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
$vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
$vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
$subnetId = $vnet.Subnets[0].Id;

# Create VMSS with managed disk
$timeoutValue = 'PT15M';
$ipCfg = New-AzVmssIpConfig -Name 'test' -SubnetId $subnetId;
$vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSku -OSImageScheduledEventEnabled -OSImageScheduledEventNotBeforeTimeoutInMinutes $timeoutValue -UpgradePolicyMode "Automatic" -SecurityType $securityTypeStnd `
    | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
    | Set-AzVmssOsProfile -ComputerNamePrefix 'test' -AdminUsername $username -AdminPassword $password `
    | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
       -ImageReferenceOffer $offer -ImageReferenceSku $imgSku -ImageReferenceVersion $version `
       -ImageReferencePublisher $publisher;

$result = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

$vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;
# $vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.Enable is the OSImageScheduledEventEnabled flag.
# $vmss.VirtualMachineProfile.ScheduledEventsProfile.OsImageNotificationProfile.NotBeforeTimeout is the timeout value 'PT15M'.
```

### Example 5: Create a Vmss with the security type TrustedLaunch
```powershell
$rgname = "rganme";
 $loc = "eastus";
 New-AzResourceGroup -Name $rgname -Location $loc -Force;
# VMSS Profile & Hardware requirements for the TrustedLaunch default behavior.
$vmssSize = 'Standard_D4s_v3';
$PublisherName = "MicrosoftWindowsServer";
$Offer = "WindowsServer";
$SKU = "2016-datacenter-gensecond";
$securityType = "TrustedLaunch";
$enable = $true;
$disable = $false;
$extDefaultName = "GuestAttestation";
$vmGADefaultIDentity = "SystemAssigned";

# NRP
$subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
$vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
$vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
$subnetId = $vnet.Subnets[0].Id;

# New VMSS Parameters
$vmssName1 = 'vmss1' + $rgname;
$vmssName2 = 'vmss2' + $rgname;
$vmssType = 'Microsoft.Compute/virtualMachineScaleSets';
$adminUsername = <Username>;
$adminPassword = ConvertTo-SecureString -String "****" -AsPlainText -Force;
$imgRef = New-Object -TypeName 'Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage';
$imgRef.PublisherName = $PublisherName;
$imgRef.Offer = $Offer;
$imgRef.Skus = $SKU;
$imgRef.Version = "latest";
$ipCfg = New-AzVmssIpConfig -Name 'test' -SubnetId $subnetId;

$vmss = New-AzVmssConfig -Location $loc -SkuCapacity 2 -SkuName $vmssSize -UpgradePolicyMode 'Manual' `
    | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
    | Set-AzVmssOsProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
    | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'ReadOnly' `
    -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
    -ImageReferencePublisher $imgRef.PublisherName;
    
# VMSS Creation using VMSSConfig for Trusted Launch SecurityType
$vmss1 = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $vmss -SecurityType $securityType;
$result = New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1 -VirtualMachineScaleSet $vmss1;
$vmssGet = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1;

# Validate that for -SecurityType "TrustedLaunch" "-Vtpm" and -"SecureBoot" are "Enabled/true"
#$vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.VTpmEnabled $true;
#$vmssGet.VirtualMachineProfile.SecurityProfile.UefiSettings.SecureBootEnabled $true;
```

This example Creates a new VMSS using VMSSConfig object for the Trusted Launch Security Type and validates flags SecureBoot and Vtpm as True by default.

## PARAMETERS

### -AutomaticRepairAction
Type of repair action (replace, restart, reimage) that will be used for repairing unhealthy virtual machines in the scale set. Default value is replace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AutomaticRepairGracePeriod
The amount of time for which automatic repairs are suspended due to a state change on VM. The grace time starts after the state change has completed. This helps avoid premature or accidental repairs. The time duration should be specified in ISO 8601 format. The minimum allowed grace period is 30 minutes (PT30M), which is also the default value. The maximum allowed grace period is 90 minutes (PT90M).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -BaseRegularPriorityCount
Specifies the minimum number of VMs that must be of Regular priority as a VMSS Flex instance scales out. This parameter is only valid for VMSS instances with Flexible OrchestrationMode. 

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -BootDiagnostic
Specifies the virtual machine scale set boot diagnostics profile.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.BootDiagnostics
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CapacityReservationGroupId
Id of the capacity reservation Group that is used to allocate.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableAutoRollback
Disable Auto Rollback for Auto OS Upgrade Policy

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EdgeZone
Sets the edge zone name. If set, the query will be routed to the specified edgezone instead of the main region.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableAutomaticOSUpgrade
Whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the image becomes available.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: AutoOSUpgrade

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAutomaticRepair
Enables automatic repairs on the virtual machine scale set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableResilientVMCreate
Specifies whether resilient VM creation should be enabled on the virtual machine scale set. The default value is false.

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

### -EnableResilientVMDelete
Specifies whether resilient VM deletion should be enabled on the virtual machine scale set. The default value is false.

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

### -EnableSecureBoot
Specifies whether secure boot should be enabled on the virtual machine.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableSpotRestore
Enables the Spot-Try-Restore feature where evicted VMSS SPOT instances will be tried to be restored opportunistically based on capacity availability and pricing constraints

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableUltraSSD
Enables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the virtual machine scale set.
Managed disks with storage account type UltraSSD_LRS can be added to a VMSS only if this property is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableVtpm
Specifies whether vTPM should be enabled on the virtual machine.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EncryptionAtHost
This parameter will enable the encryption for all the disks including Resource/Temp disk at host itself. Default: The Encryption at host will be disabled unless this property is set to true for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EvictionPolicy
Specifies the eviction policy for the virtual machines in the scale set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Extension
Specifies the extension information object for the VMSS. You can use the
**Add-AzVmssExtension** cmdlet to add this object.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSetExtension[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -HealthProbeId
Specifies the ID of a load balancer probe used to determine the health of an instance in the virtual machine scale set.
HealthProbeId is in the form of '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{probeName}'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityId
Specifies the list of user identities associated with the virtual machine scale set.
The user identity references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'

```yaml
Type: System.String[]
Parameter Sets: ExplicitIdentityParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityType
Specifies the type of identity used for the virtual machine scale set.
The type 'SystemAssignedUserAssigned' includes both an implicitly created identity and a set of user assigned identities.
The type 'None' will remove any identities from the virtual machine scale set.
The acceptable values for this parameter are:
- SystemAssigned
- UserAssigned
- SystemAssignedUserAssigned
- None

```yaml
Type: System.Nullable`1[Microsoft.Azure.Management.Compute.Models.ResourceIdentityType]
Parameter Sets: ExplicitIdentityParameterSet
Aliases:
Accepted values: SystemAssigned, UserAssigned, SystemAssignedUserAssigned, None

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ImageReferenceId
Specified the gallery image unique id for vmss deployment. This can be fetched from gallery image GET call.

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

### -LicenseType
Specify the license type, which is for bringing your own license scenario.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies the Azure location where the VMSS is created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxPrice
Specifies the maximum price you are willing to pay for a Spot VM/VMSS. This price is in US Dollars. This price will be compared with the current Spot price for the VM size. Also, the prices are compared at the time of create/update of Spot VM/VMSS and the operation will only succeed if the maxPrice is greater than the current Spot price. The maxPrice will also be used for evicting a Spot VM/VMSS if the current Spot price goes beyond the maxPrice after creation of VM/VMSS. Possible values are: any decimal value greater than zero. Example: 0.01538.  -1 indicates that the Spot VM/VMSS should not be evicted for price reasons. Also, the default max price is -1 if it is not provided by you.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkInterfaceConfiguration
Specifies the network profile object that contains the networking properties for the VMSS configuration.
You can use the **Add-AzVmssNetworkInterfaceConfiguration** cmdlet to add this object.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 9
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OrchestrationMode
Specifies the orchestration mode for the virtual machine scale set. Possible values: Uniform, Flexible

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OSImageScheduledEventEnabled
Specifies whether the OS Image Scheduled event is enabled or disabled.

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

### -OSImageScheduledEventNotBeforeTimeoutInMinutes
The length of time a virtual machine being reimaged or having its OS upgraded will have to potentially approve the OS Image Scheduled Event before the event is auto approved (timed out). The configuration is specified in ISO 8601 format, with the value set to 15 minutes (PT15M).

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

### -OsProfile
Specifies the operating system profile object that contains the operating system properties for the VMSS configuration.
You can use the **Set-AzVmssOsProfile** cmdlet to set this object.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetOSProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Overprovision
Indicates whether the cmdlet overprovisions the VMSS.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PlanName
Specifies the plan name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PlanProduct
Specifies the plan product.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PlanPromotionCode
Specifies the plan promotion code.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PlanPublisher
Specifies the plan publisher.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PlatformFaultDomainCount
Fault Domain count for each placement group.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Priority
The priority for the virtual machien in the scale set.  Only supported values are 'Regular', 'Spot' and 'Low'.
'Regular' is for regular virtual machine.
'Spot' is for spot virtual machine.
'Low' is also for spot virtual machine but is replaced by 'Spot'. Please use 'Spot' instead of 'Low'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```


### -ProximityPlacementGroupId
The resource id of the Proximity Placement Group to use with this scale set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RegularPriorityPercentage
Specifies the desired percentage of VMs, after the BaseRegularCount has been met, that are of Regular priority as the VMSS Flex instance scales out. This property is only valid for VMSS instances with Flexible OrchestrationMode.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RollingUpgradePolicy
Specifies the rolling upgrade policy.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.RollingUpgradePolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScaleInPolicy
The rules to be followed when scaling-in a virtual machine scale set.  Possible values are: 'Default', 'OldestVM' and 'NewestVM'.  'Default' when a virtual machine scale set is scaled in, the scale set will first be balanced across zones if it is a zonal scale set.  Then, it will be balanced across Fault Domains as far as possible.  Within each Fault Domain, the virtual machines chosen for removal will be the newest ones that are not protected from scale-in.  'OldestVM' when a virtual machine scale set is being scaled-in, the oldest virtual machines that are not protected from scale-in will be chosen for removal.  For zonal virtual machine scale sets, the scale set will first be balanced across zones.  Within each zone, the oldest virtual machines that are not protected will be chosen for removal.  'NewestVM' when a virtual machine scale set is being scaled-in, the newest virtual machines that are not protected from scale-in will be chosen for removal.  For zonal virtual machine scale sets, the scale set will first be balanced across zones.  Within each zone, the newest virtual machines that are not protected will be chosen for removal.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecurityType
Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. Default: UefiSettings will not be enabled unless this property is set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: TrustedLaunch, ConfidentialVM, Standard

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SharedGalleryImageId
Specified the shared gallery image unique id for vm deployment. This can be fetched from shared gallery image GET call.

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

### -SinglePlacementGroup
Specifies the single placement group.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipExtensionsOnOverprovisionedVMs
Specifies that the extensions do not run on the extra overprovisioned VMs.

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

### -SkuCapacity
Specifies the number of instances in the VMSS.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuName
Specifies the size of all the instances of VMSS. [Get-AzComputeResourceSku](https://learn.microsoft.com/en-us/powershell/module/az.compute/get-azcomputeresourcesku) can be used to find out available sizes for your subscription and region. 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountType

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuProfileAllocationStrategy
Allocation strategy for the SKU profile.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuProfileVmSize
Array of VM sizes for the scale set.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuTier
Specifies the tier of VMSS. The acceptable values for this parameter are:
- Standard
- Basic

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SpotRestoreTimeout
Specifies timeout value expressed as an ISO 8601 time duration after which the platform will not try to restore the VMSS SPOT instances

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageProfile
Specifies the storage profile object that contains the disk properties for the VMSS configuration.
You can use the **Set-AzVmssStorageProfile** cmdlet to set this object.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetStorageProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:
@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TerminateScheduledEventNotBeforeTimeoutInMinutes
Configurable length of time (in minutes) a Virtual Machine being deleted will have to potentially approve the Terminate Scheduled Event before the event is auto approved (timed out).

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TerminateScheduledEvents
Enable the Terminate Scheduled events

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UpgradePolicyMode
Specified the mode of an upgrade to virtual machines in the scale set.
The acceptable values for this parameter are:
- Automatic
- Manual

```yaml
Type: System.Nullable`1[Microsoft.Azure.Management.Compute.Models.UpgradeMode]
Parameter Sets: (All)
Aliases:
Accepted values: Automatic, Manual, Rolling

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserData
UserData for the VM, which will be base-64 encoded. Customer should not pass any secrets in here.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
Specifies the zone list for the virtual machine scale set.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ZoneBalance
Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage.

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.String

### System.Collections.Hashtable

### System.Int32

### System.Nullable`1[[Microsoft.Azure.Management.Compute.Models.UpgradeMode, Microsoft.Azure.Management.Compute, Version=23.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]

### Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetOSProfile

### Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetStorageProfile

### Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkConfiguration[]

### Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetExtension[]

### System.String[]

### Microsoft.Azure.Management.Compute.Models.RollingUpgradePolicy

### System.Management.Automation.SwitchParameter

### Microsoft.Azure.Management.Compute.Models.BootDiagnostics

### System.Nullable`1[[Microsoft.Azure.Management.Compute.Models.ResourceIdentityType, Microsoft.Azure.Management.Compute, Version=23.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

## NOTES

## RELATED LINKS

[Set-AzVmssOsProfile](./Set-AzVmssOsProfile.md)

[Set-AzVmssStorageProfile](./Set-AzVmssStorageProfile.md)

[Add-AzVmssNetworkInterfaceConfiguration](./Add-AzVmssNetworkInterfaceConfiguration.md)

[Add-AzVmssExtension](./Add-AzVmssExtension.md)

[New-AzVmss](./New-AzVmss.md)
