@{
  GUID = 'b98dded0-6e9a-4371-b2c6-d74464fb724b'
  RootModule = './Az.CustomProviders.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Custom Providers cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CustomProviders.private.dll'
  RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '2.2.5'; })
  FormatsToProcess = './Az.CustomProviders.format.ps1xml'
  FunctionsToExport = 'Get-AzCustomProvider', 'Get-AzCustomProviderAssociation', 'New-AzCustomProvider', 'New-AzCustomProviderAssociation', 'Remove-AzCustomProvider', 'Remove-AzCustomProviderAssociation', 'Update-AzCustomProvider'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CustomProviders'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = '* the first preview release'
    }
  }
}
