---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Get-AzsActionPlan

## SYNOPSIS
Gets or lists the action plans.

## SYNTAX

```
Get-AzsActionPlan [[-PlanId] <String>] [-AsJson] [<CommonParameters>]
```

## DESCRIPTION
Gets or lists the action plans.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsActionPlan
```

Lists all the action plan under the subscription.

### EXAMPLE 2
```
Get-AzsActionPlan -PlanId $planId -AsJson
```

Gets the action plan properties for plan with Id $planId.

## PARAMETERS

### -PlanId
Action Plan Id to retrieve the properties for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
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
