---
Module Name: Az.Monitor
Module Guid: 698c387c-bd6b-41c6-82ce-721f1ef39548
Download Help Link: https://docs.microsoft.com/powershell/module/az.monitor
Help Version: 4.0.4.0
Locale: en-US
---

# Az.Monitor Module
## Description
This topic displays help topics for the Azure Insights Cmdlets.

## Az.Monitor Cmdlets
### [Add-AzLogProfile](Add-AzLogProfile.md)
Creates a new activity log profile. This profile is used to either archive the activity log to an Azure storage account or stream it to an Azure event hub in the same subscription.

### [Add-AzMetricAlertRule](Add-AzMetricAlertRule.md)
Adds or updates a metric-based alert rule.

### [Add-AzMetricAlertRuleV2](Add-AzMetricAlertRuleV2.md)
Adds or updates a V2 (non-classic) metric-based alert rule.

### [Add-AzWebtestAlertRule](Add-AzWebtestAlertRule.md)
Adds or updates a webtest alert rule.

### [Get-AzActionGroup](Get-AzActionGroup.md)
Gets action group(s).

### [Get-AzActivityLog](Get-AzActivityLog.md)
Retrieve Activity Log events.

### [Get-AzActivityLogAlert](Get-AzActivityLogAlert.md)
Get an Activity Log Alert rule.

### [Get-AzAlertHistory](Get-AzAlertHistory.md)
Gets the history of classic alert rules.

### [Get-AzAlertRule](Get-AzAlertRule.md)
Gets classic alert rules.

### [Get-AzAutoscaleHistory](Get-AzAutoscaleHistory.md)
Gets the Autoscale history.

### [Get-AzAutoscalePredictiveMetric](Get-AzAutoscalePredictiveMetric.md)
get predictive autoscale metric future data

### [Get-AzAutoscaleSetting](Get-AzAutoscaleSetting.md)
Gets an autoscale setting

### [Get-AzDataCollectionRule](Get-AzDataCollectionRule.md)
Gets data collection rule(s).

### [Get-AzDataCollectionRuleAssociation](Get-AzDataCollectionRuleAssociation.md)
Gets data collection rule association(s).

### [Get-AzDiagnosticSetting](Get-AzDiagnosticSetting.md)
Gets the active diagnostic settings for the specified resource.

### [Get-AzDiagnosticSettingCategory](Get-AzDiagnosticSettingCategory.md)
Gets the diagnostic settings category for the specified resource.

### [Get-AzEventCategory](Get-AzEventCategory.md)
Get the list of available event categories supported in the Activity Logs Service.
The current list includes the following: Administrative, Security, ServiceHealth, Alert, Recommendation, Policy.

### [Get-AzInsightsPrivateLinkScope](Get-AzInsightsPrivateLinkScope.md)
Get private link scope

### [Get-AzInsightsPrivateLinkScopedResource](Get-AzInsightsPrivateLinkScopedResource.md)
Get for private link scoped resource

### [Get-AzLogProfile](Get-AzLogProfile.md)
Gets a log profile.

### [Get-AzMetric](Get-AzMetric.md)
Gets the metric values of a resource.

### [Get-AzMetricAlertRuleV2](Get-AzMetricAlertRuleV2.md)
Gets V2 (non-classic) metric alert rules

### [Get-AzMetricDefinition](Get-AzMetricDefinition.md)
Gets metric definitions.

### [Get-AzScheduledQueryRule](Get-AzScheduledQueryRule.md)
Retrieve an scheduled query rule definition.

### [Get-AzSubscriptionDiagnosticSetting](Get-AzSubscriptionDiagnosticSetting.md)
Gets the active subscription diagnostic settings for the specified resource.

### [New-AzActionGroupReceiver](New-AzActionGroupReceiver.md)
Creates an new action group receiver.

### [New-AzActivityLogAlert](New-AzActivityLogAlert.md)
Create a new Activity Log Alert rule or update an existing one.

### [New-AzActivityLogAlertActionGroupObject](New-AzActivityLogAlertActionGroupObject.md)
Create an in-memory object for ActionGroup.

### [New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject](New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject.md)
Create an in-memory object for AlertRuleAnyOfOrLeafCondition.

### [New-AzActivityLogAlertAlertRuleLeafConditionObject](New-AzActivityLogAlertAlertRuleLeafConditionObject.md)
Create an in-memory object for AlertRuleLeafCondition.

### [New-AzAlertRuleEmail](New-AzAlertRuleEmail.md)
Creates an email action for an alert rule.

### [New-AzAlertRuleWebhook](New-AzAlertRuleWebhook.md)
Creates an alert rule webhook.

### [New-AzAutoscaleNotificationObject](New-AzAutoscaleNotificationObject.md)
Create an in-memory object for AutoscaleNotification.

### [New-AzAutoscaleProfileObject](New-AzAutoscaleProfileObject.md)
Create an in-memory object for AutoscaleProfile.

### [New-AzAutoscaleScaleRuleMetricDimensionObject](New-AzAutoscaleScaleRuleMetricDimensionObject.md)
Create an in-memory object for ScaleRuleMetricDimension.

### [New-AzAutoscaleScaleRuleObject](New-AzAutoscaleScaleRuleObject.md)
Create an in-memory object for ScaleRule.

### [New-AzAutoscaleSetting](New-AzAutoscaleSetting.md)
Creates or updates an autoscale setting.

### [New-AzAutoscaleWebhookNotificationObject](New-AzAutoscaleWebhookNotificationObject.md)
Create an in-memory object for WebhookNotification.

### [New-AzDataCollectionRule](New-AzDataCollectionRule.md)
Create a data collection rule.

### [New-AzDataCollectionRuleAssociation](New-AzDataCollectionRuleAssociation.md)
Create data collection rule association.

### [New-AzDiagnosticSetting](New-AzDiagnosticSetting.md)
Creates or updates diagnostic settings for the specified resource.

### [New-AzDiagnosticSettingLogSettingsObject](New-AzDiagnosticSettingLogSettingsObject.md)
Create an in-memory object for LogSettings.

### [New-AzDiagnosticSettingMetricSettingsObject](New-AzDiagnosticSettingMetricSettingsObject.md)
Create an in-memory object for MetricSettings.

### [New-AzDiagnosticSettingSubscriptionLogSettingsObject](New-AzDiagnosticSettingSubscriptionLogSettingsObject.md)
Create an in-memory object for SubscriptionLogSettings.

### [New-AzInsightsPrivateLinkScope](New-AzInsightsPrivateLinkScope.md)
create private link scope

### [New-AzInsightsPrivateLinkScopedResource](New-AzInsightsPrivateLinkScopedResource.md)
create for private link scoped resource

### [New-AzMetricAlertRuleV2Criteria](New-AzMetricAlertRuleV2Criteria.md)
Creates a local criteria object that can be used to create a new metric alert

### [New-AzMetricAlertRuleV2DimensionSelection](New-AzMetricAlertRuleV2DimensionSelection.md)
Creates a local dimension selection object that can be used to construct a metric alert criteria.

### [New-AzMetricFilter](New-AzMetricFilter.md)
Creates a metric dimension filter that can be used to query metrics.

### [New-AzScheduledQueryRule](New-AzScheduledQueryRule.md)
Creates or updates a scheduled query rule.

### [New-AzScheduledQueryRuleConditionObject](New-AzScheduledQueryRuleConditionObject.md)
Create an in-memory object for Condition.

### [New-AzScheduledQueryRuleDimensionObject](New-AzScheduledQueryRuleDimensionObject.md)
Create an in-memory object for Dimension.

### [New-AzSubscriptionDiagnosticSetting](New-AzSubscriptionDiagnosticSetting.md)
Creates or updates subscription diagnostic settings for the specified resource.

### [Remove-AzActionGroup](Remove-AzActionGroup.md)
Removes an action group.

### [Remove-AzActivityLogAlert](Remove-AzActivityLogAlert.md)
Delete an Activity Log Alert rule.

### [Remove-AzAlertRule](Remove-AzAlertRule.md)
Removes an alert rule.

### [Remove-AzAutoscaleSetting](Remove-AzAutoscaleSetting.md)
Deletes and autoscale setting

### [Remove-AzDataCollectionRule](Remove-AzDataCollectionRule.md)
Delete a data collection rule.

### [Remove-AzDataCollectionRuleAssociation](Remove-AzDataCollectionRuleAssociation.md)
Delete a data collection rule association.

### [Remove-AzDiagnosticSetting](Remove-AzDiagnosticSetting.md)
Deletes existing diagnostic settings for the specified resource.

### [Remove-AzInsightsPrivateLinkScope](Remove-AzInsightsPrivateLinkScope.md)
delete private link scope

### [Remove-AzInsightsPrivateLinkScopedResource](Remove-AzInsightsPrivateLinkScopedResource.md)
delete for private link scoped resource

### [Remove-AzLogProfile](Remove-AzLogProfile.md)
Removes a log profile.

### [Remove-AzMetricAlertRuleV2](Remove-AzMetricAlertRuleV2.md)
Removes a V2 (non-classic) metric alert rule.

### [Remove-AzScheduledQueryRule](Remove-AzScheduledQueryRule.md)
Deletes a scheduled query rule.

### [Remove-AzSubscriptionDiagnosticSetting](Remove-AzSubscriptionDiagnosticSetting.md)
Deletes existing subscription diagnostic settings for the specified resource.

### [Set-AzActionGroup](Set-AzActionGroup.md)
Creates a new or updates an existing action group.

### [Set-AzDataCollectionRule](Set-AzDataCollectionRule.md)
Updates (full replacement) a data collection rule.

### [Update-AzActivityLogAlert](Update-AzActivityLogAlert.md)
Updates 'tags' and 'enabled' fields in an existing Alert rule.
This method is used to update the Alert rule tags, and to enable or disable the Alert rule.
To update other fields use CreateOrUpdate operation.

### [Update-AzDataCollectionRule](Update-AzDataCollectionRule.md)
Updates a data collection rule tags property.

### [Update-AzInsightsPrivateLinkScope](Update-AzInsightsPrivateLinkScope.md)
Update for private link scope

### [Update-AzScheduledQueryRule](Update-AzScheduledQueryRule.md)
Update a scheduled query rule.