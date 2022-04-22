@{
  GUID = '905e71a2-884f-4989-90c8-d4a9d0b59770'
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
  FunctionsToExport = 'Get-AzConfidentialLedger', 'New-AzConfidentialLedger', 'Remove-AzConfidentialLedger', 'Test-AzConfidentialLedgerNameAvailability', 'Update-AzConfidentialLedger', '*'
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
