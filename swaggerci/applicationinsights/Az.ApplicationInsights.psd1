@{
  GUID = '18307057-db6b-461e-924f-334f311ef139'
  RootModule = './Az.ApplicationInsights.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ApplicationInsights cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ApplicationInsights.private.dll'
  FormatsToProcess = './Az.ApplicationInsights.format.ps1xml'
  FunctionsToExport = 'Add-AzApplicationInsightsFavorite', 'Clear-AzApplicationInsightsComponent', 'Get-AzApplicationInsightsAnalyticsItem', 'Get-AzApplicationInsightsAnnotation', 'Get-AzApplicationInsightsApiKey', 'Get-AzApplicationInsightsComponent', 'Get-AzApplicationInsightsComponentAvailableFeature', 'Get-AzApplicationInsightsComponentCurrentBillingFeature', 'Get-AzApplicationInsightsComponentFeatureCapability', 'Get-AzApplicationInsightsComponentLinkedStorageAccount', 'Get-AzApplicationInsightsComponentPurgeStatus', 'Get-AzApplicationInsightsComponentQuotaStatus', 'Get-AzApplicationInsightsExportConfiguration', 'Get-AzApplicationInsightsFavorite', 'Get-AzApplicationInsightsLiveToken', 'Get-AzApplicationInsightsMyWorkbook', 'Get-AzApplicationInsightsProactiveDetectionConfiguration', 'Get-AzApplicationInsightsWebTest', 'Get-AzApplicationInsightsWebTestLocation', 'Get-AzApplicationInsightsWorkbook', 'Get-AzApplicationInsightsWorkbookRevision', 'Get-AzApplicationInsightsWorkbookTemplate', 'Get-AzApplicationInsightsWorkItemConfiguration', 'Get-AzApplicationInsightsWorkItemConfigurationDefault', 'Get-AzApplicationInsightsWorkItemConfigurationItem', 'New-AzApplicationInsightsAnnotation', 'New-AzApplicationInsightsApiKey', 'New-AzApplicationInsightsComponent', 'New-AzApplicationInsightsComponentLinkedStorageAccountAndUpdate', 'New-AzApplicationInsightsExportConfiguration', 'New-AzApplicationInsightsMyWorkbook', 'New-AzApplicationInsightsWebTest', 'New-AzApplicationInsightsWorkbook', 'New-AzApplicationInsightsWorkbookTemplate', 'New-AzApplicationInsightsWorkItemConfiguration', 'Remove-AzApplicationInsightsAnalyticsItem', 'Remove-AzApplicationInsightsAnnotation', 'Remove-AzApplicationInsightsApiKey', 'Remove-AzApplicationInsightsComponent', 'Remove-AzApplicationInsightsComponentLinkedStorageAccount', 'Remove-AzApplicationInsightsExportConfiguration', 'Remove-AzApplicationInsightsFavorite', 'Remove-AzApplicationInsightsMyWorkbook', 'Remove-AzApplicationInsightsWebTest', 'Remove-AzApplicationInsightsWorkbook', 'Remove-AzApplicationInsightsWorkbookTemplate', 'Remove-AzApplicationInsightsWorkItemConfiguration', 'Update-AzApplicationInsightsComponentLinkedStorageAccount', 'Update-AzApplicationInsightsComponentTag', 'Update-AzApplicationInsightsFavorite', 'Update-AzApplicationInsightsMyWorkbook', 'Update-AzApplicationInsightsWebTestTag', 'Update-AzApplicationInsightsWorkbook', 'Update-AzApplicationInsightsWorkbookTemplate', 'Update-AzApplicationInsightsWorkItemConfigurationItem', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ApplicationInsights'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
