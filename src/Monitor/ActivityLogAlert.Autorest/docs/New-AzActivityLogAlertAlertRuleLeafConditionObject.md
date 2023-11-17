---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzActivityLogAlertAlertRuleLeafConditionObject
schema: 2.0.0
---

# New-AzActivityLogAlertAlertRuleLeafConditionObject

## SYNOPSIS
Create an in-memory object for AlertRuleLeafCondition.

## SYNTAX

```
New-AzActivityLogAlertAlertRuleLeafConditionObject [-ContainsAny <String[]>] [-Equal <String>]
 [-Field <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AlertRuleLeafCondition.

## EXAMPLES

### Example 1: Create Alert rule leaf condition
```powershell
New-AzActivityLogAlertAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
```

Create Alert rule leaf condition

## PARAMETERS

### -ContainsAny
The value of the event's field will be compared to the values in this array (case-insensitive) to determine if the condition is met.

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

### -Equal
The value of the event's field will be compared to this value (case-insensitive) to determine if the condition is met.

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

### -Field
The name of the Activity Log event's field that this condition will examine.
        The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties'.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.AlertRuleLeafCondition

## NOTES

ALIASES

## RELATED LINKS

