@{
  GUID = '5d9ea51e-3614-409d-b09a-9188a642e11c'
  RootModule = './Az.HdInsightOnAks.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HdInsightOnAks cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HdInsightOnAks.private.dll'
  FormatsToProcess = './Az.HdInsightOnAks.format.ps1xml'
  FunctionsToExport = 'Get-AzHdInsightOnAksAvailableClusterPoolVersion', 'Get-AzHdInsightOnAksAvailableClusterVersion', 'Get-AzHdInsightOnAksCluster', 'Get-AzHdInsightOnAksClusterAvailableUpgrade', 'Get-AzHdInsightOnAksClusterInstanceView', 'Get-AzHdInsightOnAksClusterJob', 'Get-AzHdInsightOnAksClusterPool', 'Get-AzHdInsightOnAksClusterPoolAvailableUpgrade', 'Get-AzHdInsightOnAksClusterServiceConfig', 'New-AzHdInsightOnAksCluster', 'New-AzHdInsightOnAksClusterConfigFileObject', 'New-AzHdInsightOnAksClusterHotfixUpgradeObject', 'New-AzHdInsightOnAksClusterPool', 'New-AzHdInsightOnAksClusterPoolAKSUpgradeObject', 'New-AzHdInsightOnAksClusterServiceConfigObject', 'New-AzHdInsightOnAksClusterServiceConfigsProfileObject', 'New-AzHdInsightOnAksFlinkJobObject', 'New-AzHdInsightOnAksNodeProfileObject', 'New-AzHdInsightOnAksSecretReferenceObject', 'New-AzHdInsightOnAksTrinoHiveCatalogObject', 'Remove-AzHdInsightOnAksCluster', 'Remove-AzHdInsightOnAksClusterPool', 'Resize-AzHdInsightOnAksCluster', 'Set-AzHdInsightOnAksClusterPool', 'Start-AzHdInsightOnAksClusterJob', 'Test-AzHdInsightOnAksLocationNameAvailability', 'Update-AzHdInsightOnAksCluster', 'Update-AzHdInsightOnAksClusterPool', 'Update-AzHdInsightOnAksClusterPoolTag'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HdInsightOnAks'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
