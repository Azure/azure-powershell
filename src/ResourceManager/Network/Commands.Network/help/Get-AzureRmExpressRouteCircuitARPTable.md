---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: F0370845-13D9-4FB5-B30E-826A22EBC5E0
online version:
schema: 2.0.0
---

# Get-AzureRmExpressRouteCircuitARPTable

## SYNOPSIS

Gets the ARP table from an ExpressRoute circuit.

## SYNTAX

```
Get-AzureRmExpressRouteCircuitARPTable [-Name <String>] -ResourceGroupName <String>
 -ExpressRouteCircuitName <String> [-PeeringType <String>] -DevicePath <DevicePathEnum>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION

The **Get-AzureRmExpressRouteCircuitARPTable** cmdlet retrieves the ARP table from both interfaces
of an ExpressRoute circuit. The ARP table provides a mapping of the IPv4 address to MAC address for
a particular peering. You can use the ARP table to validate layer 2 configuration and connectivity.

## EXAMPLES

### Example 1: Display the ARP table for an ExpressRoute peer

```powershell
Get-AzureRmExpressRouteCircuitARPTable -ResourceGroupName $RG -ExpressRouteCircuitName $CircuitName -PeeringType MicrosoftPeering -DevicePath Primary
```

## PARAMETERS

### -Name

The name of the resource.

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

[Get-AzureRmExpressRouteCircuitRouteTable](Get-AzureRmExpressRouteCircuitRouteTable.md)

[Get-AzureRmExpressRouteCircuitRouteTableSummary](Get-AzureRmExpressRouteCircuitRouteTableSummary.md)

[Get-AzureRmExpressRouteCircuitStats](Get-AzureRmExpressRouteCircuitStats.md)
