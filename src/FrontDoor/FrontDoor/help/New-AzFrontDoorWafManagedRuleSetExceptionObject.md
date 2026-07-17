---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafmanagedrulesetexceptionobject
schema: 2.0.0
---

# New-AzFrontDoorWafManagedRuleSetExceptionObject

## SYNOPSIS
Create an in-memory object for ManagedRuleSetException.

## SYNTAX

```
New-AzFrontDoorWafManagedRuleSetExceptionObject -MatchValue <String[]> -MatchVariable <String>
 -Scope <IManagedRuleSetScope[]> -ValueMatchOperator <String> [-Selector <String>]
 [-SelectorMatchOperator <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedRuleSetException.

## EXAMPLES

### Example 1: Create a WAF managed rule set exception object
```powershell
$ruleScope = New-AzFrontDoorWafRuleScopeObject -RuleId 942100
$ruleGroupScope = New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName SQLI -RuleScope $ruleScope
$managedRuleSetScope = New-AzFrontDoorWafManagedRuleSetScopeObject -RuleSetType DefaultRuleSet -RuleSetVersion 1.0 -RuleGroupScope $ruleGroupScope
New-AzFrontDoorWafManagedRuleSetExceptionObject -MatchVariable RequestHeaderNames -SelectorMatchOperator Equals -Selector User-Agent -ValueMatchOperator Equals -MatchValue curl -Scope $managedRuleSetScope
```

```output
MatchVariable      Selector   ValueMatchOperator MatchValue Scope
-------------      --------   ------------------ ---------- -----
RequestHeaderNames User-Agent Equals             {curl}     {DefaultRuleSet}
```

Create a WAF managed rule set exception object for requests with a `User-Agent` header value of `curl`.

## PARAMETERS

### -MatchValue
List of values to be matched with.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchVariable
The variable to be evaluated for excluding the request.

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

### -Scope
Scope(s) of the exception.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSetScope[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Selector
When matchVariable is a collection, operator used to specify which elements
        in the collection this exception applies to.
        Currently supported only for RequestHeaderNames.

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

### -SelectorMatchOperator
Comparison operator to apply to the selector when specifying which elements
        in the collection this exception applies to.

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

### -ValueMatchOperator
Comparison operator to apply to the value to be matched.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleSetException

## NOTES

## RELATED LINKS
