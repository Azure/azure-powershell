---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorwafmanagedruleexclusionobject
schema: 2.0.0
---

# New-AzFrontDoorWafManagedRuleExclusionObject

## SYNOPSIS
Create an in-memory object for ManagedRuleExclusion.

## SYNTAX

```
New-AzFrontDoorWafManagedRuleExclusionObject -Operator <String> -Selector <String> -Variable <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedRuleExclusion.

## EXAMPLES

### Example 1: Create managed rule exclusion object for WAF managed rule sets, groups, or rules.
```powershell
New-AzFrontDoorWafManagedRuleExclusionObject -Variable QueryStringArgNames -Operator Equals -Selector "ParameterName"
```

```output
Operator Selector      Variable
-------- --------      --------
Equals   ParameterName QueryStringArgNames
```

Create managed rule exclusion object for WAF managed rule sets, groups, or rules.

## PARAMETERS

### -Operator
Comparison operator to apply to the selector when specifying which elements in the collection this exclusion applies to.

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

### -Selector
Selector value for which elements in the collection this exclusion applies to.

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

### -Variable
The variable type to be excluded.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleExclusion

## NOTES

## RELATED LINKS

