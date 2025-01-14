---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/add-azexpressroutecircuitmicrosoftpeeringprefixconfig
schema: 2.0.0
---

# Add-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig

## SYNOPSIS
Adds prefix validation properties required to validate the advertised public prefixes in Microsoft peering.

## SYNTAX

```
Add-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig -ExpressRouteCircuit <PSExpressRouteCircuit>
 -PeerAddressType <String> -Prefix <String> [-ValidationId <String>] [-Signature <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig** cmdlet adds the required information to validate a prefix
advertised in Microsoft peering. This cmdlet creates a new object containing all required information for validating the
prefix and attaches it to the peering config. After running **Add-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig**, 
you must call the Set-AzExpressRouteCircuit cmdlet to activate the configuration.

## EXAMPLES

### Example 1: Add Prefix validation config for IPv4 prefix
```powershell
$ckt = Get-AzExpressRouteCircuit -Name "ExpressRouteARMCircuit" -ResourceGroupName "ExpressRouteResourceGroup" 
Add-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig -ExpressRouteCircuit $ckt -PeerAddressType IPv4 -Prefix "123.1.0.0/24" -ValidationId "Azure-SKEY|7c44c70b-9c62-4a89-a6b2-d281b6ce7a49|123.1.0.0/24|ASN-23" -Signature "XxGp/5JtCJTrxSsOCeK+icaekDy18U4jZjrcHMAlN5cOTweH9XjZ7yfcLd4YegTPbGWiaKsX3Agvjk5q2hZ4fOGn+wHhL3SCNtoX6kF8/ukPVfw2cvZ7YS7otyCS7aR7g8kbugBhLDpB+g9SSChQT+/eR3QWgbC8m0C8RVGJo31gwDcXHsQ44hmnqs+OWcLI32FIVCoQeCOzmaGc4GVlZayFRvF/CiCm7g0k01+ipmVJQIkcdDArZZsfJuiXTiYNxLD57CEtuheX7knAj2AnceOJXaPpkS4f1i2Z8oVWC9YrqLWH5FCiIPU7PSh43YnDi/Pab3tT49EU3+PGZvWXCA=="
Set-AzExpressRouteCircuit -ExpressRouteCircuit $ckt
```

### Example 2: Add Prefix validation config for IPv6 prefix
```powershell
$ckt = Get-AzExpressRouteCircuit -Name "ExpressRouteARMCircuit" -ResourceGroupName "ExpressRouteResourceGroup" 
Add-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig -ExpressRouteCircuit $ckt -PeerAddressType IPv6 -Prefix "123:1::0/64" -ValidationId "Azure-SKEY|7c44c70b-9c62-4a89-a6b2-d281b6ce7a49|123:1::0/64|ASN-23" -Signature "XxGp/5JtCJTrxSsOCeK+icaekDy18U4jZjrcHMAlN5cOTweH9XjZ7yfcLd4YegTPbGWiaKsX3Agvjk5q2hZ4fOGn+wHhL3SCNtoX6kF8/ukPVfw2cvZ7YS7otyCS7aR7g8kbugBhLDpB+g9SSChQT+/eR3QWgbC8m0C8RVGJo31gwDcXHsQ44hmnqs+OWcLI32FIVCoQeCOzmaGc4GVlZayFRvF/CiCm7g0k01+ipmVJQIkcdDArZZsfJuiXTiYNxLD57CEtuheX7knAj2AnceOJXaPpkS4f1i2Z8oVWC9YrqLWH5FCiIPU7PSh43YnDi/Pab3tT49EU3+PGZvWXCA=="
Set-AzExpressRouteCircuit -ExpressRouteCircuit $ckt
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteCircuit
The ExpressRouteCircuit

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

### -PeerAddressType
PeerAddressType

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: IPv4, IPv6

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Prefix
Prefix

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

### -Signature
Signature

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

### -ValidationId
ValidationId

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

### -ProgressAction
ProgressAction

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit

## NOTES

## RELATED LINKS
