@{
  GUID = '0257ad6f-6a35-4f94-9b31-22e82f9f9d56'
  RootModule = './Az.QumuloStorage.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: QumuloStorage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.QumuloStorage.private.dll'
  FormatsToProcess = './Az.QumuloStorage.format.ps1xml'
  FunctionsToExport = 'Get-AzQumuloStorageFileSystem', 'New-AzQumuloStorageFileSystem', 'Remove-AzQumuloStorageFileSystem', 'Update-AzQumuloStorageFileSystem', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'QumuloStorage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
