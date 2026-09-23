if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryNamespaceDiscoveredAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryNamespaceDiscoveredAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryNamespaceDiscoveredAsset' {
    It 'UpdateExpanded' {
        $testConfig = $env.namespaceDiscoveredAssetTests.updateTests.UpdateExpanded
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.updateTests.createJsonFilePath
        $commonProperties = $env.namespaceDiscoveredAssetTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredAssetTests.updateTests.commonPatchConfig
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update the asset with expanded parameters
        Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -DocumentationUri $commonPatchConfig.documentationUri -SerialNumber $commonPatchConfig.serialNumber
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonPatchConfig.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
    }

    It 'UpdateViaJsonString' {
        $testConfig = $env.namespaceDiscoveredAssetTests.updateTests.UpdateViaJsonString
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredAssetTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredAssetTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Prepare update JSON string
        $updateJson = Get-Content -Path $updateJsonFilePath -Raw
        
        # Update the asset using JSON string
        Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonString $updateJson
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonPatchConfig.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
        
    }

    It 'UpdateViaJsonFilePath' {
        $testConfig = $env.namespaceDiscoveredAssetTests.updateTests.UpdateViaJsonFilePath
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredAssetTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredAssetTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update the asset using JSON file path
        Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $updateJsonFilePath
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonPatchConfig.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
    }

    It 'UpdateViaIdentityNamespaceExpanded' {
        $testConfig = $env.namespaceDiscoveredAssetTests.updateTests.UpdateViaIdentityNamespaceExpanded
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredAssetTests.updateTests.commonProperties
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.updateTests.createJsonFilePath
        $commonPatchConfig = $env.namespaceDiscoveredAssetTests.updateTests.commonPatchConfig
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
        }
        
        # Update the asset using namespace identity with expanded parameters
        Update-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName $testConfig.name -DocumentationUri $commonPatchConfig.documentationUri -SerialNumber $commonPatchConfig.serialNumber
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonPatchConfig.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
    }

    It 'UpdateViaIdentityExpanded' {
        $testConfig = $env.namespaceDiscoveredAssetTests.updateTests.UpdateViaIdentityExpanded
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredAssetTests.updateTests.commonProperties
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.updateTests.createJsonFilePath
        $commonPatchConfig = $env.namespaceDiscoveredAssetTests.updateTests.commonPatchConfig
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update the asset using the asset object as identity with expanded parameters
        Update-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $createdAsset -DocumentationUri $commonPatchConfig.documentationUri -SerialNumber $commonPatchConfig.serialNumber
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $createdAsset
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonPatchConfig.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
    }
}
