---
Module Name: Az.NewRelic
Module Guid: 9594ee80-6c29-41b6-a615-e8689b5ae0dd
Download Help Link: https://learn.microsoft.com/powershell/module/az.newrelic
Help Version: 1.0.0.0
Locale: en-US
---

# Az.NewRelic Module
## Description
Microsoft Azure PowerShell: NewRelic cmdlets

## Az.NewRelic Cmdlets
### [Get-AzNewRelicAccount](Get-AzNewRelicAccount.md)
Lists all the New Relic accounts linked to your email address, helping you understand the existing accounts that have been created

### [Get-AzNewRelicBillingInfo](Get-AzNewRelicBillingInfo.md)
Retrieves marketplace and organization information mapped to the given New Relic monitor resource

### [Get-AzNewRelicConnectedPartnerResource](Get-AzNewRelicConnectedPartnerResource.md)
List of all active deployments that are associated with the marketplace subscription linked to the given monitor.

### [Get-AzNewRelicMonitor](Get-AzNewRelicMonitor.md)
Get a NewRelicMonitorResource

### [Get-AzNewRelicMonitoredAppService](Get-AzNewRelicMonitoredAppService.md)
Lists the app service resources currently being monitored by the New Relic resource, helping you understand which app services are under monitoring

### [Get-AzNewRelicMonitoredHost](Get-AzNewRelicMonitoredHost.md)
Lists all VM resources currently being monitored by the New Relic monitor resource, helping you manage observability

### [Get-AzNewRelicMonitoredSubscription](Get-AzNewRelicMonitoredSubscription.md)
Lists all the subscriptions currently being monitored by the NewRelic monitor resource.

### [Get-AzNewRelicMonitorMetricRule](Get-AzNewRelicMonitorMetricRule.md)
Retrieves the metric rules that are configured in the New Relic monitor resource

### [Get-AzNewRelicMonitorMetricStatus](Get-AzNewRelicMonitorMetricStatus.md)
Retrieves the metric status that are configured in the New Relic monitor resource

### [Get-AzNewRelicMonitorMonitoredResource](Get-AzNewRelicMonitorMonitoredResource.md)
Lists all Azure resources that are currently being monitored by the specified New Relic monitor resource, providing insight into the coverage of your observability setup

### [Get-AzNewRelicMonitorTagRule](Get-AzNewRelicMonitorTagRule.md)
Retrieves the details of the tag rules for a specific New Relic monitor resource, providing insight into its setup and status

### [Get-AzNewRelicOrganization](Get-AzNewRelicOrganization.md)
Lists all the New Relic organizations linked to your email address, helping you understand the existing organizations that have been created

### [Get-AzNewRelicPlan](Get-AzNewRelicPlan.md)
Lists the plans data linked to your organization, providing an overview of the available plans

### [Initialize-AzNewRelicSaaSResource](Initialize-AzNewRelicSaaSResource.md)
Resolve the token to get the SaaS resource ID and activate the SaaS resource

### [Invoke-AzNewRelicHostMonitor](Invoke-AzNewRelicHostMonitor.md)
Returns the payload that needs to be passed in the request body for installing the New Relic agent on a VM, providing the necessary configuration details

### [Invoke-AzNewRelicLatestMonitorLinkedSaaS](Invoke-AzNewRelicLatestMonitorLinkedSaaS.md)
Returns the latest SaaS linked to the newrelic organization of the underlying monitor.

### [Invoke-AzNewRelicLinkMonitorSaaS](Invoke-AzNewRelicLinkMonitorSaaS.md)
Links a new SaaS to the newrelic organization of the underlying monitor.

### [Invoke-AzNewRelicResubscribeMonitor](Invoke-AzNewRelicResubscribeMonitor.md)
Resubscribes the New Relic Organization of the underlying Monitor Resource to be billed by Azure Marketplace

### [New-AzNewRelicFilteringTagObject](New-AzNewRelicFilteringTagObject.md)
Create an in-memory object for FilteringTag.

### [New-AzNewRelicMonitor](New-AzNewRelicMonitor.md)
Create a NewRelicMonitorResource

### [New-AzNewRelicMonitoredSubscription](New-AzNewRelicMonitoredSubscription.md)
Add subscriptions to be monitored by the New Relic monitor resource, enabling observability and monitoring.

### [New-AzNewRelicMonitoredSubscriptionObject](New-AzNewRelicMonitoredSubscriptionObject.md)
Create an in-memory object for MonitoredSubscription.

### [New-AzNewRelicMonitorTagRule](New-AzNewRelicMonitorTagRule.md)
Create a new set of tag rules for a specific New Relic monitor resource, determining which Azure resources are monitored based on their tags

### [Remove-AzNewRelicMonitor](Remove-AzNewRelicMonitor.md)
Deletes an existing New Relic monitor resource from your Azure subscription, removing the integration and stopping the observability of your Azure resources through New Relic

### [Remove-AzNewRelicMonitoredSubscription](Remove-AzNewRelicMonitoredSubscription.md)
Deletes the subscriptions that are being monitored by the NewRelic monitor resource

### [Remove-AzNewRelicMonitorTagRule](Remove-AzNewRelicMonitorTagRule.md)
Deletes a tag rule set for a given New Relic monitor resource, removing fine-grained control over observability based on resource tags

### [Switch-AzNewRelicMonitorBilling](Switch-AzNewRelicMonitorBilling.md)
Switches the billing for the New Relic Monitor resource to be billed by Azure Marketplace

### [Update-AzNewRelicMonitoredSubscription](Update-AzNewRelicMonitoredSubscription.md)
Add subscriptions to be monitored by the New Relic monitor resource, enabling observability and monitoring.

### [Update-AzNewRelicMonitorIngestionKey](Update-AzNewRelicMonitorIngestionKey.md)
Refreshes the ingestion key for all monitors linked to the same account associated to the underlying monitor.

### [Update-AzNewRelicMonitorTagRule](Update-AzNewRelicMonitorTagRule.md)
Update the tag rules for a specific New Relic monitor resource, allowing you to modify the rules that control which Azure resources are monitored

