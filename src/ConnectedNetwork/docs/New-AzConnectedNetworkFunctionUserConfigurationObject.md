---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.ConnectedNetwork/new-AzConnectedNetworkFunctionUserConfigurationObject
schema: 2.0.0
---

# New-AzConnectedNetworkFunctionUserConfigurationObject

## SYNOPSIS
Create a in-memory object for NetworkFunctionUserConfiguration

## SYNTAX

```
New-AzConnectedNetworkFunctionUserConfigurationObject [-NetworkInterface <INetworkInterface[]>]
 [-OSProfileCustomData <String>] [-RoleName <String>] [-UserDataParameter <IAny>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for NetworkFunctionUserConfiguration

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -NetworkInterface
The network interface configuration.
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

### -OSProfileCustomData
Specifies a base-64 encoded string of custom data.
The base-64 encoded string is decoded to a binary array that is saved as a file on the virtual machine.
The maximum length of the binary array is 65535 bytes.


 **Note: Do not pass any secrets or passwords in customData property** 

 This property cannot be updated after the VM is created.


 customData is passed to the VM to be saved as a file.
For more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/) 

 For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).

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

### -UserDataParameter
The user data parameters from the customer.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.NetworkFunctionUserConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


NETWORKINTERFACE <INetworkInterface[]>: The network interface configuration.
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

## RELATED LINKS

