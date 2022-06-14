@{
  GUID = '40504018-542b-408a-8ecd-ab6d6cd4dc6f'
  RootModule = './Az.StreamAnalytics.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StreamAnalytics cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StreamAnalytics.private.dll'
  FormatsToProcess = './Az.StreamAnalytics.format.ps1xml'
  FunctionsToExport = 'Get-AzStreamAnalyticsCluster', 'Get-AzStreamAnalyticsClusterStreamingJob', 'Get-AzStreamAnalyticsFunction', 'Get-AzStreamAnalyticsFunctionDefaultDefinition', 'Get-AzStreamAnalyticsInput', 'Get-AzStreamAnalyticsOutput', 'Get-AzStreamAnalyticsPrivateEndpoint', 'Get-AzStreamAnalyticsStreamingJob', 'Get-AzStreamAnalyticsSubscriptionQuota', 'Get-AzStreamAnalyticsTransformation', 'Invoke-AzStreamAnalyticsScaleStreamingJob', 'New-AzStreamAnalyticsCluster', 'New-AzStreamAnalyticsFunction', 'New-AzStreamAnalyticsInput', 'New-AzStreamAnalyticsOutput', 'New-AzStreamAnalyticsPrivateEndpoint', 'New-AzStreamAnalyticsStreamingJob', 'New-AzStreamAnalyticsTransformation', 'Remove-AzStreamAnalyticsCluster', 'Remove-AzStreamAnalyticsFunction', 'Remove-AzStreamAnalyticsInput', 'Remove-AzStreamAnalyticsOutput', 'Remove-AzStreamAnalyticsPrivateEndpoint', 'Remove-AzStreamAnalyticsStreamingJob', 'Start-AzStreamAnalyticsStreamingJob', 'Stop-AzStreamAnalyticsStreamingJob', 'Test-AzStreamAnalyticsFunction', 'Test-AzStreamAnalyticsInput', 'Test-AzStreamAnalyticsOutput', 'Update-AzStreamAnalyticsCluster', 'Update-AzStreamAnalyticsFunction', 'Update-AzStreamAnalyticsInput', 'Update-AzStreamAnalyticsOutput', 'Update-AzStreamAnalyticsStreamingJob', 'Update-AzStreamAnalyticsTransformation', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StreamAnalytics'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
