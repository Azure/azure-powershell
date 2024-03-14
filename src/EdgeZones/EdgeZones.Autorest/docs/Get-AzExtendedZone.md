---
external help file:
Module Name: EdgeZones
online version: https://learn.microsoft.com/powershell/module/edgezones/get-azextendedzone
schema: 2.0.0
---

# Get-AzExtendedZone

## SYNOPSIS
Get an Azure Extended Zone for a subscription

## SYNTAX

### List (Default)
```
Get-AzExtendedZone -SubscriptionId <String> [<CommonParameters>]
```

### Get
```
Get-AzExtendedZone -AzureExtendedZoneName <String> -SubscriptionId <String> [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzExtendedZone -InputObject <IEdgeZonesIdentity> [<CommonParameters>]
```

## DESCRIPTION
Get an Azure Extended Zone for a subscription

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

### -AzureExtendedZoneName
The name of the AzureExtendedZone

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AzureExtendedZone.Models.IEdgeZonesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.AzureExtendedZone.Models.IEdgeZonesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AzureExtendedZone.Models.IAzureExtendedZone

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IEdgeZonesIdentity>`: Identity Parameter
  - `[AzureExtendedZoneName <String>]`: The name of the AzureExtendedZone
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

## RELATED LINKS

