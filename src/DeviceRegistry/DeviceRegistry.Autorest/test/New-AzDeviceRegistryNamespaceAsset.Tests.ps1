if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryNamespaceAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryNamespaceAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryNamespaceAsset' {
    It 'CreateExpanded'  {
        $testConfig = $env.namespaceAssetTests.createTests.CreateExpanded
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName

        $result = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -Location $env.location -ExtendedLocationName $extendedLocationName -ExtendedLocationType $env.extendedLocationType -DeviceRefDeviceName $testConfig.properties.deviceRef.deviceName -DeviceRefEndpointName $testConfig.properties.deviceRef.endpointName -ExternalAssetId $testConfig.properties.externalAssetId -DisplayName $testConfig.properties.displayName -Manufacturer $testConfig.properties.manufacturer -ManufacturerUri $testConfig.properties.manufacturerUri -Model $testConfig.properties.model -ProductCode $testConfig.properties.productCode -SoftwareRevision $testConfig.properties.softwareRevision -HardwareRevision $testConfig.properties.hardwareRevision -SerialNumber $testConfig.properties.serialNumber -DocumentationUri $testConfig.properties.documentationUri

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $testConfig.properties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $testConfig.properties.deviceRef.endpointName
        $result.ExternalAssetId | Should -Be $testConfig.properties.externalAssetId
        $result.DisplayName | Should -Be $testConfig.properties.displayName
        $result.Manufacturer | Should -Be $testConfig.properties.manufacturer
        $result.ManufacturerUri | Should -Be $testConfig.properties.manufacturerUri
        $result.Model | Should -Be $testConfig.properties.model
        $result.ProductCode | Should -Be $testConfig.properties.productCode
        $result.SoftwareRevision | Should -Be $testConfig.properties.softwareRevision
        $result.HardwareRevision | Should -Be $testConfig.properties.hardwareRevision
        $result.SerialNumber | Should -Be $testConfig.properties.serialNumber
        $result.DocumentationUri | Should -Be $testConfig.properties.documentationUri
    }

    It 'CreateViaJsonFilePath'  {
        $testConfig = $env.namespaceAssetTests.createTests.CreateViaJsonFilePath
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath

        $result = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $jsonFilePath

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be "myDeviceName"
        $result.DeviceRefEndpointName | Should -Be "myEndpointName"
        $result.ExternalAssetId | Should -Be "test-asset-externalAssetId"
        $result.Manufacturer | Should -Be "Contoso123"
        $result.ManufacturerUri | Should -Be "https://www.contoso.com/manufacturerUri"
        $result.Model | Should -Be "ContosoModel"
        $result.ProductCode | Should -Be "SA34VDG"
        $result.SoftwareRevision | Should -Be "2.0"
        $result.SerialNumber | Should -Be "64-103816-519918-8"
        $result.DocumentationUri | Should -Be "https://www.example.com/manual/"
        $result.Dataset | Should -HaveCount 2
        $result.EventGroup | Should -HaveCount 2
        $result.Stream | Should -HaveCount 2
        $result.ManagementGroup | Should -HaveCount 1
    }

    It 'CreateViaJsonString'  {
        $testConfig = $env.namespaceAssetTests.createTests.CreateViaJsonString
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $jsonString = Get-Content -Path $jsonFilePath -Raw

        $result = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonString $jsonString

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be "myDeviceName"
        $result.DeviceRefEndpointName | Should -Be "myEndpointName"
        $result.ExternalAssetId | Should -Be "test-asset-externalAssetId"
        $result.Manufacturer | Should -Be "Contoso123"
        $result.ManufacturerUri | Should -Be "https://www.contoso.com/manufacturerUri"
        $result.Model | Should -Be "ContosoModel"
        $result.ProductCode | Should -Be "SA34VDG"
        $result.SoftwareRevision | Should -Be "2.0"
        $result.SerialNumber | Should -Be "64-103816-519918-8"
        $result.DocumentationUri | Should -Be "https://www.example.com/manual/"
        $result.Dataset | Should -HaveCount 2
        $result.EventGroup | Should -HaveCount 2
        $result.Stream | Should -HaveCount 2
        $result.ManagementGroup | Should -HaveCount 1
    }
}
