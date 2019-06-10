# Monitor

### ActivityLog

`Get-AzActivityLog` -> alias `Get-AzLog`

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzActivityLog` | No | - `-Filter` should be replaced by more specific parameters or by a querying syntax |
| `Get-AzTenantActivityLog` | Yes | |

### ActionGroup

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzActionGroup` | No | - Correct |
| `New-AzActionGroup` | No | - Create just like the Set variant.<br>- The original code also have a `New-AzActionGroup` but it is a local object creation used only for `ActivityLogAlerts` |
| `Set-AzActionGroup` | No | - The original expects ActionGroupReceiver<br>- The original aggregates different types of receiver in just one |
| `Update-AzActionGroup` | Yes | |
| `Remove-AzActionGroup` | No | - Correct |
| `New-AzActionGroupReceiver` | X | - Create in-memory receiver information. It can be an eamail, sms or webhook receiver. Used in `Set-AzActionGroup` |
| `Enable-AzActionGroupReceiver` | Yes | |

### ActivityLogAlert

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzActivityLogAlert` | No | - Correct |
| `New-AzActivityLogAlert` | Yes | - Like the Set variant |
| `Set-AzActivityLogAlert` | No | - Change `-ActionsActionGroup`, `-ConditionAllOf` and `-Enabled`<br>- `ConditionAllOf` not expanded because it is an array |
| `Update-AzActivityLogAlert` | Yes | - This operation is used in `Disable/Update-AzActivityLogAlert` cmdlets |
| `Remove-AzActivityLogAlert` | No | |
| `New-AzActivityLogAlertCondition` | X | - Create in-memory object to be used in `Set-AzActivityLogAlert`, parameter `-Condition` |
| `Disable-AzActivityLogAlert` | X | - Uses the non existant `Update-AzActivityLogAlert`|
| `Enable-AzActivityLogAlert` | X | - Uses the non existant `Update-AzActivityLogAlert` |

### Metric

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzMetric` | No |  - `-Filter` should be replaced by more specific parameters or by a querying syntax (the original uses the cmdlet `New-AzMetricFilter` for that)<br>- `-Aggregation` is string but the original has a object type `AggregationType` from another resource spec (`MetricDefinition`) |
| `New-AzMetric` | New | |
| `Get-AzMetricBaseline` | Yes | |
| `Get-AzMetricNamespace` | Yes | |
| `Get-AzMetricDefinition` | No | - No `-MetricName` |
| `New-AzMetricFilter` | X | - Format in a string syntax format the parameters. Results are passed to `-MetricFilter` in `Get-AzMetric` |

### MetricAlert (from metric alerts V2 API) or AlertRule (old API)

`Get-AzMetricAlert` -> alias `Get-AzMetricAlertRuleV2`
`New-AzMetricAlert` -> alias `Add-AzMetricAlertRuleV2`
`Remove-AzMetricAlert` -> alias `Remove-AzMetricAlertRuleV2`
`New-AzAlertRule` -> alias `Add-AzMetricAlertRule`

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzAlertRuleIncident` | Yes | |
| `Update-AzMetricAlert`<br>`Set-AzMetricAlert` | Yes | - Represents the new V2 metric alerts API |
| `Update-AzAlertRule`<br>`Set-AzAlertRule` | Yes | - Represents the old alerts API |
| `New-AzAlertRule` | Yes | - In the original is used by `Add-AzMetricAlertRule` and `Add-AzWebtestAlertRule` |
| `Add-AzMetricAlertRule` and `Add-AzWebtestAlertRule` | X | - Both use `AlertRule` API giving different conditions |
| `New-AzAlertRuleEmail`<br>`New-AzAlertRuleWebhook` | X | - Create an alert rule action |
| `New-AzMetricAlertRuleV2Criteria` | X | - Create and metric alert rule criteria (condition parameter in `Add-AzMetricAlertRuleV2`) |
| `New-AzMetricAlertRuleV2DimensionSelection` | X | - Create metric dimensions for `New-AzMetricAlertRuleV2Criteria` |

### LogProfile

`Set-AzLogProfile` -> alias `Add-AzLogProfile`

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzLogProfile` | No | - Correct |
| `Remove-AzLogProfile` | No | - Correct |
| `Set-AzLogProfile` | No | - `Add-AzLogProfile` |
| `New-AzLogProfile` | Yes | |
| `Update-AzLogProfile` | Yes | |

### Autoscale

`Set-AzAutoscaleSetting` -> alias `Add-AzAutoscaleSetting`

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzAutoscaleSetting` | No | - Missing `-DetailedOutput` |
| `Remove-AzAutoscaleSetting` | No | - Correct |
| `Set-AzAutoscaleSetting` | No | - `Add-AzAutoscaleSetting` |
| `New-AzAutoscaleSetting` | Yes | |
| `Update-AzAutoscaleSetting` | Yes | |
| `New-AzAutoscaleNotification` | X | - Create in-memory object used in `Add-AzAutoscaleSetting` |
| `New-AzAutoscaleProfile` | X | - Create in-memory object used in `Add-AzAutoscaleSetting` |
| `New-AzAutoscaleRule` | X | - Create in-memory object used in `New-AzAutoscaleProfile` |
| `New-AzAutoscaleWebhook` | X | - Create in-memory object used in `New-AzAutoscaleNotification` |

### ScheduledQuery

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `New-AzScheduledQueryRuleAlertingAction` | X | - Create in-memory object used in `Set-AzScheduleQueryRule`, parameter `-Action` |
| `New-AzScheduledQueryRuleAznsActionGroup` | X | - Create in-memory object used in `New-AzScheduledQueryRuleAlertingAction`, parameter `-AznsAction`|
| `New-AzScheduledQueryRuleLogMetricTrigger` | X | - Create in-memory object used in `AzScheduledQueryRuleTriggerCondition`, parameter `-MetricTrigger` |
| `New-AzScheduledQueryRuleSchedule` | X | - Create in-memory object used in `Set-AzScheduleQueryRule`, parameter `-Schedule` |
| `New-AzScheduledQueryRuleSource` | X | - Create in-memory object used in `Set-AzScheduleQueryRule`, parameter `-Source` |
| `New-AzScheduledQueryRuleTriggerCondition` | X | - Create in-memory object used in `New-AzScheduledQueryRuleAlertingAction`, parameter `-Trigger` |

### Others

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzBaseline` | Yes | |
| `Get-AzEventCategory` | Yes | |
| `Get-AzDiagnosticSettingsCategory` | Yes | - The `List` operation is used in the old `Set-AzDiagnosticSetting` to get the available categories for a specific resource |
| `New-AzDiagnosticSetting` | Yes | |
| `Get-AzAlertHistory` | X | - Uses `ActivityLogs` API to retrieve only logs about alerts |
| `Get-AzAutoscaleHistory` | X | - Uses `ActivityLogs` API to retrieve only logs about autoscale settings |
