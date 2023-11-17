---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/az.orbital/get-azorbitalavailablegroundstation
schema: 2.0.0
---

# Get-AzOrbitalAvailableGroundStation

## SYNOPSIS
Returns list of available ground stations.

## SYNTAX

```
Get-AzOrbitalAvailableGroundStation -Capability <CapabilityParameter> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns list of available ground stations.

## EXAMPLES

### Example 1: Gets the specified  available ground station.
```powershell
Get-AzOrbitalAvailableGroundStation -Capability 'EarthObservation'
```

```output
Location      Name                ProviderName City
--------      ----                ------------ ----
westus2       Microsoft_Quincy    Microsoft    Quincy
westus2       KSAT_Awarua         KSAT         Awarua
westus2       KSAT_Hartebeesthoek KSAT         Hartebeesthoek
westus2       KSAT_Athens         KSAT         Athens
westus2       KSAT_Svalbard       KSAT         Svalbard
swedencentral Microsoft_Gavle     Microsoft    Gavle
southeastasia Microsoft_Singapore Microsoft    Singapore
brazilsouth   Microsoft_Longovilo Microsoft    Longovilo
```

Gets the specified  available ground station.

## PARAMETERS

### -Capability
Ground Station Capability.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Support.CapabilityParameter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.IAvailableGroundStation

## NOTES

ALIASES

## RELATED LINKS

