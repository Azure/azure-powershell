@{
  GUID = 'd0405e66-f416-49c6-8711-e1aecf8b3b23'
  RootModule = './Az.HealthDeidentification.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HealthDeidentification cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HealthDeidentification.private.dll'
  FormatsToProcess = './Az.HealthDeidentification.format.ps1xml'
  FunctionsToExport = 'Get-AzDeidService', 'New-AzDeidService', 'Remove-AzDeidService', 'Update-AzDeidService'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HealthDeidentification'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
