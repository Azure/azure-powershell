@{
  GUID = '82476d92-1dea-4ab4-bfdf-9507db752160'
  RootModule = './Az.MediaServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MediaServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MediaServices.private.dll'
  FormatsToProcess = './Az.MediaServices.format.ps1xml'
  FunctionsToExport = 'Get-AzMediaServicesAccountFilter', 'Get-AzMediaServicesAsset', 'Get-AzMediaServicesAssetContainerSas', 'Get-AzMediaServicesAssetEncryptionKey', 'Get-AzMediaServicesAssetFilter', 'Get-AzMediaServicesAssetStreamingLocator', 'Get-AzMediaServicesContentKeyPolicy', 'Get-AzMediaServicesContentKeyPolicyProperty', 'Get-AzMediaServicesJob', 'Get-AzMediaServicesLiveEvent', 'Get-AzMediaServicesLiveOutput', 'Get-AzMediaServicesMediaservice', 'Get-AzMediaServicesMediaserviceEdgePolicy', 'Get-AzMediaServicesOperationResult', 'Get-AzMediaServicesOperationStatuses', 'Get-AzMediaServicesPrivateEndpointConnection', 'Get-AzMediaServicesPrivateLinkResource', 'Get-AzMediaServicesStreamingEndpoint', 'Get-AzMediaServicesStreamingLocator', 'Get-AzMediaServicesStreamingLocatorContentKey', 'Get-AzMediaServicesStreamingLocatorPath', 'Get-AzMediaServicesStreamingPolicy', 'Get-AzMediaServicesTrack', 'Get-AzMediaServicesTransform', 'Invoke-AzMediaServicesScaleStreamingEndpoint', 'Invoke-AzMediaServicesSkuStreamingEndpoint', 'New-AzMediaServicesAccountFilter', 'New-AzMediaServicesAsset', 'New-AzMediaServicesAssetFilter', 'New-AzMediaServicesContentKeyPolicy', 'New-AzMediaServicesJob', 'New-AzMediaServicesLiveEvent', 'New-AzMediaServicesLiveOutput', 'New-AzMediaServicesMediaservice', 'New-AzMediaServicesPrivateEndpointConnection', 'New-AzMediaServicesStreamingEndpoint', 'New-AzMediaServicesStreamingLocator', 'New-AzMediaServicesStreamingPolicy', 'New-AzMediaServicesTrack', 'New-AzMediaServicesTransform', 'Remove-AzMediaServicesAccountFilter', 'Remove-AzMediaServicesAsset', 'Remove-AzMediaServicesAssetFilter', 'Remove-AzMediaServicesContentKeyPolicy', 'Remove-AzMediaServicesJob', 'Remove-AzMediaServicesLiveEvent', 'Remove-AzMediaServicesLiveOutput', 'Remove-AzMediaServicesMediaservice', 'Remove-AzMediaServicesPrivateEndpointConnection', 'Remove-AzMediaServicesStreamingEndpoint', 'Remove-AzMediaServicesStreamingLocator', 'Remove-AzMediaServicesStreamingPolicy', 'Remove-AzMediaServicesTrack', 'Remove-AzMediaServicesTransform', 'Reset-AzMediaServicesLiveEvent', 'Start-AzMediaServicesLiveEvent', 'Start-AzMediaServicesStreamingEndpoint', 'Stop-AzMediaServicesJob', 'Stop-AzMediaServicesLiveEvent', 'Stop-AzMediaServicesStreamingEndpoint', 'Sync-AzMediaServicesMediaserviceStorageKey', 'Test-AzMediaServicesLocationNameAvailability', 'Update-AzMediaServicesAccountFilter', 'Update-AzMediaServicesAsset', 'Update-AzMediaServicesAssetFilter', 'Update-AzMediaServicesContentKeyPolicy', 'Update-AzMediaServicesJob', 'Update-AzMediaServicesLiveEvent', 'Update-AzMediaServicesMediaservice', 'Update-AzMediaServicesStreamingEndpoint', 'Update-AzMediaServicesTrack', 'Update-AzMediaServicesTransform', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MediaServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
