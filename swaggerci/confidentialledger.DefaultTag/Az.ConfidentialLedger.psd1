@{
  GUID = '06f22159-1adf-4987-81de-fe2201592fbc'
  RootModule = './Az.ConfidentialLedger.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ConfidentialLedger cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ConfidentialLedger.private.dll'
  FormatsToProcess = './Az.ConfidentialLedger.format.ps1xml'
  FunctionsToExport = 'Get-AzConfidentialLedger', 'Get-AzConfidentialLedgerManagedCcf', 'New-AzConfidentialLedger', 'New-AzConfidentialLedgerManagedCcf', 'Remove-AzConfidentialLedger', 'Remove-AzConfidentialLedgerManagedCcf', 'Test-AzConfidentialLedgerNameAvailability', 'Update-AzConfidentialLedger', 'Update-AzConfidentialLedgerManagedCcf', '*'
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
