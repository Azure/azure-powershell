---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/remove-azurermroutefilterruleconfig
schema: 2.0.0
---

# Remove-AzureRmRouteFilterRuleConfig

## SYNTAX

```
Remove-AzureRmRouteFilterRuleConfig -Name <String> -RouteFilter <PSRouteFilter> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmRouteFilterRuleConfig** cmdlet removes a route filter rule from a route filter. 

## EXAMPLES

### Example 1: Get route filter object and rule object and removes rule config from the route filter
```
$rf =  Get-AzureRmRouteFilter -Name "RouteFilterName" -ResourceGroupName "ResourceGroupName"
$rule = Get-AzureRmRouteFilterRuleConfig -RouteFilter $rf
Remove-AzureRmRouteFilterRuleConfig -Name $rule.Name -RouteFilter $rf
Set-AzureRmRouteFilter -RouteFilter $rf
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

### -Force
Do not ask for confirmation if you want to overrite a resource

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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

Required: True
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
[Get-AzureRmRouteFilterRuleConfig](Get-AzureRmRouteFilterRuleConfig.md)
[Set-AzureRmRouteFilterRuleConfig](Set-AzureRmRouteFilterRuleConfig.md)
