---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.MobileNetwork/new-AzMobileNetworkSimStaticIPPropertiesObject
schema: 2.0.0
---

# New-AzMobileNetworkSimStaticIPPropertiesObject

## SYNOPSIS
Create an in-memory object for SimStaticIPProperties.

## SYNTAX

```
New-AzMobileNetworkSimStaticIPPropertiesObject [-AttachedDataNetworkId <String>] [-SlouseId <String>]
 [-StaticIPIpv4Address <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SimStaticIPProperties.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AttachedDataNetworkId
Attached data network resource ID.

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

### -SlouseId
Slice resource ID.

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

### -StaticIPIpv4Address
The IPv4 address assigned to the SIM at this network scope.
This address must be in the userEquipmentStaticAddressPoolPrefix defined in the attached data network.

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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.SimStaticIPProperties

## NOTES

ALIASES

## RELATED LINKS

