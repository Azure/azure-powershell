@{
  GUID = 'a5a2a512-ec9f-44e2-9943-c4cc9c42a4ad'
  RootModule = './Az.DevCenterdata.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DevCenterdata cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DevCenterdata.private.dll'
  FormatsToProcess = './Az.DevCenterdata.format.ps1xml'
  FunctionsToExport = 'Deploy-AzDevCenterDevEnvironment', 'Get-AzDevCenterDevCatalog', 'Get-AzDevCenterDevDevBox', 'Get-AzDevCenterDevDevBoxAction', 'Get-AzDevCenterDevDevBoxRemoteConnection', 'Get-AzDevCenterDevEnvironment', 'Get-AzDevCenterDevEnvironmentDefinition', 'Get-AzDevCenterDevEnvironmentType', 'Get-AzDevCenterDevPool', 'Get-AzDevCenterDevProject', 'Get-AzDevCenterDevSchedule', 'Invoke-AzDevCenterDevDelayDevBoxAction', 'New-AzDevCenterDevDevBox', 'New-AzDevCenterDevEnvironment', 'Remove-AzDevCenterDevDevBox', 'Remove-AzDevCenterDevEnvironment', 'Restart-AzDevCenterDevDevBox', 'Set-AzDevCenterDevEnvironment', 'Skip-AzDevCenterDevDevBoxAction', 'Start-AzDevCenterDevDevBox', 'Stop-AzDevCenterDevDevBox', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DevCenterdata'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
