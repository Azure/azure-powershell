if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryNamespaceAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryNamespaceAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryNamespaceAsset' {
    It 'UpdateExpanded' {
        $testConfig = $env.namespaceAssetTests.updateTests.UpdateExpanded
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.updateTests.createJsonFilePath
        $commonProperties = $env.namespaceAssetTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceAssetTests.updateTests.commonPatchConfig
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update the asset with expanded parameters
        Update-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -DocumentationUri $commonPatchConfig.documentationUri -DisplayName $commonPatchConfig.displayName
        $result = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonProperties.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
    }

    It 'UpdateViaJsonString' {
        $testConfig = $env.namespaceAssetTests.updateTests.UpdateViaJsonString
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $commonProperties = $env.namespaceAssetTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceAssetTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $createJsonFilePath

        # Prepare update JSON string
        $updateJson = Get-Content -Path $updateJsonFilePath -Raw
        
        # Update the asset using JSON string
        Update-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonString $updateJson
        $result = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonProperties.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
        
    }

    It 'UpdateViaJsonFilePath' {
        $testConfig = $env.namespaceAssetTests.updateTests.UpdateViaJsonFilePath
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $commonProperties = $env.namespaceAssetTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceAssetTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $createJsonFilePath

        # Update the asset using JSON file path
        Update-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $updateJsonFilePath
        $result = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonProperties.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
    }

    It 'UpdateViaIdentityNamespaceExpanded' {
        $testConfig = $env.namespaceAssetTests.updateTests.UpdateViaIdentityNamespaceExpanded
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $commonProperties = $env.namespaceAssetTests.updateTests.commonProperties
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.updateTests.createJsonFilePath
        $commonPatchConfig = $env.namespaceAssetTests.updateTests.commonPatchConfig
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $createJsonFilePath

        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
        }
        
        # Update the asset using namespace identity with expanded parameters
        Update-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName $testConfig.name -DocumentationUri $commonPatchConfig.documentationUri -DisplayName $commonPatchConfig.displayName
        $result = Get-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonProperties.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
    }

    It 'UpdateViaIdentityExpanded' {
        $testConfig = $env.namespaceAssetTests.updateTests.UpdateViaIdentityExpanded
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $commonProperties = $env.namespaceAssetTests.updateTests.commonProperties
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.updateTests.createJsonFilePath
        $commonPatchConfig = $env.namespaceAssetTests.updateTests.commonPatchConfig
        
        # Create test asset to update
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update the asset using the asset object as identity with expanded parameters
        Update-AzDeviceRegistryNamespaceAsset -InputObject $createdAsset -DocumentationUri $commonPatchConfig.documentationUri -DisplayName $commonPatchConfig.displayName
        $result = Get-AzDeviceRegistryNamespaceAsset -InputObject $createdAsset
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $commonProperties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $commonProperties.deviceRef.endpointName
        $result.ExternalAssetId | Should -Be $commonProperties.externalAssetId
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.ManufacturerUri | Should -Be $commonProperties.manufacturerUri
        $result.Model | Should -Be $commonProperties.model
        $result.ProductCode | Should -Be $commonProperties.productCode
        $result.SoftwareRevision | Should -Be $commonProperties.softwareRevision
        $result.SerialNumber | Should -Be $commonProperties.serialNumber
        $result.DocumentationUri | Should -Be $commonPatchConfig.documentationUri
        $result.DisplayName | Should -Be $commonPatchConfig.displayName
    }
}
