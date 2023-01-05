@{
  GUID = 'bbcf55b0-7b13-4baf-a7f3-48ba4763f960'
  RootModule = './Az.Storage.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Storage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Storage.private.dll'
  FormatsToProcess = './Az.Storage.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageNetworkSecurityPerimeterConfiguration', 'Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Storage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
