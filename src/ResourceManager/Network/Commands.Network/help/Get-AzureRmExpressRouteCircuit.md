---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: C9954E3D-8645-473E-A6D4-86278C2F6BC1
online version: 
schema: 2.0.0
---

# Get-AzureRmExpressRouteCircuit

## SYNOPSIS
Gets an Azure ExpressRoute circuit from Azure.

## SYNTAX

```
Get-AzureRmExpressRouteCircuit [-Name <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmExpressRouteCircuit** cmdlet is used to retrieve an ExpressRoute circuit object
from your subscription. The circuit object returned can be used as input to other cmdlets that
operate on ExpressRoute circuits.

## EXAMPLES

### Example 1: Get the ExpressRoute circuit to be deleted
```
Get-AzureRmExpressRouteCircuit -Name $CircuitName -ResourceGroupName $rg | Remove-AzureRmExpressRouteCircuit
```

## PARAMETERS

### -Name
The name of the ExpressRoute circuit.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the ExpressRoute circuit.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Move-AzureRmExpressRouteCircuit](Move-AzureRmExpressRouteCircuit.md)

[New-AzureRmExpressRouteCircuit](New-AzureRmExpressRouteCircuit.md)

[Remove-AzureRmExpressRouteCircuit](Remove-AzureRmExpressRouteCircuit.md)

[Set-AzureRmExpressRouteCircuit](Set-AzureRmExpressRouteCircuit.md)