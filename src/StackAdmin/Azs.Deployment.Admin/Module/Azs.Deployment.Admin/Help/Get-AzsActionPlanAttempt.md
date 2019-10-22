---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Get-AzsActionPlanAttempt

## SYNOPSIS
Gets or lists the action plan attempt

## SYNTAX

```
Get-AzsActionPlanAttempt [-PlanId] <String> [-OperationId] <String> [[-AttemptNo] <Int32>] [-AsJson]
 [<CommonParameters>]
```

## DESCRIPTION
Gets or lists the action plan attempts

## EXAMPLES

### Example 1
```powershell
PS C:/> Get-AzsActionPlanAttempt -PlanId $planId -OperationId $operationId -AsJson
```

Gets or lists the action plan attempt properties for plan with id $planId and operation Id $operationId.

## PARAMETERS

### -PlanId
Plan Id of the action plan

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
Operation Id of the action plan attempt

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttemptNo
Action plan attempt number

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: 0
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
