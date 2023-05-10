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
  FunctionsToExport = 'Delay-AzDevCenterDevDevBoxAction', 'Deploy-AzDevCenterDevEnvironment', 'Get-AzDevCenterDevCatalog', 'Get-AzDevCenterDevDevBox', 'Get-AzDevCenterDevDevBoxAction', 'Get-AzDevCenterDevDevBoxRemoteConnection', 'Get-AzDevCenterDevEnvironment', 'Get-AzDevCenterDevEnvironmentDefinition', 'Get-AzDevCenterDevEnvironmentType', 'Get-AzDevCenterDevPool', 'Get-AzDevCenterDevProject', 'Get-AzDevCenterDevSchedule', 'New-AzDevCenterDevDevBox', 'New-AzDevCenterDevEnvironment', 'Remove-AzDevCenterDevDevBox', 'Remove-AzDevCenterDevEnvironment', 'Restart-AzDevCenterDevDevBox', 'Set-AzDevCenterDevEnvironment', 'Skip-AzDevCenterDevDevBoxAction', 'Start-AzDevCenterDevDevBox', 'Stop-AzDevCenterDevDevBox', '*'
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
