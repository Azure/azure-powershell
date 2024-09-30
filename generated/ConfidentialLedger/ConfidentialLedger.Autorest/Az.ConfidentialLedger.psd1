@{
  GUID = 'c7eaa9c1-72c4-4251-9e7d-bf9b8e8fa71e'
  RootModule = './Az.ConfidentialLedger.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ConfidentialLedger cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ConfidentialLedger.private.dll'
  FormatsToProcess = './Az.ConfidentialLedger.format.ps1xml'
  FunctionsToExport = 'Get-AzConfidentialLedger', 'New-AzConfidentialLedger', 'New-AzConfidentialLedgerAADBasedSecurityPrincipalObject', 'New-AzConfidentialLedgerCertBasedSecurityPrincipalObject', 'Remove-AzConfidentialLedger', 'Test-AzConfidentialLedgerNameAvailability', 'Update-AzConfidentialLedger', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ConfidentialLedger'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
