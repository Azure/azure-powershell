@{
  GUID = '15fbef14-845a-48e1-a35b-d8e8b910ae27'
  RootModule = './Az.Aks.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Aks cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Aks.private.dll'
  FormatsToProcess = './Az.Aks.format.ps1xml'
  FunctionsToExport = 'Get-AzAksNodePoolUpgradeProfile', 'Get-AzAksUpgradeProfile', 'Get-AzAksVersion', 'Start-AzAksCluster', 'Stop-AzAksCluster', '*'
  AliasesToExport = 'Get-AzAksClusterUpgradeProfile', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Aks'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
