@{
  GUID = '14995ab3-8dd3-4201-b5f5-9dc94eac60d4'
  RootModule = './Az.Storage.psm1'
  ModuleVersion = '5.9.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Storage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Storage.private.dll'
  FormatsToProcess = './Az.Storage.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageAccountMigration', 'Start-AzStorageAccountMigration'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Storage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
