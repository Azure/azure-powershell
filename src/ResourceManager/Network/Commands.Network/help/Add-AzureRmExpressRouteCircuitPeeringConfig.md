---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: C44AD23A-E575-418C-BE90-323B44D6D2E8
online version: 
schema: 2.0.0
---

# Add-AzureRmExpressRouteCircuitPeeringConfig

## SYNOPSIS
Adds a peering configuration to an ExpressRoute circuit.

## SYNTAX

### SetByResource (Default)
```
Add-AzureRmExpressRouteCircuitPeeringConfig -Name <String> -ExpressRouteCircuit <PSExpressRouteCircuit>
 -PeeringType <String> -PeerASN <Int32> -PrimaryPeerAddressPrefix <String> -SecondaryPeerAddressPrefix <String>
 -VlanId <Int32> [-SharedKey <String>] [-RouteFilter <PSRouteFilter>] [<CommonParameters>]
```

### MicrosoftPeeringConfig
```
Add-AzureRmExpressRouteCircuitPeeringConfig -Name <String> -ExpressRouteCircuit <PSExpressRouteCircuit>
 -PeeringType <String> -PeerASN <Int32> -PrimaryPeerAddressPrefix <String> -SecondaryPeerAddressPrefix <String>
 -VlanId <Int32> [-SharedKey <String>]
 [-MicrosoftConfigAdvertisedPublicPrefixes <System.Collections.Generic.List`1[System.String]>]
 [-MicrosoftConfigCustomerAsn <Int32>] [-MicrosoftConfigRoutingRegistryName <String>] [<CommonParameters>]
```

### SetByResourceId
```
Add-AzureRmExpressRouteCircuitPeeringConfig -Name <String> -ExpressRouteCircuit <PSExpressRouteCircuit>
 -PeeringType <String> -PeerASN <Int32> -PrimaryPeerAddressPrefix <String> -SecondaryPeerAddressPrefix <String>
 -VlanId <Int32> [-SharedKey <String>] [-RouteFilterId <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmExpressRouteCircuitPeeringConfig** cmdlet adds a peering configuration to an
ExpressRoute circuit. ExpressRoute circuits connect your on-premises network to the Microsoft cloud
by using a connectivity provider instead of the public Internet. Note that, after running
**Add-AzureRmExpressRouteCircuitPeeringConfig**, you must call the Set-AzureRmExpressRouteCircuit
cmdlet to activate the configuration.

## EXAMPLES

### Example 1: Add a peer to an existing ExpressRoute circuit
```
$circuit = Get-AzureRmExpressRouteCircuit -Name $CircuitName -ResourceGroupName $rg
$parameters = @{
    Name = 'AzurePrivatePeering'
    Circuit = $circuit
    PeeringType = 'AzurePrivatePeering'
    PeerASN = 100
    PrimaryPeerAddressPrefix = '10.6.1.0/30'
    SecondaryPeerAddressPrefix = '10.6.2.0/30'
    VlanId  = 200
}
Add-AzureRmExpressRouteCircuitPeeringConfig @parameters
Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $circuit
```

## PARAMETERS

### -ExpressRouteCircuit
The ExpressRoute circuit being modified. This is Azure object returned by the
**Get-AzureRmExpressRouteCircuit** cmdlet.

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

### -MicrosoftConfigAdvertisedPublicPrefixes
For a PeeringType of MicrosoftPeering, you must provide a list of all prefixes you plan to
advertise over the BGP session. Only public IP address prefixes are accepted. You can send a comma
separated list if you plan to send a set of prefixes. These prefixes must be registered to you in
a Routing Registry Name (RIR / IRR).

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: MicrosoftPeeringConfig
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftConfigCustomerAsn
If you are advertising prefixes that are not registered to the peering AS number, you can specify
the AS number to which they are registered.

```yaml
Type: Int32
Parameter Sets: MicrosoftPeeringConfig
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftConfigRoutingRegistryName
The Routing Registry Name (RIR / IRR) to which the AS number and prefixes are registered.

```yaml
Type: String
Parameter Sets: MicrosoftPeeringConfig
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the peering relationship to be added.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerASN
The AS number of your ExpressRoute circuit. This must be a Public ASN when the PeeringType is
AzurePublicPeering.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringType
The acceptable values for this parameter are: `AzurePrivatePeering`, `AzurePublicPeering`, and
`MicrosoftPeering`

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: AzurePrivatePeering, AzurePublicPeering, MicrosoftPeering

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryPeerAddressPrefix
This is the IP Address range for the primary routing path of this peering relationship. This must
be a /30 CIDR subnet. The first odd-numbered address in this subnet should be assigned to your
router interface. Azure will configure the next even-numbered address to the Azure router interface.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteFilter
This is an existing RouteFilter object.

```yaml
Type: PSRouteFilter
Parameter Sets: SetByResource
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RouteFilterId
This is the resource Id of an existing RouteFilter object.

```yaml
Type: String
Parameter Sets: SetByResourceId
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecondaryPeerAddressPrefix
This is the IP Address range for the secondary routing path of this peering relationship. This must
be a /30 CIDR subnet. The first odd-numbered address in this subnet should be assigned to your
router interface. Azure will configure the next even-numbered address to the Azure router interface.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedKey
This is an optional MD5 hash used as a pre-shared key for the peering configuration.

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

### -VlanId
This is the Id number of the VLAN assigned for this peering.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: True
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

[Get-AzureRmExpressRouteCircuit](Get-AzureRmExpressRouteCircuit.md)

[New-AzureRmExpressRouteCircuitPeeringConfig](New-AzureRmExpressRouteCircuitPeeringConfig.md)

[Remove-AzureRmExpressRouteCircuitPeeringConfig](Remove-AzureRmExpressRouteCircuitPeeringConfig.md)

[Set-AzureRmExpressRouteCircuit](Set-AzureRmExpressRouteCircuit.md)