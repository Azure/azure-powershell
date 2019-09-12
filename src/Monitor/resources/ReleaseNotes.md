# Release notes for module Az.Monitor

## Version x.x.x.-preview

## What's new

All in-memory create cmdlets were removed in favor of flatten cmdlets. Some cmdlets used flatten parameters and others require the creation of a HashTable.

### Notes

* `New-AzActionGroup` is the previously known `Set-AzActionGroup`. The `New-AzActionGroup` that existed before and were only used to create an in-memory object for Activity Log Alerts is now removed.
* The `MetricAlertRuleV2` set of cmdlets are now known as just `MetricAlert` and the old `MetricAlertRule` ones are now the `AlertRule` set of cmdlets.

## Future enhancements

Right now, the `Update-AzMetricAlert` and `Update-AzAlertRule` update existing resources but require that either more than a single parameter is provided or a hash table with multiple parameters.
Future versions will include a more complete Update with the ability to update fewer parameters.

## Breaking changes

## Examples

## Supported cmdlets

Disable-AzActivityLogAlert
Enable-AzActivityLogAlert
Get-AzActionGroup
Get-AzActivityLog
Get-AzActivityLogAlert
Get-AzAlertRule
Get-AzAlertRuleIncident
Get-AzAutoscaleSetting
Get-AzDiagnosticSetting
Get-AzDiagnosticSettingCategory
Get-AzEventCategory
Get-AzLogProfile
Get-AzMetric
Get-AzMetricAlert
Get-AzMetricAlertStatus
Get-AzMetricBaseline
Get-AzMetricDefinition
Get-AzMetricNamespace
Get-AzScheduledQueryRule
Get-AzTenantActivityLog
Get-AzVMInsightOnboardingStatus
Invoke-AzCalculateMetricBaseline
New-AzActionGroup
New-AzActivityLogAlert
New-AzAlertRule
New-AzAutoscaleSetting
New-AzDiagnosticSetting
New-AzLogProfile
New-AzMetricAlert
New-AzScheduledQueryRule
Remove-AzActionGroup
Remove-AzActivityLogAlert
Remove-AzAlertRule
Remove-AzAutoscaleSetting
Remove-AzDiagnosticSetting
Remove-AzLogProfile
Remove-AzMetricAlert
Remove-AzScheduledQueryRule
Set-AzActionGroup
Set-AzActivityLogAlert
Set-AzAutoscaleSetting
Set-AzDiagnosticSetting
Set-AzLogProfile
Set-AzScheduledQueryRule
Update-AzAlertRule
Update-AzAutoscaleSetting
Update-AzLogProfile
Update-AzMetricAlert
Update-AzScheduledQueryRule
