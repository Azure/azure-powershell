---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-azurermroutefilter
schema: 2.0.0
---

# Set-AzureRmRouteFilter

## SYNTAX

```
Set-AzureRmRouteFilter -RouteFilter <PSRouteFilter> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmRouteFilter** cmdlet saves the modified route filter object
from your subscription. A route filter is used in conjunction with Microsoft peering on an ExpressRoute circuit.

## EXAMPLES

### Example 1: Create a rule config based on a community list and set the route filter with the new rules
```
$communities = @("12076:51015","12076:51016")
$ruleConfig = New-AzureRmRouteFilterRuleConfig -Name "RuleName" -Access Allow -RouteFilterRuleType Community -CommunityList $communities
$rf =  Get-AzureRmRouteFilter -Name "RouteFilterName" -ResourceGroupName "ResourceGroupName"
$rf.Rules = $ruleConfig
Set-AzureRmRouteFilter -RouteFilter $rf
```



## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### Microsoft.Azure.Commands.Network.Models.PSRouteFilter

## RELATED LINKS

[New-AzureRmRouteFilter](New-AzureRmRouteFilter.md)
[Remove-AzureRmRouteFilter](Remove-AzureRmRouteFilter.md)
[Get-AzureRmRouteFilter](Get-AzureRmRouteFilter.md)
