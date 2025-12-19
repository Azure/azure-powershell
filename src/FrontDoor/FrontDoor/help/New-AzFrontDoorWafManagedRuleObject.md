---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafmanagedruleobject
schema: 2.0.0
---

# New-AzFrontDoorWafManagedRuleObject

## SYNOPSIS
Create an in-memory object for ManagedRuleSet.

## SYNTAX

```
New-AzFrontDoorWafManagedRuleObject -Type <String> -Version <String> [-Exclusion <IManagedRuleExclusion[]>]
 [-RuleGroupOverride <IManagedRuleGroupOverride[]>] [-RuleSetAction <String>] [-Action <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedRuleSet.

## EXAMPLES

### Example 1: Create ManagedRule Object for WAF policy creation
```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log
$override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2

$ruleOverride3 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "941280" -Action Log
$override2 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName XSS -ManagedRuleOverride $ruleOverride3

New-AzFrontDoorWafManagedRuleObject -Type DefaultRuleSet -Version "preview-0.1" -RuleGroupOverride $override1,$override2
```

```output
Exclusion         :
RuleGroupOverride : {{
                      "ruleGroupName": "SQLI",
                      "rules": [
                        {
                          "ruleId": "942250",
                          "action": "Log"
                        },
                        {
                          "ruleId": "942251",
                          "action": "Log"
                        }
                      ]
                    }, {
                      "ruleGroupName": "XSS",
                      "rules": [
                        {
                          "ruleId": "941280",
                          "action": "Log"
                        }
                      ]
                    }}
RuleSetAction     :
Type              : DefaultRuleSet
Version           : preview-0.1
```

Create a ManagedRule Object

## PARAMETERS

### -Action

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

### -Exclusion
Describes the exclusions that are applied to all rules in the set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleGroupOverride
Defines the rule group overrides to apply to the rule set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleGroupOverride[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetAction
Defines the rule set action.

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

### -Type
Defines the rule set type to use.

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

### -Version
Defines the version of the rule set to use.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleSet

## NOTES

## RELATED LINKS
