@{
  GUID = 'f3d53463-b28b-49f7-ad47-ad0c3fc4003a'
  RootModule = './Az.Cost.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Cost cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Cost.private.dll'
  FormatsToProcess = './Az.Cost.format.ps1xml'
  FunctionsToExport = 'Get-AzCostAlert', 'Get-AzCostAlertExternal', 'Get-AzCostDimension', 'Get-AzCostExport', 'Get-AzCostExportExecutionHistory', 'Get-AzCostGenerateDetailedCostReportOperationResult', 'Get-AzCostGenerateDetailedCostReportOperationStatus', 'Get-AzCostView', 'Invoke-AzCostByDimensionExternalCloudProviderType', 'Invoke-AzCostByGenerateReservationDetailReportBillingAccountId', 'Invoke-AzCostByGenerateReservationDetailReportBillingProfileId', 'Invoke-AzCostCloudForecast', 'Invoke-AzCostDismissAlert', 'Invoke-AzCostExecuteExport', 'Invoke-AzCostUsageForecast', 'Invoke-AzCostUsageQuery', 'New-AzCostExport', 'New-AzCostGenerateDetailedCostReportOperation', 'New-AzCostView', 'Remove-AzCostExport', 'Remove-AzCostView', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Cost'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
