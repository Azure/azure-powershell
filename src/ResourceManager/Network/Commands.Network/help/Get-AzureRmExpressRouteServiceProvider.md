---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 009F6E65-0268-4505-AEC1-FF379CB96804
online version: 
schema: 2.0.0
---

# Get-AzureRmExpressRouteServiceProvider

## SYNOPSIS
Gets a list ExpressRoute service providers and their attributes.

## SYNTAX

```
Get-AzureRmExpressRouteServiceProvider [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmExpressRouteServiceProvider** cmdlet retrieves a list ExpressRoute service
providers and their attributes. Attribute include location and bandwidth options.

## EXAMPLES

### Example 1: Get a list of service provider with locations in "Silicon Valley"
```
Get-AzureRmExpressRouteServiceProvider |
   Where-Object PeeringLocations -Contains "Silicon Valley" |
   Select-Object Name
```

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteServiceProvider

## NOTES

## RELATED LINKS

[Get-AzureRmExpressRouteCircuitARPTable](Get-AzureRmExpressRouteCircuitARPTable.md)

[Get-AzureRmExpressRouteCircuitRouteTable](Get-AzureRmExpressRouteCircuitRouteTable.md)

[Get-AzureRmExpressRouteCircuitRouteTableSummary](Get-AzureRmExpressRouteCircuitRouteTableSummary.md)

[Get-AzureRmExpressRouteCircuitStats](Get-AzureRmExpressRouteCircuitStats.md)
