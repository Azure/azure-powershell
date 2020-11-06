@{
  GUID = '0379dac3-572f-4244-bd9d-aa20ef37c710'
  RootModule = './Az.RedisEnterpriseCache.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: RedisEnterpriseCache cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.RedisEnterpriseCache.private.dll'
  FormatsToProcess = './Az.RedisEnterpriseCache.format.ps1xml'
  FunctionsToExport = 'Export-AzRedisEnterpriseCacheDatabase', 'Get-AzRedisEnterpriseCache', 'Get-AzRedisEnterpriseCacheDatabaseKey', 'Get-AzRedisEnterpriseCacheOperationStatus', 'Import-AzRedisEnterpriseCacheDatabase', 'New-AzRedisEnterpriseCache', 'New-AzRedisEnterpriseCacheDatabaseKey', 'Remove-AzRedisEnterpriseCache', 'Update-AzRedisEnterpriseCache', 'Update-AzRedisEnterpriseCacheDatabase', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'RedisEnterpriseCache'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
