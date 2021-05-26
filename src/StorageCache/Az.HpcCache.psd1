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
  FunctionsToExport = 'Get-AzHpcCache', 'Get-AzHpcCacheSku', 'Get-AzHpcCacheStorageTarget', 'Get-AzHpcCacheUsageModel', 'Invoke-AzHpcCacheFlush', 'Invoke-AzHpcCacheUpgrade', 'New-AzHpcCache', 'New-AzHpcCacheCacheDirectorySettingsObject', 'New-AzHpcCacheNamespaceJunctionObject', 'New-AzHpcCacheNfsAccessPolicyObject', 'New-AzHpcCacheNfsAccessRuleObject', 'New-AzHpcCacheStorageTarget', 'Remove-AzHpcCache', 'Remove-AzHpcCacheStorageTarget', 'Start-AzHpcCache', 'Start-AzHpcCacheDebugInfo', 'Stop-AzHpcCache', 'Update-AzHpcCache', 'Update-AzHpcCacheStorageTargetDns', '*'
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
