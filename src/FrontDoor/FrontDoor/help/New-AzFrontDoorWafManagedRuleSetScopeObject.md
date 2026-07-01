---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafmanagedrulesetscopeobject
schema: 2.0.0
---

# New-AzFrontDoorWafManagedRuleSetScopeObject

## SYNOPSIS
Create an in-memory object for ManagedRuleSetScope.

## SYNTAX

```
New-AzFrontDoorWafManagedRuleSetScopeObject -RuleSetType <String> -RuleSetVersion <String>
 [-RuleGroupScope <IRuleGroupScope[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedRuleSetScope.

## EXAMPLES

### Example 1: Create a WAF managed rule set scope object
```powershell
$ruleScope = New-AzFrontDoorWafRuleScopeObject -RuleId 942100
$ruleGroupScope = New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName SQLI -RuleScope $ruleScope
New-AzFrontDoorWafManagedRuleSetScopeObject -RuleSetType DefaultRuleSet -RuleSetVersion 1.0 -RuleGroupScope $ruleGroupScope
```

```output
RuleGroupScope RuleSetType    RuleSetVersion
-------------- -----------    --------------
{SQLI}         DefaultRuleSet 1.0
```

Create a WAF managed rule set scope object for the `DefaultRuleSet` rule set.
## PARAMETERS

### -RuleGroupScope
List of rule group scopes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRuleGroupScope[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetType
Defines the rule set type.
        Examples: DefaultRuleSet, Microsoft_DefaultRuleSet,
        Microsoft_BotManagerRuleSet, Microsoft_HTTPDDoSRuleSet, BotProtection.

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

### -RuleSetVersion
Defines the version of the rule set.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleSetScope

## NOTES

## RELATED LINKS
