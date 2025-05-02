@{
  GUID = '38e4b21d-b436-4d83-a47b-d94a7d963dc2'
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
  FunctionsToExport = 'Get-AzDeidService', 'New-AzDeidService', 'Remove-AzDeidService', 'Update-AzDeidService'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HealthDataAiServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
