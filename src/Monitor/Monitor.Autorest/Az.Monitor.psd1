@{
  GUID = 'c4501b6c-52db-4ae8-8dc3-fe377075a0b9'
  RootModule = './Az.Monitor.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Monitor cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Monitor.private.dll'
  FormatsToProcess = './Az.Monitor.format.ps1xml'
  FunctionsToExport = 'Get-AzMonitorActivityLogAlert', 'New-AzMonitorActivityLogAlert', 'Remove-AzMonitorActivityLogAlert', 'Set-AzMonitorActivityLogAlert', 'Update-AzMonitorActivityLogAlert', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Monitor'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
