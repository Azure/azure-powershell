if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryAsset' {
    It 'CreateExpanded' {
        $assetTestParams = $env.assetTests.createTests.CreateExpanded
        $commonAssetProperties = $env.assetTests.createTests.commonAssetProperties
        
        $asset = New-AzDeviceRegistryAsset -Name $assetTestParams.name -ResourceGroupName $env.resourceGroup -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef -ExternalAssetId $commonAssetProperties.externalAssetId -DisplayName $commonAssetProperties.displayName -Manufacturer $commonAssetProperties.manufacturer -ManufacturerUri $commonAssetProperties.manufacturerUri -Model $commonAssetProperties.model -ProductCode $commonAssetProperties.productCode -SerialNumber $commonAssetProperties.serialNumber -SoftwareRevision $commonAssetProperties.softwareRevision -HardwareRevision $commonAssetProperties.hardwareRevision -DocumentationUri $commonAssetProperties.documentationUri -DefaultTopicPath $commonAssetProperties.defaultTopicPath -DefaultTopicRetain $commonAssetProperties.defaultTopicRetain -DefaultDatasetsConfiguration $commonAssetProperties.defaultDatasetsConfiguration -DefaultEventsConfiguration $commonAssetProperties.defaultEventsConfiguration

        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.EndpointProfileRef | Should -Be $env.assetTests.assetEndpointProfileRef
        $asset.ExternalAssetId | Should -Be $commonAssetProperties.externalAssetId
        $asset.DisplayName | Should -Be $commonAssetProperties.displayName
        $asset.Manufacturer | Should -Be $commonAssetProperties.manufacturer
        $asset.ManufacturerUri | Should -Be $commonAssetProperties.manufacturerUri
        $asset.Model | Should -Be $commonAssetProperties.model
        $asset.ProductCode | Should -Be $commonAssetProperties.productCode
        $asset.SerialNumber | Should -Be $commonAssetProperties.serialNumber
        $asset.SoftwareRevision | Should -Be $commonAssetProperties.softwareRevision
        $asset.HardwareRevision | Should -Be $commonAssetProperties.hardwareRevision
        $asset.DocumentationUri | Should -Be $commonAssetProperties.documentationUri
        $asset.DefaultTopicPath | Should -Be $commonAssetProperties.defaultTopicPath
        $asset.DefaultTopicRetain | Should -Be $commonAssetProperties.defaultTopicRetain
        $asset.DefaultDatasetsConfiguration | Should -Be $commonAssetProperties.defaultDatasetsConfiguration
        $asset.DefaultEventsConfiguration | Should -Be $commonAssetProperties.defaultEventsConfiguration
    }

    It 'CreateViaJsonFilePath' {
        $assetTestParams = $env.assetTests.createTests.CreateViaJsonFilePath
        $commonAssetProperties = $env.assetTests.createTests.commonAssetProperties
        $jsonFilePath = (Join-Path $PSScriptRoot $assetTestParams.jsonFilePath)

        $asset = New-AzDeviceRegistryAsset -Name $assetTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath

        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.EndpointProfileRef | Should -Be $env.assetTests.assetEndpointProfileRef
        $asset.ExternalAssetId | Should -Be $commonAssetProperties.externalAssetId
        $asset.DisplayName | Should -Be $commonAssetProperties.displayName
        $asset.Manufacturer | Should -Be $commonAssetProperties.manufacturer
        $asset.ManufacturerUri | Should -Be $commonAssetProperties.manufacturerUri
        $asset.Model | Should -Be $commonAssetProperties.model
        $asset.ProductCode | Should -Be $commonAssetProperties.productCode
        $asset.SerialNumber | Should -Be $commonAssetProperties.serialNumber
        $asset.SoftwareRevision | Should -Be $commonAssetProperties.softwareRevision
        $asset.HardwareRevision | Should -Be $commonAssetProperties.hardwareRevision
        $asset.DocumentationUri | Should -Be $commonAssetProperties.documentationUri
        $asset.DefaultTopicPath | Should -Be $commonAssetProperties.defaultTopicPath
        $asset.DefaultTopicRetain | Should -Be $commonAssetProperties.defaultTopicRetain
        $asset.DefaultDatasetsConfiguration | Should -Be $commonAssetProperties.defaultDatasetsConfiguration
        $asset.DefaultEventsConfiguration | Should -Be $commonAssetProperties.defaultEventsConfiguration
        $asset.Dataset.Count | Should -Be 1
        $asset.Dataset.Name | Should -Be $assetTestParams.datasetName
        $asset.Dataset.Configuration | Should -Be $assetTestParams.datasetConfiguration
        $asset.Dataset.TopicPath | Should -Be $assetTestParams.datasetTopicPath
        $asset.Dataset.TopicRetain | Should -Be $assetTestParams.datasetTopicRetain
        $asset.Dataset[0].DataPoint.Count | Should -Be 2
        $asset.Dataset[0].DataPoint[0].Name | Should -Be $assetTestParams.dataPoint1.name
        $asset.Dataset[0].DataPoint[0].DataSource | Should -Be $assetTestParams.dataPoint1.dataSource
        $asset.Dataset[0].DataPoint[0].Configuration | Should -Be $assetTestParams.dataPoint1.dataPointConfiguration
        $asset.Dataset[0].DataPoint[1].Name | Should -Be $assetTestParams.dataPoint2.name
        $asset.Dataset[0].DataPoint[1].DataSource | Should -Be $assetTestParams.dataPoint2.dataSource
        $asset.Dataset[0].DataPoint[1].Configuration | Should -Be $assetTestParams.dataPoint2.dataPointConfiguration
        $asset.Event.Count | Should -Be 2
        $asset.Event[0].Name | Should -Be $assetTestParams.event1.name
        $asset.Event[0].Notifier | Should -Be $assetTestParams.event1.eventNotifier
        $asset.Event[0].Configuration | Should -Be $assetTestParams.event1.eventConfiguration
        $asset.Event[1].Name | Should -Be $assetTestParams.event2.name
        $asset.Event[1].Notifier | Should -Be $assetTestParams.event2.eventNotifier
        $asset.Event[1].Configuration | Should -Be $assetTestParams.event2.eventConfiguration
    }

    It 'CreateViaJsonString' {
        $assetTestParams = $env.assetTests.createTests.CreateViaJsonString
        $commonAssetProperties = $env.assetTests.createTests.commonAssetProperties
        $jsonString = Get-Content -Path (Join-Path $PSScriptRoot $assetTestParams.jsonStringFilePath) -Raw

        $asset = New-AzDeviceRegistryAsset -Name $assetTestParams.name -ResourceGroupName $env.resourceGroup -JsonString $jsonString
        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.EndpointProfileRef | Should -Be $env.assetTests.assetEndpointProfileRef
        $asset.ExternalAssetId | Should -Be $commonAssetProperties.externalAssetId
        $asset.DisplayName | Should -Be $commonAssetProperties.displayName
        $asset.Manufacturer | Should -Be $commonAssetProperties.manufacturer
        $asset.ManufacturerUri | Should -Be $commonAssetProperties.manufacturerUri
        $asset.Model | Should -Be $commonAssetProperties.model
        $asset.ProductCode | Should -Be $commonAssetProperties.productCode
        $asset.SerialNumber | Should -Be $commonAssetProperties.serialNumber
        $asset.SoftwareRevision | Should -Be $commonAssetProperties.softwareRevision
        $asset.HardwareRevision | Should -Be $commonAssetProperties.hardwareRevision
        $asset.DocumentationUri | Should -Be $commonAssetProperties.documentationUri
        $asset.DefaultTopicPath | Should -Be $commonAssetProperties.defaultTopicPath
        $asset.DefaultTopicRetain | Should -Be $commonAssetProperties.defaultTopicRetain
        $asset.DefaultDatasetsConfiguration | Should -Be $commonAssetProperties.defaultDatasetsConfiguration
        $asset.DefaultEventsConfiguration | Should -Be $commonAssetProperties.defaultEventsConfiguration
        $asset.Dataset.Count | Should -Be 1
        $asset.Dataset[0].DataPoint.Count | Should -Be 2
        $asset.Event.Count | Should -Be 2
    }
}
