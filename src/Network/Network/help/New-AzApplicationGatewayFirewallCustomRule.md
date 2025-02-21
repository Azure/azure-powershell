---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallcustomrule
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallCustomRule

## SYNOPSIS
Creates a new custom rule for the application gateway firewall policy.

## SYNTAX

```
New-AzApplicationGatewayFirewallCustomRule -Name <String> -Priority <Int32> [-RateLimitDuration <String>]
 [-RateLimitThreshold <Int32>] -RuleType <String> -MatchCondition <PSApplicationGatewayFirewallCondition[]>
 [-GroupByUserSession <PSApplicationGatewayFirewallCustomRuleGroupByUserSession[]>] -Action <String>
 [-State <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallCustomRule** creates a custom rule for firewall policy.

## EXAMPLES

### Example 1
```powershell
New-AzApplicationGatewayFirewallCustomRule -Name example-rule -Priority 1 -RuleType MatchRule -MatchCondition $condtion -Action Allow
```

```output
Name                : example-rule
Priority            : 1
RuleType            : MatchRule
MatchConditions     : {Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCondition}
Action              : Allow
State               : Enabled
MatchConditionsText : [
                        {
                          "MatchVariables": [
                            {
                              "VariableName": "RequestHeaders",
                              "Selector": "Malicious-Header"
                            }
                          ],
                          "OperatorProperty": "Any",
                          "NegationConditon": false
                        }
                      ]
```

The command creates a new custom rule with name of example-rule, priority 1 and the rule type will be MatchRule with condition defined in the condition variable, the action will the allow.

### Example 2
```powershell
New-AzApplicationGatewayFirewallCustomRule -Name example-rule -Priority 2 -RuleType MatchRule -MatchCondition $condition -Action Allow -State Disabled
```

```output
Name                : example-rule
Priority            : 2
RuleType            : MatchRule
MatchConditions     : {Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCondition}
Action              : Allow
State               : Disabled
MatchConditionsText : [
                        {
                          "MatchVariables": [
                            {
                              "VariableName": "RequestHeaders",
                              "Selector": "Malicious-Header"
                            }
                          ],
                          "OperatorProperty": "Any",
                          "NegationConditon": false
                        }
                      ]
```

The command creates a new custom rule with name of example-rule, state as Disabled, priority 2 and the rule type will be MatchRule with condition defined in the condition variable, the action will the allow.

### Example 3
```powershell
New-AzApplicationGatewayFirewallCustomRule -Name RateLimitRule3 -Priority 3 -RateLimitDuration OneMin -RateLimitThreshold 10 -RuleType RateLimitRule -MatchCondition $condition -GroupByUserSession $groupbyUserSes -Action Allow -State Disabled
```

```output
Name                : RateLimitRule3
Priority            : 3
RateLimitDuration   : OneMin
RateLimitThreshold  : 10
RuleType            : RateLimitRule
MatchConditions     : {Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCondition}
GroupByUserSession  : {Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCustomRuleGroupByUserSession}
Action              : Allow
State               : Disabled
MatchConditionsText : [
                        {
                          "MatchVariables": [
                            {
                              "VariableName": "RequestHeaders",
                              "Selector": "Malicious-Header"
                            }
                          ],
                          "OperatorProperty": "Any",
                          "NegationConditon": false
                        }
                      ]
GroupByUserSessionText : [
                        {
                          "groupByVariables": [
                            {
                              "variableName": "ClientAddr"
                            }
                          ]
                        }
                      ]
```

The command creates a new custom rule with name of RateLimitRule3, state as Disabled, priority 3, RateLimitDuration OneMin, RateLimitThreshold 10 and the rule type will be RateLimitRule with condition defined in the condition variable, the action will the allow, the GroupByUserSession defined in the GroupByUserSession condition variable.

## PARAMETERS

### -Action
Type of Actions.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Allow, Block, Log

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -GroupByUserSession
List of match conditions.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCustomRuleGroupByUserSession[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchCondition
List of match conditions.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCondition[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Name of the Rule.

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

### -Priority
Describes priority of the rule.
Rules with a lower value will be evaluated before rules with a higher value.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RateLimitDuration
Describes duration over which Rate Limit policy will be applied. Applies only when ruleType is RateLimitRule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: OneMin, FiveMins

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RateLimitThreshold
Describes rate limit threshold. Applies only when ruleType is RateLimitRule.Accepted range for this value is 1 - 5000.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleType
Describes type of rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: MatchRule, RateLimitRule

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
State variable of the custom rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, Enabled

Required: False
Position: Named
Default value: Enabled
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCustomRule

## NOTES

## RELATED LINKS
