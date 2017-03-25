---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 2A3B7343-9AA0-4505-AEDE-31C0C5B98694
online version: 
schema: 2.0.0
---

# Set-AzureRmExpressRouteCircuit

## SYNOPSIS
Modifies an ExpressRoute circuit.

## SYNTAX

```
Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit <PSExpressRouteCircuit> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmExpressRouteCircuit** cmdlet saves the modified ExpressRoute circuit to Azure.

## EXAMPLES

### Example 1: Change the ServiceKey of an ExpressRoute circuit
```
$ckt = Get-AzureRmExpressRouteCircuitï¿½-Nameï¿½$CircuitNameï¿½-ResourceGroupNameï¿½$rg
$ckt.ServiceKey = '64ce99dd-ee70-4e74-b6b8-91c6307433a0'
Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $ckt
```

## PARAMETERS

### -ExpressRouteCircuit
Specifies the **ExpressRouteCircuit** object that this cmdlet modifies.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmExpressRouteCircuit](./Get-AzureRmExpressRouteCircuit.md)

[Move-AzureRmExpressRouteCircuit](./Move-AzureRmExpressRouteCircuit.md)

[New-AzureRmExpressRouteCircuit](./New-AzureRmExpressRouteCircuit.md)

[Remove-AzureRmExpressRouteCircuit](./Remove-AzureRmExpressRouteCircuit.md)
