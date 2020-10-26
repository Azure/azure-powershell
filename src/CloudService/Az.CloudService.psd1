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
  FunctionsToExport = 'Get-AzCloudService', 'Get-AzCloudServiceNetworkInterfaces', 'Get-AzCloudServicePublicIPAddress', 'Get-AzCloudServiceRoleInstance', 'Get-AzCloudServiceRoleInstanceRemoteDesktopFile', 'Invoke-AzCloudServiceWalkCloudServiceUpdateDomain', 'New-AzCloudService', 'New-AzCloudServiceExtensionObject', 'New-AzCloudServiceLoadBalancerConfigurationObject', 'New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject', 'New-AzCloudServiceRemoteDesktopExtensionObject', 'New-AzCloudServiceRoleProfilePropertiesObject', 'Remove-AzCloudService', 'Reset-AzCloudService', 'Reset-AzCloudServiceRoleInstance', 'Start-AzCloudService', 'Stop-AzCloudService', 'Switch-AzCloudService', 'Update-AzCloudService', '*'
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
