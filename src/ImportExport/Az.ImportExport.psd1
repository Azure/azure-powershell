@{
  GUID = '47cfc32b-a3bc-46e1-935e-11a63032bb86'
  RootModule = './Az.ImportExport.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ImportExport cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ImportExport.private.dll'
  RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '2.2.5'; })
  FormatsToProcess = './Az.ImportExport.format.ps1xml'
  FunctionsToExport = 'Get-AzImportExport', 'Get-AzImportExportBitLockerKey', 'Get-AzImportExportLocation', 'New-AzImportExport', 'New-AzImportExportDriveListObject', 'Remove-AzImportExport', 'Update-AzImportExport'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ImportExport'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
