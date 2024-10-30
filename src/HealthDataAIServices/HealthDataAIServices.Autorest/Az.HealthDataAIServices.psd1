@{
  GUID = '7a644a2f-9234-4acc-a551-b906b0be7188'
  RootModule = './Az.HealthDataAIServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HealthDataAiServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HealthDataAIServices.private.dll'
  FormatsToProcess = './Az.HealthDataAIServices.format.ps1xml'
  FunctionsToExport = 'Get-AzDeidPrivateEndpointConnection', 'Get-AzDeidService', 'New-AzDeidPrivateEndpointConnection', 'New-AzDeidService', 'Remove-AzDeidPrivateEndpointConnection', 'Remove-AzDeidService', 'Update-AzDeidService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HealthDataAiServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
