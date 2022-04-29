@{
  GUID = 'd41ab191-1da6-44aa-91ba-a3f9e942c929'
  RootModule = './Az.ManagedServiceIdentity.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ManagedServiceIdentity cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ManagedServiceIdentity.private.dll'
  FormatsToProcess = './Az.ManagedServiceIdentity.format.ps1xml'
  FunctionsToExport = 'Get-AzManagedServiceIdentitySystemAssignedIdentity', 'Get-AzManagedServiceIdentityUserAssignedIdentity', 'Get-AzManagedServiceIdentityUserAssignedIdentityAssociatedResource', 'New-AzManagedServiceIdentityUserAssignedIdentity', 'Remove-AzManagedServiceIdentityUserAssignedIdentity', 'Update-AzManagedServiceIdentityUserAssignedIdentity', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ManagedServiceIdentity'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
