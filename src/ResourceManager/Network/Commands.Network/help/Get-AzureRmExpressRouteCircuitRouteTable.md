---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: BA7F6BAC-6047-42B0-B8CA-0B36302951B0
online version:
schema: 2.0.0
---

# Get-AzureRmExpressRouteCircuitRouteTable

## SYNOPSIS

Gets a route table from an ExpressRoute circuit.

## SYNTAX

```
Get-AzureRmExpressRouteCircuitRouteTable -ResourceGroupName <String> -ExpressRouteCircuitName
 <String> [-PeeringType <String>] -DevicePath <DevicePathEnum> [-InformationAction
 <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION

The **Get-AzureRmExpressRouteCircuitRouteTable** cmdlet retrieves a detailed route table of an
ExpressRoute circuit. The route table will show all routes or can be filtered to show routes for a
specific peering type. You can use the route table to validate your peering configuration and
connectivity.


## EXAMPLES

### Example 1: Display the route table for the primary path

```powershell
Get-AzureRmExpressRouteCircuitRouteTable -ResourceGroupName $RG -ExpressRouteCircuitName $CircuitName -DevicePath 'Primary'
```

## PARAMETERS

### -ResourceGroupName

The name of the resource group containing the ExpressRoute circuit.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpressRouteCircuitName

The name of the ExpressRoute circuit being examined.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PeeringType

The acceptable values for this parameter are: `AzurePrivatePeering`, `AzurePublicPeering`, and
`MicrosoftPeering`

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

### -DevicePath

The acceptable values for this parameter are: `Primary` or `Secondary`

```yaml
Type: DevicePathEnum
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationAction

Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable

Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose,
-WarningAction, and -WarningVariable. For more information, see about_CommonParameters
(http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmExpressRouteCircuitARPTable](Get-AzureRmExpressRouteCircuitARPTable.md)

[Get-AzureRmExpressRouteCircuitRouteTableSummary](Get-AzureRmExpressRouteCircuitRouteTableSummary.md)

[Get-AzureRmExpressRouteCircuitStats](Get-AzureRmExpressRouteCircuitStats.md)
