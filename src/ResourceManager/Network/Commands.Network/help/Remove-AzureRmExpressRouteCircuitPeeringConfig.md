---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 462F3EF7-4C15-41F8-853D-CDCC8E67673D
online version: 
schema: 2.0.0
---

# Remove-AzureRmExpressRouteCircuitPeeringConfig

## SYNOPSIS
Removes an ExpressRoute circuit peering configuration.

## SYNTAX

```
Remove-AzureRmExpressRouteCircuitPeeringConfig [-Name <String>] -ExpressRouteCircuit <PSExpressRouteCircuit>
 [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmExpressRouteCircuitPeeringConfig** cmdlet removes an ExpressRoute circuit
peering configuration.

## EXAMPLES

### Example 1: Remove a peering configuration from an ExpressRoute circuit
```
$circuit = Get-AzureRmExpressRouteCircuit -Name $CircuitName -ResourceGroupName $rg
Remove-AzureRmExpressRouteCircuitPeeringConfig -Name 'AzurePrivatePeering' -ExpressRouteCircuit $circuit
Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $circuit
```

## PARAMETERS

### -ExpressRouteCircuit
The ExpressRoute circuit containing the peering configuration to be removed.

```yaml
Type: PSExpressRouteCircuit
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the peering configuration to be removed.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Add-AzureRmExpressRouteCircuitPeeringConfig](Add-AzureRmExpressRouteCircuitPeeringConfig.md)

[Get-AzureRmExpressRouteCircuit](Get-AzureRmExpressRouteCircuit.md)

[New-AzureRmExpressRouteCircuitPeeringConfig](New-AzureRmExpressRouteCircuitPeeringConfig.md)

[Set-AzureRmExpressRouteCircuit](Set-AzureRmExpressRouteCircuit.md)