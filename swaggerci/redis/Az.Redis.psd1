@{
  GUID = '895ae017-3cbf-49d7-9c66-0032b6d42728'
  RootModule = './Az.Redis.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Redis cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Redis.private.dll'
  FormatsToProcess = './Az.Redis.format.ps1xml'
  FunctionsToExport = 'Export-AzRedisData', 'Get-AzRedis', 'Get-AzRedisAsyncOperationStatus', 'Get-AzRedisFirewallRule', 'Get-AzRedisKey', 'Get-AzRedisLinkedServer', 'Get-AzRedisPatchSchedule', 'Get-AzRedisPrivateEndpointConnection', 'Get-AzRedisPrivateLinkResource', 'Get-AzRedisUpgradeNotification', 'Import-AzRedisData', 'New-AzRedis', 'New-AzRedisFirewallRule', 'New-AzRedisKey', 'New-AzRedisLinkedServer', 'New-AzRedisPatchSchedule', 'Remove-AzRedis', 'Remove-AzRedisFirewallRule', 'Remove-AzRedisLinkedServer', 'Remove-AzRedisPatchSchedule', 'Remove-AzRedisPrivateEndpointConnection', 'Restart-AzRedis', 'Test-AzRedisNameAvailability', 'Update-AzRedis', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Redis'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
