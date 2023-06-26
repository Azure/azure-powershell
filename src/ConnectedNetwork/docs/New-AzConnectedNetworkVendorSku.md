---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/new-azconnectednetworkvendorsku
schema: 2.0.0
---

# New-AzConnectedNetworkVendorSku

## SYNOPSIS
Creates or updates a sku.
This operation can take up to 2 hours to complete.
This is expected service behavior.

## SYNTAX

```
New-AzConnectedNetworkVendorSku -SkuName <String> -VendorName <String> [-SubscriptionId <String>]
 [-DeploymentMode <SkuDeploymentMode>] [-ManagedApplicationParameter <Hashtable>]
 [-ManagedApplicationTemplate <Hashtable>]
 [-NetworkFunctionRoleConfigurationType <INetworkFunctionRoleConfiguration[]>]
 [-NetworkFunctionType <NetworkFunctionType>] [-Preview] [-SkuType <SkuType>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a sku.
This operation can take up to 2 hours to complete.
This is expected service behavior.

## EXAMPLES

### Example 1: New-AzConnectedNetworkVendorSku
```powershell
$role = New-AzConnectedNetworkFunctionRoleConfigurationObject -NetworkInterface $ip1,$ip2 -OSDiskName NetFoundry -OSDiskOstype Linux -OSDiskSizeGb 40 -OSProfileCustomDataRequired $False -OSProfileAdminUsername MecUser -RoleName hpehss -RoleType VirtualMachine -VirtualMachineSize "Standard_D3_v2" -SshPublicKey $key -StorageProfileDataDisk $storage -VhdUri "https://mecvdrvhd.blob.core.windows/myvhd.vhd"
New-AzConnectedNetworkVendorSku -SkuName sku1 -VendorName myVendor -SubscriptionId xxxxx-22222-xxxxx-22222 -SkuType VirtualMachine -DeploymentMode PrivateEdgeZone -NetworkFunctionRoleConfigurationType @($role)
```

Creating NF role configuration object wuth the specified details.
Using this to create sku with sku name sku1, vendor name myVendor, sku type VirtualMachine, deployment type PrivateEdgeZone.

## PARAMETERS

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
```

### -DeploymentMode
The sku deployment mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.SkuDeploymentMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedApplicationParameter
The parameters for the managed application to be supplied by the vendor.

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

### -ManagedApplicationTemplate
The template for the managed application deployment.

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

### -NetworkFunctionRoleConfigurationType
An array of network function role definitions.
To construct, see NOTES section for NETWORKFUNCTIONROLECONFIGURATIONTYPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkFunctionRoleConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFunctionType
The network function type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.NetworkFunctionType
Parameter Sets: (All)
Aliases:

Required: False
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

### -Preview
Indicates if the vendor sku is in preview mode.

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

### -SkuName
The name of the sku.

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

### -SkuType
The sku type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.SkuType
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

### -VendorName
The name of the vendor.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IVendorSku

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


NETWORKFUNCTIONROLECONFIGURATIONTYPE <INetworkFunctionRoleConfiguration[]>: An array of network function role definitions.
  - `[CustomProfileMetadataConfigurationPath <String>]`: Path for metadata configuration.
  - `[ImageReferenceExactVersion <String>]`: Specifies in decimal numbers, the exact version of image used to create the virtual machine.
  - `[ImageReferenceOffer <String>]`: Specifies the offer of the image used to create the virtual machine.
  - `[ImageReferencePublisher <String>]`: The image publisher.
  - `[ImageReferenceSku <String>]`: The image SKU.
  - `[ImageReferenceVersion <String>]`: Specifies the version of the image used to create the virtual machine. The allowed formats are Major.Minor.Build or 'latest'. Major, Minor, and Build are decimal numbers. Specify 'latest' to use the latest version of an image available at deploy time. Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available.
  - `[NetworkInterface <INetworkInterface[]>]`: The network interface configurations.
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
  - `[OSDiskName <String>]`: The VHD name.
  - `[OSDiskOstype <OperatingSystemTypes?>]`: The OS type.
  - `[OSDiskSizeGb <Int32?>]`: Specifies the size of os disk in gigabytes. This is the fully expanded disk size needed of the VHD image on the ASE. This disk size should be greater than the size of the VHD provided in vhdUri.
  - `[OSProfileAdminUsername <String>]`: Specifies the name of the administrator account.    **Windows-only restriction:** Cannot end in "."    **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5".    **Minimum-length (Linux):** 1  character    **Max-length (Linux):** 64 characters    **Max-length (Windows):** 20 characters    <li> For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privileges?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json) <li> For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernames?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  - `[OSProfileCustomData <String>]`: Specifies a base-64 encoded string of custom data. The base-64 encoded string is decoded to a binary array that is saved as a file on the virtual machine. The maximum length of the binary array is 65535 bytes.    **Note: Do not pass any secrets or passwords in customData property**    This property cannot be updated after the VM is created.    customData is passed to the VM to be saved as a file. For more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/)    For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
  - `[OSProfileCustomDataRequired <Boolean?>]`: Indicates if custom data is required to deploy this role.
  - `[RoleName <String>]`: The name of the network function role.
  - `[RoleType <NetworkFunctionRoleConfigurationType?>]`: Role type.
  - `[SshPublicKey <ISshPublicKey[]>]`: The list of SSH public keys used to authenticate with linux based VMs.
    - `[KeyData <String>]`: SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
    - `[Path <String>]`: Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys
  - `[StorageProfileDataDisk <IDataDisk[]>]`: Specifies the parameters that are used to add a data disk to a virtual machine.
    - `[CreateOption <DiskCreateOptionTypes?>]`: Specifies how the virtual machine should be created.
    - `[DiskSizeGb <Int32?>]`: Specifies the size of an empty disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image.
    - `[Name <String>]`: The name of data disk.
  - `[UserDataParameter <IAny>]`: The user parameters for customers. The format of user data parameters has to be matched with the provided user data template.
  - `[UserDataTemplate <IAny>]`: The user data template for customers. This is a json schema template describing the format and data type of user data parameters.
  - `[VhdUri <String>]`: Specifies the virtual hard disk's uri.
  - `[VirtualMachineSize <VirtualMachineSizeTypes?>]`: The size of the virtual machine.

## RELATED LINKS

