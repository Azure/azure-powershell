@{
  GUID = '382ba7a1-610b-4194-9aaa-e1142a4399d5'
  RootModule = './Az.Monitors.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Monitors cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Monitors.private.dll'
  FormatsToProcess = './Az.Monitors.format.ps1xml'
  FunctionsToExport = 'Get-AzWorkloadsMonitor', 'Get-AzWorkloadsProviderInstance', 'Get-AzWorkloadsSapLandscapeMonitor', 'New-AzWorkloadsMonitor', 'New-AzWorkloadsProviderDB2InstanceObject', 'New-AzWorkloadsProviderHanaDbInstanceObject', 'New-AzWorkloadsProviderInstance', 'New-AzWorkloadsProviderPrometheusHaClusterInstanceObject', 'New-AzWorkloadsProviderPrometheusOSInstanceObject', 'New-AzWorkloadsProviderSapNetWeaverInstanceObject', 'New-AzWorkloadsProviderSqlServerInstanceObject', 'New-AzWorkloadsSapLandscapeMonitor', 'New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject', 'New-AzWorkloadsSapLandscapeMonitorSidMappingObject', 'Remove-AzWorkloadsMonitor', 'Remove-AzWorkloadsProviderInstance', 'Remove-AzWorkloadsSapLandscapeMonitor', 'Update-AzWorkloadsMonitor', 'Update-AzWorkloadsSapLandscapeMonitor', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Monitors'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
