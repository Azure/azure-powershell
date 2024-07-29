@{
  GUID = 'b12bc6f4-a4bf-4e80-89e4-f13e640b7f12'
  RootModule = './Az.AksArc.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AksArc cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AksArc.private.dll'
  FormatsToProcess = './Az.AksArc.format.ps1xml'
  FunctionsToExport = 'Get-AzAksArcCluster', 'Get-AzAksArcClusterAdminKubeconfig', 'Get-AzAksArcClusterUpgrade', 'Get-AzAksArcClusterUserKubeconfig', 'Get-AzAksArcKubernetesVersion', 'Get-AzAksArcLog', 'Get-AzAksArcNodepool', 'Get-AzAksArcVirtualNetwork', 'Get-AzAksArcVMSku', 'Invoke-AzAksArcClusterUpgrade', 'New-AzAksArcCluster', 'New-AzAksArcNodepool', 'New-AzAksArcVirtualNetwork', 'Remove-AzAksArcCluster', 'Remove-AzAksArcNodepool', 'Remove-AzAksArcVirtualNetwork', 'Update-AzAksArcCluster', 'Update-AzAksArcNodepool'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AksArc'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
