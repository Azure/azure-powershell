---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermroutefilterruleconfig
schema: 2.0.0
---

# Get-AzureRmRouteFilterRuleConfig

## SYNTAX

```
Get-AzureRmRouteFilterRuleConfig [-Name <String>] -RouteFilter <PSRouteFilter>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmRouteFilterRuleConfig cmdlet is used to retrieve an existing route filter rule configuration associated to a route filter. The route filter rule configuration object returned can be used as input to other cmdlets that are related to route filters or route filter rule configs. A route filter is used in conjunction with Microsoft peering on an ExpressRoute circuit.

## EXAMPLES

### Example 1: Get the route filter object and return the rule associated to the route filter
```
$rf =  Get-AzureRmRouteFilter -Name "RouteFilter" -ResourceGroupName "ResourceGroupName"
Get-AzureRmRouteFilterRuleConfig -RouteFilter $rf

```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the route filter rule

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

### -RouteFilter
The RouteFilter

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRouteFilter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteFilter
Parameters: RouteFilter (ByValue)

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteFilterRule

## RELATED LINKS

[New-AzureRmRouteFilterRuleConfig](New-AzureRmRouteFilterRuleConfig.md)
[Add-AzureRmRouteFilterRuleConfig](Add-AzureRmRouteFilterRuleConfig.md)
[Remove-AzureRmRouteFilterRuleConfig](Remove-AzureRmRouteFilterRuleConfig.md)
[Set-AzureRmRouteFilterRuleConfig](Set-AzureRmRouteFilterRuleConfig.md)
