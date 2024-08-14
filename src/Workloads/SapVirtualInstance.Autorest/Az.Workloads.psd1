@{
  GUID = 'cbe5c695-f562-48bb-9c72-329310c96915'
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
  FunctionsToExport = 'Get-AzWorkloadsSapApplicationInstance', 'Get-AzWorkloadsSapCentralInstance', 'Get-AzWorkloadsSapDatabaseInstance', 'Get-AzWorkloadsSapVirtualInstance', 'Invoke-AzWorkloadsSapDiskConfiguration', 'Invoke-AzWorkloadsSapSizingRecommendation', 'Invoke-AzWorkloadsSapSupportedSku', 'New-AzWorkloadsSapVirtualInstance', 'Remove-AzWorkloadsSapVirtualInstance', 'Start-AzWorkloadsSapApplicationInstance', 'Start-AzWorkloadsSapCentralInstance', 'Start-AzWorkloadsSapDatabaseInstance', 'Start-AzWorkloadsSapVirtualInstance', 'Stop-AzWorkloadsSapApplicationInstance', 'Stop-AzWorkloadsSapCentralInstance', 'Stop-AzWorkloadsSapDatabaseInstance', 'Stop-AzWorkloadsSapVirtualInstance', 'Update-AzWorkloadsSapApplicationInstance', 'Update-AzWorkloadsSapCentralInstance', 'Update-AzWorkloadsSapDatabaseInstance', 'Update-AzWorkloadsSapVirtualInstance', '*'
  AliasesToExport = 'Get-AzVisSapVirtualInstance', 'Remove-AzVisSapVirtualInstance', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Workloads'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
