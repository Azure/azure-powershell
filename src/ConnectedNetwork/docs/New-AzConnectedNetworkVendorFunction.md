---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/new-azconnectednetworkvendorfunction
schema: 2.0.0
---

# New-AzConnectedNetworkVendorFunction

## SYNOPSIS
Creates or updates a vendor network function.
This operation can take up to 6 hours to complete.
This is expected service behavior.

## SYNTAX

```
New-AzConnectedNetworkVendorFunction -LocationName <String> -ServiceKey <String> -VendorName <String>
 [-SubscriptionId <String>] [-SkuType <SkuType>]
 [-VendorConfiguration <INetworkFunctionVendorConfiguration[]>]
 [-VendorProvisioningState <VendorProvisioningState>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a vendor network function.
This operation can take up to 6 hours to complete.
This is expected service behavior.

## EXAMPLES

### Example 1: New-AzConnectedNetworkVendorFunction
```powershell
$ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
$ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
$keyData = @{keyData = "ssh-rsa\AAAAB3NzaC1yc2EAAAADAQABAAABAQCyMpVbBgu0kftv1k+z1c3NtcB5CVDoo/X9X1LE2JUjlLlo0luEkFGJk61i53BhiTSTeRmQXN8hAZ7sn4MDUmZK7fWcHouZ2fsJo+ehses3wQPLubWBFw2L/hoSTyXifXMbEBu9SxHgqf1CEKQcvdNiWf4U7npXwjweXW9DtsF5E7h4kxhKJKFI4sNFTIX0IwUB15QEVHoBs92kDwH3fBH3kZZCMBJE/u6kT+XB22crRKkIGlp3a9gcogtOCvP+3xmsP7hjw5+nHxMUwkc/6kYyfTeLwvfI4xrTWpnB5xufts5LW5/U5GOXVg97ix9EXgiV0czThowG5K2xQ649UlJb redmond\user@n1-azuredev1"; path = $Null}
$keys = @{ }
$key += $keyData
$vendorconf = New-AzConnectedNetworkFunctionVendorConfigurationObject -NetworkInterface $ip1,$ip2 -RoleName hpehss -OSProfileAdminUsername MecUser -OSProfileCustomData $customData -OSProfileCustomDataRequired $True -SshPublicKey $key
$vendorvnf1 = New-AzConnectedNetworkVendorFunction -LocationName eastus2euap -ServiceKey b78d39-xxxx-xxxx-00946c5 -SubscriptionId xxxx-4444-xxxx-4444 -VendorName myVendor -VendorConfiguration $vendorconf -SkuType EvolvedPacketCore -VendorProvisioningState Provisioning
```

Creating network interfaces with dynamic method allocation and ip version to IPv4.
And using these to create two network configuration objects with vm switch type.
Creating a ssh key identity, Then using those to create vendor configuration object with role name hpehss, custom data, keyData and network interface array.
Using this to create vendor NF with the specified service key, vendor subscription, location eastus2euap, vendor name myVendor, sku type EvolvedPacketCore, vendor provisioning state Provisioning.

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

### -LocationName
The Azure region where the network function resource was created by the customer.

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

### -ServiceKey
The GUID for the vendor network function.

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

### -VendorConfiguration
An array of network function vendor configurations.
To construct, see NOTES section for VENDORCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkFunctionVendorConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### -VendorProvisioningState
The vendor controlled provisioning state of the vendor network function.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.VendorProvisioningState
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IVendorNetworkFunction

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


VENDORCONFIGURATION <INetworkFunctionVendorConfiguration[]>: An array of network function vendor configurations.
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
  - `[OSProfileAdminUsername <String>]`: Specifies the name of the administrator account.    **Windows-only restriction:** Cannot end in "."    **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5".    **Minimum-length (Linux):** 1  character    **Max-length (Linux):** 64 characters    **Max-length (Windows):** 20 characters    <li> For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privileges?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json) <li> For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernames?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  - `[OSProfileCustomData <String>]`: Specifies a base-64 encoded string of custom data. The base-64 encoded string is decoded to a binary array that is saved as a file on the virtual machine. The maximum length of the binary array is 65535 bytes.    **Note: Do not pass any secrets or passwords in customData property**    This property cannot be updated after the VM is created.    customData is passed to the VM to be saved as a file. For more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/)    For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
  - `[OSProfileCustomDataRequired <Boolean?>]`: Indicates if custom data is required to deploy this role.
  - `[RoleName <String>]`: The name of the vendor network function role.
  - `[SshPublicKey <ISshPublicKey[]>]`: The list of SSH public keys used to authenticate with linux based VMs.
    - `[KeyData <String>]`: SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
    - `[Path <String>]`: Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys

## RELATED LINKS

