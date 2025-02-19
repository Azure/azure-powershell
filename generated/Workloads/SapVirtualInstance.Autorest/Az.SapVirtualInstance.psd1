@{
  GUID = 'afd2bdc9-d7ac-4bb4-941e-b8371d57b833'
  RootModule = './Az.SapVirtualInstance.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SapVirtualInstance cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SapVirtualInstance.private.dll'
  FormatsToProcess = './Az.SapVirtualInstance.format.ps1xml'
  FunctionsToExport = 'Get-AzWorkloadsSapApplicationInstance', 'Get-AzWorkloadsSapCentralInstance', 'Get-AzWorkloadsSapDatabaseInstance', 'Get-AzWorkloadsSapVirtualInstance', 'Invoke-AzWorkloadsSapDiskConfiguration', 'Invoke-AzWorkloadsSapSizingRecommendation', 'Invoke-AzWorkloadsSapSupportedSku', 'New-AzWorkloadsSapVirtualInstance', 'Remove-AzWorkloadsSapVirtualInstance', 'Start-AzWorkloadsSapApplicationInstance', 'Start-AzWorkloadsSapCentralInstance', 'Start-AzWorkloadsSapDatabaseInstance', 'Start-AzWorkloadsSapVirtualInstance', 'Stop-AzWorkloadsSapApplicationInstance', 'Stop-AzWorkloadsSapCentralInstance', 'Stop-AzWorkloadsSapDatabaseInstance', 'Stop-AzWorkloadsSapVirtualInstance', 'Update-AzWorkloadsSapApplicationInstance', 'Update-AzWorkloadsSapCentralInstance', 'Update-AzWorkloadsSapDatabaseInstance', 'Update-AzWorkloadsSapVirtualInstance', '*'
  AliasesToExport = 'Get-AzVISApplicationInstance', 'Get-AzVISCentralInstance', 'Get-AzVISDatabaseInstance', 'Get-AzVIS', 'Invoke-AzVISDiskConfiguration', 'Invoke-AzVISSizingRecommendation', 'Invoke-AzVISSupportedSku', 'New-AzVIS', 'Remove-AzVIS', 'Start-AzVISApplicationInstance', 'Start-AzVISCentralInstance', 'Start-AzVISDatabaseInstance', 'Start-AzVIS', 'Stop-AzVISApplicationInstance', 'Stop-AzVISCentralInstance', 'Stop-AzVISDatabaseInstance', 'Stop-AzVIS', 'Update-AzVISApplicationInstance', 'Update-AzVISCentralInstance', 'Update-AzVISDatabaseInstance', 'Update-AzVIS', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SapVirtualInstance'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
