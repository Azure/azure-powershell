---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 39AADD19-2EDD-4C1F-BC9E-22186DD9A085
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azvmoperatingsystem
schema: 2.0.0
---

# Set-AzVMOperatingSystem

## SYNOPSIS
Sets operating system properties during the creation of a new virtual machine or updating a virtual machine.

## SYNTAX

### Windows (Default)
```
Set-AzVMOperatingSystem [-VM] <PSVirtualMachine> [-Windows] [[-ComputerName] <String>]
 [[-Credential] <PSCredential>] [[-CustomData] <String>] [-ProvisionVMAgent] [-EnableAutoUpdate]
 [[-TimeZone] <String>] [-WinRMHttp] [-PatchMode <String>] [-EnableHotpatching] [-AssessmentMode <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### WindowsWinRmHttps
```
Set-AzVMOperatingSystem [-VM] <PSVirtualMachine> [-Windows] [[-ComputerName] <String>]
 [[-Credential] <PSCredential>] [[-CustomData] <String>] [-ProvisionVMAgent] [-EnableAutoUpdate]
 [[-TimeZone] <String>] [-WinRMHttp] [-WinRMHttps] [-WinRMCertificateUrl] <Uri> [-PatchMode <String>]
 [-EnableHotpatching] [-AssessmentMode <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### WindowsDisableVMAgent
```
Set-AzVMOperatingSystem [-VM] <PSVirtualMachine> [-Windows] [[-ComputerName] <String>]
 [[-Credential] <PSCredential>] [[-CustomData] <String>] [-DisableVMAgent] [-EnableAutoUpdate]
 [[-TimeZone] <String>] [-WinRMHttp] [-PatchMode <String>] [-EnableHotpatching] [-AssessmentMode <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### WindowsDisableVMAgentWinRmHttps
```
Set-AzVMOperatingSystem [-VM] <PSVirtualMachine> [-Windows] [[-ComputerName] <String>]
 [[-Credential] <PSCredential>] [[-CustomData] <String>] [-DisableVMAgent] [-EnableAutoUpdate]
 [[-TimeZone] <String>] [-WinRMHttp] [-WinRMHttps] [-WinRMCertificateUrl] <Uri> [-PatchMode <String>]
 [-EnableHotpatching] [-AssessmentMode <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### Linux
```
Set-AzVMOperatingSystem [-VM] <PSVirtualMachine> [-Linux] [[-ComputerName] <String>]
 [[-Credential] <PSCredential>] [[-CustomData] <String>] [-PatchMode <String>] [-DisablePasswordAuthentication]
 [-AssessmentMode <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzVMOperatingSystem** cmdlet sets operating system properties during the creation of a new virtual machine.
You can specify logon credentials, computer name, and operating system type.

## EXAMPLES

### Example 1: Set operating system properties for a new virtual machine
```powershell
$SecurePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force
$Credential = New-Object System.Management.Automation.PSCredential ("FullerP", $SecurePassword); 
$AvailabilitySet = Get-AzAvailabilitySet -ResourceGroupName "ResourceGroup11" -Name "AvailabilitySet03" 
$VirtualMachine = New-AzVMConfig -VMName "VirtualMachine07" -VMSize "Standard_A1" -AvailabilitySetID $AvailabilitySet.Id
$ComputerName = "ContosoVM122"
$WinRMCertUrl = "http://keyVaultName.vault.azure.net/secrets/secretName/secretVersion"
$TimeZone = "Pacific Standard Time"
$CustomData = "echo 'Hello World'"
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -CustomData $CustomData -WinRMHttp -WinRMHttps -WinRMCertificateUrl $WinRMCertUrl -ProvisionVMAgent -EnableAutoUpdate -TimeZone $TimeZone -PatchMode "AutomaticByPlatform"
```

The first command converts a password to a secure string, and then stores it in the $SecurePassword variable.
For more information, type `Get-Help ConvertTo-SecureString`.
The second command creates a credential for the user FullerP and the password stored in $SecurePassword, and then stores the credential in the $Credential variable.
For more information, type `Get-Help New-Object`.
The third command gets the availability set named AvailabilitySet03 in the resource group named ResourceGroup11, and then stores that object in the $AvailabilitySet variable.
The fourth command creates a virtual machine object, and then stores it in the $VirtualMachine variable.
The command assigns a name and size to the virtual machine.
The virtual machine belongs to the availability set stored in $AvailabilitySet.
The next four commands assign values to variables to use in the following command.
Because you could specify these strings directly in the **Set-AzVMOperatingSystem** command, this approach is used only for readability.
However, you might use an approach such as this in scripts.
The final command sets operating system properties for the virtual machine stored in $VirtualMachine.
The command uses the credentials stored in $Credential.
The command uses variables assigned in previous commands for some parameters.

### Example 2: Set operating system properties for a new virtual machine with hot patching enabled
```powershell
$SecurePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force
$Credential = New-Object System.Management.Automation.PSCredential ("FullerP", $SecurePassword); 
$AvailabilitySet = Get-AzAvailabilitySet -ResourceGroupName "ResourceGroup11" -Name "AvailabilitySet03" 
$VirtualMachine = New-AzVMConfig -VMName "VirtualMachine07" -VMSize "Standard_A1" -AvailabilitySetID $AvailabilitySet.Id
$ComputerName = "ContosoVM122"
$WinRMCertUrl = "http://keyVaultName.vault.azure.net/secrets/secretName/secretVersion"
$TimeZone = "Pacific Standard Time"
$CustomData = "echo 'Hello World'"
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -CustomData $CustomData -WinRMHttp -WinRMHttps -WinRMCertificateUrl $WinRMCertUrl -ProvisionVMAgent -EnableAutoUpdate -TimeZone $TimeZone -PatchMode "AutomaticByPlatform" -EnableHotPatching
```

The first command converts a password to a secure string, and then stores it in the $SecurePassword variable.
For more information, type `Get-Help ConvertTo-SecureString`.
The second command creates a credential for the user FullerP and the password stored in $SecurePassword, and then stores the credential in the $Credential variable.
For more information, type `Get-Help New-Object`.
The third command gets the availability set named AvailabilitySet03 in the resource group named ResourceGroup11, and then stores that object in the $AvailabilitySet variable.
The fourth command creates a virtual machine object, and then stores it in the $VirtualMachine variable.
The command assigns a name and size to the virtual machine.
The virtual machine belongs to the availability set stored in $AvailabilitySet.
The next four commands assign values to variables to use in the following command.
Because you could specify these strings directly in the **Set-AzVMOperatingSystem** command, this approach is used only for readability.
However, you might use an approach such as this in scripts.
The final command sets operating system properties for the virtual machine stored in $VirtualMachine.
The command uses the credentials stored in $Credential.
The command uses variables assigned in previous commands for some parameters.
The command enables Hotpatching on the virtual machine.

### Example 3: Set operating system properties for a new Linux virtual machine
```powershell
$SecurePassword = ConvertTo-SecureString -String "****" -AsPlainText -Force
$Credential = New-Object System.Management.Automation.PSCredential ("FullerP", $SecurePassword); 
$AvailabilitySet = Get-AzAvailabilitySet -ResourceGroupName "ResourceGroup11" -Name "AvailabilitySet03" 
$VirtualMachine = New-AzVMConfig -VMName "VirtualMachine07" -VMSize "Standard_A1" -AvailabilitySetID $AvailabilitySet.Id
$ComputerName = "ContosoVM122"
$CustomData = "echo 'Hello World'"
$VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Linux -ComputerName $ComputerName -Credential $Credential -CustomData $CustomData -PatchMode "AutomaticByPlatform"
```

The first command converts a password to a secure string, and then stores it in the $SecurePassword variable.
For more information, type `Get-Help ConvertTo-SecureString`.
The second command creates a credential for the user FullerP and the password stored in $SecurePassword, and then stores the credential in the $Credential variable.
For more information, type `Get-Help New-Object`.
The third command gets the availability set named AvailabilitySet03 in the resource group named ResourceGroup11, and then stores that object in the $AvailabilitySet variable.
The fourth command creates a virtual machine object, and then stores it in the $VirtualMachine variable.
The command assigns a name and size to the virtual machine.
The virtual machine belongs to the availability set stored in $AvailabilitySet.
The next two commands assign values to variables to use in the following command.
The final command sets operating system properties for the virtual machine stored in $VirtualMachine.
The command uses the credentials stored in $Credential.
The command uses variables assigned in previous commands for some parameters.
The command sets the patch mode value on the virtual machine to "AutomaticByPlatform".

### Example 4: Set operating system properties with a Credential parameter when the VM does not have an OSProfile.
```powershell
$rgname = <Resource Group Name>;
$loc = <Azure Region>;
New-AzResourceGroup -Name $rgname -Location $loc -Force;
# create credential
$password = <Password>;
$securePassword = $password | ConvertTo-SecureString -AsPlainText -Force;
$user = <Username>;
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

# Setup parameters
$domainNameLabel = "d2" + $rgname;
$vmsize = 'Standard_D4s_v3';
$vmname = 'v' + $rgname;
$vnetname = "vn" + $rgname;
$vnetAddress = "10.0.0.0/16";
$subnetname = "slb" + $rgname;
$subnetAddress = "10.0.2.0/24";
$OSDiskName = $vmname + "d";
$NICName = $vmname+ "n";
$NSGName = $vmname + "nsg";

# Creating a VM using Default parameterset
$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetname -AddressPrefix $subnetAddress;

$vnet = New-AzVirtualNetwork -Name $vnetname -ResourceGroupName $rgname -Location $loc -AddressPrefix $vnetAddress -Subnet $frontendSubnet;

$nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name RDP  -Protocol Tcp  -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389 -Access Allow;
$nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgname -Location $loc -Name $NSGName  -SecurityRules $nsgRuleRDP;
$nic = New-AzNetworkInterface -Name $NICName -ResourceGroupName $rgname -Location $loc -SubnetId $vnet.Subnets[0].Id -NetworkSecurityGroupId $nsg.Id -EnableAcceleratedNetworking;

$vmConfig = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
$vmConfig = Set-AzVMOperatingSystem -VM $vmConfig -Windows -ComputerName $vmname -Credential $cred;
$vmConfig = Add-AzVMNetworkInterface -VM $vmConfig -Id $nic.Id;

# Verify a VM is created. 
New-AzVM -ResourceGroupName $rgname -Location $loc -VM $vmConfig;
$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname;
```

## PARAMETERS

### -AssessmentMode
Automatic assessment mode value for the virtual machine. Possible values are ImageDefault and AutomaticByPlatform.

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

### -ComputerName
Specifies the name of the computer.

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

### -Credential
Specifies the user name and password for the virtual machine as a **PSCredential** object.
To obtain a credential, use the Get-Credential cmdlet.
For more information, type `Get-Help Get-Credential`.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CustomData
Specifies a string to be passed to the virtual machine. For more information see [Custom Data on Azure VMs](https://learn.microsoft.com/azure/virtual-machines/custom-data).
**Note: It is not recommended to store sensitive information in custom data.**


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

### -DisablePasswordAuthentication
Indicates that this cmdlet disables password authentication.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Linux
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisableVMAgent
Disable Provision VM Agent.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: WindowsDisableVMAgent, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAutoUpdate
Indicates that this cmdlet enables auto update.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Windows, WindowsWinRmHttps, WindowsDisableVMAgent, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableHotpatching
Enables customers to patch their Azure VMs without requiring a reboot. For enableHotpatching, the 'provisionVMAgent' must be set to true and 'patchMode' must be set to 'AutomaticByPlatform'.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Windows, WindowsWinRmHttps, WindowsDisableVMAgent, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Linux
Indicates that the type of operating system is Linux.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Linux
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PatchMode
Specifies the mode of in-guest patching to IaaS virtual machine.<br><br>
Possible values are:<br>
**AutomaticByPlatform** - Patch installation for the virtual machine will be managed by Azure. Use with -Windows or -Linux. Requires -ProvisionVMAgent. Requires -EnableAutoUpdate when used with -Windows. <br>
**AutomaticByOS** - Patch installation for the virtual machine will be managed by the OS. Use with -Windows. Requires -ProvisionVMAgent and -EnableAutoUpdate.<br>
**Manual** - You control the application of patches to a virtual machine. Use with -Windows. Requires -ProvisionVMAgent.<br>
**ImageDefault** - Patch installation managed by the default settings on the OS image. Use with -Linux.

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

### -ProvisionVMAgent
Indicates that the settings require that the virtual machine agent be installed on the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Windows, WindowsWinRmHttps
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TimeZone
Specifies the time zone of the virtual machine. e.g. \"Pacific Standard Time\". <br>
Possible values can be [TimeZoneInfo.Id](https://learn.microsoft.com/dotnet/api/system.timezoneinfo.id?#System_TimeZoneInfo_Id) value from time zones returned by [TimeZoneInfo.GetSystemTimeZones](https://learn.microsoft.com/dotnet/api/system.timezoneinfo.getsystemtimezones).

```yaml
Type: System.String
Parameter Sets: Windows, WindowsWinRmHttps, WindowsDisableVMAgent, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VM
Specifies the local virtual machine object on which to set operating system properties.
To obtain a virtual machine object, use the Get-AzVM cmdlet.
Create a virtual machine object by using the New-AzVMConfig cmdlet.

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

### -Windows
Indicates that the type of operating system is Windows.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Windows, WindowsWinRmHttps, WindowsDisableVMAgent, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WinRMCertificateUrl
Specifies the URI of a WinRM certificate.
This needs to be stored in a Key Vault.

```yaml
Type: System.Uri
Parameter Sets: WindowsWinRmHttps, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: True
Position: 10
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WinRMHttp
Indicates that this operating system uses HTTP WinRM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Windows, WindowsWinRmHttps, WindowsDisableVMAgent, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WinRMHttps
Indicates that this operating system uses HTTPS WinRM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: WindowsWinRmHttps, WindowsDisableVMAgentWinRmHttps
Aliases:

Required: True
Position: 9
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### System.Management.Automation.SwitchParameter

### System.String

### System.Management.Automation.PSCredential

### System.Uri

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS

[Get-AzVM](./Get-AzVM.md)

[New-AzVMConfig](./New-AzVMConfig.md)
