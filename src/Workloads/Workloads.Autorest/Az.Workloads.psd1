@{
  GUID = 'ee197d70-9add-4652-9b94-eab7bc0e93e1'
  RootModule = './Az.Workloads.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Workloads cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Workloads.private.dll'
  FormatsToProcess = './Az.Workloads.format.ps1xml'
  FunctionsToExport = 'Get-AzWorkloadsMonitor', 'Get-AzWorkloadsProviderInstance', 'Get-AzWorkloadsSapApplicationInstance', 'Get-AzWorkloadsSapCentralInstance', 'Get-AzWorkloadsSapDatabaseInstance', 'Get-AzWorkloadsSapLandscapeMonitor', 'Get-AzWorkloadsSapVirtualInstance', 'Invoke-AzWorkloadsSapDiskConfiguration', 'Invoke-AzWorkloadsSapSizingRecommendation', 'Invoke-AzWorkloadsSapSupportedSku', 'New-AzWorkloadsMonitor', 'New-AzWorkloadsProviderDB2InstanceObject', 'New-AzWorkloadsProviderHanaDbInstanceObject', 'New-AzWorkloadsProviderInstance', 'New-AzWorkloadsProviderPrometheusHaClusterInstanceObject', 'New-AzWorkloadsProviderPrometheusOSInstanceObject', 'New-AzWorkloadsProviderSapNetWeaverInstanceObject', 'New-AzWorkloadsProviderSqlServerInstanceObject', 'New-AzWorkloadsSapLandscapeMonitor', 'New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject', 'New-AzWorkloadsSapLandscapeMonitorSidMappingObject', 'New-AzWorkloadsSapVirtualInstance', 'Remove-AzWorkloadsMonitor', 'Remove-AzWorkloadsProviderInstance', 'Remove-AzWorkloadsSapLandscapeMonitor', 'Remove-AzWorkloadsSapVirtualInstance', 'Start-AzWorkloadsSapApplicationInstance', 'Start-AzWorkloadsSapCentralInstance', 'Start-AzWorkloadsSapDatabaseInstance', 'Start-AzWorkloadsSapVirtualInstance', 'Stop-AzWorkloadsSapApplicationInstance', 'Stop-AzWorkloadsSapCentralInstance', 'Stop-AzWorkloadsSapDatabaseInstance', 'Stop-AzWorkloadsSapVirtualInstance', 'Update-AzWorkloadsMonitor', 'Update-AzWorkloadsSapApplicationInstance', 'Update-AzWorkloadsSapCentralInstance', 'Update-AzWorkloadsSapDatabaseInstance', 'Update-AzWorkloadsSapLandscapeMonitor', 'Update-AzWorkloadsSapVirtualInstance', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Workloads'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
