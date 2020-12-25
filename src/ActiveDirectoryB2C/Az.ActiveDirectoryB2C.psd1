@{
  GUID = '09c05b78-dd84-4a3c-ae7b-7c58bbf5ca85'
  RootModule = './Az.ActiveDirectoryB2C.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ActiveDirectoryB2C cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ActiveDirectoryB2C.private.dll'
  FormatsToProcess = './Az.ActiveDirectoryB2C.format.ps1xml'
  FunctionsToExport = 'Get-AzADB2CTenant', 'New-AzADB2CTenant', 'Remove-AzADB2CTenant', 'Update-AzADB2CTenant', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ActiveDirectoryB2C'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
