---
Module Name: Az.Consumption
Module Guid: 07c26876-5225-4acf-9e45-673895935092
Download Help Link: https://learn.microsoft.com/powershell/module/az.consumption
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Consumption Module
## Description
Microsoft Azure PowerShell: Consumption cmdlets

## Az.Consumption Cmdlets
### [Get-AzConsumptionAggregatedCost](Get-AzConsumptionAggregatedCost.md)
Provides the aggregate cost of a management group and all child management groups by current billing period.

### [Get-AzConsumptionBalance](Get-AzConsumptionBalance.md)
Gets the balances for a scope by billingAccountId.
Balances are available via this API only for May 1, 2014 or later.

### [Get-AzConsumptionBudget](Get-AzConsumptionBudget.md)
Gets the budget for the scope by budget name.

### [Get-AzConsumptionCharge](Get-AzConsumptionCharge.md)
Lists the charges based for the defined scope.

### [Get-AzConsumptionCredit](Get-AzConsumptionCredit.md)
The credit summary by billingAccountId and billingProfileId.

### [Get-AzConsumptionEvent](Get-AzConsumptionEvent.md)
Lists the events that decrements Azure credits or Microsoft Azure consumption commitment for a billing account or a billing profile for a given start and end date.

### [Get-AzConsumptionLot](Get-AzConsumptionLot.md)
Lists all Azure credits for a billing account or a billing profile.
The API is only supported for Microsoft Customer Agreements (MCA) billing accounts.

### [Get-AzConsumptionMarketplace](Get-AzConsumptionMarketplace.md)
Lists the marketplaces for a scope at the defined scope.
Marketplaces are available via this API only for May 1, 2014 or later.

### [Get-AzConsumptionPriceSheet](Get-AzConsumptionPriceSheet.md)
Gets the price sheet for a subscription.
Price sheet is available via this API only for May 1, 2014 or later.

### [Get-AzConsumptionReservationDetail](Get-AzConsumptionReservationDetail.md)
Lists the reservations details for provided date range.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
If the data size is too large, customers may also get 504 as the API timed out preparing the data.
In such cases, API call should be made with smaller date ranges or a call to Generate Reservation Details Report API should be made as it is asynchronous and will not run into response size time outs.

### [Get-AzConsumptionReservationRecommendation](Get-AzConsumptionReservationRecommendation.md)
List of recommendations for purchasing reserved instances.

### [Get-AzConsumptionReservationRecommendationDetail](Get-AzConsumptionReservationRecommendationDetail.md)
Details of a reservation recommendation for what-if analysis of reserved instances.

### [Get-AzConsumptionReservationsDetail](Get-AzConsumptionReservationsDetail.md)
Lists the reservations details for provided date range.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
If the data size is too large, customers may also get 504 as the API timed out preparing the data.
In such cases, API call should be made with smaller date ranges or a call to Generate Reservation Details Report API should be made as it is asynchronous and will not run into response size time outs.

### [Get-AzConsumptionReservationsSummary](Get-AzConsumptionReservationsSummary.md)
Lists the reservations summaries for the defined scope daily or monthly grain.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
In such cases, API call should be made with smaller date ranges.

### [Get-AzConsumptionReservationSummary](Get-AzConsumptionReservationSummary.md)
Lists the reservations summaries for daily or monthly grain.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
In such cases, API call should be made with smaller date ranges.

### [Get-AzConsumptionReservationTransaction](Get-AzConsumptionReservationTransaction.md)
List of transactions for reserved instances on billing account scope.
Note: The refund transactions are posted along with its purchase transaction (i.e.
in the purchase billing month).
For example, The refund is requested in May 2021.
This refund transaction will have event date as May 2021 but the billing month as April 2020 when the reservation purchase was made.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
In such cases, API call should be made with smaller date ranges.

### [Get-AzConsumptionTag](Get-AzConsumptionTag.md)
Get all available tag keys for the defined scope

### [Get-AzConsumptionUsageDetail](Get-AzConsumptionUsageDetail.md)
Lists the usage details for the defined scope.
Usage details are available via this API only for May 1, 2014 or later.

### [New-AzConsumptionBudget](New-AzConsumptionBudget.md)
The operation to create or update a budget.
You can optionally provide an eTag if desired as a form of concurrency control.
To obtain the latest eTag for a given budget, perform a get operation prior to your put operation.

### [Remove-AzConsumptionBudget](Remove-AzConsumptionBudget.md)
The operation to delete a budget.

