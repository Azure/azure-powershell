---
external help file:
Module Name: Az.AlertsManagement
online version: https://learn.microsoft.com/powershell/module/az./new-AzPrometheusRuleObject
schema: 2.0.0
---

# New-AzPrometheusRuleObject

## SYNOPSIS
Create an in-memory object for PrometheusRule.

## SYNTAX

```
New-AzPrometheusRuleObject -Expression <String> [-Action <IPrometheusRuleGroupAction[]>] [-Alert <String>]
 [-Annotation <IPrometheusRuleAnnotations>] [-Enabled <Boolean>] [-For <String>]
 [-Label <IPrometheusRuleLabels>] [-Record <String>] [-ResolveConfigurationAutoResolved <Boolean>]
 [-ResolveConfigurationTimeToResolve <String>] [-Severity <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrometheusRule.

## EXAMPLES

### Example 1:Create an in-memory object for PrometheusRule.
```powershell
 new-AzPrometheusRuleObject -Alert "Billing_Processing_Very_Slow" -Expression "job_type:billing_jobs_duration_seconds:99p5m > 30" -Severity 2 -For PT5M
```

```output
Alert                        Enabled Expression                                        For  Record Severity
-----                        ------- ----------                                        ---  ------ --------
Billing_Processing_Very_Slow         job_type:billing_jobs_duration_seconds:99p5m > 30 PT5M        2
```

Create an in-memory object for PrometheusRule.

## PARAMETERS

### -Action
The array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
Only relevant for alerts.
To construct, see NOTES section for ACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.IPrometheusRuleGroupAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Alert
the name of the alert rule.

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

### -Annotation
annotations for rule group.
Only relevant for alerts.
To construct, see NOTES section for ANNOTATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.IPrometheusRuleAnnotations
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
the flag that indicates whether the Prometheus rule is enabled.

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

### -Expression
the expression to run for the rule.

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

### -For
the amount of time alert must be active before firing.
Only relevant for alerts.

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

### -Label
labels for rule group.
Only relevant for alerts.
To construct, see NOTES section for LABEL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.IPrometheusRuleLabels
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Record
the name of the recording rule.

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

### -ResolveConfigurationAutoResolved
the flag that indicates whether or not to auto resolve a fired alert.

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

### -ResolveConfigurationTimeToResolve
the duration a rule must evaluate as healthy before the fired alert is automatically resolved represented in ISO 8601 duration format.
Should be between 1 and 15 minutes.

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

### -Severity
the severity of the alerts fired by the rule.
Only relevant for alerts.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.Alerts.Models.Api20210722Preview.PrometheusRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ACTION <IPrometheusRuleGroupAction[]>`: The array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved. Only relevant for alerts.
  - `[ActionGroupId <String>]`: The resource id of the action group to use.
  - `[ActionProperty <IPrometheusRuleGroupActionProperties>]`: The properties of an action group object.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

`ANNOTATION <IPrometheusRuleAnnotations>`: annotations for rule group. Only relevant for alerts.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`LABEL <IPrometheusRuleLabels>`: labels for rule group. Only relevant for alerts.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

