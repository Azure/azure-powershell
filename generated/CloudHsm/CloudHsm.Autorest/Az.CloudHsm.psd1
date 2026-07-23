@{
  GUID = '462847d6-b164-4f24-9045-1473c774b0f2'
  RootModule = './Az.CloudHsm.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CloudHsm cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CloudHsm.private.dll'
  FormatsToProcess = './Az.CloudHsm.format.ps1xml'
  FunctionsToExport = 'Backup-AzCloudHsm', 'Get-AzCloudHsm', 'New-AzCloudHsm', 'Remove-AzCloudHsm', 'Restore-AzCloudHsm', 'Update-AzCloudHsm'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CloudHsm'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
