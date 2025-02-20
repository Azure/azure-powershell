@{
  GUID = '79ad50da-e6b5-4703-885a-d36974a4d9b9'
  RootModule = './Az.HanaOnAzure.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HanaOn cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HanaOnAzure.private.dll'
  FormatsToProcess = './Az.HanaOnAzure.format.ps1xml'
  FunctionsToExport = 'Get-AzSapMonitor', 'Get-AzSapMonitorProviderInstance', 'New-AzSapMonitor', 'New-AzSapMonitorProviderInstance', 'Remove-AzSapMonitor', 'Remove-AzSapMonitorProviderInstance', 'Update-AzSapMonitor', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HanaOn'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
