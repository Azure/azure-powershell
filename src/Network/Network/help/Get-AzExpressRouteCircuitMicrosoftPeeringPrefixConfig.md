---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressroutecircuitmicrosoftpeeringprefixconfig
schema: 2.0.0
---

# Get-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig

## SYNOPSIS
Gets prefix validation properties for an advertised public prefix in Microsoft peering.

## SYNTAX

```
Get-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig -ExpressRouteCircuit <PSExpressRouteCircuit>
 -PeerAddressType <String> -Prefix <String> [-ValidationId <String>] [-Signature <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig** cmdlet retrieves the properties used for validating
the advertised public prefix in Microsoft peering.

## EXAMPLES

### Example 1: Get prefix validation information for IPv4 prefix
```powershell
$ckt = Get-AzExpressRouteCircuit -Name "ExpressRouteARMCircuit" -ResourceGroupName "ExpressRouteResourceGroup"
Get-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig -ExpressRouteCircuit $ckt -PeerAddressType IPv4 -Prefix "123.1.0.0/24"
```

### Example 1: Get prefix validation information for IPv6 prefix
```powershell
$ckt = Get-AzExpressRouteCircuit -Name "ExpressRouteARMCircuit" -ResourceGroupName "ExpressRouteResourceGroup"
Get-AzExpressRouteCircuitMicrosoftPeeringPrefixConfig -ExpressRouteCircuit $ckt -PeerAddressType IPv6 -Prefix "123:1::/64"
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteCircuit
The circuit

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
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
Type: System.String
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
Type: System.String
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
Type: System.String
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPeeringPrefixConfig

## NOTES

## RELATED LINKS
