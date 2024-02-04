---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.Peering/new-AzPeeringCheckServiceProviderAvailabilityInputObject
schema: 2.0.0
---

# New-AzPeeringCheckServiceProviderAvailabilityInputObject

## SYNOPSIS
Create an in-memory object for CheckServiceProviderAvailabilityInput.

## SYNTAX

```
New-AzPeeringCheckServiceProviderAvailabilityInputObject [-PeeringServiceLocation <String>]
 [-PeeringServiceProvider <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CheckServiceProviderAvailabilityInput.

## EXAMPLES

### Example 1: Create a check service provider availability object
```powershell
New-AzPeeringCheckServiceProviderAvailabilityInputObject -PeeringServiceLocation Osaka -PeeringServiceProvider IIJ
```

```output
PeeringServiceLocation PeeringServiceProvider
---------------------- ----------------------
Osaka                  IIJ
```

Creates a CheckServiceProviderAvailabilityInputObject with the specified location and provider and stores it in memory

## PARAMETERS

### -PeeringServiceLocation
Gets or sets the peering service location.

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

### -PeeringServiceProvider
Gets or sets the peering service provider.

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.CheckServiceProviderAvailabilityInput

## NOTES

ALIASES

## RELATED LINKS

