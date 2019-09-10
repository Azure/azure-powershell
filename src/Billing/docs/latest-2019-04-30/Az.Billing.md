---
Module Name: Az.Billing
Module Guid: f6447640-ffdf-42f9-5ffe-a11eed4aa63f
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.billing
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Billing Module
## Description
Microsoft Azure PowerShell: Billing cmdlets

## Az.Billing Cmdlets
### [Get-AzBillingPeriod](Get-AzBillingPeriod.md)
Gets a named billing period.
This is only supported for Azure Web-Direct subscriptions.
Other subscription types which were not purchased directly through the Azure web portal are not supported through this preview API.

### [Get-AzBudget](Get-AzBudget.md)
Gets the budget for the scope by budget name.

### [Get-AzEnrollmentAccount](Get-AzEnrollmentAccount.md)
Get the enrollment account by id.

### [Get-AzInvoice](Get-AzInvoice.md)
Get the invoice by name.

### [Get-AzMarketplace](Get-AzMarketplace.md)
Lists the marketplaces for a scope at the defined scope.
Marketplaces are available via this API only for May 1, 2014 or later.

### [Get-AzPriceSheet](Get-AzPriceSheet.md)
Gets the price sheet for a scope by subscriptionId.
Price sheet is available via this API only for May 1, 2014 or later.

### [Get-AzReservationDetail](Get-AzReservationDetail.md)
Lists the reservations details for provided date range.

### [Get-AzReservationSummary](Get-AzReservationSummary.md)
Lists the reservations summaries for daily or monthly grain.

### [Get-AzUsageAggregate](Get-AzUsageAggregate.md)
Query aggregated Azure subscription consumption data for a date range.

### [Get-AzUsageDetail](Get-AzUsageDetail.md)
Lists the usage details for the defined scope.
Usage details are available via this API only for May 1, 2014 or later.

### [New-AzBudget](New-AzBudget.md)
The operation to create or update a budget.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [Remove-AzBudget](Remove-AzBudget.md)
The operation to delete a budget.

### [Set-AzBudget](Set-AzBudget.md)
The operation to create or update a budget.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

