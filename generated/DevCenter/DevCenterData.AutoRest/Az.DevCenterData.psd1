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
  FunctionsToExport = 'Approve-AzDevCenterUserDevBox', 'Deploy-AzDevCenterUserEnvironment', 'Disable-AzDevCenterUserDevBoxAddOn', 'Enable-AzDevCenterUserDevBoxAddOn', 'Get-AzDevCenterUserCatalog', 'Get-AzDevCenterUserDevBox', 'Get-AzDevCenterUserDevBoxAction', 'Get-AzDevCenterUserDevBoxAddon', 'Get-AzDevCenterUserDevBoxCustomizationGroup', 'Get-AzDevCenterUserDevBoxCustomizationTaskDefinition', 'Get-AzDevCenterUserDevBoxCustomizationTaskLog', 'Get-AzDevCenterUserDevBoxImagingTaskLog', 'Get-AzDevCenterUserDevBoxOperation', 'Get-AzDevCenterUserDevBoxRemoteConnection', 'Get-AzDevCenterUserDevBoxSnapshot', 'Get-AzDevCenterUserDevCenterApproval', 'Get-AzDevCenterUserEnvironment', 'Get-AzDevCenterUserEnvironmentAction', 'Get-AzDevCenterUserEnvironmentDefinition', 'Get-AzDevCenterUserEnvironmentLog', 'Get-AzDevCenterUserEnvironmentOperation', 'Get-AzDevCenterUserEnvironmentOutput', 'Get-AzDevCenterUserEnvironmentType', 'Get-AzDevCenterUserEnvironmentTypeAbility', 'Get-AzDevCenterUserPool', 'Get-AzDevCenterUserProject', 'Get-AzDevCenterUserProjectAbility', 'Get-AzDevCenterUserSchedule', 'Invoke-AzDevCenterUserAlignPool', 'Invoke-AzDevCenterUserDelayDevBoxAction', 'Invoke-AzDevCenterUserDelayEnvironmentAction', 'New-AzDevCenterUserDevBox', 'New-AzDevCenterUserDevBoxAddOn', 'New-AzDevCenterUserDevBoxCustomizationGroup', 'New-AzDevCenterUserDevBoxSnapshot', 'New-AzDevCenterUserEnvironment', 'Remove-AzDevCenterUserDevBox', 'Remove-AzDevCenterUserDevBoxAddOn', 'Remove-AzDevCenterUserEnvironment', 'Repair-AzDevCenterUserDevBox', 'Restart-AzDevCenterUserDevBox', 'Restore-AzDevCenterUserDevBoxSnapshot', 'Set-AzDevCenterUserDevBoxActiveHour', 'Skip-AzDevCenterUserDevBoxAction', 'Skip-AzDevCenterUserEnvironmentAction', 'Start-AzDevCenterUserDevBox', 'Stop-AzDevCenterUserDevBox', 'Test-AzDevCenterUserDevBoxCustomizationTaskAction', 'Update-AzDevCenterUserEnvironment', '*'
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
