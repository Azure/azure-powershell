@{
  GUID = '25536d6e-88b4-466f-8673-8a34eabbc9aa'
  RootModule = './Az.RedHatOpenShiftHcp.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: RedHatOpenShiftHcp cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.RedHatOpenShiftHcp.private.dll'
  FormatsToProcess = './Az.RedHatOpenShiftHcp.format.ps1xml'
  FunctionsToExport = 'Get-AzRedHatOpenShiftHcpCluster', 'Get-AzRedHatOpenShiftHcpExternalAuth', 'Get-AzRedHatOpenShiftHcpNodePool', 'Get-AzRedHatOpenShiftHcpVersion', 'New-AzRedHatOpenShiftHcpCluster', 'New-AzRedHatOpenShiftHcpExternalAuth', 'New-AzRedHatOpenShiftHcpNodePool', 'Remove-AzRedHatOpenShiftHcpCluster', 'Remove-AzRedHatOpenShiftHcpExternalAuth', 'Remove-AzRedHatOpenShiftHcpNodePool', 'Request-AzRedHatOpenShiftHcpClusterAdminCredential', 'Revoke-AzRedHatOpenShiftHcpClusterCredentials', 'Update-AzRedHatOpenShiftHcpCluster', 'Update-AzRedHatOpenShiftHcpExternalAuth', 'Update-AzRedHatOpenShiftHcpNodePool'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'RedHatOpenShiftHcp'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
