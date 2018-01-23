---
Module Name: AzureRM.Insights
Module Guid: XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
Download Help Link: {{Please enter FwLink manually}}
Help Version: {{Please enter version of help manually (X.X.X.X) format}}
Locale: en-US
---

# AzureRM.Insights Module
## Description
This topic displays help topics for the Azure Insights Cmdlets.

## AzureRM.Insights Cmdlets
### [Add-AzureRmAutoscaleSetting](Add-AzureRmAutoscaleSetting.md)
Creates an Autoscale setting.

### [Add-AzureRmLogAlertRule](Add-AzureRmLogAlertRule.md)
Adds or replaces a log alert rule.

### [Add-AzureRmLogProfile](Add-AzureRmLogProfile.md)
Creates a new activity log profile. This profile is used to either archive the activity log to an Azure storage account or stream it to an Azure event hub in the same subscription. 

- **Storage Account** - Only standard storage account (premium storage account is not supported) is supported. It could either be of type ARM or Classic. If it's logged to a storage account, the cost of storing the activity log is billed at normal standard storage rates. There could be only one log profile per subscription consequentially only one storage account per subscription can be used to export activity log. 

- **Event Hub** - There could be only one log profile per subscription consequentially only one event hub per subscription can be used to export activity log. If activity log is streamed to an event hub, standard event hub pricing will apply. 

In the activity log, events can pertain to a region or could be "Global". Global essentially means these events are region agnostics and are independent of region, in fact majority of events fall into this category. If the activity log profile is set from the portal, it implicitly adds "Global" along with any other region selected in the user interface. When using the cmdlet, the location as "Global" must be explicitly mentioned apart from any other region. 

**Note** :- **Failing to set "Global" in the locations will result in a majority of activity log not getting exported.** 

### [Add-AzureRmMetricAlertRule](Add-AzureRmMetricAlertRule.md)
Adds or updates a metric-based alert rule.

### [Add-AzureRmWebtestAlertRule](Add-AzureRmWebtestAlertRule.md)
Adds or updates a webtest alert rule.

### [Disable-AzureRmActivityLogAlert](Disable-AzureRmActivityLogAlert.md)
Disables an activity log alert and sets its tags.

### [Enable-AzureRmActivityLogAlert](Enable-AzureRmActivityLogAlert.md)
Enables an activity log alert and sets its Tags.

### [Get-AzureRmActionGroup](Get-AzureRmActionGroup.md)
Gets action group(s).

### [Get-AzureRmActivityLogAlert](Get-AzureRmActivityLogAlert.md)
Gets one or more activity log alert resources.

### [Get-AzureRmAlertHistory](Get-AzureRmAlertHistory.md)
Gets the history of alerts.

### [Get-AzureRmAlertRule](Get-AzureRmAlertRule.md)
Gets alert rules.

### [Get-AzureRmAutoscaleHistory](Get-AzureRmAutoscaleHistory.md)
Gets the Autoscale history.

### [Get-AzureRmAutoscaleSetting](Get-AzureRmAutoscaleSetting.md)
Gets Autoscale settings.

### [Get-AzureRmDiagnosticSetting](Get-AzureRmDiagnosticSetting.md)
Gets the logged categories and time grains.

### [Get-AzureRmLog](Get-AzureRmLog.md)
Gets a log of events.

### [Get-AzureRmLogProfile](Get-AzureRmLogProfile.md)
Gets a log profile.

### [Get-AzureRmMetric](Get-AzureRmMetric.md)
Gets the metric values of a resource.

### [Get-AzureRmMetricDefinition](Get-AzureRmMetricDefinition.md)
Gets metric definitions.

### [Get-AzureRmUsage](Get-AzureRmUsage.md)
Gets the usage metrics for a resource.

### [New-AzureRmActionGroup](New-AzureRmActionGroup.md)
Creates an ActionGroup reference object in memory.

### [New-AzureRmActionGroupReceiver](New-AzureRmActionGroupReceiver.md)
Creates an new action group receiver.

### [New-AzureRmActivityLogAlertCondition](New-AzureRmActivityLogAlertCondition.md)
Creates an new activity log alert condition object in memory.

### [New-AzureRmAlertRuleEmail](New-AzureRmAlertRuleEmail.md)
Creates an email action for an alert rule.

### [New-AzureRmAlertRuleWebhook](New-AzureRmAlertRuleWebhook.md)
Creates an alert rule webhook.

### [New-AzureRmAutoscaleNotification](New-AzureRmAutoscaleNotification.md)
Creates an Autoscale email notification.

### [New-AzureRmAutoscaleProfile](New-AzureRmAutoscaleProfile.md)
Creates an Autoscale profile.

### [New-AzureRmAutoscaleRule](New-AzureRmAutoscaleRule.md)
Creates an Autoscale rule.

### [New-AzureRmAutoscaleWebhook](New-AzureRmAutoscaleWebhook.md)
Creates an Autoscale webhook.

### [Remove-AzureRmActionGroup](Remove-AzureRmActionGroup.md)
Removes an action group.

### [Remove-AzureRmActivityLogAlert](Remove-AzureRmActivityLogAlert.md)
Removes an activity log alert.

### [Remove-AzureRmAlertRule](Remove-AzureRmAlertRule.md)
Removes an alert rule.

### [Remove-AzureRmAutoscaleSetting](Remove-AzureRmAutoscaleSetting.md)
Removes an Autoscale setting.

### [Remove-AzureRmLogProfile](Remove-AzureRmLogProfile.md)
Removes a log profile.

### [Set-AzureRmActionGroup](Set-AzureRmActionGroup.md)
Creates a new or updates an existing action group.

### [Set-AzureRmActivityLogAlert](Set-AzureRmActivityLogAlert.md)
Creates a new or sets an existing activity log alert.

### [Set-AzureRmDiagnosticSetting](Set-AzureRmDiagnosticSetting.md)
Sets the logs and metrics settings for the resource.

