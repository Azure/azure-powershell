---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 3efb6270-f908-4734-bdb1-6c7e4e4eb382
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermexpressroutecrossconnection
schema: 2.0.0
---

# Get-AzureRmExpressRouteCrossConnection

## SYNOPSIS
Gets an Azure ExpressRoute cross connection from Azure.

## SYNTAX

```
Get-AzureRmExpressRouteCrossConnection [-Name <String>] [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmExpressRouteCrossConnection** cmdlet is used to retrieve an ExpressRoute cross connection object
from your subscription.
AzureRmExpressRouteCrossConnection
## EXAMPLES

### Example 1: Get the ExpressRoute cross connection
```
Get-AzureRmExpressRouteCrossConnection -Name $CrossConnectionName -ResourceGroupName $rg
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

### -Name
The name of the ExpressRoute cross connection.

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
The name of the resource group that contains the ExpressRoute cross connection.

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

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCrossConnection

## NOTES

## RELATED LINKS

[Set-AzureRmExpressRouteCrossConnection](Set-AzureRmExpressRouteCrossConnection.md)