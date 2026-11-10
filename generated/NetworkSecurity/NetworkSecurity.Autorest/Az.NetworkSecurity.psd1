@{
  GUID = '4bd5a49c-3584-40f8-a24c-efc9395c8524'
  RootModule = './Az.NetworkSecurity.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NetworkSecurity cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NetworkSecurity.private.dll'
  FormatsToProcess = './Az.NetworkSecurity.format.ps1xml'
  FunctionsToExport = 'Get-AzNetworkSecurityNeuroShield', 'Get-AzNetworkSecurityNeuroShieldFinding', 'Get-AzNetworkSecurityNeuroShieldMitigation', 'Get-AzNetworkSecurityNeuroShieldOperationStatus', 'Get-AzNetworkSecurityNeuroShieldProtectedResource', 'Get-AzNetworkSecurityNeuroShieldSummary', 'Get-AzNetworkSecurityOperation', 'Invoke-AzNetworkSecurityNeuroShieldFindingMitigation', 'Invoke-AzNetworkSecurityNeuroShieldFindingRollback', 'Invoke-AzNetworkSecurityNeuroShieldMitigationExecution', 'Invoke-AzNetworkSecurityNeuroShieldMitigationRollback', 'Invoke-AzNetworkSecurityNeuroShieldProtectedResourceInventoryUpload', 'New-AzNetworkSecurityNeuroShield', 'New-AzNetworkSecurityNeuroShieldProtectedResource', 'Remove-AzNetworkSecurityNeuroShield', 'Remove-AzNetworkSecurityNeuroShieldProtectedResource', 'Update-AzNetworkSecurityNeuroShield'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NetworkSecurity'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
