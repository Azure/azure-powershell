@{
  GUID = 'a41eb61d-c5a1-4e9b-81a7-b8905fff7f2c'
  RootModule = './Az.CloudService.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CloudService cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CloudService.private.dll'
  FormatsToProcess = './Az.CloudService.format.ps1xml'
  FunctionsToExport = 'Get-AzCloudService', 'Get-AzCloudServiceInstanceView', 'Get-AzCloudServiceRole', 'Get-AzCloudServiceRoleInstance', 'Get-AzCloudServiceRoleInstanceRemoteDesktopFile', 'Get-AzCloudServiceRoleInstanceView', 'Invoke-AzCloudServiceRebuildCloudService', 'Invoke-AzCloudServiceRebuildCloudServiceRoleInstance', 'Invoke-AzCloudServiceWalkCloudServiceUpdateDomain', 'New-AzCloudService', 'Remove-AzCloudService', 'Remove-AzCloudServiceInstance', 'Remove-AzCloudServiceRoleInstance', 'Restart-AzCloudService', 'Restart-AzCloudServiceRoleInstance', 'Start-AzCloudService', 'Stop-AzCloudService', 'Update-AzCloudService', 'Update-AzCloudServiceRoleInstance', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CloudService'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
