---
external help file:
Module Name: Az.ApplicationInsights
online version: https://docs.microsoft.com/powershell/module/az.ApplicationInsights/new-AzApplicationInsightsWebTestGeolocationObject
schema: 2.0.0
---

# New-AzApplicationInsightsWebTestGeolocationObject

## SYNOPSIS
Create an in-memory object for WebTestGeolocation.

## SYNTAX

```
New-AzApplicationInsightsWebTestGeolocationObject [-Location <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WebTestGeolocation.

## EXAMPLES

### Example 1: Create a in-memory object for WebTestGeolocation
```powershell
PS C:\> New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"

Location
--------
emea-nl-ams-azr
```

This command creates a memory object for WebTestGeolocation.
As value of the `GeoLocation` parameter in `New-AzApplicationInsightsWebTest`.

## PARAMETERS

### -Location
Location ID for the WebTest to run from.

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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20180501Preview.WebTestGeolocation

## NOTES

ALIASES

## RELATED LINKS

