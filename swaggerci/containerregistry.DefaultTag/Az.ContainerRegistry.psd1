@{
  GUID = 'ebfee888-0541-412d-8718-0ab382c45e26'
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
  FunctionsToExport = 'Get-AzContainerRegistry', 'Get-AzContainerRegistryAgentPool', 'Get-AzContainerRegistryAgentPoolQueueStatus', 'Get-AzContainerRegistryBuildSourceUploadUrl', 'Get-AzContainerRegistryCacheRule', 'Get-AzContainerRegistryConnectedRegistry', 'Get-AzContainerRegistryCredentials', 'Get-AzContainerRegistryCredentialSet', 'Get-AzContainerRegistryExportPipeline', 'Get-AzContainerRegistryImportPipeline', 'Get-AzContainerRegistryPipelineRun', 'Get-AzContainerRegistryPrivateEndpointConnection', 'Get-AzContainerRegistryPrivateLinkResource', 'Get-AzContainerRegistryReplication', 'Get-AzContainerRegistryRun', 'Get-AzContainerRegistryRunLogSasUrl', 'Get-AzContainerRegistryScopeMap', 'Get-AzContainerRegistryTask', 'Get-AzContainerRegistryTaskDetail', 'Get-AzContainerRegistryTaskRun', 'Get-AzContainerRegistryTaskRunDetail', 'Get-AzContainerRegistryToken', 'Get-AzContainerRegistryUsage', 'Get-AzContainerRegistryWebhook', 'Get-AzContainerRegistryWebhookCallbackConfig', 'Get-AzContainerRegistryWebhookEvent', 'Import-AzContainerRegistryImage', 'Invoke-AzContainerRegistryDeactivateConnectedRegistry', 'Invoke-AzContainerRegistryScheduleRegistryRun', 'New-AzContainerRegistry', 'New-AzContainerRegistryAgentPool', 'New-AzContainerRegistryCacheRule', 'New-AzContainerRegistryConnectedRegistry', 'New-AzContainerRegistryCredential', 'New-AzContainerRegistryCredentials', 'New-AzContainerRegistryCredentialSet', 'New-AzContainerRegistryExportPipeline', 'New-AzContainerRegistryImportPipeline', 'New-AzContainerRegistryPipelineRun', 'New-AzContainerRegistryPrivateEndpointConnection', 'New-AzContainerRegistryReplication', 'New-AzContainerRegistryScopeMap', 'New-AzContainerRegistryTask', 'New-AzContainerRegistryTaskRun', 'New-AzContainerRegistryToken', 'New-AzContainerRegistryWebhook', 'Ping-AzContainerRegistryWebhook', 'Remove-AzContainerRegistry', 'Remove-AzContainerRegistryAgentPool', 'Remove-AzContainerRegistryCacheRule', 'Remove-AzContainerRegistryConnectedRegistry', 'Remove-AzContainerRegistryCredentialSet', 'Remove-AzContainerRegistryExportPipeline', 'Remove-AzContainerRegistryImportPipeline', 'Remove-AzContainerRegistryPipelineRun', 'Remove-AzContainerRegistryPrivateEndpointConnection', 'Remove-AzContainerRegistryReplication', 'Remove-AzContainerRegistryScopeMap', 'Remove-AzContainerRegistryTask', 'Remove-AzContainerRegistryTaskRun', 'Remove-AzContainerRegistryToken', 'Remove-AzContainerRegistryWebhook', 'Stop-AzContainerRegistryRun', 'Test-AzContainerRegistryNameAvailability', 'Update-AzContainerRegistry', 'Update-AzContainerRegistryAgentPool', 'Update-AzContainerRegistryCacheRule', 'Update-AzContainerRegistryConnectedRegistry', 'Update-AzContainerRegistryCredentialSet', 'Update-AzContainerRegistryReplication', 'Update-AzContainerRegistryRun', 'Update-AzContainerRegistryScopeMap', 'Update-AzContainerRegistryTask', 'Update-AzContainerRegistryTaskRun', 'Update-AzContainerRegistryToken', 'Update-AzContainerRegistryWebhook', '*'
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
