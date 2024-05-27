@{
  GUID = '9268e549-a958-48b5-ae1e-acd7267ddb58'
  RootModule = './Az.ManagedServiceIdentity.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ManagedServiceIdentity cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ManagedServiceIdentity.private.dll'
  FormatsToProcess = './Az.ManagedServiceIdentity.format.ps1xml'
  FunctionsToExport = 'Get-AzFederatedIdentityCredential', 'Get-AzSystemAssignedIdentity', 'Get-AzUserAssignedIdentity', 'Get-AzUserAssignedIdentityAssociatedResource', 'New-AzFederatedIdentityCredential', 'New-AzUserAssignedIdentity', 'Remove-AzFederatedIdentityCredential', 'Remove-AzUserAssignedIdentity', 'Update-AzFederatedIdentityCredential', 'Update-AzUserAssignedIdentity', '*'
  AliasesToExport = 'Get-AzFederatedIdentityCredentials', 'New-AzFederatedIdentityCredentials', 'Remove-AzFederatedIdentityCredentials', 'Update-AzFederatedIdentityCredentials', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ManagedServiceIdentity'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
