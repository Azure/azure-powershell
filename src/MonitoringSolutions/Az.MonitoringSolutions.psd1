@{
  GUID = '4e0cdc62-833e-41bd-aa97-f8f042986de3'
  RootModule = './Az.MonitoringSolutions.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MonitoringSolutions cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MonitoringSolutions.private.dll'
<<<<<<< HEAD
  RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '2.2.8'; })
=======
  RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '2.7.4'; })
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
  FormatsToProcess = './Az.MonitoringSolutions.format.ps1xml'
  FunctionsToExport = 'Get-AzMonitorLogAnalyticsSolution', 'New-AzMonitorLogAnalyticsSolution', 'Remove-AzMonitorLogAnalyticsSolution', 'Update-AzMonitorLogAnalyticsSolution'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MonitoringSolutions'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = '* the first preview release'
    }
  }
}
