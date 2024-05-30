@{
  GUID = '0e2f96c9-10b2-4c68-b181-d29e3bdfdeed'
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
  FunctionsToExport = 'Get-AzAksArcCluster', 'Get-AzAksArcClusterAdminKubeconfig', 'Get-AzAksArcClusterUpgrade', 'Get-AzAksArcClusterUserKubeconfig', 'Get-AzAksArcKubernetesVersion', 'Get-AzAksArcLog', 'Get-AzAksArcNodepool', 'Get-AzAksArcVMSku', 'New-AzAksArcCluster', 'New-AzAksArcNodepool', 'Remove-AzAksArcCluster', 'Remove-AzAksArcNodepool', 'Update-AzAksArcCluster', 'Update-AzAksArcNodepool'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AksArc'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
