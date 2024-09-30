@{
  GUID = 'bb1182ed-2a39-47be-8b39-46b13e973cea'
  RootModule = './Az.StandbyPool.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StandbyPool cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StandbyPool.private.dll'
  FormatsToProcess = './Az.StandbyPool.format.ps1xml'
  FunctionsToExport = 'Get-AzStandbyContainerGroupPool', 'Get-AzStandbyContainerGroupPoolStatus', 'Get-AzStandbyVMPool', 'Get-AzStandbyVMPoolStatus', 'New-AzStandbyContainerGroupPool', 'New-AzStandbyVMPool', 'Remove-AzStandbyContainerGroupPool', 'Remove-AzStandbyVMPool', 'Update-AzStandbyContainerGroupPool', 'Update-AzStandbyVMPool'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StandbyPool'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
