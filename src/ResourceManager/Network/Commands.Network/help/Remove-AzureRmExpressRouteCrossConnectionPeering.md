---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 462F3EF7-4C15-41F8-853D-CDCC8E67673D
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/Remove-AzureRmExpressRouteCrossConnectionPeering
schema: 2.0.0
---

# Remove-AzureRmExpressRouteCrossConnectionPeering

## SYNOPSIS
Removes an ExpressRoute cross connection peering configuration.

## SYNTAX

```
Remove-AzureRmExpressRouteCrossConnectionPeering [-Name <String>] -ExpressRouteCrossConnection <PSExpressRouteCrossConnection>
 [-PeerAddressType <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmExpressRouteCrossConnectionPeering** cmdlet removes an ExpressRoute cross connection
peering configuration.

## EXAMPLES

### Example 1: Remove a peering configuration from an ExpressRoute cross connection
```
$cc = Get-AzureRmExpressRouteCrossConnection -Name $CrossConnectionName -ResourceGroupName $rg
Remove-AzureRmExpressRouteCrossConnectionPeering -Name 'AzurePrivatePeering' -ExpressRouteCrossConnection $cc
Set-AzureRmExpressRouteCrossConnection -ExpressRouteCrossConnection $cc
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteCrossConnection
The ExpressRoute cross connection containing the peering configuration to be removed.

```yaml
Type: PSExpressRouteCrossConnection
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

### -PeerAddressType
The Address family of the peering

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: IPv4, IPv6, All

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSExpressRouteCrossConnection
Parameter 'ExpressRouteCrossConnection' accepts value of type 'PSExpressRouteCrossConnection' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCrossConnection

## NOTES

## RELATED LINKS

[Add-AzureRmExpressRouteCrossConnectionPeering](Add-AzureRmExpressRouteCrossConnectionPeering.md)

[Get-AzureRmExpressRouteCrossConnection](Get-AzureRmExpressRouteCrossConnection.md)

[New-AzureRmExpressRouteCrossConnectionPeering](New-AzureRmExpressRouteCrossConnectionPeering.md)

[Set-AzureRmExpressRouteCrossConnection](Set-AzureRmExpressRouteCrossConnection.md)
