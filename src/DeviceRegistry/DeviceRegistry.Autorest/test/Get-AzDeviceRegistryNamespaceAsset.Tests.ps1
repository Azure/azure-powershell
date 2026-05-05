if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryNamespaceAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryNamespaceAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryNamespaceAsset' {
    It 'List' {
        $testConfig = $env.namespaceAssetTests.getTests.List
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.getTests.jsonFilePath
        New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name1 -JsonFilePath $jsonFilePath
        New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name2 -JsonFilePath $jsonFilePath

        $result = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
        
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 2
        $assetNames = $result | ForEach-Object { $_.Name }
        $assetNames | Should -Contain $testConfig.name1
        $assetNames | Should -Contain $testConfig.name2
    }

    It 'GetViaIdentityNamespace' {
        $testConfig = $env.namespaceAssetTests.getTests.GetViaIdentityNamespace
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.getTests.jsonFilePath
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $jsonFilePath
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
        }
        
        $result = Get-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName $testConfig.name
        
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

    It 'Get' {
        $testConfig = $env.namespaceAssetTests.getTests.Get
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.getTests.jsonFilePath
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $jsonFilePath

        $result = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name

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

    It 'GetViaIdentity' {
        $testConfig = $env.namespaceAssetTests.getTests.GetViaIdentity
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $extendedLocationName = $env.namespaceAssetTests.extendedLocationName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.getTests.jsonFilePath
        $createdAsset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $jsonFilePath
        $identity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
            AssetName = $testConfig.name
        }
        
        $result = Get-AzDeviceRegistryNamespaceAsset -InputObject $identity
        
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
