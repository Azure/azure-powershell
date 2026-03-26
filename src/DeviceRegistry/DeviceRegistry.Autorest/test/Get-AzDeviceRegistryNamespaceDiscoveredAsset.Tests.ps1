if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryNamespaceDiscoveredAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryNamespaceDiscoveredAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryNamespaceDiscoveredAsset' {
    It 'List' {
        $testConfig = $env.namespaceDiscoveredAssetTests.getTests.List
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.getTests.jsonFilePath
        New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name1 -JsonFilePath $jsonFilePath
        New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name2 -JsonFilePath $jsonFilePath
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName
        
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 2
        $DiscoveredAssetNames = $result | ForEach-Object { $_.Name }
        $DiscoveredAssetNames | Should -Contain $testConfig.name1
        $DiscoveredAssetNames | Should -Contain $testConfig.name2
    }

    It 'GetViaIdentityNamespace' {
        $testConfig = $env.namespaceDiscoveredAssetTests.getTests.GetViaIdentityNamespace
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.getTests.jsonFilePath
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $jsonFilePath
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
        }
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName $testConfig.name
        
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

    It 'Get' {
        $testConfig = $env.namespaceDiscoveredAssetTests.getTests.Get
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.getTests.jsonFilePath
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $jsonFilePath
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name
        
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

    It 'GetViaIdentity' {
        $testConfig = $env.namespaceDiscoveredAssetTests.getTests.GetViaIdentity
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.getTests.jsonFilePath
        $createdAsset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $jsonFilePath
        $identity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
            DiscoveredAssetName = $testConfig.name
        }
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $identity
        
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
