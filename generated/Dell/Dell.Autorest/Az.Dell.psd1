@{
  GUID = 'ff3b29eb-e74c-461d-9105-d5e96af0b95a'
  RootModule = './Az.Dell.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Dell cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Dell.private.dll'
  FormatsToProcess = './Az.Dell.format.ps1xml'
  FunctionsToExport = 'Get-AzDellFileSystem', 'New-AzDellFileSystem', 'Remove-AzDellFileSystem'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Dell'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
