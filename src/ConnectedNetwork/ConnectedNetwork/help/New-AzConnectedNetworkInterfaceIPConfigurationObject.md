---
external help file: Az.ConnectedNetwork-help.xml
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/Az.ConnectedNetwork/new-azconnectednetworkinterfaceipconfigurationobject
schema: 2.0.0
---

# New-AzConnectedNetworkInterfaceIPConfigurationObject

## SYNOPSIS
Create an in-memory object for NetworkInterfaceIPConfiguration.

## SYNTAX

```
New-AzConnectedNetworkInterfaceIPConfigurationObject [-DnsServer <String[]>] [-Gateway <String>]
 [-IPAddress <String>] [-IPAllocationMethod <String>] [-IPVersion <String>] [-Subnet <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NetworkInterfaceIPConfiguration.

## EXAMPLES

### Example 1: Create a in-memory object for NetworkInterfaceIPConfiguration
```powershell
New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
```

```output
DnsServer Gateway IPAddress IPAllocationMethod IPVersion Subnet
--------- ------- --------- ------------------ --------- ------
                            Dynamic            IPv4
```

Create a in-memory object for NetworkInterfaceIPConfiguration

## PARAMETERS

### -DnsServer
The list of DNS servers IP addresses.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Gateway
The value of the gateway.

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

### -IPAddress
The value of the IP address.

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

### -IPAllocationMethod
IP address allocation method.

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

### -IPVersion
IP address version.

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

### -Subnet
The value of the subnet.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.NetworkInterfaceIPConfiguration

## NOTES

## RELATED LINKS
