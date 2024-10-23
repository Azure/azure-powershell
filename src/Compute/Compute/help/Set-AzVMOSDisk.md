---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 8F7AF1B8-D769-452C-92CF-4486C3EB894D
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azvmosdisk
schema: 2.0.0
---

# Set-AzVMOSDisk

## SYNOPSIS
Sets the operating system disk properties on a virtual machine.

## SYNTAX

### DefaultParamSet (Default)
```
Set-AzVMOSDisk [-VM] <PSVirtualMachine> [[-Name] <String>] [[-VhdUri] <String>] [[-Caching] <CachingTypes>]
 [[-SourceImageUri] <String>] [[-CreateOption] <String>] [-DiskSizeInGB <Int32>] [-ManagedDiskId <String>]
 [-StorageAccountType <String>] [-DiskEncryptionSetId <String>] [-WriteAccelerator] [-DiffDiskSetting <String>]
 [-DiffDiskPlacement <String>] [-DeleteOption <String>] [-SecurityEncryptionType <String>]
 [-SecureVMDiskEncryptionSet <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### WindowsParamSet
```
Set-AzVMOSDisk [-VM] <PSVirtualMachine> [[-Name] <String>] [[-VhdUri] <String>] [[-Caching] <CachingTypes>]
 [[-SourceImageUri] <String>] [[-CreateOption] <String>] [-Windows] [-DiskSizeInGB <Int32>]
 [-ManagedDiskId <String>] [-StorageAccountType <String>] [-DiskEncryptionSetId <String>] [-WriteAccelerator]
 [-DiffDiskSetting <String>] [-DiffDiskPlacement <String>] [-DeleteOption <String>]
 [-SecurityEncryptionType <String>] [-SecureVMDiskEncryptionSet <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### WindowsDiskEncryptionParameterSet
```
Set-AzVMOSDisk [-VM] <PSVirtualMachine> [[-Name] <String>] [[-VhdUri] <String>] [[-Caching] <CachingTypes>]
 [[-SourceImageUri] <String>] [[-CreateOption] <String>] [-Windows] [-DiskEncryptionKeyUrl] <String>
 [-DiskEncryptionKeyVaultId] <String> [[-KeyEncryptionKeyUrl] <String>] [[-KeyEncryptionKeyVaultId] <String>]
 [-DiskSizeInGB <Int32>] [-ManagedDiskId <String>] [-StorageAccountType <String>]
 [-DiskEncryptionSetId <String>] [-WriteAccelerator] [-DiffDiskSetting <String>] [-DiffDiskPlacement <String>]
 [-DeleteOption <String>] [-SecurityEncryptionType <String>] [-SecureVMDiskEncryptionSet <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### LinuxParamSet
```
Set-AzVMOSDisk [-VM] <PSVirtualMachine> [[-Name] <String>] [[-VhdUri] <String>] [[-Caching] <CachingTypes>]
 [[-SourceImageUri] <String>] [[-CreateOption] <String>] [-Linux] [-DiskSizeInGB <Int32>]
 [-ManagedDiskId <String>] [-StorageAccountType <String>] [-DiskEncryptionSetId <String>] [-WriteAccelerator]
 [-DiffDiskSetting <String>] [-DiffDiskPlacement <String>] [-DeleteOption <String>]
 [-SecurityEncryptionType <String>] [-SecureVMDiskEncryptionSet <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### LinuxDiskEncryptionParameterSet
```
Set-AzVMOSDisk [-VM] <PSVirtualMachine> [[-Name] <String>] [[-VhdUri] <String>] [[-Caching] <CachingTypes>]
 [[-SourceImageUri] <String>] [[-CreateOption] <String>] [-Linux] [-DiskEncryptionKeyUrl] <String>
 [-DiskEncryptionKeyVaultId] <String> [[-KeyEncryptionKeyUrl] <String>] [[-KeyEncryptionKeyVaultId] <String>]
 [-DiskSizeInGB <Int32>] [-ManagedDiskId <String>] [-StorageAccountType <String>]
 [-DiskEncryptionSetId <String>] [-WriteAccelerator] [-DiffDiskSetting <String>] [-DiffDiskPlacement <String>]
 [-DeleteOption <String>] [-SecurityEncryptionType <String>] [-SecureVMDiskEncryptionSet <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzVMOSDisk** cmdlet sets the operating system disk properties on a virtual machine.

## EXAMPLES

### Example 1: Set properties on a virtual machine from platform image
```powershell
$AvailabilitySet = Get-AzAvailabilitySet -ResourceGroupName "ResourceGroup11" -Name "AvailabilitySet13" 
$VirtualMachine = New-AzVMConfig -VMName "VirtualMachine17" -VMSize "Standard_A1" -AvailabilitySetID $AvailabilitySet.Id 
Set-AzVMOSDisk -VM $VirtualMachine -Name "OsDisk12" -VhdUri "os.vhd" -Caching ReadWrite
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Linux -ComputerName "MainComputer" -Credential (Get-Credential) 
$VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName "Canonical" -Offer "UbuntuServer" -Skus "15.10" -Version "latest"
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -Name "osDisk.vhd" -VhdUri "https://mystorageaccount.blob.core.windows.net/disks/" -CreateOption FromImage
New-AzVM -VM $VirtualMachine -ResourceGroupName "ResourceGroup11"
```

The first command gets the availability set named AvailabilitySet13 in the resource group named ResourceGroup11, and then stores that object in the $AvailabilitySet variable.
The second command creates a virtual machine object, and then stores it in the $VirtualMachine variable.
The command assigns a name and size to the virtual machine.
The virtual machine belongs to the availability set stored in $AvailabilitySet.
The final command sets the properties on the virtual machine in $VirtualMachine.

### Example 2: Sets properties on a virtual machine from generalized user image
```powershell
$AvailabilitySet = Get-AzAvailabilitySet -ResourceGroupName "ResourceGroup11" -Name "AvailabilitySet13" 
$VirtualMachine = New-AzVMConfig -VMName "VirtualMachine17" -VMSize "Standard_A1"
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Linux -ComputerName "MainComputer" -Credential (Get-Credential)
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -Name "osDisk.vhd" -SourceImageUri "https://mystorageaccount.blob.core.windows.net/vhds/myOSImage.vhd" -VhdUri "https://mystorageaccount.blob.core.windows.net/disks/" -CreateOption fromImage -Linux
New-AzVM -VM $VirtualMachine -ResourceGroupName "ResourceGroup11"
```

The first command gets the availability set named AvailabilitySet13 in the resource group named ResourceGroup11 and stores that object in the $AvailabilitySet variable.
The second command creates a virtual machine object and stores it in the $VirtualMachine variable.
The command assigns a name and size to the virtual machine.
The virtual machine belongs to the availability set stored in $AvailabilitySet.
The final command sets the properties on the virtual machine in $VirtualMachine.

### Example 3: Sets properties on a virtual machine from specialized user image
```powershell
$AvailabilitySet = Get-AzAvailabilitySet -ResourceGroupName "ResourceGroup11" -Name "AvailabilitySet13" 
$VirtualMachine = New-AzVMConfig -VMName "VirtualMachine17" -VMSize "Standard_A1"
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -Name "osDisk.vhd" -VhdUri "https://mystorageaccount.blob.core.windows.net/disks/" -CreateOption Attach -Linux
New-AzVM -VM $VirtualMachine -ResourceGroupName "ResourceGroup11"
```

The first command gets the availability set named AvailabilitySet13 in the resource group named ResourceGroup11 and stores that object in the $AvailabilitySet variable.
The second command creates a virtual machine object and stores it in the $VirtualMachine variable.
The command assigns a name and size to the virtual machine.
The virtual machine belongs to the availability set stored in $AvailabilitySet.
The final command sets the properties on the virtual machine in $VirtualMachine.

### Example 4: Set the disk encryption settings on a virtual machine operating system disk
```powershell
$VirtualMachine = New-AzVMConfig -VMName "VirtualMachine17" -VMSize "Standard_A1"
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -Name "OsDisk12" -VhdUri "os.vhd" -Caching ReadWrite -Windows -CreateOption "Attach" -DiskEncryptionKeyUrl "https://mytestvault.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bddaaaaaa" -DiskEncryptionKeyVaultId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.KeyVault/vaults/mytestvault"
New-AzVM -VM $VirtualMachine -ResourceGroupName " ResourceGroup11"
```

This example sets the disk encryption settings on a virtual machine operating system disk.

### Example 5: Create a ConfidentialVM virtual machine with VM OS Disk encryption of DiskWithVMGuestState, and Disk Encryption Set encryption of ConfidentialVmEncryptedWithCustomerKey.
```powershell
# Create Resource Group
$Location = 'northeurope';
New-AzResourceGroup -Name $ResourceGroupName -Location $Location;

$vmSize = "Standard_DC2as_v5";        
$identityType = "SystemAssigned";
$secureEncryptGuestState = "DiskWithVMGuestState";
$vmSecurityType = "ConfidentialVM";
$securePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force; 
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

# Create Key Vault
New-AzKeyVault -Name $keyVaultName -Location $Location -ResourceGroupName $ResourceGroupName -Sku Premium -EnablePurgeProtection -EnabledForDiskEncryption;

$cvmAgent = Get-AzADServicePrincipal -ApplicationId '00001111-aaaa-2222-bbbb-3333cccc4444';
Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ResourceGroupName $ResourceGroupName -ObjectId $cvmAgent.id -PermissionsToKeys get,release;

# Add Key vault Key
$KeyName = "keyname";
$KeySize = 3072;

Add-AzKeyVaultKey -VaultName $kvname -Name $KeyName -Size $KeySize -KeyOps wrapKey,unwrapKey -KeyType RSA -Destination HSM -Exportable -UseDefaultCVMPolicy;
        
# Capture Key Vault and Key details
$encryptionKeyVaultId = (Get-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $ResourceGroupName).ResourceId;
$encryptionKeyURL = (Get-AzKeyVaultKey -VaultName $keyVaultName -KeyName $keyName).Key.Kid;

# Create new DES Config and Disk Encryption Set
$diskEncryptionType = "ConfidentialVmEncryptedWithCustomerKey";
$desConfig = New-AzDiskEncryptionSetConfig -Location $loc -SourceVaultId $encryptionKeyVaultId -KeyUrl $encryptionKeyURL -IdentityType SystemAssigned -EncryptionType $diskEncryptionType;
New-AzDiskEncryptionSet -ResourceGroupName $ResourceGroupName -Name $desName -DiskEncryptionSet $desConfig;
        
$diskencset = Get-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $desName;
        
# Assign DES Access Policy to key vault
$desIdentity = (Get-AzDiskEncryptionSet -Name $desName -ResourceGroupName $ResourceGroupName).Identity.PrincipalId;
        
Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ResourceGroupName $ResourceGroupName -ObjectId $desIdentity -PermissionsToKeys wrapKey,unwrapKey,get -BypassObjectIdValidation;
        
$VirtualMachine = New-AzVMConfig -VMName $VMName -VMSize $vmSize;
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent -EnableAutoUpdate;
$VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName 'MicrosoftWindowsServer' -Offer 'windowsserver' -Skus '2022-datacenter-smalldisk-g2' -Version "latest";
        
$subnet = New-AzVirtualNetworkSubnetConfig -Name ($subnetPrefix + $ResourceGroupName) -AddressPrefix "10.0.0.0/24";
$vnet = New-AzVirtualNetwork -Force -Name ($vnetPrefix + $ResourceGroupName) -ResourceGroupName $ResourceGroupName -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
$vnet = Get-AzVirtualNetwork -Name ($vnetPrefix + $ResourceGroupName) -ResourceGroupName $ResourceGroupName;
$subnetId = $vnet.Subnets[0].Id;
$pubip = New-AzPublicIpAddress -Force -Name ($pubIpPrefix + $ResourceGroupName) -ResourceGroupName $ResourceGroupName -Location $loc -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2;
$pubip = Get-AzPublicIpAddress -Name ($pubIpPrefix + $ResourceGroupName) -ResourceGroupName $ResourceGroupName;
$pubipId = $pubip.Id;
$nic = New-AzNetworkInterface -Force -Name ($nicPrefix + $ResourceGroupName) -ResourceGroupName $ResourceGroupName -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
$nic = Get-AzNetworkInterface -Name ($nicPrefix + $ResourceGroupName) -ResourceGroupName $ResourceGroupName;
$nicId = $nic.Id;

$VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $nicId;

# Set VM SecurityType and connect to DES
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -StorageAccountType "StandardSSD_LRS" -CreateOption "FromImage" -SecurityEncryptionType $secureEncryptGuestState -SecureVMDiskEncryptionSet $diskencset.Id;
$VirtualMachine = Set-AzVmSecurityProfile -VM $VirtualMachine -SecurityType $vmSecurityType;
$VirtualMachine = Set-AzVmUefi -VM $VirtualMachine -EnableVtpm $true -EnableSecureBoot $true;

New-AzVM -ResourceGroupName $ResourceGroupName -Location $loc -Vm $VirtualMachine;
$vm = Get-AzVm -ResourceGroupName $ResourceGroupName -Name $vmname;

# Verify the SecurityEncryptionType value on the disk.
# $vm.StorageProfile.OsDisk.ManagedDisk.SecurityProfile.SecurityEncryptionType == 'DiskWithVMGuestState';
```

## PARAMETERS

### -Caching
Specifies the caching mode of the operating system disk.
Valid values are: 
- ReadOnly
- ReadWrite
The default value is ReadWrite.
Changing the caching value causes the virtual machine to restart.
This setting affects the performance of the disk.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Management.Compute.Models.CachingTypes]
Parameter Sets: (All)
Aliases:
Accepted values: None, ReadOnly, ReadWrite

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateOption
Specifies whether this cmdlet creates a disk in the virtual machine from a platform or user image, or attaches an existing disk.
Valid values are: 
- Attach.
Specify this option to create a virtual machine from a specialized disk.
When you specify this option, do not specify the *SourceImageUri* parameter.
Instead, use the Set-AzVMSourceImage cmdlet.
You must also use the use the *Windows* or *Linux* parameters to tell the azure platform the type of the operating system on the VHD.
The *VhdUri* parameter is enough to tell the azure platform the location of the disk to attach. 
- FromImage.
Specify this option to create a virtual machine from a platform image or a generalized user image.
In the case of a generalized user image, you also need to specify the *SourceImageUri* parameter and either the *Windows* or *Linux* parameters to tell the Azure platform the location and type of the operating system disk VHD instead of using the **Set-AzVMSourceImage** cmdlet.
In the case of a platform image, the *VhdUri* parameter is sufficient. 
- Empty.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
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

### -DeleteOption
Specifies OS Disk delete option after VM deletion. Options are Detach, Delete

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

### -DiffDiskPlacement
Specifies the ephemeral disk placement for operating system disk. This property can be used by user in the request to choose the location i.e. cache disk or resource disk space for Ephemeral OS disk provisioning. For more information on Ephemeral OS disk size requirements, please refer Ephemeral OS disk size requirements for Windows VM at https://learn.microsoft.com/azure/virtual-machines/windows/ephemeral-os-disks#size-requirements and Linux VM at https://learn.microsoft.com/azure/virtual-machines/linux/ephemeral-os-disks#size-requirements. This parameter can only be used if the parameter DiffDiskSetting is set to 'Local'.

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

### -DiffDiskSetting
Specifies the differencing disk settings for operating system disk.

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

### -DiskEncryptionKeyUrl
Specifies the location of the disk encryption key.

```yaml
Type: System.String
Parameter Sets: WindowsDiskEncryptionParameterSet, LinuxDiskEncryptionParameterSet
Aliases:

Required: True
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskEncryptionKeyVaultId
Specifies the resource ID of the Key Vault containing the disk encryption key.

```yaml
Type: System.String
Parameter Sets: WindowsDiskEncryptionParameterSet, LinuxDiskEncryptionParameterSet
Aliases:

Required: True
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskEncryptionSetId
Specifies the resource Id of customer managed disk encryption set.  This can only be specified for managed disk.

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

### -DiskSizeInGB
Specifies the size, in GB, of the operating system disk.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionKeyUrl
Specifies the location of the key encryption key.

```yaml
Type: System.String
Parameter Sets: WindowsDiskEncryptionParameterSet, LinuxDiskEncryptionParameterSet
Aliases:

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionKeyVaultId
Specifies the resource ID of the Key Vault containing the key encryption key.

```yaml
Type: System.String
Parameter Sets: WindowsDiskEncryptionParameterSet, LinuxDiskEncryptionParameterSet
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Linux
Indicates that the operating system on the user image is Linux.
Specify this parameter for user image based virtual machine deployment.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: LinuxParamSet, LinuxDiskEncryptionParameterSet
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedDiskId
Specifies the ID of a managed disk.

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
Specifies the name of the operating system disk.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: OSDiskName, DiskName

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureVMDiskEncryptionSet
ARM Resource ID for Disk Encryption Set. Allows customer to provide ARM ID for Disk Encryption Set created with ConfidentialVmEncryptedWithCustomerKey encryption type. This will allow customer to use Customer Managed Key (CMK) encryption with Confidential VM. Parameter SecurityEncryptionType value should be DiskwithVMGuestState.

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

### -SecurityEncryptionType
Sets the SecurityEncryptionType value on the managed disk of the VM. possible values include: TrustedLaunch, ConfidentialVM_DiskEncryptedWithCustomerKey, ConfidentialVM_VMGuestStateOnlyEncryptedWithPlatformKey, ConfidentialVM_DiskEncryptedWithPlatformKey

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

### -SourceImageUri
Specifies the URI of the VHD for user image scenarios.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SourceImage

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountType
Specifies the storage account type of managed disk.

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

### -VhdUri
Specifies the Uniform Resource Identifier (URI) of a virtual hard disk (VHD).
For an image based virtual machine, this parameter specifies the VHD file to create when a platform image or user image is specified.
This is the location from which the image binary large object (BLOB) is copied to start the virtual machine.
For a disk based virtual machine boot scenario, this parameter specifies the VHD file that the virtual machine uses directly for starting up.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: OSDiskVhdUri, DiskVhdUri

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VM
Specifies the local virtual machine object on which to set operating system disk properties.
To obtain a virtual machine object, use the Get-AzVM cmdlet.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases: VMProfile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Windows
Indicates that the operating system on the user image is Windows.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: WindowsParamSet, WindowsDiskEncryptionParameterSet
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WriteAccelerator
Specifies whether WriteAccelerator should be enabled or disabled on the OS disk.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS

[Get-AzVM](./Get-AzVM.md)

[Get-AzAvailabilitySet](./Get-AzAvailabilitySet.md)

[New-AzVMConfig](./New-AzVMConfig.md)
