---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.ConnectedNetwork/new-AzConnectedNetworkFunctionRoleConfigurationObject
schema: 2.0.0
---

# New-AzConnectedNetworkFunctionRoleConfigurationObject

## SYNOPSIS
Create a in-memory object for NetworkFunctionRoleConfiguration

## SYNTAX

```
New-AzConnectedNetworkFunctionRoleConfigurationObject [-CustomProfileMetadataConfigurationPath <String>]
 [-ImageReferenceExactVersion <String>] [-ImageReferenceOffer <String>] [-ImageReferencePublisher <String>]
 [-ImageReferenceSku <String>] [-ImageReferenceVersion <String>] [-NetworkInterface <INetworkInterface[]>]
 [-OSDiskName <String>] [-OSDiskOstype <OperatingSystemTypes>] [-OSDiskSizeGb <Int32>]
 [-OSProfileAdminUsername <String>] [-OSProfileCustomData <String>] [-OSProfileCustomDataRequired <Boolean>]
 [-RoleName <String>] [-RoleType <NetworkFunctionRoleConfigurationType>] [-SshPublicKey <ISshPublicKey[]>]
 [-StorageProfileDataDisk <IDataDisk[]>] [-UserDataParameter <IAny>] [-UserDataTemplate <IAny>]
 [-VhdUri <String>] [-VirtualMachineSize <VirtualMachineSizeTypes>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for NetworkFunctionRoleConfiguration

## EXAMPLES

### Example 1: New-AzConnectedNetworkFunctionUserConfigurationObject
```powershell
$ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
$ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
$keyData = @{keyData = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCyMpVbBgu0kftv1k+z1c3NtcB5CVDoo/X9X1LE2JUjlLlo0luEkFGJk61i53BhiTSTeRmQXN8hAZ7sn4MDUmZK7fWcHouZ2fsJo+ehses3wQPLubWBFw2L/hoSTyXifXMbEBu9SxHgqf1CEKQcvdNiWf4U7npXwjweXW9DtsF5E7h4kxhKJKFI4sNFTIX0IwUB15QEVHoBs92kDwH3fBH3kZZCMBJE/u6kT+XB22crRKkIGlp3a9gcogtOCvP+3xmsP7hjw5+nHxMUwkc/6kYyfTeLwvfI4xrTWpnB5xufts5LW5/U5GOXVg97ix9EXgiV0czThowG5K2xQ649UlJb"; path = $Null}
$key = @( $keyData)
$role = New-AzConnectedNetworkFunctionRoleConfigurationObject -NetworkInterface $ip1,$ip2 -OSDiskName Disk1 -OSDiskOstype Linux -OSDiskSizeGb 40 -OSProfileCustomDataRequired $False -OSProfileAdminUsername MecUser -RoleName hpehss -RoleType VirtualMachine -VirtualMachineSize "Standard_D3_v2" -SshPublicKey $key -StorageProfileDataDisk $storage -VhdUri "https://mecvdrvhd.blob.core.windows/myvhd.vhd"
```

```output
RoleName RoleType       VirtualMachineSize
-------- --------       ------------------
hpehss   VirtualMachine Standard_D3_v2

```

Creating 2 ip configuration objects (ipconf1 and ipconf2) with dynamic allocation method and IPv4.
Using these to create network interface objects with ipconfiguration $ipconf1 and $ipconf2, interface name as mrmmanagementnic1 and mrmlannic1 and switch type as management and lan, respectively.
Storing the os profile key Data in key array.
And creating network function user configuration object from the network interface objects, key data and role name hpehss.

## PARAMETERS

### -CustomProfileMetadataConfigurationPath
Path for metadata configuration.

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

### -ImageReferenceExactVersion
Specifies in decimal numbers, the exact version of image used to create the virtual machine.

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

### -ImageReferenceOffer
Specifies the offer of the image used to create the virtual machine.

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

### -ImageReferencePublisher
The image publisher.

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

### -ImageReferenceSku
The image SKU.

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

### -ImageReferenceVersion
Specifies the version of the image used to create the virtual machine.
The allowed formats are Major.Minor.Build or 'latest'.
Major, Minor, and Build are decimal numbers.
Specify 'latest' to use the latest version of an image available at deploy time.
Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available.

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

### -NetworkInterface
The network interface configurations.
To construct, see NOTES section for NETWORKINTERFACE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkInterface[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskName
The VHD name.

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

### -OSDiskOstype
The OS type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.OperatingSystemTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskSizeGb
Specifies the size of os disk in gigabytes.
This is the fully expanded disk size needed of the VHD image on the ASE.
This disk size should be greater than the size of the VHD provided in vhdUri.

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

### -OSProfileAdminUsername
Specifies the name of the administrator account.


 **Windows-only restriction:** Cannot end in "." 

 **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5".


 **Minimum-length (Linux):** 1  character 

 **Max-length (Linux):** 64 characters 

 **Max-length (Windows):** 20 characters  

\<li\> For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privileges?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
\<li\> For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernames?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).

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

### -OSProfileCustomData
Specifies a base-64 encoded string of custom data.
The base-64 encoded string is decoded to a binary array that is saved as a file on the virtual machine.
The maximum length of the binary array is 65535 bytes.


 **Note: Do not pass any secrets or passwords in customData property** 

 This property cannot be updated after the VM is created.


 customData is passed to the VM to be saved as a file.
For more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/) 

 For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).

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

### -OSProfileCustomDataRequired
Indicates if custom data is required to deploy this role.

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

### -RoleName
The name of the network function role.

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

### -RoleType
Role type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.NetworkFunctionRoleConfigurationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshPublicKey
The list of SSH public keys used to authenticate with linux based VMs.
To construct, see NOTES section for SSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.ISshPublicKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileDataDisk
Specifies the parameters that are used to add a data disk to a virtual machine.
To construct, see NOTES section for STORAGEPROFILEDATADISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IDataDisk[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDataParameter
The user parameters for customers.
The format of user data parameters has to be matched with the provided user data template.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDataTemplate
The user data template for customers.
This is a json schema template describing the format and data type of user data parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VhdUri
Specifies the virtual hard disk's uri.

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

### -VirtualMachineSize
The size of the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.VirtualMachineSizeTypes
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.NetworkFunctionRoleConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


NETWORKINTERFACE <INetworkInterface[]>: The network interface configurations.
  - `[IPConfiguration <INetworkInterfaceIPConfiguration[]>]`: A list of IP configurations of the network interface.
    - `[DnsServer <String[]>]`: The list of DNS servers IP addresses.
    - `[Gateway <String>]`: The value of the gateway.
    - `[IPAddress <String>]`: The value of the IP address.
    - `[IPAllocationMethod <IPAllocationMethod?>]`: IP address allocation method.
    - `[IPVersion <IPVersion?>]`: IP address version.
    - `[Subnet <String>]`: The value of the subnet.
  - `[MacAddress <String>]`: The MAC address of the network interface.
  - `[Name <String>]`: The name of the network interface.
  - `[VMSwitchType <VMSwitchType?>]`: The type of the VM switch.

SSHPUBLICKEY <ISshPublicKey[]>: The list of SSH public keys used to authenticate with linux based VMs.
  - `[KeyData <String>]`: SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  - `[Path <String>]`: Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys

STORAGEPROFILEDATADISK <IDataDisk[]>: Specifies the parameters that are used to add a data disk to a virtual machine.
  - `[CreateOption <DiskCreateOptionTypes?>]`: Specifies how the virtual machine should be created.
  - `[DiskSizeGb <Int32?>]`: Specifies the size of an empty disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image.
  - `[Name <String>]`: The name of data disk.

## RELATED LINKS

