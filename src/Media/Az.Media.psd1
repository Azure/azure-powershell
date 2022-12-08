@{
  GUID = 'd4eb7ddc-b2bb-4fb8-ae81-c8688365bad9'
  RootModule = './Az.Media.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Media cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Media.private.dll'
  FormatsToProcess = './Az.Media.format.ps1xml'
  FunctionsToExport = 'Get-AzMediaAccountFilter', 'Get-AzMediaAsset', 'Get-AzMediaAssetContainerSas', 'Get-AzMediaAssetEncryptionKey', 'Get-AzMediaAssetFilter', 'Get-AzMediaAssetStreamingLocator', 'Get-AzMediaAsyncLiveEventOperation', 'Get-AzMediaAsyncLiveOutputOperation', 'Get-AzMediaAsyncStreamingEndpointOperation', 'Get-AzMediaContentKeyPolicy', 'Get-AzMediaContentKeyPolicyProperty', 'Get-AzMediaJob', 'Get-AzMediaLiveEvent', 'Get-AzMediaLiveOutput', 'Get-AzMediaOperationLiveEventLocation', 'Get-AzMediaOperationLiveOutputLocation', 'Get-AzMediaOperationResult', 'Get-AzMediaOperationStatuses', 'Get-AzMediaOperationStreamingEndpointLocation', 'Get-AzMediaPrivateEndpointConnection', 'Get-AzMediaPrivateLinkResource', 'Get-AzMediaScaleStreamingEndpoint', 'Get-AzMediaService', 'Get-AzMediaServiceEdgePolicy', 'Get-AzMediaServicesOperationResult', 'Get-AzMediaServicesOperationStatuses', 'Get-AzMediaSkuStreamingEndpoint', 'Get-AzMediaStreamingEndpoint', 'Get-AzMediaStreamingLocator', 'Get-AzMediaStreamingLocatorContentKey', 'Get-AzMediaStreamingLocatorPath', 'Get-AzMediaStreamingPolicy', 'Get-AzMediaTrack', 'Get-AzMediaTransform', 'New-AzMediaAccountFilter', 'New-AzMediaAkamaiSignatureHeaderAuthenticationKeyObject', 'New-AzMediaAsset', 'New-AzMediaAssetFilter', 'New-AzMediaContentKeyPolicy', 'New-AzMediaContentKeyPolicyOptionObject', 'New-AzMediaFilterTrackPropertyConditionObject', 'New-AzMediaFilterTrackSelectionObject', 'New-AzMediaIPRangeObject', 'New-AzMediaJob', 'New-AzMediaJobOutputObject', 'New-AzMediaLiveEvent', 'New-AzMediaLiveEventEndpointObject', 'New-AzMediaLiveEventInputTrackSelectionObject', 'New-AzMediaLiveEventTranscriptionObject', 'New-AzMediaLiveOutput', 'New-AzMediaPrivateEndpointConnection', 'New-AzMediaService', 'New-AzMediaStorageAccountObject', 'New-AzMediaStreamingEndpoint', 'New-AzMediaStreamingLocator', 'New-AzMediaStreamingLocatorContentKeyObject', 'New-AzMediaStreamingPolicy', 'New-AzMediaStreamingPolicyContentKeyObject', 'New-AzMediaTrack', 'New-AzMediaTrackPropertyConditionObject', 'New-AzMediaTrackSelectionObject', 'New-AzMediaTransform', 'New-AzMediaTransformOutputObject', 'Remove-AzMediaAccountFilter', 'Remove-AzMediaAsset', 'Remove-AzMediaAssetFilter', 'Remove-AzMediaContentKeyPolicy', 'Remove-AzMediaJob', 'Remove-AzMediaLiveEvent', 'Remove-AzMediaLiveOutput', 'Remove-AzMediaPrivateEndpointConnection', 'Remove-AzMediaService', 'Remove-AzMediaStreamingEndpoint', 'Remove-AzMediaStreamingLocator', 'Remove-AzMediaStreamingPolicy', 'Remove-AzMediaTrack', 'Remove-AzMediaTransform', 'Reset-AzMediaLiveEvent', 'Start-AzMediaLiveEvent', 'Start-AzMediaStreamingEndpoint', 'Stop-AzMediaJob', 'Stop-AzMediaLiveEvent', 'Stop-AzMediaStreamingEndpoint', 'Sync-AzMediaServiceStorageKey', 'Test-AzMediaLocationNameAvailability', 'Update-AzMediaAccountFilter', 'Update-AzMediaAsset', 'Update-AzMediaAssetFilter', 'Update-AzMediaContentKeyPolicy', 'Update-AzMediaJob', 'Update-AzMediaLiveEvent', 'Update-AzMediaService', 'Update-AzMediaStreamingEndpoint', 'Update-AzMediaTrack', 'Update-AzMediaTransform', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Media'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
