@{
  GUID = 'd5c7f2ce-fe23-49d5-a869-fb780e78a663'
  RootModule = './Az.WindowsIotServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: WindowsIotServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.WindowsIotServices.private.dll'
  FormatsToProcess = './Az.WindowsIotServices.format.ps1xml'
  FunctionsToExport = 'Get-AzWindowsIotServicesDevice', 'New-AzWindowsIotServicesDevice', 'Remove-AzWindowsIotServicesDevice', 'Update-AzWindowsIotServicesDevice', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'WindowsIotServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
