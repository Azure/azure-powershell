@{
  GUID = '031a685e-5904-433f-b2f8-4fcef3cd15d8'
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
  FunctionsToExport = 'Get-AzApplicationInsights', 'Get-AzApplicationInsightsApiKey', 'Get-AzApplicationInsightsContinuousExport', 'Get-AzApplicationInsightsLinkedStorageAccount', 'Get-AzApplicationInsightsMyWorkbook', 'Get-AzApplicationInsightsWebTest', 'Get-AzApplicationInsightsWorkbook', 'Get-AzApplicationInsightsWorkbookRevision', 'Get-AzApplicationInsightsWorkbookTemplate', 'New-AzApplicationInsights', 'New-AzApplicationInsightsApiKey', 'New-AzApplicationInsightsContinuousExport', 'New-AzApplicationInsightsLinkedStorageAccount', 'New-AzApplicationInsightsMyWorkbook', 'New-AzApplicationInsightsWebTest', 'New-AzApplicationInsightsWebTestGeolocationObject', 'New-AzApplicationInsightsWebTestHeaderFieldObject', 'New-AzApplicationInsightsWorkbook', 'New-AzApplicationInsightsWorkbookTemplate', 'New-AzApplicationInsightsWorkbookTemplateGalleryObject', 'Remove-AzApplicationInsights', 'Remove-AzApplicationInsightsApiKey', 'Remove-AzApplicationInsightsContinuousExport', 'Remove-AzApplicationInsightsLinkedStorageAccount', 'Remove-AzApplicationInsightsMyWorkbook', 'Remove-AzApplicationInsightsWebTest', 'Remove-AzApplicationInsightsWorkbook', 'Remove-AzApplicationInsightsWorkbookTemplate', 'Set-AzApplicationInsightsContinuousExport', 'Set-AzApplicationInsightsDailyCap', 'Set-AzApplicationInsightsPricingPlan', 'Update-AzApplicationInsights', 'Update-AzApplicationInsightsLinkedStorageAccount', 'Update-AzApplicationInsightsMyWorkbook', 'Update-AzApplicationInsightsWebTestTag', 'Update-AzApplicationInsightsWorkbook', 'Update-AzApplicationInsightsWorkbookTemplate', '*'
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
