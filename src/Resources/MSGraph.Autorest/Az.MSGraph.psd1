@{
  GUID = '9c1e9bcf-5175-4d03-99c7-a7f2f7040f46'
  RootModule = './Az.MSGraph.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MSGraph cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MSGraph.private.dll'
  FormatsToProcess = './Az.MSGraph.format.ps1xml'
  FunctionsToExport = 'Add-AzADAppPermission', 'Add-AzADGroupMember', 'Get-AzADAppCredential', 'Get-AzADApplication', 'Get-AzADApplicationFederatedIdentityCredential', 'Get-AzADAppPermission', 'Get-AzADGroup', 'Get-AzADGroupMember', 'Get-AzADServicePrincipal', 'Get-AzADSpCredential', 'Get-AzADUser', 'New-AzADAppCredential', 'New-AzADApplication', 'New-AzADapplicationfederatedidentitycredential', 'New-AzADGroup', 'New-AzADServicePrincipal', 'New-AzADSpCredential', 'New-AzADUser', 'Remove-AzADAppCredential', 'Remove-AzADApplication', 'Remove-AzADapplicationfederatedidentitycredential', 'Remove-AzADAppPermission', 'Remove-AzADGroup', 'Remove-AzADGroupMember', 'Remove-AzADServicePrincipal', 'Remove-AzADSpCredential', 'Remove-AzADUser', 'Update-AzADApplication', 'Update-AzADapplicationfederatedidentitycredential', 'Update-AzADGroup', 'Update-AzADServicePrincipal', 'Update-AzADUser', '*'
  AliasesToExport = 'Get-AzADServicePrincipalCredential', 'New-AzADServicePrincipalCredential', 'Remove-AzADServicePrincipalCredential', 'Set-AzADApplication', 'Set-AzADServicePrincipal', 'Set-AzADUser', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MSGraph'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
