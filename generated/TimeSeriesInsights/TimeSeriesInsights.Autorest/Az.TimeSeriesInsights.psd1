@{
  GUID = 'c3da39a4-7b6f-4973-be69-542c2174633a'
  RootModule = './Az.TimeSeriesInsights.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: TimeSeriesInsights cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.TimeSeriesInsights.private.dll'
  FormatsToProcess = './Az.TimeSeriesInsights.format.ps1xml'
  FunctionsToExport = 'Get-AzTimeSeriesInsightsAccessPolicy', 'Get-AzTimeSeriesInsightsEnvironment', 'Get-AzTimeSeriesInsightsEventSource', 'Get-AzTimeSeriesInsightsReferenceDataSet', 'New-AzTimeSeriesInsightsAccessPolicy', 'New-AzTimeSeriesInsightsEnvironment', 'New-AzTimeSeriesInsightsEventSource', 'New-AzTimeSeriesInsightsReferenceDataSet', 'Remove-AzTimeSeriesInsightsAccessPolicy', 'Remove-AzTimeSeriesInsightsEnvironment', 'Remove-AzTimeSeriesInsightsEventSource', 'Remove-AzTimeSeriesInsightsReferenceDataSet', 'Update-AzTimeSeriesInsightsAccessPolicy', 'Update-AzTimeSeriesInsightsEnvironment', 'Update-AzTimeSeriesInsightsEventSource', 'Update-AzTimeSeriesInsightsReferenceDataSet', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'TimeSeriesInsights'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
