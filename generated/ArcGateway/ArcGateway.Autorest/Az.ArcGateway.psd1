@{
  GUID = '40089cb6-1178-4576-8452-c678f0e34495'
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
