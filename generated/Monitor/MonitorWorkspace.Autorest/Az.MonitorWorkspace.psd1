@{
  GUID = 'b9f9a546-cc15-45f4-b5cd-579de4cc57ec'
  RootModule = './Az.MonitorWorkspace.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MonitorWorkspace cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MonitorWorkspace.private.dll'
  FormatsToProcess = './Az.MonitorWorkspace.format.ps1xml'
  FunctionsToExport = 'Get-AzMonitorWorkspace', 'New-AzMonitorWorkspace', 'Remove-AzMonitorWorkspace', 'Update-AzMonitorWorkspace', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MonitorWorkspace'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
