@{
  GUID = '3cffe974-28ed-4d53-ba17-f80f0d1cebc5'
  RootModule = './Az.DataCollectionRule.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataCollectionRule cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataCollectionRule.private.dll'
  FormatsToProcess = './Az.DataCollectionRule.format.ps1xml'
  FunctionsToExport = 'Get-AzDataCollectionEndpoint', 'Get-AzDataCollectionRule', 'Get-AzDataCollectionRuleAssociation', 'New-AzDataCollectionEndpoint', 'New-AzDataCollectionRule', 'New-AzDataCollectionRuleAssociation', 'New-AzDataFlowObject', 'New-AzEventHubDestinationObject', 'New-AzEventHubDirectDestinationObject', 'New-AzExtensionDataSourceObject', 'New-AzIisLogsDataSourceObject', 'New-AzLogAnalyticsDestinationObject', 'New-AzLogFilesDataSourceObject', 'New-AzMonitoringAccountDestinationObject', 'New-AzPerfCounterDataSourceObject', 'New-AzPlatformTelemetryDataSourceObject', 'New-AzPrometheusForwarderDataSourceObject', 'New-AzStorageBlobDestinationObject', 'New-AzStorageTableDestinationObject', 'New-AzSyslogDataSourceObject', 'New-AzWindowsEventLogDataSourceObject', 'New-AzWindowsFirewallLogsDataSourceObject', 'Remove-AzDataCollectionEndpoint', 'Remove-AzDataCollectionRule', 'Remove-AzDataCollectionRuleAssociation', 'Update-AzDataCollectionEndpoint', 'Update-AzDataCollectionRule', 'Update-AzDataCollectionRuleAssociation'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataCollectionRule'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
