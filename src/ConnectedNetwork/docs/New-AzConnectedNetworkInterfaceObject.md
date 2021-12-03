---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.ConnectedNetwork/new-AzConnectedNetworkInterfaceObject
schema: 2.0.0
---

# New-AzConnectedNetworkInterfaceObject

## SYNOPSIS
Create a in-memory object for NetworkInterface

## SYNTAX

```
New-AzConnectedNetworkInterfaceObject [-IPConfiguration <INetworkInterfaceIPConfiguration[]>]
 [-MacAddress <String>] [-Name <String>] [-VMSwitchType <VMSwitchType>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for NetworkInterface

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

### -IPConfiguration
A list of IP configurations of the network interface.
To construct, see NOTES section for IPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkInterfaceIPConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MacAddress
The MAC address of the network interface.

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
The name of the network interface.

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

### -VMSwitchType
The type of the VM switch.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.VMSwitchType
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.NetworkInterface

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


IPCONFIGURATION <INetworkInterfaceIPConfiguration[]>: A list of IP configurations of the network interface.
  - `[DnsServer <String[]>]`: The list of DNS servers IP addresses.
  - `[Gateway <String>]`: The value of the gateway.
  - `[IPAddress <String>]`: The value of the IP address.
  - `[IPAllocationMethod <IPAllocationMethod?>]`: IP address allocation method.
  - `[IPVersion <IPVersion?>]`: IP address version.
  - `[Subnet <String>]`: The value of the subnet.

## RELATED LINKS

