@{
  GUID = '40af02af-b9a4-40ef-9dc5-5ea4d5e5e3be'
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
  FunctionsToExport = 'Get-AzHdInsightOnAksAvailableClusterPoolVersion', 'Get-AzHdInsightOnAksAvailableClusterVersion', 'Get-AzHdInsightOnAksCluster', 'Get-AzHdInsightOnAksClusterAvailableUpgrade', 'Get-AzHdInsightOnAksClusterInstanceView', 'Get-AzHdInsightOnAksClusterJob', 'Get-AzHdInsightOnAksClusterLibrary', 'Get-AzHdInsightOnAksClusterPool', 'Get-AzHdInsightOnAksClusterPoolAvailableUpgrade', 'Get-AzHdInsightOnAksClusterPoolUpgradeHistory', 'Get-AzHdInsightOnAksClusterServiceConfig', 'Get-AzHdInsightOnAksClusterUpgradeHistory', 'Invoke-AzHdInsightOnAksManageClusterLibrary', 'New-AzHdInsightOnAksCluster', 'New-AzHdInsightOnAksClusterConfigFileObject', 'New-AzHdInsightOnAksClusterHotfixUpgradeObject', 'New-AzHdInsightOnAksClusterMavenLibraryObject', 'New-AzHdInsightOnAksClusterPool', 'New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject', 'New-AzHdInsightOnAksClusterPyPiLibraryObject', 'New-AzHdInsightOnAksClusterServiceConfigObject', 'New-AzHdInsightOnAksClusterServiceConfigsProfileObject', 'New-AzHdInsightOnAksFlinkJobObject', 'New-AzHdInsightOnAksManagedIdentityObject', 'New-AzHdInsightOnAksNodeProfileObject', 'New-AzHdInsightOnAksSecretReferenceObject', 'New-AzHdInsightOnAksTrinoHiveCatalogObject', 'Remove-AzHdInsightOnAksCluster', 'Remove-AzHdInsightOnAksClusterPool', 'Resize-AzHdInsightOnAksCluster', 'Set-AzHdInsightOnAksClusterPool', 'Start-AzHdInsightOnAksClusterJob', 'Test-AzHdInsightOnAksLocationNameAvailability', 'Update-AzHdInsightOnAksCluster', 'Update-AzHdInsightOnAksClusterPoolTag', 'Upgrade-AzHdInsightOnAksCluster', 'Upgrade-AzHdInsightOnAksClusterManualRollback', 'Upgrade-AzHdInsightOnAksClusterPool'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HdInsightOnAks'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
