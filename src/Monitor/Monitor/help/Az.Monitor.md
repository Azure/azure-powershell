---
Module Name: Az.Monitor
Module Guid: 698c387c-bd6b-41c6-82ce-721f1ef39548
Download Help Link: https://learn.microsoft.com/powershell/module/az.monitor
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
Adds or updates a claasic metric-based alert rule (already retired on public cloud). To create a new metric alert rule, use the [Add-AzMetricAlertRuleV2](./Add-AzMetricAlertRuleV2.md) cmdlet.

### [Add-AzMetricAlertRuleV2](Add-AzMetricAlertRuleV2.md)
Adds or updates a V2 (non-classic) metric-based alert rule.

### [Add-AzWebtestAlertRule](Add-AzWebtestAlertRule.md)
Adds or updates a classic webtest alert rule (already retired on public cloud).
To create a new webtest alert rule, use the [Add-AzMetricAlertRuleV2](./Add-AzMetricAlertRuleV2.md) cmdlet, passing a criteria object for webtest (created via the [New-AzMetricAlertRuleV2Criteria](./New-AzMetricAlertRuleV2Criteria.md) cmdlet with a "-WebTest" criteria type).

### [Enable-AzActionGroupReceiver](Enable-AzActionGroupReceiver.md)
Enable a receiver in an action group.
This changes the receiver's status from Disabled to Enabled.
This operation is only supported for Email or SMS receivers.

### [Get-AzActionGroup](Get-AzActionGroup.md)
Get an action group.

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

### [Get-AzDataCollectionEndpoint](Get-AzDataCollectionEndpoint.md)
Returns the specified data collection endpoint.

### [Get-AzDataCollectionRule](Get-AzDataCollectionRule.md)
Returns the specified data collection rule.

### [Get-AzDataCollectionRuleAssociation](Get-AzDataCollectionRuleAssociation.md)
Returns the specified association.

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

### [Get-AzMonitorWorkspace](Get-AzMonitorWorkspace.md)
Returns the specific Azure Monitor workspace

### [Get-AzScheduledQueryRule](Get-AzScheduledQueryRule.md)
Retrieve an scheduled query rule definition.

### [Get-AzSubscriptionDiagnosticSetting](Get-AzSubscriptionDiagnosticSetting.md)
Gets the active subscription diagnostic settings for the specified resource.

### [New-AzActionGroup](New-AzActionGroup.md)
Create a new action group or update an existing one.

### [New-AzActionGroupArmRoleReceiverObject](New-AzActionGroupArmRoleReceiverObject.md)
Create an in-memory object for ArmRoleReceiver.

### [New-AzActionGroupAutomationRunbookReceiverObject](New-AzActionGroupAutomationRunbookReceiverObject.md)
Create an in-memory object for AutomationRunbookReceiver.

### [New-AzActionGroupAzureAppPushReceiverObject](New-AzActionGroupAzureAppPushReceiverObject.md)
Create an in-memory object for AzureAppPushReceiver.

### [New-AzActionGroupAzureFunctionReceiverObject](New-AzActionGroupAzureFunctionReceiverObject.md)
Create an in-memory object for AzureFunctionReceiver.

### [New-AzActionGroupEmailReceiverObject](New-AzActionGroupEmailReceiverObject.md)
Create an in-memory object for EmailReceiver.

### [New-AzActionGroupEventHubReceiverObject](New-AzActionGroupEventHubReceiverObject.md)
Create an in-memory object for EventHubReceiver.

### [New-AzActionGroupItsmReceiverObject](New-AzActionGroupItsmReceiverObject.md)
Create an in-memory object for ItsmReceiver.

### [New-AzActionGroupLogicAppReceiverObject](New-AzActionGroupLogicAppReceiverObject.md)
Create an in-memory object for LogicAppReceiver.

### [New-AzActionGroupSmsReceiverObject](New-AzActionGroupSmsReceiverObject.md)
Create an in-memory object for SmsReceiver.

### [New-AzActionGroupVoiceReceiverObject](New-AzActionGroupVoiceReceiverObject.md)
Create an in-memory object for VoiceReceiver.

### [New-AzActionGroupWebhookReceiverObject](New-AzActionGroupWebhookReceiverObject.md)
Create an in-memory object for WebhookReceiver.

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

### [New-AzDataCollectionEndpoint](New-AzDataCollectionEndpoint.md)
Create a data collection endpoint.

### [New-AzDataCollectionRule](New-AzDataCollectionRule.md)
Create a data collection rule.

### [New-AzDataCollectionRuleAssociation](New-AzDataCollectionRuleAssociation.md)
Create an association.

### [New-AzDataFlowObject](New-AzDataFlowObject.md)
Create an in-memory object for DataFlow.

### [New-AzDiagnosticSetting](New-AzDiagnosticSetting.md)
Creates or updates diagnostic settings for the specified resource.

### [New-AzDiagnosticSettingLogSettingsObject](New-AzDiagnosticSettingLogSettingsObject.md)
Create an in-memory object for LogSettings.

### [New-AzDiagnosticSettingMetricSettingsObject](New-AzDiagnosticSettingMetricSettingsObject.md)
Create an in-memory object for MetricSettings.

### [New-AzDiagnosticSettingSubscriptionLogSettingsObject](New-AzDiagnosticSettingSubscriptionLogSettingsObject.md)
Create an in-memory object for SubscriptionLogSettings.

### [New-AzEventHubDestinationObject](New-AzEventHubDestinationObject.md)
Create an in-memory object for EventHubDestination.

### [New-AzEventHubDirectDestinationObject](New-AzEventHubDirectDestinationObject.md)
Create an in-memory object for EventHubDirectDestination.

### [New-AzExtensionDataSourceObject](New-AzExtensionDataSourceObject.md)
Create an in-memory object for ExtensionDataSource.

### [New-AzIisLogsDataSourceObject](New-AzIisLogsDataSourceObject.md)
Create an in-memory object for IisLogsDataSource.

### [New-AzInsightsPrivateLinkScope](New-AzInsightsPrivateLinkScope.md)
create private link scope

### [New-AzInsightsPrivateLinkScopedResource](New-AzInsightsPrivateLinkScopedResource.md)
create for private link scoped resource

### [New-AzLogAnalyticsDestinationObject](New-AzLogAnalyticsDestinationObject.md)
Create an in-memory object for LogAnalyticsDestination.

### [New-AzLogFilesDataSourceObject](New-AzLogFilesDataSourceObject.md)
Create an in-memory object for LogFilesDataSource.

### [New-AzMetricAlertRuleV2Criteria](New-AzMetricAlertRuleV2Criteria.md)
Creates a local criteria object that can be used to create a new metric alert

### [New-AzMetricAlertRuleV2DimensionSelection](New-AzMetricAlertRuleV2DimensionSelection.md)
Creates a local dimension selection object that can be used to construct a metric alert criteria.

### [New-AzMetricFilter](New-AzMetricFilter.md)
Creates a metric dimension filter that can be used to query metrics.

### [New-AzMonitoringAccountDestinationObject](New-AzMonitoringAccountDestinationObject.md)
Create an in-memory object for MonitoringAccountDestination.

### [New-AzMonitorWorkspace](New-AzMonitorWorkspace.md)
Create or update a workspace

### [New-AzPerfCounterDataSourceObject](New-AzPerfCounterDataSourceObject.md)
Create an in-memory object for PerfCounterDataSource.

### [New-AzPlatformTelemetryDataSourceObject](New-AzPlatformTelemetryDataSourceObject.md)
Create an in-memory object for PlatformTelemetryDataSource.

### [New-AzPrometheusForwarderDataSourceObject](New-AzPrometheusForwarderDataSourceObject.md)
Create an in-memory object for PrometheusForwarderDataSource.

### [New-AzScheduledQueryRule](New-AzScheduledQueryRule.md)
Creates or updates a scheduled query rule.

### [New-AzScheduledQueryRuleConditionObject](New-AzScheduledQueryRuleConditionObject.md)
Create an in-memory object for Condition.

### [New-AzScheduledQueryRuleDimensionObject](New-AzScheduledQueryRuleDimensionObject.md)
Create an in-memory object for Dimension.

### [New-AzStorageBlobDestinationObject](New-AzStorageBlobDestinationObject.md)
Create an in-memory object for StorageBlobDestination.

### [New-AzStorageTableDestinationObject](New-AzStorageTableDestinationObject.md)
Create an in-memory object for StorageTableDestination.

### [New-AzSubscriptionDiagnosticSetting](New-AzSubscriptionDiagnosticSetting.md)
Creates or updates subscription diagnostic settings for the specified resource.

### [New-AzSyslogDataSourceObject](New-AzSyslogDataSourceObject.md)
Create an in-memory object for SyslogDataSource.

### [New-AzWindowsEventLogDataSourceObject](New-AzWindowsEventLogDataSourceObject.md)
Create an in-memory object for WindowsEventLogDataSource.

### [New-AzWindowsFirewallLogsDataSourceObject](New-AzWindowsFirewallLogsDataSourceObject.md)
Create an in-memory object for WindowsFirewallLogsDataSource.

### [Remove-AzActionGroup](Remove-AzActionGroup.md)
Delete an action group.

### [Remove-AzActivityLogAlert](Remove-AzActivityLogAlert.md)
Delete an Activity Log Alert rule.

### [Remove-AzAlertRule](Remove-AzAlertRule.md)
Removes an alert rule.

### [Remove-AzAutoscaleSetting](Remove-AzAutoscaleSetting.md)
Deletes and autoscale setting

### [Remove-AzDataCollectionEndpoint](Remove-AzDataCollectionEndpoint.md)
Deletes a data collection endpoint.

### [Remove-AzDataCollectionRule](Remove-AzDataCollectionRule.md)
Deletes a data collection rule.

### [Remove-AzDataCollectionRuleAssociation](Remove-AzDataCollectionRuleAssociation.md)
Deletes an association.

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

### [Remove-AzMonitorWorkspace](Remove-AzMonitorWorkspace.md)
Delete a workspace

### [Remove-AzScheduledQueryRule](Remove-AzScheduledQueryRule.md)
Deletes a scheduled query rule.

### [Remove-AzSubscriptionDiagnosticSetting](Remove-AzSubscriptionDiagnosticSetting.md)
Deletes existing subscription diagnostic settings for the specified resource.

### [Test-AzActionGroup](Test-AzActionGroup.md)
Send test notifications to a set of provided receivers

### [Update-AzActionGroup](Update-AzActionGroup.md)
Create a new action group or update an existing one.

### [Update-AzActivityLogAlert](Update-AzActivityLogAlert.md)
Updates 'tags' and 'enabled' fields in an existing Alert rule.
This method is used to update the Alert rule tags, and to enable or disable the Alert rule.
To update other fields use CreateOrUpdate operation.

### [Update-AzAutoscaleSetting](Update-AzAutoscaleSetting.md)
Updates an existing AutoscaleSettingsResource.
To update other fields use the CreateOrUpdate method.

### [Update-AzDataCollectionEndpoint](Update-AzDataCollectionEndpoint.md)
Updates part of a data collection endpoint.

### [Update-AzDataCollectionRule](Update-AzDataCollectionRule.md)
Update a data collection rule.

### [Update-AzDataCollectionRuleAssociation](Update-AzDataCollectionRuleAssociation.md)
Create an association.

### [Update-AzInsightsPrivateLinkScope](Update-AzInsightsPrivateLinkScope.md)
Update for private link scope

### [Update-AzMonitorWorkspace](Update-AzMonitorWorkspace.md)
Updates part of a workspace

### [Update-AzScheduledQueryRule](Update-AzScheduledQueryRule.md)
Update a scheduled query rule.

