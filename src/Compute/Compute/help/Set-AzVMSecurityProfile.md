---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azvmsecurityprofile
schema: 2.0.0
---

# Set-AzVMSecurityProfile

## SYNOPSIS
Sets the SecurityType enum for Virtual Machines.

## SYNTAX

```
Set-AzVMSecurityProfile [-VM] <PSVirtualMachine> [-SecurityType <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzVMSecurityProfile** cmdlet sets the Security Type of the VM

## EXAMPLES

### Example 1
```powershell
$VM = Get-AzVM -ResourceGroupName "ResourceGroup11" -VMName "ContosoVM07"
$VM = Set-AzVMSecurityProfile -VM $VM -SecurityType "TrustedLaunch"
```

The first command gets the virtual machine named ContosoVM07 by using **Get-AzVm**.
The command stores it in the $VM variable.
The second command sets the SecurityType enum to "TrustedLaunch". Trusted launch requires the creation of new virtual machines. You can't enable trusted launch on existing virtual machines that were initially created without it.

### Example 2: Create a ConfidentialVM Virtual Machine and the Disk encrypted with the VMGuestStateOnly type.
```powershell
$vmSize = "Standard_DC2as_v5";         
$DNSNameLabel = "cvm1" +$ResourceGroupName; 
$SubnetAddressPrefix = "10.0.0.0/24";
$VnetAddressPrefix = "10.0.0.0/16";

# Credential setup.
$securePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force;
$credential = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

$SecurityType = "ConfidentialVM";
$vmDiskSecurityEncryptionType = "VMGuestStateOnly";
$VirtualMachine = New-AzVMConfig -VMName $VMName -VMSize $VMSize;

# Create the Network resources and VM OS setup.
$SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix;
$Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $rgname -Location $LocationName -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet;
$PIP = New-AzPublicIpAddress -Name $PublicIPAddressName -DomainNameLabel $DNSNameLabel -ResourceGroupName $rgname -Location $LocationName -AllocationMethod Dynamic;
$NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $rgname -Location $LocationName -SubnetId $Vnet.Subnets[0].Id -PublicIpAddressId $PIP.Id;
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate;
$VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id;
$VirtualMachine = Set-AzVMSourceImage -VM $VirtualMachine -PublisherName 'MicrosoftWindowsServer' -Offer 'windowsserver' -Skus '2022-datacenter-smalldisk-g2' -Version 'latest';
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -StorageAccountType "StandardSSD_LRS" -CreateOption "FromImage";

# Set the SecurityType and necessary values on the Uefi settings. 
$VirtualMachine = Set-AzVMSecurityProfile -VM $VirtualMachine -SecurityType $SecurityType;
$VirtualMachine = Set-AzVMUefi -VM $VirtualMachine -EnableVtpm $true -EnableSecureBoot $true;

# Set the Disk Encryption Type. 
$VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -StorageAccountType "StandardSSD_LRS" -CreateOption "FromImage" -SecurityEncryptionType $vmDiskSEcurityEncryptionType;

$vm = New-AzVM -ResourceGroupName $rgname -Location $LocationName -VM $VirtualMachine;
$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
# Verify SecurityType value.
# $vm.SecurityProfile.SecurityType == "ConfidentialVM";
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -SecurityType
Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. By default, UefiSettings will not be enabled unless this property is set.

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

### -VM
The virtual machine profile.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases: VMProfile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### Microsoft.Azure.Management.Compute.Models.SecurityTypes

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
