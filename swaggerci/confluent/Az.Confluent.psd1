@{
  GUID = '3ed3f85a-2632-4099-b6c4-6fbc8618d71e'
  RootModule = './Az.Confluent.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Confluent cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Confluent.private.dll'
  FormatsToProcess = './Az.Confluent.format.ps1xml'
  FunctionsToExport = 'Get-AzConfluentMarketplaceAgreement', 'Get-AzConfluentOrganization', 'Get-AzConfluentOrganizationOperation', 'New-AzConfluentMarketplaceAgreement', 'New-AzConfluentOrganization', 'Remove-AzConfluentOrganization', 'Test-AzConfluentValidationOrganization', 'Update-AzConfluentOrganization', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Confluent'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
