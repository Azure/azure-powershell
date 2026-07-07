---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafrulegroupscopeobject
schema: 2.0.0
---

# New-AzFrontDoorWafRuleGroupScopeObject

## SYNOPSIS
Create an in-memory object for RuleGroupScope.

## SYNTAX

```
New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName <String> [-RuleScope <IRuleScope[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RuleGroupScope.

## EXAMPLES

### Example 1: Create a WAF managed rule group scope object
```powershell
$ruleScope = New-AzFrontDoorWafRuleScopeObject -RuleId 942100
New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName SQLI -RuleScope $ruleScope
```

```output
RuleGroupName RuleScope
------------- ---------
SQLI          {942100}
```

Create a WAF managed rule group scope object for the `SQLI` rule group and rule `942100`.
## PARAMETERS

### -RuleGroupName
Defines the rule group name.

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

### -RuleScope
List of rule scopes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRuleScope[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RuleGroupScope

## NOTES

## RELATED LINKS
