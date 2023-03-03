---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject
schema: 2.0.0
---

# New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject

## SYNOPSIS
Create an in-memory object for AlertRuleAnyOfOrLeafCondition.

## SYNTAX

```
New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject [-AnyOf <IAlertRuleLeafCondition[]>]
 [-ContainsAny <String[]>] [-Equal <String>] [-Field <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AlertRuleAnyOfOrLeafCondition.

## EXAMPLES

### Example 1: Create alert rule condition
```powershell
New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
```

Create alert rule condition

### Example 2: Create alert rule condition with leaf condition
```powershell
$any=New-AzActivityLogAlertAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -AnyOf $any
```

Create alert rule condition with leaf condition

## PARAMETERS

### -AnyOf
An Activity Log Alert rule condition that is met when at least one of its member leaf conditions are met.
To construct, see NOTES section for ANYOF properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.IAlertRuleLeafCondition[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.AlertRuleAnyOfOrLeafCondition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ANYOF <IAlertRuleLeafCondition[]>`: An Activity Log Alert rule condition that is met when at least one of its member leaf conditions are met.
  - `[ContainsAny <String[]>]`: The value of the event's field will be compared to the values in this array (case-insensitive) to determine if the condition is met.
  - `[Equal <String>]`: The value of the event's field will be compared to this value (case-insensitive) to determine if the condition is met.
  - `[Field <String>]`: The name of the Activity Log event's field that this condition will examine.         The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties'.

## RELATED LINKS

