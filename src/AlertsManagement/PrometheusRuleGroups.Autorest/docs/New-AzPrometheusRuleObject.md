---
external help file:
Module Name: Az.AlertsManagement
online version: https://learn.microsoft.com/powershell/module/Az.AlertsManagement/new-AzPrometheusRuleObject
schema: 2.0.0
---

# New-AzPrometheusRuleObject

## SYNOPSIS
Create an in-memory object for PrometheusRule.

## SYNTAX

```
New-AzPrometheusRuleObject -Expression <String> [-Action <IPrometheusRuleGroupAction[]>] [-Alert <String>]
 [-Annotation <IPrometheusRuleAnnotations>] [-Enabled <Boolean>] [-For <TimeSpan>]
 [-Label <IPrometheusRuleLabels>] [-Record <String>] [-ResolveConfigurationAutoResolved <Boolean>]
 [-ResolveConfigurationTimeToResolve <TimeSpan>] [-Severity <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrometheusRule.

## EXAMPLES

### Example 1:  Create an in-memory object for PrometheusRule.
```powershell
New-AzPrometheusRuleObject -Record "job_type:billing_jobs_duration_seconds:99p5m" -Expression 'histogram_quantile(0.99, sum(rate(jobs_duration_seconds_bucket{service="billing-processing"}[5m])) by (job_type))'
```

```output
Alert Enabled Expression
----- ------- ----------
              histogram_quantile(0.99, sum(rate(jobs_duration_seconds_bucket{service="billing-processing"}[5m])) by (job_type))'
```

Create an in-memory object for PrometheusRule.

## PARAMETERS

### -Action
Actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
To construct, see NOTES section for ACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.Api20230301.IPrometheusRuleGroupAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Alert
Alert rule name.

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
The annotations clause specifies a set of informational labels that can be used to store longer additional information such as alert descriptions or runbook links.
The annotation values can be templated.
To construct, see NOTES section for ANNOTATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.Api20230301.IPrometheusRuleAnnotations
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Enable/disable rule.

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
The PromQL expression to evaluate.
https://prometheus.io/docs/prometheus/latest/querying/basics/.
Evaluated periodically as given by 'interval', and the result recorded as a new set of time series with the metric name as given by 'record'.

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
The amount of time alert must be active before firing.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
Labels to add or overwrite before storing the result.
To construct, see NOTES section for LABEL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.Api20230301.IPrometheusRuleLabels
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Record
Recorded metrics name.

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
Enable alert auto-resolution.

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
Alert auto-resolution timeout.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
The severity of the alerts fired by the rule.
Must be between 0 and 4.

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

### Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.Api20230301.PrometheusRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ACTION <IPrometheusRuleGroupAction[]>`: Actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
  - `[ActionGroupId <String>]`: The resource id of the action group to use.
  - `[ActionProperty <IPrometheusRuleGroupActionProperties>]`: The properties of an action group object.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

`ANNOTATION <IPrometheusRuleAnnotations>`: The annotations clause specifies a set of informational labels that can be used to store longer additional information such as alert descriptions or runbook links. The annotation values can be templated.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`LABEL <IPrometheusRuleLabels>`: Labels to add or overwrite before storing the result.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

