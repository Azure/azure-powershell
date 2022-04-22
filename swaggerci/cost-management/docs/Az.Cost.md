---
Module Name: Az.Cost
Module Guid: f3d53463-b28b-49f7-ad47-ad0c3fc4003a
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.cost
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Cost Module
## Description
Microsoft Azure PowerShell: Cost cmdlets

## Az.Cost Cmdlets
### [Get-AzCostAlert](Get-AzCostAlert.md)
Gets the alert for the scope by alert ID.

### [Get-AzCostAlertExternal](Get-AzCostAlertExternal.md)
Lists the Alerts for external cloud provider type defined.

### [Get-AzCostDimension](Get-AzCostDimension.md)
Lists the dimensions by the defined scope.

### [Get-AzCostExport](Get-AzCostExport.md)
The operation to get the export for the defined scope by export name.

### [Get-AzCostExportExecutionHistory](Get-AzCostExportExecutionHistory.md)
The operation to get the execution history of an export for the defined scope and export name.

### [Get-AzCostGenerateDetailedCostReportOperationResult](Get-AzCostGenerateDetailedCostReportOperationResult.md)
Get the result of the specified operation.
This link is provided in the GenerateDetailedCostReport creation request response header.

### [Get-AzCostGenerateDetailedCostReportOperationStatus](Get-AzCostGenerateDetailedCostReportOperationStatus.md)
Get the status of the specified operation.
This link is provided in the GenerateDetailedCostReport creation request response header.

### [Get-AzCostView](Get-AzCostView.md)
Gets the view by view name.

### [Invoke-AzCostByDimensionExternalCloudProviderType](Invoke-AzCostByDimensionExternalCloudProviderType.md)
Lists the dimensions by the external cloud provider type.

### [Invoke-AzCostByGenerateReservationDetailReportBillingAccountId](Invoke-AzCostByGenerateReservationDetailReportBillingAccountId.md)
Generates the reservations details report for provided date range asynchronously based on enrollment id.

### [Invoke-AzCostByGenerateReservationDetailReportBillingProfileId](Invoke-AzCostByGenerateReservationDetailReportBillingProfileId.md)
Generates the reservations details report for provided date range asynchronously by billing profile.

### [Invoke-AzCostCloudForecast](Invoke-AzCostCloudForecast.md)
Lists the forecast charges for external cloud provider type defined.

### [Invoke-AzCostDismissAlert](Invoke-AzCostDismissAlert.md)
Dismisses the specified alert

### [Invoke-AzCostExecuteExport](Invoke-AzCostExecuteExport.md)
The operation to execute an export.

### [Invoke-AzCostUsageForecast](Invoke-AzCostUsageForecast.md)
Lists the forecast charges for scope defined.

### [Invoke-AzCostUsageQuery](Invoke-AzCostUsageQuery.md)
Query the usage data for scope defined.

### [New-AzCostExport](New-AzCostExport.md)
The operation to create or update a export.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [New-AzCostGenerateDetailedCostReportOperation](New-AzCostGenerateDetailedCostReportOperation.md)
Generates the detailed cost report for provided date range, billing period(Only enterprise customers) or Invoice Id asynchronously at a certain scope.
Call returns a 202 with header Azure-Consumption-AsyncOperation providing a link to the operation created.
A call on the operation will provide the status and if the operation is completed the blob file where generated detailed cost report is being stored.

### [New-AzCostView](New-AzCostView.md)
The operation to create or update a view.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [Remove-AzCostExport](Remove-AzCostExport.md)
The operation to delete a export.

### [Remove-AzCostView](Remove-AzCostView.md)
The operation to delete a view.

