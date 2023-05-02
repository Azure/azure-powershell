---
Module Name: Az.CostManagement
Module Guid: 4cd9af10-559e-4fb9-8dcd-d3e8eb9e03b7
Download Help Link: https://learn.microsoft.com/powershell/module/az.costmanagement
Help Version: 1.0.0.0
Locale: en-US
---

# Az.CostManagement Module
## Description
Microsoft Azure PowerShell: Cost cmdlets

## Az.CostManagement Cmdlets
### [Get-AzCostManagementExport](Get-AzCostManagementExport.md)
The operation to get the export for the defined scope by export name.

### [Get-AzCostManagementExportExecutionHistory](Get-AzCostManagementExportExecutionHistory.md)
The operation to get the execution history of an export for the defined scope and export name.

### [Invoke-AzCostManagementExecuteExport](Invoke-AzCostManagementExecuteExport.md)
The operation to execute an export.

### [Invoke-AzCostManagementQuery](Invoke-AzCostManagementQuery.md)
Query the usage data for scope defined.

### [Invoke-AzCostManagementReservationDetailReport](Invoke-AzCostManagementReservationDetailReport.md)
Generates the reservations details report for provided date range asynchronously based on enrollment id.
The Reservation usage details can be viewed only by certain enterprise roles.
For more details on the roles see, https://learn.microsoft.com/en-us/azure/cost-management-billing/manage/understand-ea-roles#usage-and-costs-access-by-role

### [New-AzCostManagementDetailReport](New-AzCostManagementDetailReport.md)
This API is the replacement for all previously release Usage Details APIs.
Request to generate a cost details report for the provided date range, billing period (Only enterprise customers) or Invoice Id asynchronously at a certain scope.
The initial call to request a report will return a 202 with a 'Location' and 'Retry-After' header.
The 'Location' header will provide the endpoint to poll to get the result of the report generation.
The 'Retry-After' provides the duration to wait before polling for the generated report.
A call to poll the report operation will provide a 202 response with a 'Location' header if the operation is still in progress.
Once the report generation operation completes, the polling endpoint will provide a 200 response along with details on the report blob(s) that are available for download.
The details on the file(s) available for download will be available in the polling response body.

### [New-AzCostManagementExport](New-AzCostManagementExport.md)
The operation to create or update a export.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [New-AzCostManagementQueryComparisonExpressionObject](New-AzCostManagementQueryComparisonExpressionObject.md)
Create a in-memory object for QueryComparisonExpression

### [New-AzCostManagementQueryFilterObject](New-AzCostManagementQueryFilterObject.md)
Create a in-memory object for QueryFilter

### [Remove-AzCostManagementExport](Remove-AzCostManagementExport.md)
The operation to delete a export.

### [Update-AzCostManagementExport](Update-AzCostManagementExport.md)
The operation to create or update a export.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

