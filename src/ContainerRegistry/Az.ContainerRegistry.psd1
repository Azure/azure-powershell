@{
  GUID = '52ef0264-8c4d-4432-b4cc-808a67fd43c6'
  RootModule = './Az.ContainerRegistry.psm1'
  ModuleVersion = '0.1.3'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ContainerRegistry cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ContainerRegistry.private.dll'
  FormatsToProcess = './Az.ContainerRegistry.format.ps1xml'
  CmdletsToExport = 'Build-AzContainerRegistryQueue', 'Get-AzContainerRegistry', 'Get-AzContainerRegistryAcrManifestAcrMetadataAcrManifest', 'Get-AzContainerRegistryAcrManifestAcrMetadataAcrManifestAttribute', 'Get-AzContainerRegistryAcrRepository', 'Get-AzContainerRegistryAcrRepositoryAcrMetadataAcrRepositoryAttribute', 'Get-AzContainerRegistryAcrTagAcrMetadataAcrTag', 'Get-AzContainerRegistryAcrTagAcrMetadataAcrTagAttribute', 'Get-AzContainerRegistryBuild', 'Get-AzContainerRegistryBuildLogLink', 'Get-AzContainerRegistryBuildSourceUploadUrl', 'Get-AzContainerRegistryBuildStep', 'Get-AzContainerRegistryBuildStepBuildArgument', 'Get-AzContainerRegistryBuildTask', 'Get-AzContainerRegistryBuildTaskSourceRepositoryProperty', 'Get-AzContainerRegistryCredentials', 'Get-AzContainerRegistryManifest', 'Get-AzContainerRegistryPolicy', 'Get-AzContainerRegistryReplication', 'Get-AzContainerRegistryRepository', 'Get-AzContainerRegistryRun', 'Get-AzContainerRegistryRunLogSasUrl', 'Get-AzContainerRegistryTagList', 'Get-AzContainerRegistryTask', 'Get-AzContainerRegistryTaskDetail', 'Get-AzContainerRegistryUsage', 'Get-AzContainerRegistryWebhook', 'Get-AzContainerRegistryWebhookCallbackConfig', 'Get-AzContainerRegistryWebhookEvent', 'Import-AzContainerRegistryImage', 'Invoke-AzContainerRegistryScheduleRegistryRun', 'New-AzContainerRegistry', 'New-AzContainerRegistryBuildStep', 'New-AzContainerRegistryBuildTask', 'New-AzContainerRegistryCredential', 'New-AzContainerRegistryCredentials', 'New-AzContainerRegistryReplication', 'New-AzContainerRegistryTask', 'New-AzContainerRegistryWebhook', 'Ping-AzContainerRegistryWebhook', 'Remove-AzContainerRegistry', 'Remove-AzContainerRegistryAcrRepository', 'Remove-AzContainerRegistryAcrTagAcrMetadataAcrTag', 'Remove-AzContainerRegistryBuildStep', 'Remove-AzContainerRegistryBuildTask', 'Remove-AzContainerRegistryReplication', 'Remove-AzContainerRegistryTask', 'Remove-AzContainerRegistryWebhook', 'Stop-AzContainerRegistryBuild', 'Stop-AzContainerRegistryRun', 'Test-AzContainerRegistryNameAvailability', 'Update-AzContainerRegistry', 'Update-AzContainerRegistryAcrManifestAcrMetadataAcrManifestAttribute', 'Update-AzContainerRegistryAcrRepositoryAcrMetadataAcrRepositoryAttribute', 'Update-AzContainerRegistryAcrTagAcrMetadataAcrTagAttribute', 'Update-AzContainerRegistryBuild', 'Update-AzContainerRegistryBuildStep', 'Update-AzContainerRegistryBuildTask', 'Update-AzContainerRegistryPolicy', 'Update-AzContainerRegistryReplication', 'Update-AzContainerRegistryRun', 'Update-AzContainerRegistryTask', 'Update-AzContainerRegistryWebhook', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'ContainerRegistry'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30'
    }
  }
}
