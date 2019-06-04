@{
# region definition 
  RootModule = './Az.Billing.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Billing cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Billing.private.dll'
  FormatsToProcess = './Az.Billing.format.ps1xml'
# endregion 

# region persistent data 
  GUID = 'f6447640-ffdf-42f9-5ffe-a11eed4aa63f'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Billing'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30'
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Add-AzBillingBillingRoleAssignment', 'Get-AzAggregatedCost', 'Get-AzAgreement', 'Get-AzAvailableCreditBalance', 'Get-AzBalance', 'Get-AzBillingAccount', 'Get-AzBillingBillingRoleAssignment', 'Get-AzBillingPeriod', 'Get-AzBillingPermission', 'Get-AzBillingPolicy', 'Get-AzBillingProduct', 'Get-AzBillingProfile', 'Get-AzBillingProperty', 'Get-AzBillingRoleDefinition', 'Get-AzBillingSubscription', 'Get-AzBudget', 'Get-AzCharge', 'Get-AzChargesByBillingAccount', 'Get-AzChargesByBillingProfile', 'Get-AzChargesByInvoiceSection', 'Get-AzConsumptionCostTag', 'Get-AzConsumptionTag', 'Get-AzConsumptionTenant', 'Get-AzCreditSummary', 'Get-AzDepartment', 'Get-AzEnrollmentAccount', 'Get-AzEventsByBillingProfile', 'Get-AzForecast', 'Get-AzInvoice', 'Get-AzInvoiceLatest', 'Get-AzInvoiceSection', 'Get-AzLotsByBillingProfile', 'Get-AzMarketplace', 'Get-AzPaymentMethod', 'Get-AzPriceSheet', 'Get-AzRateCard', 'Get-AzRecipientTransfer', 'Get-AzReservationDetail', 'Get-AzReservationRecommendation', 'Get-AzReservationSummary', 'Get-AzTransaction', 'Get-AzTransfer', 'Get-AzUsageAggregate', 'Get-AzUsageDetail', 'Invoke-AzAcceptRecipientTransfer', 'Invoke-AzDeclineRecipientTransfer', 'Invoke-AzDownloadBillingProfilePricesheet', 'Invoke-AzDownloadInvoicePricesheet', 'Invoke-AzDownloadPriceSheet', 'Invoke-AzElevateInvoiceSectionToBillingProfile', 'Invoke-AzInitiateTransfer', 'Move-AzBillingProduct', 'Move-AzBillingSubscription', 'New-AzBudget', 'New-AzConsumptionCostTag', 'New-AzInvoiceSection', 'Remove-AzBillingBillingRoleAssignment', 'Remove-AzBudget', 'Set-AzBillingPolicy', 'Set-AzBillingProfile', 'Set-AzBudget', 'Set-AzConsumptionCostTag', 'Set-AzInvoiceSection', 'Stop-AzTransfer', 'Update-AzBillingProductAutoRenew', '*'
  AliasesToExport = 'Get-AzConsumptionAggregatedCost', 'Get-AzBillingAgreement', 'Get-AzConsumptionAvailableBalance', 'Get-AzConsumptionBalance', 'Get-AzConsumptionBudget', 'Get-AzConsumptionCharge', 'Get-AzConsumptionChargesByBillingAccount', 'Get-AzConsumptionChargesByBillingProfile', 'Get-AzBillingChargesByInvoiceSection', 'Get-AzConsumptionChargesByInvoiceSection', 'Get-AzConsumptionCostTag', 'Get-AzConsumptionCreditSummary', 'Get-AzBillingDepartment', 'Get-AzConsumptionForecast', 'Get-AzBillingInvoice', 'Get-AzBillingInvoiceLatest', 'Get-AzBillingInvoiceSection', 'Get-AzConsumptionMarketplace', 'Get-AzBillingPaymentMethod', 'Get-AzConsumptionPriceSheet', 'Get-AzBillingRecipientTransfer', 'Get-AzConsumptionReservationDetail', 'Get-AzConsumptionReservationRecommendation', 'Get-AzConsumptionReservationSummary', 'Get-AzBillingTransaction', 'Get-AzBillingTransfer', 'Get-AzConsumptionUsageDetail', 'Invoke-AzBillingAcceptRecipientTransfer', 'Invoke-AzBillingDeclineRecipientTransfer', 'Invoke-AzConsumptionDownloadBillingProfilePricesheet', 'Invoke-AzBillingDownloadInvoicePricesheet', 'Invoke-AzConsumptionDownloadInvoicePricesheet', 'Invoke-AzConsumptionDownloadPriceSheet', 'Invoke-AzBillingElevateInvoiceSectionToBillingProfile', 'Invoke-AzBillingInitiateTransfer', 'New-AzConsumptionBudget', 'New-AzConsumptionCostTag', 'New-AzBillingInvoiceSection', 'Remove-AzConsumptionBudget', 'Set-AzConsumptionBudget', 'Set-AzConsumptionCostTag', 'Set-AzBillingInvoiceSection', 'Stop-AzBillingTransfer', '*'
# endregion

}