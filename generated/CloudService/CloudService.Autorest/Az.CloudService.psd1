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
  FunctionsToExport = 'Get-AzCloudService', 'Get-AzCloudServiceInstanceView', 'Get-AzCloudServiceNetworkInterface', 'Get-AzCloudServiceOSFamily', 'Get-AzCloudServiceOSVersion', 'Get-AzCloudServicePublicIPAddress', 'Get-AzCloudServiceRoleInstance', 'Get-AzCloudServiceRoleInstanceRemoteDesktopFile', 'Get-AzCloudServiceRoleInstanceView', 'Invoke-AzCloudServiceRebuild', 'Invoke-AzCloudServiceReimage', 'Invoke-AzCloudServiceRoleInstanceRebuild', 'Invoke-AzCloudServiceRoleInstanceReimage', 'New-AzCloudService', 'New-AzCloudServiceDiagnosticsExtension', 'New-AzCloudServiceExtensionObject', 'New-AzCloudServiceLoadBalancerConfigurationObject', 'New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject', 'New-AzCloudServiceRemoteDesktopExtensionObject', 'New-AzCloudServiceRoleProfilePropertiesObject', 'New-AzCloudServiceVaultSecretGroupObject', 'Remove-AzCloudService', 'Remove-AzCloudServiceRoleInstance', 'Restart-AzCloudService', 'Restart-AzCloudServiceRoleInstance', 'Set-AzCloudServiceUpdateDomain', 'Start-AzCloudService', 'Stop-AzCloudService', 'Switch-AzCloudService', 'Update-AzCloudService', '*'
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
