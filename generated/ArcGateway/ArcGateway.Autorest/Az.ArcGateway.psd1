@{
  GUID = '7d097c91-83f3-47a6-88ef-deee8f86df84'
  RootModule = './Az.ArcGateway.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ArcGateway cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ArcGateway.private.dll'
  FormatsToProcess = './Az.ArcGateway.format.ps1xml'
  FunctionsToExport = 'Get-AzArcGateway', 'New-AzArcGateway', 'Remove-AzArcGateway', 'Update-AzArcSetting'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ArcGateway'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
