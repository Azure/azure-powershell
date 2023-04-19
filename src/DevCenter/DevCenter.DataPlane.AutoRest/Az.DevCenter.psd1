@{
  GUID = '3cfc7165-158b-4c84-a966-01e1f1c829bc'
  RootModule = './Az.DevCenter.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DevCenter cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DevCenter.private.dll'
  FormatsToProcess = './Az.DevCenter.format.ps1xml'
  FunctionsToExport = 'Delay-AzDevDevBoxAction', 'Deploy-AzDevEnvironment', 'Get-AzDevCatalog', 'Get-AzDevDevBox', 'Get-AzDevDevBoxAction', 'Get-AzDevDevBoxRemoteConnection', 'Get-AzDevEnvironment', 'Get-AzDevEnvironmentDefinition', 'Get-AzDevEnvironmentType', 'Get-AzDevPool', 'Get-AzDevProject', 'Get-AzDevSchedule', 'New-AzDevDevBox', 'New-AzDevEnvironment', 'Remove-AzDevDevBox', 'Remove-AzDevEnvironment', 'Restart-AzDevDevBox', 'Skip-AzDevDevBoxAction', 'Start-AzDevDevBox', 'Stop-AzDevDevBox', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DevCenter'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
