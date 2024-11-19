---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafcustomruleobject
schema: 2.0.0
---

# New-AzFrontDoorWafCustomRuleObject

## SYNOPSIS
Create an in-memory object for WebApplicationFirewallCustomRule.

## SYNTAX

```
New-AzFrontDoorWafCustomRuleObject -Action <String> -MatchCondition <IMatchCondition[]> -Priority <Int32>
 -RuleType <String> [-CustomRule <IGroupByUserSession[]>] [-EnabledState <String>] [-Name <String>]
 [-RateLimitDurationInMinutes <String>] [-RateLimitThreshold <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WebApplicationFirewallCustomRule.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Action
Type of Actions.

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

### -CustomRule
List of user session identifier group by clauses.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IGroupByUserSession[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnabledState
Describes if the custom rule is in enabled or disabled state.
Defaults to Enabled if not specified.

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

### -MatchCondition
List of match conditions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IMatchCondition[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource that is unique within a policy.
This name can be used to access the resource.

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

### -Priority
Priority of the rule.
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

### -RateLimitDurationInMinutes
Duration over which Rate Limit policy will be applied.
Applies only when ruleType is RateLimitRule.

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

### -RateLimitThreshold
Rate Limit threshold to apply in case ruleType is RateLimitRule.
Must be greater than or equal to 1.

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
The rule type.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.WebApplicationFirewallCustomRule

## NOTES

## RELATED LINKS

