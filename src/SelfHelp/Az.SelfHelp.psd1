@{
  GUID = 'cf107540-2c79-419e-99b6-5aaf44afb2ba'
  RootModule = './Az.SelfHelp.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SelfHelp cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SelfHelp.private.dll'
  FormatsToProcess = './Az.SelfHelp.format.ps1xml'
  FunctionsToExport = 'Get-AzSelfHelpDiagnostic', 'Get-AzSelfHelpDiscoverySolution', 'New-AzSelfHelpDiagnostic', 'Test-AzSelfHelpDiagnosticNameAvailability', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SelfHelp'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
