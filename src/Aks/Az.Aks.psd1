@{
  GUID = '86a05d9c-17c1-4a8c-b761-3317c410d768'
  RootModule = './Az.Aks.psm1'
  ModuleVersion = '4.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Aks cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Aks.private.dll'
  FormatsToProcess = './Az.Aks.format.ps1xml'
  CmdletsToExport = 'Get-AzAks', 'Get-AzAksAccessProfile', 'Get-AzAksAdminCredentials', 'Get-AzAksAgentPool', 'Get-AzAksAgentPoolUpgradeProfile', 'Get-AzAksAvailableAgentPoolVersion', 'Get-AzAksUpgradeProfile', 'Get-AzAksUserCredentials', 'Import-AzAksCredential', 'Invoke-AzRotateAksCertificate', 'New-AzAks', 'New-AzAksAgentPool', 'Remove-AzAks', 'Remove-AzAksAgentPool', 'Reset-AzAksAadProfile', 'Reset-AzAksServicePrincipalProfile', 'Set-AzAks', 'Set-AzAksAgentPool', 'Start-AzAksDashboard', 'Stop-AzAksDashboard', 'Update-AzAksTag', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Aks'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
