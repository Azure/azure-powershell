---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Get-AzsActionPlanOperation

## SYNOPSIS
Gets or lists action plan operations.

## SYNTAX

```
Get-AzsActionPlanOperation [-PlanId] <String> [[-OperationId] <String>] [-AsJson] [<CommonParameters>]
```

## DESCRIPTION
Gets or lists action plan operations.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsActionPlanOperation -PlanId $planId -AsJson
```

Gets the action plan operations for plan with id $planId.

## PARAMETERS

### -PlanId
Action Plan Identifier.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationId
Operation Id to retrieve the properties for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJson
Outputs the result in Json format.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
