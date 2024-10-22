@{
  GUID = '7d8873aa-0ba9-4513-bde3-0483ad83058b'
  RootModule = './Az.HealthDeid.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HealthDeid cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HealthDeid.private.dll'
  FormatsToProcess = './Az.HealthDeid.format.ps1xml'
  FunctionsToExport = 'Get-AzHealthDeidPrivateLink', 'Get-AzHealthDeidService', 'New-AzHealthDeidService', 'Remove-AzHealthDeidService', 'Update-AzHealthDeidService'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HealthDeid'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
