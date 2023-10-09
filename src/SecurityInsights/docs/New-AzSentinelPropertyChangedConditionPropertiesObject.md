---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/Az.SecurityInsights/new-azsentinelpropertychangedconditionpropertiesobject
schema: 2.0.0
---

# New-AzSentinelPropertyChangedConditionPropertiesObject

## SYNOPSIS
Create an in-memory object for PropertyChangedConditionProperties.

## SYNTAX

```
New-AzSentinelPropertyChangedConditionPropertiesObject [-ConditionPropertyChangeType <String>]
 [-ConditionPropertyName <String>] [-ConditionPropertyOperator <String>] [-ConditionPropertyValue <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PropertyChangedConditionProperties.

## EXAMPLES

### Example 1: Create a PropertyChanged automation rule condition object for automation rule
```powershell
New-AzSentinelPropertyChangedConditionPropertiesObject -ConditionPropertyName IncidentStatus
```

```output
ConditionPropertyChangeType : 
ConditionPropertyName       : IncidentStatus
ConditionPropertyOperator   : 
ConditionPropertyValue      : 
ConditionType               : PropertyChanged
```

This command creates an automation rule condition object for automation rule.

## PARAMETERS

### -ConditionPropertyChangeType


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

### -ConditionPropertyName


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

### -ConditionPropertyOperator


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

### -ConditionPropertyValue


```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.PropertyChangedConditionProperties

## NOTES

## RELATED LINKS

