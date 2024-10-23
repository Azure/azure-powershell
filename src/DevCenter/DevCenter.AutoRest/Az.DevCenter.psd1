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
  FunctionsToExport = 'Connect-AzDevCenterAdminCatalog', 'Connect-AzDevCenterAdminProjectCatalog', 'Get-AzDevCenterAdminAttachedNetwork', 'Get-AzDevCenterAdminCatalog', 'Get-AzDevCenterAdminCatalogSyncErrorDetail', 'Get-AzDevCenterAdminCustomizationTask', 'Get-AzDevCenterAdminCustomizationTaskErrorDetail', 'Get-AzDevCenterAdminDevBoxDefinition', 'Get-AzDevCenterAdminDevCenter', 'Get-AzDevCenterAdminEnvironmentDefinition', 'Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail', 'Get-AzDevCenterAdminEnvironmentType', 'Get-AzDevCenterAdminGallery', 'Get-AzDevCenterAdminImage', 'Get-AzDevCenterAdminImageVersion', 'Get-AzDevCenterAdminNetworkConnection', 'Get-AzDevCenterAdminNetworkConnectionHealthDetail', 'Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint', 'Get-AzDevCenterAdminOperationStatus', 'Get-AzDevCenterAdminPlan', 'Get-AzDevCenterAdminPlanMember', 'Get-AzDevCenterAdminPool', 'Get-AzDevCenterAdminProject', 'Get-AzDevCenterAdminProjectAllowedEnvironmentType', 'Get-AzDevCenterAdminProjectCatalog', 'Get-AzDevCenterAdminProjectCatalogSyncErrorDetail', 'Get-AzDevCenterAdminProjectEnvironmentDefinition', 'Get-AzDevCenterAdminProjectEnvironmentDefinitionErrorDetail', 'Get-AzDevCenterAdminProjectEnvironmentType', 'Get-AzDevCenterAdminProjectInheritedSetting', 'Get-AzDevCenterAdminSchedule', 'Get-AzDevCenterAdminSku', 'Get-AzDevCenterAdminUsage', 'Invoke-AzDevCenterAdminExecuteCheckNameAvailability', 'Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability', 'New-AzDevCenterAdminAttachedNetwork', 'New-AzDevCenterAdminCatalog', 'New-AzDevCenterAdminDevBoxDefinition', 'New-AzDevCenterAdminDevCenter', 'New-AzDevCenterAdminEnvironmentType', 'New-AzDevCenterAdminGallery', 'New-AzDevCenterAdminNetworkConnection', 'New-AzDevCenterAdminPlan', 'New-AzDevCenterAdminPlanMember', 'New-AzDevCenterAdminPool', 'New-AzDevCenterAdminProject', 'New-AzDevCenterAdminProjectCatalog', 'New-AzDevCenterAdminProjectEnvironmentType', 'New-AzDevCenterAdminSchedule', 'Remove-AzDevCenterAdminAttachedNetwork', 'Remove-AzDevCenterAdminCatalog', 'Remove-AzDevCenterAdminDevBoxDefinition', 'Remove-AzDevCenterAdminDevCenter', 'Remove-AzDevCenterAdminEnvironmentType', 'Remove-AzDevCenterAdminGallery', 'Remove-AzDevCenterAdminNetworkConnection', 'Remove-AzDevCenterAdminPlan', 'Remove-AzDevCenterAdminPlanMember', 'Remove-AzDevCenterAdminPool', 'Remove-AzDevCenterAdminProject', 'Remove-AzDevCenterAdminProjectCatalog', 'Remove-AzDevCenterAdminProjectEnvironmentType', 'Remove-AzDevCenterAdminSchedule', 'Start-AzDevCenterAdminNetworkConnectionHealthCheck', 'Start-AzDevCenterAdminPoolHealthCheck', 'Sync-AzDevCenterAdminCatalog', 'Sync-AzDevCenterAdminProjectCatalog', 'Update-AzDevCenterAdminCatalog', 'Update-AzDevCenterAdminDevBoxDefinition', 'Update-AzDevCenterAdminDevCenter', 'Update-AzDevCenterAdminEnvironmentType', 'Update-AzDevCenterAdminNetworkConnection', 'Update-AzDevCenterAdminPlan', 'Update-AzDevCenterAdminPlanMember', 'Update-AzDevCenterAdminPool', 'Update-AzDevCenterAdminProject', 'Update-AzDevCenterAdminProjectCatalog', 'Update-AzDevCenterAdminProjectEnvironmentType', 'Update-AzDevCenterAdminSchedule', '*'
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
