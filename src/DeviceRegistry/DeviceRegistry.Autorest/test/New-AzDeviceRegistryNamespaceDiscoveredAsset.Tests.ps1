if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryNamespaceDiscoveredAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryNamespaceDiscoveredAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryNamespaceDiscoveredAsset' {
    It 'CreateExpanded'  {
        $testConfig = $env.namespaceDiscoveredAssetTests.createTests.CreateExpanded
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName

        $result = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -Location $env.location -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -DeviceRefDeviceName $testConfig.properties.deviceRef.deviceName -DeviceRefEndpointName $testConfig.properties.deviceRef.endpointName -DiscoveryId $testConfig.properties.discoveryId -Version $testConfig.properties.version -Manufacturer $testConfig.properties.manufacturer -ManufacturerUri $testConfig.properties.manufacturerUri -Model $testConfig.properties.model -ProductCode $testConfig.properties.productCode -SoftwareRevision $testConfig.properties.softwareRevision -HardwareRevision $testConfig.properties.hardwareRevision -SerialNumber $testConfig.properties.serialNumber -DocumentationUri $testConfig.properties.documentationUri

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be $testConfig.properties.deviceRef.deviceName
        $result.DeviceRefEndpointName | Should -Be $testConfig.properties.deviceRef.endpointName
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
        $testConfig = $env.namespaceDiscoveredAssetTests.createTests.CreateViaJsonFilePath
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        $result = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $jsonFilePath
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be "myDeviceName"
        $result.DeviceRefEndpointName | Should -Be "myEndpointName"
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
        $testConfig = $env.namespaceDiscoveredAssetTests.createTests.CreateViaJsonString
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $jsonString = Get-Content -Path $jsonFilePath -Raw
        
        $result = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonString $jsonString
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DeviceRefDeviceName | Should -Be "myDeviceName"
        $result.DeviceRefEndpointName | Should -Be "myEndpointName"
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
