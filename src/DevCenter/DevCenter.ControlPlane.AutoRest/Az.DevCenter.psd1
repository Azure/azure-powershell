@{
  GUID = '24d861ed-547c-4787-81d0-d5e222ff4d0d'
  RootModule = './Az.DevCenter.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DevCenter cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DevCenter.private.dll'
  FormatsToProcess = './Az.DevCenter.format.ps1xml'
  FunctionsToExport = 'Get-AzAdminAttachedNetwork', 'Get-AzAdminCatalog', 'Get-AzAdminDevBoxDefinition', 'Get-AzAdminDevCenter', 'Get-AzAdminEnvironmentType', 'Get-AzAdminGallery', 'Get-AzAdminImage', 'Get-AzAdminImageVersion', 'Get-AzAdminNetworkConnection', 'Get-AzAdminNetworkConnectionHealthDetail', 'Get-AzAdminNetworkConnectionOutboundNetworkDependencyEndpoint', 'Get-AzAdminOperationStatuses', 'Get-AzAdminPool', 'Get-AzAdminProject', 'Get-AzAdminProjectAllowedEnvironmentType', 'Get-AzAdminProjectEnvironmentType', 'Get-AzAdminSchedule', 'Get-AzAdminSku', 'Invoke-AzAdminExecuteCheckNameAvailability', 'New-AzAdminAttachedNetwork', 'New-AzAdminCatalog', 'New-AzAdminDevBoxDefinition', 'New-AzAdminDevCenter', 'New-AzAdminEnvironmentType', 'New-AzAdminGallery', 'New-AzAdminNetworkConnection', 'New-AzAdminPool', 'New-AzAdminProject', 'New-AzAdminProjectEnvironmentType', 'New-AzAdminSchedule', 'Remove-AzAdminAttachedNetwork', 'Remove-AzAdminCatalog', 'Remove-AzAdminDevBoxDefinition', 'Remove-AzAdminDevCenter', 'Remove-AzAdminEnvironmentType', 'Remove-AzAdminGallery', 'Remove-AzAdminNetworkConnection', 'Remove-AzAdminPool', 'Remove-AzAdminProject', 'Remove-AzAdminProjectEnvironmentType', 'Remove-AzAdminSchedule', 'Set-AzAdminAttachedNetwork', 'Set-AzAdminCatalog', 'Set-AzAdminDevBoxDefinition', 'Set-AzAdminDevCenter', 'Set-AzAdminEnvironmentType', 'Set-AzAdminGallery', 'Set-AzAdminNetworkConnection', 'Set-AzAdminPool', 'Set-AzAdminProject', 'Set-AzAdminProjectEnvironmentType', 'Set-AzAdminSchedule', 'Start-AzAdminNetworkConnectionHealthCheck', 'Start-AzAdminPoolHealthCheck', 'Sync-AzAdminCatalog', 'Update-AzAdminCatalog', 'Update-AzAdminDevBoxDefinition', 'Update-AzAdminDevCenter', 'Update-AzAdminEnvironmentType', 'Update-AzAdminNetworkConnection', 'Update-AzAdminPool', 'Update-AzAdminProject', 'Update-AzAdminProjectEnvironmentType', 'Update-AzAdminSchedule', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DevCenter'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
