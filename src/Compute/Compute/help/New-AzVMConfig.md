---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 1BECAC91-BB43-46EB-B2C9-C965C6FBC831
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azvmconfig
schema: 2.0.0
---

# New-AzVMConfig

## SYNOPSIS
Creates a configurable virtual machine object.

## SYNTAX

### DefaultParameterSet (Default)
```
New-AzVMConfig [-VMName] <String> [-VMSize] <String> [[-AvailabilitySetId] <String>] [[-LicenseType] <String>]
 [-Zone <String[]>] [-ProximityPlacementGroupId <String>] [-HostId <String>] [-VmssId <String>]
 [-MaxPrice <Double>] [-EvictionPolicy <String>] [-Priority <String>] [-Tags <Hashtable>] [-EnableUltraSSD]
 [-EncryptionAtHost] [-CapacityReservationGroupId <String>] [-ImageReferenceId <String>]
 [-DiskControllerType <String>] [-UserData <String>] [-PlatformFaultDomain <Int32>] [-HibernationEnabled]
 [-vCPUCountAvailable <Int32>] [-vCPUCountPerCore <Int32>] [-SharedGalleryImageId <String>]
 [-SecurityType <String>] [-EnableVtpm <Boolean>] [-EnableSecureBoot <Boolean>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ExplicitIdentityParameterSet
```
New-AzVMConfig [-VMName] <String> [-VMSize] <String> [[-AvailabilitySetId] <String>] [[-LicenseType] <String>]
 [-IdentityType] <ResourceIdentityType> [-IdentityId <String[]>] [-Zone <String[]>]
 [-ProximityPlacementGroupId <String>] [-HostId <String>] [-VmssId <String>] [-MaxPrice <Double>]
 [-EvictionPolicy <String>] [-Priority <String>] [-Tags <Hashtable>] [-EnableUltraSSD] [-EncryptionAtHost]
 [-CapacityReservationGroupId <String>] [-ImageReferenceId <String>] [-DiskControllerType <String>]
 [-UserData <String>] [-PlatformFaultDomain <Int32>] [-HibernationEnabled] [-vCPUCountAvailable <Int32>]
 [-vCPUCountPerCore <Int32>] [-SharedGalleryImageId <String>] [-SecurityType <String>] [-EnableVtpm <Boolean>]
 [-EnableSecureBoot <Boolean>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVMConfig** cmdlet creates a configurable local virtual machine object for Azure. <br>

The following cmdlets are used to set different properties of the virtual machine object: <br>
- **[Add-AzVMNetworkInterface](https://learn.microsoft.com/en-us/powershell/module/az.compute/add-azvmnetworkinterface)** to set the network profile.<br>
- **[Set-AzVMOperatingSystem](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmoperatingsystem)** to set the OS profile. <br>
- **[Set-AzVMSourceImage](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmsourceimage)** to set the source image.<br>
- **[Set-AzVMOSDisk](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmosdisk)** to set the OS disk (storage profile).<br>
- **[Get-AzComputeResourceSku](https://learn.microsoft.com/en-us/powershell/module/az.compute/get-azcomputeresourcesku)** can also be used to find out available virtual machine sizes for your subscription and region.<br>
<br>
See [Quickstart: Create a Windows virtual machine in Azure with PowerShell](https://learn.microsoft.com/en-us/azure/virtual-machines/windows/quick-create-powershell) for tutorial. <br>

## EXAMPLES

### Example 1: Create a virtual machine resource
```powershell
$rgname = "resourceGroupName";
$loc = "eastus";

New-AzResourceGroup -Name $rgname -Location $loc -Force;

# General Setup
$vmname = 'v' + $rgname;
$domainNameLabel = "d1" + $rgname;
$vmSize = 'Standard_DS3_v2';
$computerName = "c" + $rgname;
$securityTypeStnd = "Standard";
        
# Credential. Input Username and Password values
$user = "";
$securePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force;  
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        
# Creating a VMConfig 
$vmconfig = New-AzVMConfig -VMName $vmname -vmsize $vmsize -SecurityType $securityTypeStnd;

# Set source image values
$publisherName = "MicrosoftWindowsServer";
$offer = "WindowsServer";
$sku = "2019-DataCenter";
$vmconfig = Set-AzVMSourceImage -VM $vmconfig -PublisherName $publisherName -Offer $offer -Skus $sku -Version 'latest';

# NRP Setup
$subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
$vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
$vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
$subnetId = $vnet.Subnets[0].Id;
$pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Static -DomainNameLabel $domainNameLabel;
$pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
$pubipId = $pubip.Id;
$nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
$nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
$nicId = $nic.Id;

$vmconfig = Add-AzVMNetworkInterface -VM $vmconfig -Id $nicId;
$vmconfig = Set-AzVMOperatingSystem -VM $vmconfig -Windows -ComputerName $computerName -Credential $cred;

# Create the VM
New-AzVM -ResourceGroupName $rgname -Location $loc -Vm $vmconfig;
$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
```

### Example 2: Create a virtual machine object in a virtual machine scale set with fault domains setup
```powershell
$rgname = "resourceGroupName";
$loc = "eastus";
$vmname = "vm" + $rgname;

New-AzResourceGroup -Name $rgname -Location $loc -Force;

$domainNameLabel = "d1" + $rgname;
$vmname = "v" + $rgname;
$vnetname = "myVnet";
$vnetAddress = "10.0.0.0/16";
$subnetname = "slb" + $rgname;
$subnetAddress = "10.0.2.0/24";
$vmssName = "vmss" + $rgname;
$faultDomainNumber = 2;
$vmssFaultDomain = 3;
$securityTypeStnd = "Standard";

$OSDiskName = $vmname + "-osdisk";
$NICName = $vmname+ "-nic";
$NSGName = $vmname + "-NSG";
$OSDiskSizeinGB = 128;
$VMSize = "Standard_DS2_v2";
$PublisherName = "MicrosoftWindowsServer";
$Offer = "WindowsServer";
$SKU = "2019-Datacenter";
        
# Credential. Input Username and Password values.
$user = "";
$securePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force;  
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;
$vnet = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;

$vmssConfig = New-AzVmssConfig -Location $loc -PlatformFaultDomainCount $vmssFaultDomain -SecurityType $securityTypeStnd;
$vmss = New-AzVmss -ResourceGroupName $RGName -Name $VMSSName -VirtualMachineScaleSet $vmssConfig;

$nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name RDP  -Protocol Tcp  -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389 -Access Allow;
$nsg = New-AzNetworkSecurityGroup -ResourceGroupName $RGName -Location $loc -Name $NSGName  -SecurityRules $nsgRuleRDP;
$nic = New-AzNetworkInterface -Name $NICName -ResourceGroupName $RGName -Location $loc -SubnetId $vnet.Subnets[0].Id -NetworkSecurityGroupId $nsg.Id -EnableAcceleratedNetworking;

# VM
$vmConfig = New-AzVMConfig -VMName $vmName -VMSize $VMSize  -VmssId $vmss.Id -PlatformFaultDomain $faultDomainNumber -SecurityType $securityTypeStnd;
Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $vmName -Credential $cred ;
Set-AzVMOSDisk -VM $vmConfig -StorageAccountType "Premium_LRS" -Caching ReadWrite -Name $OSDiskName -DiskSizeInGB $OSDiskSizeinGB -CreateOption FromImage ;
Set-AzVMSourceImage -VM $vmConfig -PublisherName $PublisherName -Offer $Offer -Skus $SKU -Version latest ;
Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id;

New-AzVM -ResourceGroupName $RGName -Location $loc -VM $vmConfig;
$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmName;
```

### Example 2: Create a VM using Virtual Machine Config object for TrustedLaunch Security Type, flags Vtpm and Secure Boot are set to True by default.
```powershell
$rgname = "rgname";
$loc = "eastus";
New-AzResourceGroup -Name $rgname -Location $loc -Force;    
 
# VM Profile & Hardware
$domainNameLabel = "d1" + $rgname;
$vmsize = 'Standard_D4s_v3';
$vmname = $rgname + 'Vm';
$securityType_TL = "TrustedLaunch";
$vnetname = "myVnet";
$vnetAddress = "10.0.0.0/16";
$subnetname = "slb" + $rgname;
$subnetAddress = "10.0.2.0/24";
$OSDiskName = $vmname + "-osdisk";
$NICName = $vmname+ "-nic";
$NSGName = $vmname + "-NSG";
$OSDiskSizeinGB = 128;
$PublisherName = "MicrosoftWindowsServer";
$Offer = "WindowsServer";
$SKU = "2016-datacenter-gensecond";
$disable = $false;
$enable = $true;
$extDefaultName = "GuestAttestation";
$vmGADefaultIDentity = "SystemAssigned";
# Credential
$securePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force;  
$user = <Username>;
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
# Network resources
$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;
$vnet = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;
$nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name RDP  -Protocol Tcp  -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389 -Access Allow;
$nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgname -Location $loc -Name $NSGName  -SecurityRules $nsgRuleRDP;
$nic = New-AzNetworkInterface -Name $NICName -ResourceGroupName $rgname -Location $loc -SubnetId $vnet.Subnets[0].Id -NetworkSecurityGroupId $nsg.Id -EnableAcceleratedNetworking;
# Configure Values using VMConfig Object
$vmConfig = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $vmname -Credential $cred;
Set-AzVMSourceImage -VM $vmConfig -PublisherName $PublisherName -Offer $Offer -Skus $SKU -Version latest ;
Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id;
  
# VM Creation using VMConfig for Trusted Launch SecurityType
$vmConfig = Set-AzVMSecurityProfile -VM $vmConfig -SecurityType $securityType_TL;
New-AzVM -ResourceGroupName $rgname -Location $loc -VM $vmConfig;
$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
# Validate that for -SecurityType "TrustedLaunch", "-Vtpm" and "-SecureBoot" are "Enabled/true"
#$vm.SecurityProfile.UefiSettings.VTpmEnabled $true;
#$vm.SecurityProfile.UefiSettings.SecureBootEnabled $true;
```

This example creates a VM using a VMConfig object for the TrustedLaunch Security Type and validates flags VtpmEnabled and SecureBootEnabled are true by default.

## PARAMETERS

### -AvailabilitySetId
Specifies the ID of an availability set.
To obtain an availability set object, use the Get-AzAvailabilitySet cmdlet.
The availability set object contains an ID property. <br>
Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. <br>
For more information about availability sets, see [Manage the availability of virtual machines](/azure/virtual-machines/availability). <br>
For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](/azure/virtual-machines/maintenance-and-updates?toc=/azure/virtual-machines/windows/toc.json&bc=/azure/virtual-machines/windows/breadcrumb/toc.json) <br>
Currently, a VM can only be added to availability set at creation time. The availability set to which the VM is being added should be under the same resource group as the availability set resource. An existing VM cannot be added to an availability set. <br>
This property cannot exist along with a non-null properties.virtualMachineScaleSet reference.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
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

### -DiskControllerType
Specifies the disk controller type configured for the VM and VirtualMachineScaleSet. This property is only supported for virtual machines whose operating system disk and VM sku supports Generation 2 (https://learn.microsoft.com/en-us/azure/virtual-machines/generation-2), please check the HyperVGenerations capability returned as part of VM sku capabilities in the response of Microsoft.Compute SKUs api for the region contains V2 (https://learn.microsoft.com/rest/api/compute/resourceskus/list) . <br> For more information about Disk Controller Types supported please refer to https://aka.ms/azure-diskcontrollertypes.

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

### -EnableUltraSSD
Enables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM.
Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine only if this property is enabled.


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
EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine or virtual machine scale set.
This will enable the encryption for all the disks including Resource/Temp disk at host itself.
Default: The Encryption at host will be disabled unless this property is set to true for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -EvictionPolicy
The eviction policy for the Azure Spot virtual machine.  Supported values are 'Deallocate' and 'Delete'.

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

### -HibernationEnabled
The flag that enables or disables hibernation capability on the VM.

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

### -HostId
The Id of Host

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
The identity of the virtual machine, if configured.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Management.Compute.Models.ResourceIdentityType]
Parameter Sets: ExplicitIdentityParameterSet
Aliases:
Accepted values: SystemAssigned, UserAssigned, SystemAssignedUserAssigned, None

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageReferenceId
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

### -LicenseType
Specifies a license type, which indicates that the image or disk for the virtual machine was licensed on-premises.
Possible values for Windows Server are:
- Windows_Client
- Windows_Server

Possible values for Linux Server operating system are:
- RHEL_BYOS (for RHEL)
- SLES_BYOS (for SUSE)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrice
Specifies the maximum price you are willing to pay for a low priority VM/VMSS. This price is in US Dollars. This price will be compared with the current low priority price for the VM size. Also, the prices are compared at the time of create/update of low priority VM/VMSS and the operation will only succeed if the maxPrice is greater than the current low priority price. The maxPrice will also be used for evicting a low priority VM/VMSS if the current low priority price goes beyond the maxPrice after creation of VM/VMSS. Possible values are: any decimal value greater than zero. Example: 0.01538.  -1 indicates that the low priority VM/VMSS should not be evicted for price reasons. Also, the default max price is -1 if it is not provided by you.

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

### -PlatformFaultDomain
Specifies the fault domain of the virtual machine.

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
The priority for the virtual machine.  Only supported values are 'Regular', 'Spot' and 'Low'.
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
The resource id of the Proximity Placement Group to use with this virtual machine.

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

### -SecurityType
Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. By default, UefiSettings will not be enabled unless this property is set.

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

### -Tags
The tags attached to the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tag

Required: False
Position: Named
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

### -vCPUCountAvailable
Specifies the number of vCPUs available for the VM. When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).

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

### -vCPUCountPerCore
Specifies the vCPU to physical core ratio. When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list). Setting this property to 1 also means that hyper-threading is disabled.

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

### -VMName
Specifies a name for the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, Name

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VMSize
Specifies the size for the virtual machine. [Get-AzComputeResourceSku](https://learn.microsoft.com/en-us/powershell/module/az.compute/get-azcomputeresourcesku) can be used to find out available sizes for your subscription and region. 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VmssId
The Id of virtual machine scale set

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
Specifies the availability zone for the virtual machine. Although it takes in an array of zones, virtual machines do not support multiple availability zones.
The allowed value depends on the capabilities of the region. Allowed value will normally be 1, 2, or 3. More information on [Azure availability zones](https://learn.microsoft.com/en-us/azure/reliability/availability-zones-overview#availability-zones).

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String[]

### System.Collections.Hashtable

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS

[Update-AzVM](./Update-AzVM.md)

[Set-AzVMOperatingSystem](./Set-AzVMOperatingSystem.md)

[Set-AzVMSourceImage](./Set-AzVMSourceImage.md)

[Get-AzAvailabilitySet](./Get-AzAvailabilitySet.md)
