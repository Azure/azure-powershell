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
### [Get-AzActivityLog](Get-AzActivityLog.md)
Provides the list of records from the activity logs.

### [Get-AzDiagnosticSetting](Get-AzDiagnosticSetting.md)
Gets the active diagnostic settings for the specified resource.

### [Get-AzEventCategory](Get-AzEventCategory.md)
Get the list of available event categories supported in the Activity Logs Service.<br>The current list includes the following: Administrative, Security, ServiceHealth, Alert, Recommendation, Policy.

### [Get-AzMetric](Get-AzMetric.md)
**Lists the metric values for a resource**.

### [Get-AzMetricDefinition](Get-AzMetricDefinition.md)
Lists the metric definitions for the resource.

### [Get-AzTenantActivityLog](Get-AzTenantActivityLog.md)
Gets the Activity Logs for the Tenant.<br>Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).<br>One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.

### [New-AzDiagnosticSetting](New-AzDiagnosticSetting.md)
Creates or updates diagnostic settings for the specified resource.

### [Remove-AzDiagnosticSetting](Remove-AzDiagnosticSetting.md)
Deletes existing diagnostic settings for the specified resource.

### [Set-AzDiagnosticSetting](Set-AzDiagnosticSetting.md)
Creates or updates diagnostic settings for the specified resource.

