@{
  GUID = 'badd78e2-dda0-4533-8fc3-9453c50837cf'
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
