@{
  GUID = '9570a2dc-64ee-44f7-98d7-7a705803aa39'
  RootModule = './Az.Storage.psm1'
  ModuleVersion = '5.9.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Storage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Storage.private.dll'
  FormatsToProcess = './Az.Storage.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageAccountMigration', 'Get-AzStorageAdvancedPlatformMetricsRule', 'Get-AzStorageBlobAccessPointConfiguration', 'Get-AzStorageContextCache', 'Get-AzStorageContextCacheContainer', 'Get-AzStorageFileServiceUsage', 'Get-AzStorageNetworkSecurityPerimeterConfiguration', 'Get-AzStorageSku', 'Get-AzStorageTaskAssignment', 'Get-AzStorageTaskAssignmentInstancesReport', 'Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration', 'New-AzStorageAdvancedPlatformMetricsRule', 'New-AzStorageBlobAccessPointConfiguration', 'New-AzStorageContextCache', 'New-AzStorageContextCacheContainer', 'New-AzStorageTaskAssignment', 'Remove-AzStorageAdvancedPlatformMetricsRule', 'Remove-AzStorageBlobAccessPointConfiguration', 'Remove-AzStorageContextCache', 'Remove-AzStorageContextCacheContainer', 'Remove-AzStorageTaskAssignment', 'Set-AzStorageAdvancedPlatformMetricsRule', 'Set-AzStorageContextCache', 'Set-AzStorageContextCacheContainer', 'Start-AzStorageAccountMigration', 'Test-AzStorageBlobAccessPointConfigurationConnection', 'Test-AzStorageBlobAccessPointConnection', 'Test-AzStorageContextCacheNameAvailability', 'Update-AzStorageAdvancedPlatformMetricsRule', 'Update-AzStorageBlobAccessPointConfiguration', 'Update-AzStorageContextCache', 'Update-AzStorageContextCacheContainer', 'Update-AzStorageTaskAssignment'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Storage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
