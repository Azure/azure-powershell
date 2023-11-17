@{
  GUID = '3dce2f0c-9968-453b-86b0-45b7c2e51740'
  RootModule = './Az.ContainerRegistry.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ContainerRegistry cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ContainerRegistry.private.dll'
  FormatsToProcess = './Az.ContainerRegistry.format.ps1xml'
  FunctionsToExport = 'Get-AzContainerRegistry', 'Get-AzContainerRegistryAgentPool', 'Get-AzContainerRegistryAgentPoolQueueStatus', 'Get-AzContainerRegistryCredential', 'Get-AzContainerRegistryExportPipeline', 'Get-AzContainerRegistryImportPipeline', 'Get-AzContainerRegistryReplication', 'Get-AzContainerRegistryScopeMap', 'Get-AzContainerRegistryToken', 'Get-AzContainerRegistryUsage', 'Get-AzContainerRegistryWebhook', 'Get-AzContainerRegistryWebhookCallbackConfig', 'Get-AzContainerRegistryWebhookEvent', 'Import-AzContainerRegistryImage', 'New-AzContainerRegistry', 'New-AzContainerRegistryAgentPool', 'New-AzContainerRegistryCredentials', 'New-AzContainerRegistryExportPipeline', 'New-AzContainerRegistryImportPipeline', 'New-AzContainerRegistryIPRuleObject', 'New-AzContainerRegistryReplication', 'New-AzContainerRegistryScopeMap', 'New-AzContainerRegistryToken', 'New-AzContainerRegistryWebhook', 'Remove-AzContainerRegistry', 'Remove-AzContainerRegistryAgentPool', 'Remove-AzContainerRegistryExportPipeline', 'Remove-AzContainerRegistryImportPipeline', 'Remove-AzContainerRegistryReplication', 'Remove-AzContainerRegistryScopeMap', 'Remove-AzContainerRegistryToken', 'Remove-AzContainerRegistryWebhook', 'Test-AzContainerRegistryNameAvailability', 'Test-AzContainerRegistryWebhook', 'Update-AzContainerRegistry', 'Update-AzContainerRegistryAgentPool', 'Update-AzContainerRegistryCredential', 'Update-AzContainerRegistryScopeMap', 'Update-AzContainerRegistryToken', 'Update-AzContainerRegistryWebhook', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ContainerRegistry'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
