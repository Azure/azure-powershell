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
  FunctionsToExport = 'Get-AzAksMaintenanceConfiguration', 'Get-AzAksManagedClusterCommandResult', 'Get-AzAksManagedClusterOSOption', 'Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint', 'Get-AzAksNodePoolUpgradeProfile', 'Get-AzAksSnapshot', 'Get-AzAksUpgradeProfile', 'Get-AzAksVersion', 'Install-AzAksCliTool', 'Invoke-AzAksAbortAgentPoolLatestOperation', 'Invoke-AzAksAbortManagedClusterLatestOperation', 'Invoke-AzAksRotateManagedClusterServiceAccountSigningKey', 'New-AzAksMaintenanceConfiguration', 'New-AzAksSnapshot', 'New-AzAksTimeInWeekObject', 'New-AzAksTimeSpanObject', 'Remove-AzAksMaintenanceConfiguration', 'Remove-AzAksSnapshot', 'Start-AzAksCluster', 'Start-AzAksManagedClusterCommand', 'Stop-AzAksCluster', '*'
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
