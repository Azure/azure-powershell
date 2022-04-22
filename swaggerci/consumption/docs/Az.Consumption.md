---
Module Name: Az.Consumption
Module Guid: be1f13c1-ed9d-42d8-a044-47adbc11ec5e
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.consumption
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
Lists all Azure credits and Microsoft Azure consumption commitments for a billing account or a billing profile.
Microsoft Azure consumption commitments are only supported for the billing account scope.

### [Get-AzConsumptionMarketplace](Get-AzConsumptionMarketplace.md)
Lists the marketplaces for a scope at the defined scope.
Marketplaces are available via this API only for May 1, 2014 or later.

### [Get-AzConsumptionPriceSheet](Get-AzConsumptionPriceSheet.md)
Gets the price sheet for a subscription.
Price sheet is available via this API only for May 1, 2014 or later.

### [Get-AzConsumptionReservationDetail](Get-AzConsumptionReservationDetail.md)
Lists the reservations details for provided date range.

### [Get-AzConsumptionReservationRecommendation](Get-AzConsumptionReservationRecommendation.md)
List of recommendations for purchasing reserved instances.

### [Get-AzConsumptionReservationRecommendationDetail](Get-AzConsumptionReservationRecommendationDetail.md)
Details of a reservation recommendation for what-if analysis of reserved instances.

### [Get-AzConsumptionReservationsDetail](Get-AzConsumptionReservationsDetail.md)
Lists the reservations details for the defined scope and provided date range.

### [Get-AzConsumptionReservationsSummary](Get-AzConsumptionReservationsSummary.md)
Lists the reservations summaries for the defined scope daily or monthly grain.

### [Get-AzConsumptionReservationSummary](Get-AzConsumptionReservationSummary.md)
Lists the reservations summaries for daily or monthly grain.

### [Get-AzConsumptionReservationTransaction](Get-AzConsumptionReservationTransaction.md)
List of transactions for reserved instances on billing account scope

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

