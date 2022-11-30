---
external help file:
Module Name: Az.VoiceServices
online version: https://learn.microsoft.com/powershell/module/az.VoiceServices/new-AzVoiceServicesCommunicationsGatewayServiceRegionObject
schema: 2.0.0
---

# New-AzVoiceServicesCommunicationsGatewayServiceRegionObject

## SYNOPSIS
Create an in-memory object for ServiceRegionProperties.

## SYNTAX

```
New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name <String>
 -PrimaryRegionOperatorAddress <String[]> [-PrimaryRegionEsrpAddress <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceRegionProperties.

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

### -Name
The name of the region in which the resources needed for Teams Calling will be deployed.

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

### -PrimaryRegionEsrpAddress
IP address to use to contact the ESRP from this region.

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

### -PrimaryRegionOperatorAddress
IP address to use to contact the operator network from this region.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VoiceServices.Models.Api20221201Preview.ServiceRegionProperties

## NOTES

ALIASES

## RELATED LINKS

