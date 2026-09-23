@{
  GUID = 'e0f28b9c-6a6b-4b66-833e-c01780a5577b'
  RootModule = './Az.KeyVault.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: KeyVault cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.KeyVault.private.dll'
  FormatsToProcess = './Az.KeyVault.format.ps1xml'
  FunctionsToExport = 'Add-AzKeyVaultManagedHsmRegion', 'Get-AzKeyVaultManagedHsmRegion', 'Remove-AzKeyVaultManagedHsmRegion', 'Test-AzKeyVaultManagedHsmNameAvailability', 'Test-AzKeyVaultNameAvailability'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'KeyVault'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
