@{
  GUID = '5644f9a4-c709-49fc-b6ae-afce8fdc21f3'
  RootModule = './Az.HpcCache.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HpcCache cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HpcCache.private.dll'
  FormatsToProcess = './Az.HpcCache.format.ps1xml'
  FunctionsToExport = 'Clear-AzHpcCacheCach', 'Debug-AzHpcCacheCachInfo', 'Get-AzHpcCacheAscOperation', 'Get-AzHpcCacheCach', 'Get-AzHpcCacheSku', 'Get-AzHpcCacheStorageTarget', 'Get-AzHpcCacheUsageModel', 'New-AzHpcCacheCach', 'New-AzHpcCacheCacheDirectorySettingsObject', 'New-AzHpcCacheNamespaceJunctionObject', 'New-AzHpcCacheNfsAccessPolicyObject', 'New-AzHpcCacheNfsAccessRuleObject', 'New-AzHpcCacheStorageTarget', 'Remove-AzHpcCacheCach', 'Remove-AzHpcCacheStorageTarget', 'Set-AzHpcCacheCach', 'Set-AzHpcCacheStorageTarget', 'Start-AzHpcCacheCach', 'Stop-AzHpcCacheCach', 'Update-AzHpcCacheCach', 'Update-AzHpcCacheCachFirmware', 'Update-AzHpcCacheStorageTargetDns', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HpcCache'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
