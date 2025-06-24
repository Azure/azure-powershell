@{
  GUID = '811e8d3c-d8cf-49b5-b59b-0e8820950993'
  RootModule = './Az.Carbon.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Carbon cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Carbon.private.dll'
  FormatsToProcess = './Az.Carbon.format.ps1xml'
  FunctionsToExport = 'Get-AzCarbonEmissionDataAvailableDateRange', 'Get-AzCarbonEmissionReport', 'New-AzCarbonItemDetailsQueryFilterObject', 'New-AzCarbonMonthlySummaryReportQueryFilterObject', 'New-AzCarbonOverallSummaryReportQueryFilterObject', 'New-AzCarbonTopItemsMonthlySummaryReportQueryFilterObject', 'New-AzCarbonTopItemsSummaryReportQueryFilterObject'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Carbon'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
