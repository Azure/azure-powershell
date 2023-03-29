@{
  GUID = 'f054a259-7742-43cc-b3de-dda185f265f2'
  RootModule = './Az.HelpRp.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HelpRp cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HelpRp.private.dll'
  FormatsToProcess = './Az.HelpRp.format.ps1xml'
  FunctionsToExport = 'Get-AzHelpRpDiagnostic', 'Get-AzHelpRpDiscoverySolution', 'New-AzHelpRpDiagnostic', 'Test-AzHelpRpDiagnosticNameAvailability', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HelpRp'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
