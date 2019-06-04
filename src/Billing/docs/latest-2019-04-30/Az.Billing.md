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
### [Add-AzBillingBillingRoleAssignment](Add-AzBillingBillingRoleAssignment.md)
The operation to add a role assignment to a billing account.

### [Get-AzAggregatedCost](Get-AzAggregatedCost.md)
Provides the aggregate cost of a management group and all child management groups by current billing period.

### [Get-AzAgreement](Get-AzAgreement.md)
Get the agreement by name.

### [Get-AzAvailableCreditBalance](Get-AzAvailableCreditBalance.md)
The latest available credit balance for a given billingAccountName and billingProfileName.

### [Get-AzBalance](Get-AzBalance.md)
Gets the balances for a scope by billingAccountId.
Balances are available via this API only for May 1, 2014 or later.

### [Get-AzBillingAccount](Get-AzBillingAccount.md)
Get the billing account by id.

### [Get-AzBillingBillingRoleAssignment](Get-AzBillingBillingRoleAssignment.md)
Get the role assignment for the caller

### [Get-AzBillingPeriod](Get-AzBillingPeriod.md)
Gets a named billing period.
This is only supported for Azure Web-Direct subscriptions.
Other subscription types which were not purchased directly through the Azure web portal are not supported through this preview API.

### [Get-AzBillingPermission](Get-AzBillingPermission.md)
Lists all billing permissions for the caller under a billing account.

### [Get-AzBillingPolicy](Get-AzBillingPolicy.md)
The policy for a given billing account name and billing profile name.

### [Get-AzBillingProduct](Get-AzBillingProduct.md)
Get a single product by name.

### [Get-AzBillingProfile](Get-AzBillingProfile.md)
Get the billing profile by id.

### [Get-AzBillingProperty](Get-AzBillingProperty.md)
Get billing property by subscription Id.

### [Get-AzBillingRoleDefinition](Get-AzBillingRoleDefinition.md)
Gets the role definition for a role

### [Get-AzBillingSubscription](Get-AzBillingSubscription.md)
Get a single billing subscription by name.

### [Get-AzBudget](Get-AzBudget.md)
Gets the budget for the scope by budget name.

### [Get-AzCharge](Get-AzCharge.md)
Lists the charges based for the defined scope.

### [Get-AzChargesByBillingAccount](Get-AzChargesByBillingAccount.md)
Lists the charges by billingAccountId for given start and end date.
Start and end date are used to determine the billing period.
For current month, the data will be provided from month to date.
If there are no charges for a month then that month will show all zeroes.

### [Get-AzChargesByBillingProfile](Get-AzChargesByBillingProfile.md)
Lists the charges by billing profile id for given start and end date.
Start and end date are used to determine the billing period.
For current month, the data will be provided from month to date.
If there are no charges for a month then that month will show all zeroes.

### [Get-AzChargesByInvoiceSection](Get-AzChargesByInvoiceSection.md)
Lists the charges by invoice section id for given start and end date.
Start and end date are used to determine the billing period.
For current month, the data will be provided from month to date.
If there are no charges for a month then that month will show all zeroes.

### [Get-AzConsumptionCostTag](Get-AzConsumptionCostTag.md)
Get cost tags for a billing account.

### [Get-AzConsumptionCostTag](Get-AzConsumptionCostTag.md)
Get cost tags for a billing account.

### [Get-AzConsumptionTag](Get-AzConsumptionTag.md)
Get all available tag keys for the defined scope

### [Get-AzConsumptionTenant](Get-AzConsumptionTenant.md)
Gets a Tenant Properties.

### [Get-AzCreditSummary](Get-AzCreditSummary.md)
The credit summary by billingAccountId and billingProfileId for given start and end date.

### [Get-AzDepartment](Get-AzDepartment.md)
Get the department by id.

### [Get-AzEnrollmentAccount](Get-AzEnrollmentAccount.md)
Get the enrollment account by id.

### [Get-AzEventsByBillingProfile](Get-AzEventsByBillingProfile.md)
Lists the events by billingAccountId and billingProfileId for given start and end date.

### [Get-AzForecast](Get-AzForecast.md)
Lists the forecast charges by subscriptionId.

### [Get-AzInvoice](Get-AzInvoice.md)
Get the invoice by name.

### [Get-AzInvoiceLatest](Get-AzInvoiceLatest.md)
Gets the most recent invoice.
When getting a single invoice, the downloadUrl property is expanded automatically.
This is only supported for Azure Web-Direct subscriptions.
Other subscription types which were not purchased directly through the Azure web portal are not supported through this preview API.

### [Get-AzInvoiceSection](Get-AzInvoiceSection.md)
Get the InvoiceSection by id.

### [Get-AzLotsByBillingProfile](Get-AzLotsByBillingProfile.md)
Lists the lots by billingAccountId and billingProfileId for given start and end date.

### [Get-AzMarketplace](Get-AzMarketplace.md)
Lists the marketplaces for a scope at the defined scope.
Marketplaces are available via this API only for May 1, 2014 or later.

### [Get-AzPaymentMethod](Get-AzPaymentMethod.md)
Lists the Payment Methods by billing profile Id.

### [Get-AzPriceSheet](Get-AzPriceSheet.md)
Gets the price sheet for a scope by subscriptionId.
Price sheet is available via this API only for May 1, 2014 or later.

### [Get-AzRateCard](Get-AzRateCard.md)
Enables you to query for the resource/meter metadata and related prices used in a given subscription by Offer ID, Currency, Locale and Region.
The metadata associated with the billing meters, including but not limited to service names, types, resources, units of measure, and regions, is subject to change at any time and without notice.
If you intend to use this billing data in an automated fashion, please use the billing meter GUID to uniquely identify each billable item.
If the billing meter GUID is scheduled to change due to a new billing model, you will be notified in advance of the change.

### [Get-AzRecipientTransfer](Get-AzRecipientTransfer.md)
Gets the transfer with given transfer Id.

### [Get-AzReservationDetail](Get-AzReservationDetail.md)
Lists the reservations details for provided date range.

### [Get-AzReservationRecommendation](Get-AzReservationRecommendation.md)
List of recommendations for purchasing reserved instances.

### [Get-AzReservationSummary](Get-AzReservationSummary.md)
Lists the reservations summaries for daily or monthly grain.

### [Get-AzTransaction](Get-AzTransaction.md)
Lists the transactions by billing account name for given start and end date.

### [Get-AzTransfer](Get-AzTransfer.md)
Gets the transfer details for given transfer Id.

### [Get-AzUsageAggregate](Get-AzUsageAggregate.md)
Query aggregated Azure subscription consumption data for a date range.

### [Get-AzUsageDetail](Get-AzUsageDetail.md)
Lists the usage details for the defined scope.
Usage details are available via this API only for May 1, 2014 or later.

### [Invoke-AzAcceptRecipientTransfer](Invoke-AzAcceptRecipientTransfer.md)
Accepts the transfer with given transfer Id.

### [Invoke-AzDeclineRecipientTransfer](Invoke-AzDeclineRecipientTransfer.md)
Declines the transfer with given transfer Id.

### [Invoke-AzDownloadBillingProfilePricesheet](Invoke-AzDownloadBillingProfilePricesheet.md)
Get pricesheet data for invoice id (invoiceName).

### [Invoke-AzDownloadInvoicePricesheet](Invoke-AzDownloadInvoicePricesheet.md)
Get pricesheet data for invoice id (invoiceName).

### [Invoke-AzDownloadPriceSheet](Invoke-AzDownloadPriceSheet.md)
Download price sheet for an invoice.

### [Invoke-AzElevateInvoiceSectionToBillingProfile](Invoke-AzElevateInvoiceSectionToBillingProfile.md)
Elevates the caller's access to match their billing profile access.

### [Invoke-AzInitiateTransfer](Invoke-AzInitiateTransfer.md)
Initiates the request to transfer the legacy subscriptions or RIs.

### [Move-AzBillingProduct](Move-AzBillingProduct.md)
The operation to transfer a Product to another invoice section.

### [Move-AzBillingSubscription](Move-AzBillingSubscription.md)
Transfers the subscription from one invoice section to another within a billing account.

### [New-AzBudget](New-AzBudget.md)
The operation to create or update a budget.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [New-AzConsumptionCostTag](New-AzConsumptionCostTag.md)
The operation to create or update cost tags associated with a billing account.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [New-AzConsumptionCostTag](New-AzConsumptionCostTag.md)
The operation to create or update cost tags associated with a billing account.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [New-AzInvoiceSection](New-AzInvoiceSection.md)
The operation to create a InvoiceSection.

### [Remove-AzBillingBillingRoleAssignment](Remove-AzBillingBillingRoleAssignment.md)
Delete the role assignment on this billing account

### [Remove-AzBudget](Remove-AzBudget.md)
The operation to delete a budget.

### [Set-AzBillingPolicy](Set-AzBillingPolicy.md)
The operation to update a policy.

### [Set-AzBillingProfile](Set-AzBillingProfile.md)
The operation to update a billing profile.

### [Set-AzBudget](Set-AzBudget.md)
The operation to create or update a budget.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [Set-AzConsumptionCostTag](Set-AzConsumptionCostTag.md)
The operation to create or update cost tags associated with a billing account.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [Set-AzConsumptionCostTag](Set-AzConsumptionCostTag.md)
The operation to create or update cost tags associated with a billing account.
Update operation requires latest eTag to be set in the request mandatorily.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.

### [Set-AzInvoiceSection](Set-AzInvoiceSection.md)
The operation to update a InvoiceSection.

### [Stop-AzTransfer](Stop-AzTransfer.md)
Cancels the transfer for given transfer Id.

### [Update-AzBillingProductAutoRenew](Update-AzBillingProductAutoRenew.md)
Cancel auto renew for product by product id and billing account name

