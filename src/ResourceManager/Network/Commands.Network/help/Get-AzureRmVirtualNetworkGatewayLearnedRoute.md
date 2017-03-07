---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmVirtualNetworkGatewayLearnedRoute

## SYNOPSIS
Retrieves a list of routes an Azure virtual network gateway has learned

## SYNTAX

```
Get-AzureRmVirtualNetworkGatewayLearnedRoute -VirtualNetworkGatewayName <String> -ResourceGroupName <String>
 [<CommonParameters>]
```

## DESCRIPTION
Enumerates learned routes for an Azure virtual network gateway. The output will include routes not learned over BGP. The origin for a route indicates how the Azure gateway learned that route.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmVirtualNetworkGatewayLearnedRoute -ResourceGroupName "resourceGroup" -VirtualNetworkGatewayName "gatewayName"
```

Retrieves learned routes for the gateway "gatewayName" in resource group "resourceGroup"

## PARAMETERS

### -ResourceGroupName
Virtual network gateway resource group's name

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

### -VirtualNetworkGatewayName
Virtual network gateway name

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSGatewayRoute

## NOTES

## RELATED LINKS

