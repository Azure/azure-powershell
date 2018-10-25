---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 47C45467-F368-4993-937E-E7E975F400B5
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermexpressroutecrossconnectionpeering
schema: 2.0.0
---

# Get-AzureRmExpressRouteCrossConnectionPeering

## SYNOPSIS
Gets an ExpressRoute cross connection peering configuration.

## SYNTAX

```
Get-AzureRmExpressRouteCrossConnectionPeering [-Name <String>] -ExpressRouteCrossConnection <PSExpressRouteCrossConnection>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmExpressRouteCrossConnectionPeering** cmdlet retrieves the configuration of a peering
relationship for an ExpressRoute cross connection.

## EXAMPLES

### Example 1: Display the peering configuration for an ExpressRoute cross connection
```
$cc = Get-AzureRmExpressRouteCrossConnection -Name $CrossConnectionName -ResourceGroupName $RG
Get-AzureRmExpressRouteCrossConnectionPeering -Name "AzurePrivatePeering" -ExpressRouteCrossConnection $cc
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
The ExpressRoute cross connection object containing the peering configuration.

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
The name of the peering configuration to be retrieved.

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

### PSExpressRouteCrossConnection
Parameter 'ExpressRouteCrossConnection' accepts value of type 'PSExpressRouteCrossConnection' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPeering

## NOTES

## RELATED LINKS

[Add-AzureRmExpressRouteCrossConnectionPeering](Add-AzureRmExpressRouteCrossConnectionPeering.md)

[New-AzureRmExpressRouteCrossConnectionPeering](New-AzureRmExpressRouteCrossConnectionPeering.md)

[Remove-AzureRmExpressRouteCrossConnectionPeering](Remove-AzureRmExpressRouteCrossConnectionPeering.md)

[Set-AzureRmExpressRouteCrossConnection](Set-AzureRmExpressRouteCrossConnection.md)
