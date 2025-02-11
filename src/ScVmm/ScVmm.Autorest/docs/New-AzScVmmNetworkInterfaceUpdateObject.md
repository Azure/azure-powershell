---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/Az.ScVmm/new-azscvmmnetworkinterfaceupdateobject
schema: 2.0.0
---

# New-AzScVmmNetworkInterfaceUpdateObject

## SYNOPSIS
Create an in-memory object for NetworkInterfaceUpdate.

## SYNTAX

```
New-AzScVmmNetworkInterfaceUpdateObject [-Ipv4AddressType <String>] [-Ipv6AddressType <String>]
 [-MacAddress <String>] [-MacAddressType <String>] [-Name <String>] [-NicId <String>]
 [-VirtualNetworkId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NetworkInterfaceUpdate.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Ipv4AddressType
Gets or sets the ipv4 address type.

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

### -Ipv6AddressType
Gets or sets the ipv6 address type.

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

### -MacAddress
Gets or sets the nic MAC address.

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

### -MacAddressType
Gets or sets the mac address type.

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
Gets or sets the name of the network interface.

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

### -NicId
Gets or sets the nic id.

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

### -VirtualNetworkId
Gets or sets the ARM Id of the Microsoft.ScVmm/virtualNetwork resource to connect the nic.

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.NetworkInterfaceUpdate

## NOTES

## RELATED LINKS

