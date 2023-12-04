---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azroutemaprule
schema: 2.0.0
---

# New-AzRouteMapRule

## SYNOPSIS
Create a route map rule.

## SYNTAX

```
New-AzRouteMapRule [-MatchCriteria <PSRouteMapRuleCriterion[]>] -RouteMapRuleAction <PSRouteMapRuleAction[]>
 -NextStepIfMatched <String> -Name <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a route map rule.

## EXAMPLES

### Example 1

```powershell
# creating new route map rules and a new route map resource
$routeMapMatchCriterion1 = New-AzRouteMapRuleCriterion -MatchCondition "Contains" -RoutePrefix @("10.0.0.0/16")
$routeMapRuleActionParameter1 = New-AzRouteMapRuleActionParameter -AsPath @("12345")
$routeMapRuleAction1 = New-AzRouteMapRuleAction -Type "Add" -Parameter @($routeMapRuleActionParameter1)
New-AzRouteMapRule -Name "rule1" -MatchCriteria @($routeMapMatchCriterion1) -RouteMapRuleAction @($routeMapRuleAction1) -NextStepIfMatched "Continue"
```

```output
MatchCriteria     : {}
Actions           : {}
NextStepIfMatched : Continue
MatchCriteriaText : [
                      {
                        "MatchCondition": "Contains",
                        "RoutePrefix": [
                          "10.0.0.0/16"
                        ]
                      }
                    ]
ActionsText       : [
                      {
                        "Type": "Add",
                        "Parameters": [
                          {
                            "AsPath": [
                              "12345"
                            ]
                          }
                        ]
                      }
                    ]
Name              : rule1
Etag              :
Id                :
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

### -MatchCriteria
The route map rule Match Criteria. If not providing, will match all

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleCriterion[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The route map rule name.

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

### -NextStepIfMatched
Next step if the route map rule matched.

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

### -RouteMapRuleAction
The route map rule actions.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleAction[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleCriterion

### Microsoft.Azure.Commands.Network.Models.PSRouteMapRuleAction

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteMapRule

## NOTES

## RELATED LINKS

[New-AzRouteMap](./New-AzRouteMap.md)

[New-AzRouteMapRuleAction](./New-AzRouteMapRuleAction.md)

[New-AzRouteMap](./New-AzRouteMap.md)