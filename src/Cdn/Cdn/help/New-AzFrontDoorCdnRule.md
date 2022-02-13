---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnrule
schema: 2.0.0
---

# New-AzFrontDoorCdnRule

## SYNOPSIS
Creates the rule.

## SYNTAX

```
New-AzFrontDoorCdnRule
 -Action <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdRuleAction]>
 [-Condition <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdRuleCondition]>]
 -ProfileName <String> -ResourceGroupName <String> -RuleSetName <String> -RuleName <String> -Order <Int32>
 [-MatchProcessingBehavior <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates the rule.

## EXAMPLES

### Example 1
```powershell
New-AzFrontDoorCdnRule -Action $action -Condition $condition -ProfileName $profileName -ResourceGroupName $resourceGroupName -RuleSetName $ruleSetName -RuleName $ruleName -Order $order
```

Creates the rule.

## PARAMETERS

### -Action
The set of actions for the delivery rule.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdRuleAction]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Condition
The set of conditions for the delivery rule.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdRuleCondition]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchProcessingBehavior
If this rule is a match should the rules engine continue running the remaining rules or stop.
If not present, defaults to Continue.

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

### -Order
The order in which the rules are applied for the endpoint.
Possible values {0,1,2,3,………}.
A rule with a lesser order will be applied before a rule with a greater order.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
The Azure Front Door profile name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Azure resource group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleName
The Azure Front Door rule name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetName
The Azure Front Door rule set name.

```yaml
Type: String
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdRule

## NOTES

## RELATED LINKS
