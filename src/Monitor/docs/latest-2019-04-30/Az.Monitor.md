---
Module Name: Az.Monitor
Module Guid: 8af1772b-37e1-433d-78ad-cafc09b9763e
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.monitor
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Monitor Module
## Description
Microsoft Azure PowerShell: Monitor cmdlets

## Az.Monitor Cmdlets
### [Enable-AzActionGroupReceiver](Enable-AzActionGroupReceiver.md)
Enable a receiver in an action group.
This changes the receiver's status from Disabled to Enabled.
This operation is only supported for Email or SMS receivers.

### [Get-AzActionGroup](Get-AzActionGroup.md)
Get an action group.

### [Get-AzActivityLog](Get-AzActivityLog.md)
Provides the list of records from the activity logs.

### [Get-AzActivityLogAlert](Get-AzActivityLogAlert.md)
Get an activity log alert.

### [Get-AzAlertRule](Get-AzAlertRule.md)
Gets an alert rule

### [Get-AzAlertRuleIncident](Get-AzAlertRuleIncident.md)
Gets an incident associated to an alert rule

### [Get-AzAutoscaleSetting](Get-AzAutoscaleSetting.md)
Gets an autoscale setting

### [Get-AzBaseline](Get-AzBaseline.md)
**Lists the metric baseline values for a resource**.

### [Get-AzDiagnosticSetting](Get-AzDiagnosticSetting.md)
Gets the active diagnostic settings for the specified resource.

### [Get-AzDiagnosticSettingsCategory](Get-AzDiagnosticSettingsCategory.md)
Gets the diagnostic settings category for the specified resource.

### [Get-AzEventCategory](Get-AzEventCategory.md)
Get the list of available event categories supported in the Activity Logs Service.<br>The current list includes the following: Administrative, Security, ServiceHealth, Alert, Recommendation, Policy.

### [Get-AzLogProfile](Get-AzLogProfile.md)
Gets the log profile.

### [Get-AzMetric](Get-AzMetric.md)
**Lists the metric values for a resource**.

### [Get-AzMetricAlert](Get-AzMetricAlert.md)
Retrieve an alert rule definition.

### [Get-AzMetricAlertsStatus](Get-AzMetricAlertsStatus.md)
Retrieve an alert rule status.

### [Get-AzMetricAlertStatus](Get-AzMetricAlertStatus.md)
Retrieve an alert rule status.

### [Get-AzMetricBaseline](Get-AzMetricBaseline.md)
**Gets the baseline values for a specific metric**.

### [Get-AzMetricDefinition](Get-AzMetricDefinition.md)
Lists the metric definitions for the resource.

### [Get-AzMetricNamespace](Get-AzMetricNamespace.md)
Lists the metric namespaces for the resource.

### [Get-AzScheduledQueryRule](Get-AzScheduledQueryRule.md)
Gets an Log Search rule

### [Get-AzTenantActivityLog](Get-AzTenantActivityLog.md)
Gets the Activity Logs for the Tenant.<br>Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).<br>One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.

### [Get-AzVMInsightOnboardingStatus](Get-AzVMInsightOnboardingStatus.md)
Retrieves the VM Insights onboarding status for the specified resource or resource scope.

### [Invoke-AzCalculateMetricBaseline](Invoke-AzCalculateMetricBaseline.md)
**Lists the baseline values for a resource**.

### [New-AzActionGroup](New-AzActionGroup.md)
Create a new action group or update an existing one.

### [New-AzActivityLogAlert](New-AzActivityLogAlert.md)
Create a new activity log alert or update an existing one.

### [New-AzAlertRule](New-AzAlertRule.md)
Creates or updates an alert rule.

### [New-AzAutoscaleSetting](New-AzAutoscaleSetting.md)
Creates or updates an autoscale setting.

### [New-AzDiagnosticSetting](New-AzDiagnosticSetting.md)
Creates or updates diagnostic settings for the specified resource.

### [New-AzLogProfile](New-AzLogProfile.md)
Create or update a log profile in Azure Monitoring REST API.

### [New-AzMetric](New-AzMetric.md)
**Post the metric values for a resource**.

### [New-AzMetricAlert](New-AzMetricAlert.md)
Create or update an metric alert definition.

### [New-AzScheduledQueryRule](New-AzScheduledQueryRule.md)
Creates or updates an log search rule.

### [Remove-AzActionGroup](Remove-AzActionGroup.md)
Delete an action group.

### [Remove-AzActivityLogAlert](Remove-AzActivityLogAlert.md)
Delete an activity log alert.

### [Remove-AzAlertRule](Remove-AzAlertRule.md)
Deletes an alert rule

### [Remove-AzAutoscaleSetting](Remove-AzAutoscaleSetting.md)
Deletes and autoscale setting

### [Remove-AzDiagnosticSetting](Remove-AzDiagnosticSetting.md)
Deletes existing diagnostic settings for the specified resource.

### [Remove-AzLogProfile](Remove-AzLogProfile.md)
Deletes the log profile.

### [Remove-AzMetricAlert](Remove-AzMetricAlert.md)
Delete an alert rule definition.

### [Remove-AzScheduledQueryRule](Remove-AzScheduledQueryRule.md)
Deletes a Log Search rule

### [Set-AzActionGroup](Set-AzActionGroup.md)
Create a new action group or update an existing one.

### [Set-AzActivityLogAlert](Set-AzActivityLogAlert.md)
Create a new activity log alert or update an existing one.

### [Set-AzAlertRule](Set-AzAlertRule.md)
Creates or updates an alert rule.

### [Set-AzAutoscaleSetting](Set-AzAutoscaleSetting.md)
Creates or updates an autoscale setting.

### [Set-AzDiagnosticSetting](Set-AzDiagnosticSetting.md)
Creates or updates diagnostic settings for the specified resource.

### [Set-AzLogProfile](Set-AzLogProfile.md)
Create or update a log profile in Azure Monitoring REST API.

### [Set-AzMetricAlert](Set-AzMetricAlert.md)
Create or update an metric alert definition.

### [Set-AzScheduledQueryRule](Set-AzScheduledQueryRule.md)
Creates or updates an log search rule.

### [Update-AzActionGroup](Update-AzActionGroup.md)
Updates an existing action group's tags.
To update other fields use the CreateOrUpdate method.

### [Update-AzActivityLogAlert](Update-AzActivityLogAlert.md)
Updates an existing ActivityLogAlertResource's tags.
To update other fields use the CreateOrUpdate method.

### [Update-AzAlertRule](Update-AzAlertRule.md)
Updates an existing AlertRuleResource.
To update other fields use the CreateOrUpdate method.

### [Update-AzAutoscaleSetting](Update-AzAutoscaleSetting.md)
Updates an existing AutoscaleSettingsResource.
To update other fields use the CreateOrUpdate method.

### [Update-AzLogProfile](Update-AzLogProfile.md)
Updates an existing LogProfilesResource.
To update other fields use the CreateOrUpdate method.

### [Update-AzMetricAlert](Update-AzMetricAlert.md)
Update an metric alert definition.

### [Update-AzScheduledQueryRule](Update-AzScheduledQueryRule.md)
Update log search Rule.

