@{
  GUID = 'e8498ee5-1280-4b71-b186-d48b5cbc3eec'
  RootModule = './Az.IoTCentral.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: IoTCentral cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.IoTCentral.private.dll'
  FormatsToProcess = './Az.IoTCentral.format.ps1xml'
  FunctionsToExport = 'Get-AzIoTCentralApp', 'Get-AzIoTCentralAppTemplate', 'New-AzIoTCentralApp', 'Remove-AzIoTCentralApp', 'Update-AzIoTCentralApp', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'IoTCentral'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
