@{
  GUID = '8d7b53b3-f39f-4f40-a64f-cb07e29ede3a'
  RootModule = './Az.Fleet.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Fleet cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Fleet.private.dll'
  FormatsToProcess = './Az.Fleet.format.ps1xml'
  FunctionsToExport = 'Get-AzFleet', 'Get-AzFleetCredentials', 'Get-AzFleetMember', 'Get-AzFleetUpdateRun', 'Get-AzFleetUpdateStrategy', 'New-AzFleet', 'New-AzFleetMember', 'New-AzFleetUpdateGroupObject', 'New-AzFleetUpdateRun', 'New-AzFleetUpdateStageObject', 'New-AzFleetUpdateStrategy', 'Remove-AzFleet', 'Remove-AzFleetMember', 'Remove-AzFleetUpdateRun', 'Remove-AzFleetUpdateStrategy', 'Start-AzFleetUpdateRun', 'Stop-AzFleetUpdateRun', 'Update-AzFleet', 'Update-AzFleetMember', 'Update-AzFleetUpdateRun', 'Update-AzFleetUpdateStrategy'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Fleet'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
