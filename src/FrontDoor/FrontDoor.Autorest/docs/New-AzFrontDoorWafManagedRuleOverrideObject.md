---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafmanagedruleoverrideobject
schema: 2.0.0
---

# New-AzFrontDoorWafManagedRuleOverrideObject

## SYNOPSIS
Create an in-memory object for ManagedRuleOverride.

## SYNTAX

```
New-AzFrontDoorWafManagedRuleOverrideObject -RuleId <String> [-Action <String>] [-Disabled]
 [-Exclusion <IManagedRuleExclusion[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedRuleOverride.

## EXAMPLES

### Example 1: Create PSAzureManagedRuleOverride Object for managed WAF rule group override object creation.
```powershell
New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
```

```output
Action EnabledState Exclusion RuleId
------ ------------ --------- ------
Log                           942250
```

Create PSAzureManagedRuleOverride Object for managed WAF rule group override object creation.

## PARAMETERS

### -Action
Describes the override action to be applied when rule matches.

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

### -Disabled
Describes if the managed rule is in enabled or disabled state.
Defaults to Disabled if not specified.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exclusion
Describes the exclusions that are applied to this specific rule.

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

### -RuleId
Identifier for the managed rule.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleOverride

## NOTES

## RELATED LINKS

