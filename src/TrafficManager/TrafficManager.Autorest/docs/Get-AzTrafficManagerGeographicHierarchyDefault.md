---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/get-aztrafficmanagergeographichierarchydefault
schema: 2.0.0
---

# Get-AzTrafficManagerGeographicHierarchyDefault

## SYNOPSIS
Gets the default Geographic Hierarchy used by the Geographic traffic routing method.

## SYNTAX

```
Get-AzTrafficManagerGeographicHierarchyDefault [<CommonParameters>]
```

## DESCRIPTION
Gets the default Geographic Hierarchy used by the Geographic traffic routing method.

## EXAMPLES

### Example 1: Get the geographic hierarchy
```powershell
Get-AzTrafficManagerGeographicHierarchyDefault
```

```output
Id   : /providers/Microsoft.Network/trafficManagerGeographicHierarchies/default
Name : default
```

Gets the default geographic hierarchy used by the Geographic traffic routing method. This hierarchy contains all the regions that can be mapped to Traffic Manager endpoints.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Az.TrafficManager.Models.ITrafficManagerGeographicHierarchy

## NOTES

## RELATED LINKS

