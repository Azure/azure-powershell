---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafcustomruleobject
schema: 2.0.0
---

# New-AzFrontDoorWafCustomRuleObject

## SYNOPSIS
Create an in-memory object for CustomRule.

## SYNTAX

```
New-AzFrontDoorWafCustomRuleObject -Action <String> -MatchCondition <IMatchCondition[]> -Priority <Int32>
 -RuleType <String> [-EnabledState <String>] [-GroupByCustomRule <IGroupByVariable[]>] [-Name <String>]
 [-RateLimitDurationInMinutes <Int32?>] [-RateLimitThreshold <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomRule.

## EXAMPLES

### Example 1: Create CustomRule Object for WAF policy creation
```powershell
New-AzFrontDoorWafCustomRuleObject -Name "Rule1" -RuleType MatchRule -MatchCondition $matchCondition1 -Action Block -Priority 2
```

```output
Action                     : Block
EnabledState               : Enabled
GroupByCustomRule          :
MatchCondition             : {{
                               "selector": "Rules-Engine-Route-Forward",
                               "negateCondition": false,
                               "transforms": [ "LowerCase", "UpperCase" ]
                             }}
Name                       : Rule1
Priority                   : 2
RateLimitDurationInMinutes : 1
RateLimitThreshold         :
RuleType                   : MatchRule
```

Create a CustomRule Object

## PARAMETERS

### -Action
Describes what action to be applied when rule matches.

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

### -GroupByCustomRule
Describes the list of variables to group the rate limit requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IGroupByVariable[]
Parameter Sets: (All)
Aliases: CustomRule

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
Describes the name of the rule.

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

### -RateLimitDurationInMinutes
Time window for resetting the rate limit count.
Default is 1 minute.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RateLimitThreshold
Number of allowed requests per client within the time window.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.CustomRule

## NOTES

## RELATED LINKS

