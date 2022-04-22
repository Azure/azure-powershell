@{
  GUID = 'be1f13c1-ed9d-42d8-a044-47adbc11ec5e'
  RootModule = './Az.Consumption.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Consumption cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Consumption.private.dll'
  FormatsToProcess = './Az.Consumption.format.ps1xml'
  FunctionsToExport = 'Get-AzConsumptionAggregatedCost', 'Get-AzConsumptionBalance', 'Get-AzConsumptionBudget', 'Get-AzConsumptionCharge', 'Get-AzConsumptionCredit', 'Get-AzConsumptionEvent', 'Get-AzConsumptionLot', 'Get-AzConsumptionMarketplace', 'Get-AzConsumptionPriceSheet', 'Get-AzConsumptionReservationDetail', 'Get-AzConsumptionReservationRecommendation', 'Get-AzConsumptionReservationRecommendationDetail', 'Get-AzConsumptionReservationsDetail', 'Get-AzConsumptionReservationsSummary', 'Get-AzConsumptionReservationSummary', 'Get-AzConsumptionReservationTransaction', 'Get-AzConsumptionTag', 'Get-AzConsumptionUsageDetail', 'New-AzConsumptionBudget', 'Remove-AzConsumptionBudget', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Consumption'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
