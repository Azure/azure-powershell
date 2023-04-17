@{
  GUID = '7ecf6752-9e5d-434a-8fb4-dc59791c37fe'
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
  FunctionsToExport = 'Get-AzDevDevBox', 'Get-AzDevDevBoxAction', 'Get-AzDevDevBoxPool', 'Get-AzDevDevBoxRemoteConnection', 'Get-AzDevDevBoxSchedule', 'Get-AzDevDevCenterDevBox', 'Get-AzDevDevCenterProject', 'Get-AzDevEnvironment', 'Get-AzDevEnvironmentCatalog', 'Get-AzDevEnvironmentDefinition', 'Get-AzDevEnvironmentType', 'Invoke-AzDevDelayDevBoxAction', 'New-AzDevDevBox', 'New-AzDevEnvironment', 'Remove-AzDevDevBox', 'Remove-AzDevEnvironment', 'Restart-AzDevDevBox', 'Set-AzDevEnvironment', 'Skip-AzDevDevBoxAction', 'Start-AzDevDevBox', 'Stop-AzDevDevBox', '*'
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
