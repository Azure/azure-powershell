if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryNamespaceDiscoveredDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryNamespaceDiscoveredDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryNamespaceDiscoveredDevice' {
    It 'List' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.getTests.List
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.getTests.jsonFilePath
        New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name1 -JsonFilePath $jsonFilePath
        New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name2 -JsonFilePath $jsonFilePath
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName
        
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 2
        $deviceNames = $result | ForEach-Object { $_.Name }
        $deviceNames | Should -Contain $testConfig.name1
        $deviceNames | Should -Contain $testConfig.name2
    }

    It 'GetViaIdentityNamespace' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.getTests.GetViaIdentityNamespace
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.createTests.commonProperties
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.getTests.jsonFilePath
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $jsonFilePath
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
        }
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonProperties.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.EndpointInbound.Count | Should -Be 2
    }

    It 'Get' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.getTests.Get
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.createTests.commonProperties
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.getTests.jsonFilePath
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $jsonFilePath
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonProperties.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointInbound.Count | Should -Be 2
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Version | Should -Be $commonProperties.inboundVersion1
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Version | Should -Be $commonProperties.inboundVersion2
    }

    It 'GetViaIdentity' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.getTests.GetViaIdentity
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.createTests.commonProperties
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.getTests.jsonFilePath
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $jsonFilePath
        $identity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
            DiscoveredDeviceName = $testConfig.name
        }
        
        $result = Get-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $identity
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonProperties.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointInbound.Count | Should -Be 2
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Version | Should -Be $commonProperties.inboundVersion1
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Version | Should -Be $commonProperties.inboundVersion2
    }
}
