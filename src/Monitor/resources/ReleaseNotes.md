# Release notes for module Az.Monitor

## Version x.x.x.-preview

## What's new

All in-memory create cmdlets were removed in favor of `flattened` cmdlet parameters. This allows you to specify the properties of many objects inline, and for others, provide a simple inline hashtable like ```@{Property1="Value1"}```.

### Notes

* `New-AzActionGroup` is the previously known `Set-AzActionGroup`. The `New-AzActionGroup` that existed before and was only used to create an in-memory object for Activity Log Alerts is now removed.
* The cmdlet noun `MetricAlertRuleV2` was changed to `MetricAlert` and the old `MetricAlertRule` cmdlet noun was changed to `AlertRule`.

## Future enhancements

The `Update-AzMetricAlert` and `Update-AzAlertRule` cmdlets will be simplified in an upcoming release.  In this release, these cmdlets require users to specify the entire configuration of the MetricAlert or AlertRule in order to make changes to the existing resource. They also require inline Hashtables for some parameters.
Future versions will include a PATCH-style Update functionality, which will allow changing individual properties. Parameter types will also be simplified.

## Supported cmdlets

- Disable-AzActivityLogAlert
- Enable-AzActivityLogAlert
- Get-AzActionGroup
- Get-AzActivityLog
- Get-AzActivityLogAlert
- Get-AzAlertRule
- Get-AzAlertRuleIncident
- Get-AzAutoscaleSetting
- Get-AzDiagnosticSetting
- Get-AzDiagnosticSettingCategory
- Get-AzEventCategory
- Get-AzLogProfile
- Get-AzMetric
- Get-AzMetricAlert
- Get-AzMetricAlertStatus
- Get-AzMetricBaseline
- Get-AzMetricDefinition
- Get-AzMetricNamespace
- Get-AzScheduledQueryRule
- Get-AzTenantActivityLog
- Get-AzVMInsightOnboardingStatus
- Invoke-AzCalculateMetricBaseline
- New-AzActionGroup
- New-AzActivityLogAlert
- New-AzAlertRule
- New-AzAutoscaleSetting
- New-AzDiagnosticSetting
- New-AzLogProfile
- New-AzMetricAlert
- New-AzScheduledQueryRule
- Remove-AzActionGroup
- Remove-AzActivityLogAlert
- Remove-AzAlertRule
- Remove-AzAutoscaleSetting
- Remove-AzDiagnosticSetting
- Remove-AzLogProfile
- Remove-AzMetricAlert
- Remove-AzScheduledQueryRule
- Set-AzActionGroup
- Set-AzActivityLogAlert
- Set-AzAutoscaleSetting
- Set-AzDiagnosticSetting
- Set-AzLogProfile
- Set-AzScheduledQueryRule
- Update-AzAlertRule
- Update-AzAutoscaleSetting
- Update-AzLogProfile
- Update-AzMetricAlert
- Update-AzScheduledQueryRule

## Removed cmdlets

- Add-AzWebtestAlertRule
- Get-AzAlertHistory
- Get-AzAutoscaleHistory
- New-AzActionGroupReceiver
- New-AzActivityLogAlertCondition
- New-AzAlertRuleEmail
- New-AzAlertRuleWebhook
- New-AzAutoscaleNotification
- New-AzAutoscaleProfile
- New-AzAutoscaleRule
- New-AzAutoscaleWebhook
- New-AzMetricAlertRuleV2Criteria
- New-AzMetricAlertRuleV2DimensionSelection
- New-AzMetricFilter
- New-AzScheduledQueryRuleAlertingAction
- New-AzScheduledQueryRuleAznsActionGroup
- New-AzScheduledQueryRuleLogMetricTrigger
- New-AzScheduledQueryRuleSchedule
- New-AzScheduledQueryRuleSource
- New-AzScheduledQueryRuleTriggerCondition