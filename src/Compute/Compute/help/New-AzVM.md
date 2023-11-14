---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 05E6155D-4F0E-406B-9312-77AD97EF66EE
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azvm
schema: 2.0.0
---

# New-AzVM

## SYNOPSIS
Creates a virtual machine.

## SYNTAX

### SimpleParameterSet (Default)
```
New-AzVM [[-ResourceGroupName] <String>] [[-Location] <String>] [-EdgeZone <String>] [[-Zone] <String[]>]
 [-PublicIpSku <String>] -Name <String> -Credential <PSCredential> [-NetworkInterfaceDeleteOption <String>]
 [-VirtualNetworkName <String>] [-AddressPrefix <String>] [-SubnetName <String>]
 [-SubnetAddressPrefix <String>] [-PublicIpAddressName <String>] [-DomainNameLabel <String>]
 [-AllocationMethod <String>] [-SecurityGroupName <String>] [-OpenPorts <Int32[]>] [-Image <String>]
 [-Size <String>] [-AvailabilitySetName <String>] [-SystemAssignedIdentity] [-UserAssignedIdentity <String>]
 [-AsJob] [-OSDiskDeleteOption <String>] [-DataDiskSizeInGb <Int32[]>] [-DataDiskDeleteOption <String>]
 [-EnableUltraSSD] [-ProximityPlacementGroupId <String>] [-HostId <String>] [-VmssId <String>]
 [-Priority <String>] [-EvictionPolicy <String>] [-MaxPrice <Double>] [-EncryptionAtHost]
 [-HostGroupId <String>] [-SshKeyName <String>] [-GenerateSshKey] [-CapacityReservationGroupId <String>]
 [-UserData <String>] [-ImageReferenceId <String>] [-PlatformFaultDomain <Int32>] [-HibernationEnabled]
 [-vCPUCountAvailable <Int32>] [-vCPUCountPerCore <Int32>] [-DiskControllerType <String>]
 [-SharedGalleryImageId <String>] [-SecurityType <String>] [-EnableVtpm <Boolean>]
 [-EnableSecureBoot <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DefaultParameterSet
```
New-AzVM [-ResourceGroupName] <String> [-Location] <String> [-EdgeZone <String>] [-VM] <PSVirtualMachine>
 [[-Zone] <String[]>] [-DisableBginfoExtension] [-Tag <Hashtable>] [-LicenseType <String>] [-AsJob]
 [-OSDiskDeleteOption <String>] [-DataDiskDeleteOption <String>] [-SshKeyName <String>] [-GenerateSshKey]
 [-vCPUCountAvailable <Int32>] [-vCPUCountPerCore <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DiskFileParameterSet
```
New-AzVM [[-ResourceGroupName] <String>] [[-Location] <String>] [-EdgeZone <String>] [-PublicIpSku <String>]
 -Name <String> [-NetworkInterfaceDeleteOption <String>] [-VirtualNetworkName <String>]
 [-AddressPrefix <String>] [-SubnetName <String>] [-SubnetAddressPrefix <String>]
 [-PublicIpAddressName <String>] [-DomainNameLabel <String>] [-AllocationMethod <String>]
 [-SecurityGroupName <String>] [-OpenPorts <Int32[]>] -DiskFile <String> [-Linux] [-Size <String>]
 [-AvailabilitySetName <String>] [-SystemAssignedIdentity] [-UserAssignedIdentity <String>] [-AsJob]
 [-OSDiskDeleteOption <String>] [-DataDiskSizeInGb <Int32[]>] [-DataDiskDeleteOption <String>]
 [-EnableUltraSSD] [-ProximityPlacementGroupId <String>] [-HostId <String>] [-VmssId <String>]
 [-Priority <String>] [-EvictionPolicy <String>] [-MaxPrice <Double>] [-EncryptionAtHost]
 [-HostGroupId <String>] [-CapacityReservationGroupId <String>] [-UserData <String>]
 [-PlatformFaultDomain <Int32>] [-HibernationEnabled] [-vCPUCountAvailable <Int32>] [-vCPUCountPerCore <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVM** cmdlet creates a virtual machine in Azure.
This cmdlet takes a virtual machine object as input. The **New-AzVM** cmdlet will create a new storage account for boot diagnostics if one does not already exist. <br> <br>
Use the **[New-AzVMConfig](https://learn.microsoft.com/en-us/powershell/module/az.compute/new-azvmconfig)** cmdlet to create a virtual machine object. <br> 
Then use the following cmdlets to set different properties of the virtual machine object:
- **[Add-AzVMNetworkInterface](https://learn.microsoft.com/en-us/powershell/module/az.compute/add-azvmnetworkinterface)** to set the network profile.<br>
- **[Set-AzVMOperatingSystem](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmoperatingsystem)** to set the OS profile. <br>
- **[Set-AzVMSourceImage](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmsourceimage)** to set the source image.<br>
- **[Set-AzVMOSDisk](https://learn.microsoft.com/en-us/powershell/module/az.compute/set-azvmosdisk)** to set the OS disk(storage profile).<br>
- **[Get-AzComputeResourceSku](https://learn.microsoft.com/en-us/powershell/module/az.compute/get-azcomputeresourcesku)** can also be used to find out available virtual machine sizes for your subscription and region.<br>
<br>
The `SimpleParameterSet` provides a convenient method to create a VM by making common VM creation arguments optional.<br>
<br>
See [Quickstart: Create a Windows virtual machine in Azure with PowerShell](https://learn.microsoft.com/en-us/azure/virtual-machines/windows/quick-create-powershell) for tutorial. <br>

## EXAMPLES

### Example 1: Create a virtual machine
```powershell
New-AzVM -Name MyVm -Credential (Get-Credential) -SecurityType "Standard"
```

```output
VERBOSE: Use 'mstsc /v:myvm-222222.eastus.cloudapp.azure.com' to connect to the VM.

ResourceGroupName        : MyVm
Id                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyVm/provi
ders/Microsoft.Compute/virtualMachines/MyVm
VmId                     : 11111111-1111-1111-1111-111111111111
Name                     : MyVm
Type                     : Microsoft.Compute/virtualMachines
Location                 : eastus
Tags                     : {}
HardwareProfile          : {VmSize}
NetworkProfile           : {NetworkInterfaces}
OSProfile                : {ComputerName, AdminUsername, WindowsConfiguration, Secrets}
ProvisioningState        : Succeeded
StorageProfile           : {ImageReference, OsDisk, DataDisks}
FullyQualifiedDomainName : myvm-222222.eastus.cloudapp.azure.com
```

This example script shows how to create a virtual machine.
The script will ask a user name and password for the VM.
This script uses several other cmdlets.

### Example 2: Create a virtual machine from a custom user image
```powershell
## VM Account
# Credentials for Local Admin account you created in the sysprepped (generalized) vhd image
$VMLocalAdminUser = "LocalAdminUser"
$VMLocalAdminSecurePassword = ConvertTo-SecureString "Password" -AsPlainText -Force
## Azure Account
$LocationName = "westus"
$ResourceGroupName = "MyResourceGroup"
# This a Premium_LRS storage account.
# It is required in order to run a client VM with efficiency and high performance.
$StorageAccount = "Mydisk"

## VM
$OSDiskName = "MyClient"
$ComputerName = "MyClientVM"
$OSDiskUri = "https://Mydisk.blob.core.windows.net/disks/MyOSDisk.vhd"
$SourceImageUri = "https://Mydisk.blob.core.windows.net/vhds/MyOSImage.vhd"
$VMName = "MyVM"
# Modern hardware environment with fast disk, high IOPs performance.
# Required to run a client VM with efficiency and performance
$VMSize = "Standard_DS3"
$OSDiskCaching = "ReadWrite"
$OSCreateOption = "FromImage"

## Networking
$DNSNameLabel = "mydnsname" # mydnsname.westus.cloudapp.azure.com
$NetworkName = "MyNet"
$NICName = "MyNIC"
$PublicIPAddressName = "MyPIP"
$SubnetName = "MySubnet"
$SubnetAddressPrefix = "10.0.0.0/24"
$VnetAddressPrefix = "10.0.0.0/16"

$SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix
$Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $ResourceGroupName -Location $LocationName -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet
$PIP = New-AzPublicIpAddress -Name $PublicIPAddressName -DomainNameLabel $DNSNameLabel -ResourceGroupName $ResourceGroupName -Location $LocationName -AllocationMethod Dynamic
$NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $ResourceGroupName -Location $LocationName -SubnetId $Vnet.Subnets[0].Id -PublicIpAddressId $PIP.Id

$Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);

$securityTypeStnd = "Standard"
$VirtualMachine = New-AzVMConfig -VMName $VMName -VMSize $VMSize -SecurityType $securityTypeStnd 
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate
$VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -Name $OSDiskName -VhdUri $OSDiskUri -SourceImageUri $SourceImageUri -Caching $OSDiskCaching -CreateOption $OSCreateOption -Windows

New-AzVM -ResourceGroupName $ResourceGroupName -Location $LocationName -VM $VirtualMachine -Verbose -Zone @("1")
```

This example takes an existing sys-prepped, generalized custom operating system image and attaches a data disk to it, provisions a new network, deploys the VHD, and runs it.
This script can be used for automatic provisioning because it uses the local virtual machine admin credentials inline instead of calling **Get-Credential** which requires user interaction.
This script assumes that you are already logged into your Azure account.
You can confirm your login status by using the **Get-AzSubscription** cmdlet.

### Example 3: Create a VM from a marketplace image without a Public IP
```powershell
$VMLocalAdminUser = "LocalAdminUser"
$VMLocalAdminSecurePassword = ConvertTo-SecureString "password" -AsPlainText -Force
$LocationName = "eastus2"
$ResourceGroupName = "MyResourceGroup"
$ComputerName = "MyVM"
$VMName = "MyVM"
$VMSize = "Standard_DS3"

$NetworkName = "MyNet"
$NICName = "MyNIC"
$SubnetName = "MySubnet"
$SubnetAddressPrefix = "10.0.0.0/24"
$VnetAddressPrefix = "10.0.0.0/16"

$SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix
$Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $ResourceGroupName -Location $LocationName -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet
$NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $ResourceGroupName -Location $LocationName -SubnetId $Vnet.Subnets[0].Id

$Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);

$securityTypeStnd = "Standard"
$VirtualMachine = New-AzVMConfig -VMName $VMName -VMSize $VMSize -SecurityType $securityTypeStnd
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate
$VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id
$VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName 'MicrosoftWindowsServer' -Offer 'WindowsServer' -Skus '2022-datacenter-azure-edition-core' -Version latest

New-AzVM -ResourceGroupName $ResourceGroupName -Location $LocationName -VM $VirtualMachine -Verbose
```

This command creates a VM from a marketplace image without a Public IP.

### Example 4: Create a VM with a UserData value:
```powershell
# VM Account
$VMLocalAdminUser = "LocalAdminUser";
$VMLocalAdminSecurePassword = ConvertTo-SecureString "Password" -AsPlainText -Force;

# Azure Account
$LocationName = "eastus";
$ResourceGroupName = "MyResourceGroup";

# VM Profile & Hardware
$securityTypeStnd = "Standard";
$VMName = 'v' + $ResourceGroupName;
$domainNameLabel = "d1" + $ResourceGroupName;
$Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);

# Create UserData value
$text = "text for UserData";
$bytes = [System.Text.Encoding]::Unicode.GetBytes($text);
$userData = [Convert]::ToBase64String($bytes);

# Create VM
New-AzVM -ResourceGroupName $ResourceGroupName -Name $VMName -Credential $Credential -DomainNameLabel $domainNameLabel -UserData $userData -SecurityType $securityTypeStnd;
$vm = Get-AzVM -ResourceGroupName $ResourceGroupName -Name $VMName -UserData;
```

The UserData value must always be Base64 encoded. 

### Example 5: Creating a new VM with an existing subnet in another resource group
```powershell
$UserName = "User"
$Password = ConvertTo-SecureString "############" -AsPlainText -Force
$psCred = New-Object System.Management.Automation.PSCredential($UserName, $Password)
$securityTypeStnd = "Standard";

$Vnet = $(Get-AzVirtualNetwork -ResourceGroupName ResourceGroup2 -Name VnetName)
$PIP = (Get-AzPublicIpAddress -ResourceGroupName ResourceGroup2 -Name PublicIPName)

$NIC = New-AzNetworkInterface -Name NICname -ResourceGroupName ResourceGroup2 -Location SouthCentralUS -SubnetId $Vnet.Subnets[1].Id -PublicIpAddressId $PIP.Id
$VirtualMachine = New-AzVMConfig -VMName VirtualMachineName -VMSize Standard_D4s_v3 -SecurityType $securityTypeStnd
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName computerName -Credential $psCred -ProvisionVMAgent -EnableAutoUpdate
$VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id
$VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName 'MicrosoftWindowsServer' -Offer 'WindowsServer' -Skus '2022-datacenter-azure-edition-core' -Version latest
New-AzVM -ResourceGroupName ResourceGroup1 -Location SouthCentralUS -VM $VirtualMachine
```

This example deploys a Windows VM from the marketplace in one resource group with an existing subnet in another resource group.

### Example 6: Creating a new VM as part of a VMSS with a PlatformFaultDomain value.
```powershell
$resourceGroupName= "ResourceGroupName";
$loc = 'eastus';
New-AzResourceGroup -Name $resourceGroupName -Location $loc -Force;
$securityTypeStnd = "Standard";

$domainNameLabel = "d1" + $resourceGroupName;
$vmname = "vm" + $resourceGroupName;
$platformFaultDomainVMDefaultSet = 2;
$vmssFaultDomain = 3;
$securePassword = <PASSWORD> | ConvertTo-SecureString -AsPlainText -Force;
$user = <USERNAME>;
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
$vmssName = "vmss" + $resourceGroupName;

$vmssConfig = New-AzVmssConfig -Location $loc -PlatformFaultDomainCount $vmssFaultDomain -SecurityType $securityTypeStnd;
$vmss = New-AzVmss -ResourceGroupName $resourceGroupName -Name $vmssName -VirtualMachineScaleSet $vmssConfig;

$vm = New-AzVM -ResourceGroupName $resourceGroupName -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -PlatformFaultDomain $platformFaultDomainVMDefaultSet -VmssId $vmss.Id;
```

This example creates a new VM as part of a VMSS with a PlatformFaultDomain value.

### Example 7: Create a VM using the -Image alias.
```powershell
$resourceGroupName= "<Resource Group Name>"
$loc = "<Azure Region>"
$domainNameLabel = "<Domain Name Label>"
$vmname = "<Virtual Machine Name>"
$securePassword = "<Password>" | ConvertTo-SecureString -AsPlainText -Force
$user = "<Username>"
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword)
$securityTypeStnd = "Standard"

New-AzResourceGroup -Name $resourceGroupName -Location $loc -Force

# Create a VM using an Image alias.
$vmname = 'v' + $resourceGroupName
$domainNameLabel = "d" + $resourceGroupName
$vm = New-AzVM -ResourceGroupName $resourceGroupName -Name $vmname -Credential $cred -Image OpenSuseLeap154Gen2 -DomainNameLabel $domainNameLabel -SecurityType $securityTypeStnd

$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmname
```

This example creates a new VM using the -Image parameter, providing many default values to the VM. 

### Example 8: Creating a VM for Trusted Launch SecurityType.
```powershell
$rgname = <Resource Group Name>;
$loc = "eastus";
 
New-AzResourceGroup -Name $rgname -Location $loc -Force;    
# VM Profile & Hardware       
$domainNameLabel1 = 'd1' + $rgname;
$vmsize = 'Standard_D4s_v3';
$vmname1 = 'v' + $rgname;
$imageName = "Win2016DataCenterGenSecond";
$disable = $false;
$enable = $true;
$securityType = "TrustedLaunch";

$password = <Password>;
$securePassword = $password | ConvertTo-SecureString -AsPlainText -Force;  
$user = <Username>;
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

# VM creation using Simple parameterset
New-AzVM -ResourceGroupName $rgname -Location $loc -Name $vmname1 -Credential $cred -Size $vmsize -Image $imageName -DomainNameLabel $domainNameLabel1 -SecurityType $securityType;
$vm1 = Get-AzVM -ResourceGroupName $rgname -Name $vmname1;

# Verify Values
#$vm1.SecurityProfile.SecurityType "TrustedLaunch";
#$vm1.SecurityProfile.UefiSettings.VTpmEnabled $true;
#$vm1.SecurityProfile.UefiSettings.SecureBootEnabled $true;

# Verify the GuestAttestation extension is installed.
$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname1;
$extDefaultName = "GuestAttestation";
$vmExt = Get-AzVMExtension -ResourceGroupName $rgname -VMName $vmname1 -Name $extDefaultName;
# verify $vmExt.Name is "GuestAttestation";
```

This example Creates a new VM with the TrustedLaunch Security Type and sets flags EnableSecureBoot and EnableVtpm as True by default. 
It also checks that the GuestAttestation extension is installed by default when using TrustedLaunch and the EnableSecureBoot and EnableVtpm are True.

## PARAMETERS

### -AddressPrefix
The address prefix for the virtual network which will be created for the VM.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: 192.168.0.0/16
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllocationMethod
The IP allocation method for the public IP which will be created for the VM.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:
Accepted values: Static, Dynamic

Required: False
Position: Named
Default value: Static
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background and return a Job to track progress.

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

### -AvailabilitySetName
Specifies a name for the availability set.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CapacityReservationGroupId
Id of the capacity reservation Group that is used to allocate.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
The administrator credentials for the VM. <br><br>
**Username** <br>
**Restriction:** <br>
Windows: Cannot contain special characters \/""[]:|<>+=;,?*@& or end in \".\" <br>
Linux: Username must only contain letters, numbers, hyphens, and underscores and may not start with a hyphen or number. <br>
**Disallowed values:** \"administrator\", \"admin\", \"user\", \"user1\", \"test\", \"user2\", \"test1\", \"user3\", \"admin1\", \"1\", \"123\", \"a\", \"actuser\", \"adm\", \"admin2\", \"aspnet\", \"backup\", \"console\", \"david\", \"guest\", \"john\", \"owner\", \"root\", \"server\", \"sql\", \"support\", \"support_388945a0\", \"sys\", \"test2\", \"test3\", \"user4\", \"user5\". <br>
**Minimum-length:** 1  character <br>
**Max-length:** 20 characters for Windows, 64 characters for Linux <br><br>
**Password** <br>
Must have 3 of the following: 1 lower case character, 1 upper case character, 1 number, and 1 special character. <br>
The value must be between 12 and 123 characters long.


```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: SimpleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataDiskDeleteOption
Specifies Data Disk delete option after VM deletion. Options are Detach, Delete

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

### -DataDiskSizeInGb
Specifies the sizes of data disks in GB.

```yaml
Type: System.Int32[]
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
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

### -DisableBginfoExtension
Indicates that this cmdlet does not install the **BG Info** extension on the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DefaultParameterSet
Aliases:

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
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskFile
The local path to the virtual hard disk file to be uploaded to the cloud and for creating the VM, and it must have '.vhd' as its suffix.

```yaml
Type: System.String
Parameter Sets: DiskFileParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainNameLabel
The subdomain label for the fully-qualified domain name (FQDN) of the VM.  This will take the form `{domainNameLabel}.{location}.cloudapp.azure.com`.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
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

### -EnableSecureBoot
Specifies whether secure boot should be enabled on the virtual machine.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableUltraSSD
Use UltraSSD disks for the vm.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableVtpm
Specifies whether vTPM should be enabled on the virtual machine.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: SimpleParameterSet
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
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
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
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GenerateSshKey
Generate a SSH Public/Private key pair and create a SSH Public Key resource on Azure.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SimpleParameterSet, DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HibernationEnabled
The flag that enables or disables hibernation capability on the VM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -HostGroupId
Specifies the dedicated host group the virtual machine will reside in.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
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
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image
The friendly image name upon which the VM will be built. The available aliases are: Win2022AzureEditionCore, Win2019Datacenter, Win2016Datacenter, Win2012R2Datacenter, Win2012Datacenter, Ubuntu2204, CentOS85Gen2, Debian11, OpenSuseLeap154Gen2, RHELRaw8LVMGen2, SuseSles15SP3, FlatcarLinuxFreeGen2.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet
Aliases: ImageName

Required: False
Position: Named
Default value: Win2016Datacenter
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageReferenceId
Specified the shared gallery image unique id for vm deployment. This can be fetched from shared gallery image GET call.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet
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
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Linux
Indicates whether the disk file is for Linux VM, if specified; or Windows, if not specified by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies a location for the virtual machine.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrice
The max price of the billing of a low priority virtual machine.

```yaml
Type: System.Double
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the VM resource.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterfaceDeleteOption
Specifies what action to perform on the NetworkInterface resource when the VM is deleted. Options are: Detach, Delete.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OpenPorts
A list of ports to open on the network security group (NSG) for the created VM.  The default value depends on the type of image chosen (i.e., Windows: 3389, 5985 and Linux: 22).

```yaml
Type: System.Int32[]
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskDeleteOption
Specifies OS Disk delete option after VM deletion. Options are Detach, Delete

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

### -PlatformFaultDomain
Specifies the fault domain of the virtual machine.

```yaml
Type: System.Int32
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
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
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProximityPlacementGroupId
The resource id of the Proximity Placement Group to use with this virtual machine.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases: ProximityPlacementGroup

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIpAddressName
The name of a new (or existing) public IP address for the created VM to use.  If not specified, a name will be generated.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIpSku
Specifies public IP sku name

Accepted values are "Basic" and "Standard"

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityGroupName
The name of a new (or existing) network security group (NSG) for the created VM to use.  If not specified, a name will be generated.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityType
Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. By default, UefiSettings will not be enabled unless this property is set.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet
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
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Size
The Virtual Machine Size. [Get-AzComputeResourceSku](https://learn.microsoft.com/en-us/powershell/module/az.compute/get-azcomputeresourcesku) can be used to find out available sizes for your subscription and region.<br>
The Default Value is: Standard_D2s_v3.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: Standard_D2s_v3
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshKeyName
Name of the SSH Public Key resource.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetAddressPrefix
The address prefix for the subnet which will be created for the VM.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: 192.168.1.0/24
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetName
The name of a new (or existing) subnet for the created VM to use.  If not specified, a name will be generated.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemAssignedIdentity
If the parameter is present then the VM is assigned a managed system identity that is auto generated.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Specifies that resources and resource groups can be tagged with a set of name-value pairs.
Adding tags to resources enables you to group resources together across resource groups and to create your own views.
Each resource or resource group can have a maximum of 15 tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserAssignedIdentity
The name of a managed service identity that should be assigned to the VM.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserData
UserData for the VM, which will be base-64 encoded. Customer should not pass any secrets in here.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
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

### -VirtualNetworkName
The name of a new (or existing) virtual network for the created VM to use.  If not specified, a name will be generated.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VM
Specifies a local virtual machine to create.
To obtain a virtual machine object, use the New-AzVMConfig cmdlet.
Other cmdlets can be used to configure the virtual machine, such as Set-AzVMOperatingSystem, Set-AzVMSourceImage, and Add-AzVMNetworkInterface.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: DefaultParameterSet
Aliases: VMProfile

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -VmssId
The ID of Virtual Machine Scale Set that this VM will be associated with

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet, DiskFileParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
Specifies the zone of the virtual machine. Although it takes in an array of zones, virtual machines do not support multiple availability zones.
The allowed value depends on the capabilities of the region. Allowed value will normally be 1, 2, or 3. More information on [Azure availability zones](https://learn.microsoft.com/en-us/azure/reliability/availability-zones-overview#availability-zones).

```yaml
Type: System.String[]
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String[]
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: 3
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### System.String[]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSAzureOperationResponse

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS

[Get-AzVM](./Get-AzVM.md)

[Remove-AzVM](./Remove-AzVM.md)

[Restart-AzVM](./Restart-AzVM.md)

[Start-AzVM](./Start-AzVM.md)

[Stop-AzVM](./Stop-AzVM.md)

[Update-AzVM](./Update-AzVM.md)

[Add-AzVMDataDisk](./Add-AzVMDataDisk.md)

[Add-AzVMNetworkInterface](./Add-AzVMNetworkInterface.md)

[New-AzVMConfig](./New-AzVMConfig.md)

[Set-AzVMOperatingSystem](./Set-AzVMOperatingSystem.md)

[Set-AzVMSourceImage](./Set-AzVMSourceImage.md)

[Set-AzVMOSDisk](./Set-AzVMOSDisk.md)


