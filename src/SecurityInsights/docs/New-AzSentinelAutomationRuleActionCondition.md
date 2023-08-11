---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelautomationruleactioncondition
schema: 2.0.0
---

# New-AzSentinelAutomationRuleActionCondition

## SYNOPSIS
Create the automation rule action condition.

## SYNTAX

### CreatePropertyArrayChanged (Default)
```
New-AzSentinelAutomationRuleActionCondition -Type <String> [-ArrayChangeType <String>] [-ArrayType <String>]
 [<CommonParameters>]
```

### CreateProperty
```
New-AzSentinelAutomationRuleActionCondition -Type <String> [-Operator <String>] [-PropertyName <String>]
 [-PropertyValue <String[]>] [<CommonParameters>]
```

### CreatePropertyChanged
```
New-AzSentinelAutomationRuleActionCondition -Type <String> [-ChangedPropertyName <Object>]
 [-ChangeType <String>] [-Operator <String>] [-PropertyValue <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create the automation rule action condition.

## EXAMPLES

### Example 1: Create a PropertyChanged automation rule condition object for automation rule
```powershell
New-AzSentinelAutomationRuleActionCondition -Type PropertyChanged -ChangedPropertyName IncidentOwner
```

```output
ConditionPropertyChangeType : 
ConditionPropertyName       : IncidentOwner
ConditionPropertyOperator   : 
ConditionPropertyValue      : 
ConditionType               : PropertyChanged
```

This command creates an automation rule condition object for automation rule

## PARAMETERS

### -ArrayChangeType
ConditionPropertyChangeType

```yaml
Type: System.String
Parameter Sets: CreatePropertyArrayChanged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArrayType
ConditionPropertyArrayType

```yaml
Type: System.String
Parameter Sets: CreatePropertyArrayChanged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangedPropertyName
ConditionPropertyName

```yaml
Type: System.Object
Parameter Sets: CreatePropertyChanged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeType
ConditionPropertyChangeType

```yaml
Type: System.String
Parameter Sets: CreatePropertyChanged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operator
ConditionPropertyOperator

```yaml
Type: System.String
Parameter Sets: CreateProperty, CreatePropertyChanged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertyName
ConditionPropertyName

```yaml
Type: System.String
Parameter Sets: CreateProperty
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertyValue
ConditionPropertyValue

```yaml
Type: System.String[]
Parameter Sets: CreateProperty, CreatePropertyChanged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the automation rule action.
ConditionType

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAutomationRuleCondition

## NOTES

## RELATED LINKS

