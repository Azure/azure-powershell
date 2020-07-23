@{
  GUID = 'f6447640-ffdf-42f9-5ffe-a11eed4aa63f'
  RootModule = './Az.Billing.psm1'
  ModuleVersion = '4.0.2'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Billing cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Billing.private.dll'
  FormatsToProcess = './Az.Billing.format.ps1xml'
  CmdletsToExport = 'Get-AzBillingPeriod', 'Get-AzBudget', 'Get-AzEnrollmentAccount', 'Get-AzInvoice', 'Get-AzMarketplace', 'Get-AzPriceSheet', 'Get-AzReservationDetail', 'Get-AzReservationSummary', 'Get-AzUsageAggregate', 'Get-AzUsageDetail', 'New-AzBudget', 'Remove-AzBudget', 'Set-AzBudget', '*'
  AliasesToExport = 'Get-AzConsumptionBudget', 'Get-AzBillingInvoice', 'Get-AzConsumptionMarketplace', 'Get-AzConsumptionPriceSheet', 'Get-AzConsumptionReservationDetail', 'Get-AzConsumptionReservationSummary', 'Get-UsageAggregates', 'Get-AzConsumptionUsageDetail', 'New-AzConsumptionBudget', 'Remove-AzConsumptionBudget', 'Set-AzConsumptionBudget', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Billing'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Prerelease = 'preview'
      Profiles = 'latest-2019-04-30'
    }
  }
}
