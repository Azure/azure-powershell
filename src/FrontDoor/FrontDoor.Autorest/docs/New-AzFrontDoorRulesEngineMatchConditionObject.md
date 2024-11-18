---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorrulesenginematchconditionobject
schema: 2.0.0
---

# New-AzFrontDoorRulesEngineMatchConditionObject

## SYNOPSIS
Create an in-memory object for RulesEngineMatchCondition.

## SYNTAX

```
New-AzFrontDoorRulesEngineMatchConditionObject -RulesEngineMatchValue <String[]>
 -RulesEngineMatchVariable <String> -RulesEngineOperator <String> [-NegateCondition <Boolean>]
 [-Selector <String>] [-Transform <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RulesEngineMatchCondition.

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

### -NegateCondition
Describes if this is negate condition or not.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RulesEngineMatchValue
Match values to match against.
The operator will apply to each value in here with OR semantics.
If any of them match the variable with the given operator this match condition is considered a match.

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

### -RulesEngineMatchVariable
Match Variable.

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

### -RulesEngineOperator
Describes operator to apply to the match condition.

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
Name of selector in RequestHeader or RequestBody to be matched.

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

### -Transform
List of transforms.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineMatchCondition

## NOTES

## RELATED LINKS

