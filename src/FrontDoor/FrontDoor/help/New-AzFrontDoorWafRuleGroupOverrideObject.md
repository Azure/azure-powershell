---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafrulegroupoverrideobject
schema: 2.0.0
---

# New-AzFrontDoorWafRuleGroupOverrideObject

## SYNOPSIS
Create an in-memory object for ManagedRuleGroupOverride.

## SYNTAX

```
New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName <String> [-Exclusion <IManagedRuleExclusion[]>]
 [-ManagedRuleOverride <IManagedRuleOverride[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedRuleGroupOverride.

## EXAMPLES

### Example 1: Create RuleGroupOverride Object for WAF policy creation
```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log

New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2
```

```output
Exclusion ManagedRuleOverride                                                                              RuleGroupName
--------- -------------------                                                                              -------------
          {{…                                                                                              SQLI
```

Create a RuleGroupOverride Object

## PARAMETERS

### -Exclusion
Describes the exclusions that are applied to all rules in the group.

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

### -ManagedRuleOverride
List of rules that will be disabled.
If none specified, all rules in the group will be disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleOverride[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleGroupName
Describes the managed rule group to override.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleGroupOverride

## NOTES

## RELATED LINKS
