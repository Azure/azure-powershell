@{
  GUID = '21b6474b-a74c-47e9-a8f9-f446838bd166'
  RootModule = './Az.PowerBiEmbedded.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PowerBiEmbedded cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PowerBiEmbedded.private.dll'
  FormatsToProcess = './Az.PowerBiEmbedded.format.ps1xml'
  FunctionsToExport = 'Get-AzPowerBiEmbeddedAvailableOperation', 'Get-AzPowerBiEmbeddedWorkspace', 'Get-AzPowerBiEmbeddedWorkspaceCollection', 'Get-AzPowerBiEmbeddedWorkspaceCollectionAccessKey', 'Move-AzPowerBiEmbeddedWorkspaceCollection', 'New-AzPowerBiEmbeddedWorkspaceCollection', 'New-AzPowerBiEmbeddedWorkspaceCollectionKey', 'Remove-AzPowerBiEmbeddedWorkspaceCollection', 'Test-AzPowerBiEmbeddedWorkspaceCollectionNameAvailability', 'Update-AzPowerBiEmbeddedWorkspaceCollection', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PowerBiEmbedded'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
