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
  FunctionsToExport = 'Deploy-AzDevCenterUserEnvironment', 'Get-AzDevCenterUserCatalog', 'Get-AzDevCenterUserDevBox', 'Get-AzDevCenterUserDevBoxAction', 'Get-AzDevCenterUserDevBoxOperation', 'Get-AzDevCenterUserDevBoxRemoteConnection', 'Get-AzDevCenterUserEnvironment', 'Get-AzDevCenterUserEnvironmentAction', 'Get-AzDevCenterUserEnvironmentDefinition', 'Get-AzDevCenterUserEnvironmentLog', 'Get-AzDevCenterUserEnvironmentOperation', 'Get-AzDevCenterUserEnvironmentOutput', 'Get-AzDevCenterUserEnvironmentType', 'Get-AzDevCenterUserPool', 'Get-AzDevCenterUserProject', 'Get-AzDevCenterUserSchedule', 'Invoke-AzDevCenterUserDelayDevBoxAction', 'Invoke-AzDevCenterUserDelayEnvironmentAction', 'New-AzDevCenterUserDevBox', 'New-AzDevCenterUserEnvironment', 'Remove-AzDevCenterUserDevBox', 'Remove-AzDevCenterUserEnvironment', 'Repair-AzDevCenterUserDevBox', 'Restart-AzDevCenterUserDevBox', 'Skip-AzDevCenterUserDevBoxAction', 'Skip-AzDevCenterUserEnvironmentAction', 'Start-AzDevCenterUserDevBox', 'Stop-AzDevCenterUserDevBox', 'Update-AzDevCenterUserEnvironment', '*'
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
