if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryNamespaceDiscoveredDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryNamespaceDiscoveredDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryNamespaceDiscoveredDevice' {
    It 'CreateExpanded' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.createTests.CreateExpanded
        $commonProperties = $env.namespaceDiscoveredDeviceTests.createTests.commonProperties
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $outboundAssigned = @{
            $commonProperties.outboundEndpointName = @{
                address = $commonProperties.outboundAddress
                endpointType = $commonProperties.outboundEndpointType
            }
        }
        $endpointInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                Version = $commonProperties.inboundVersion1
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                Version = $commonProperties.inboundVersion2
            }
        }

        $result = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -Location $env.location -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -DiscoveryId $commonProperties.discoveryId -Version $commonProperties.version -Manufacturer $commonProperties.manufacturer -Model $commonProperties.model -OperatingSystem $commonProperties.operatingSystem -OperatingSystemVersion $commonProperties.operatingSystemVersion -OutboundAssigned $outboundAssigned -EndpointInbound $endpointInbound
        
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

    It 'CreateViaJsonFilePath' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.createTests.CreateViaJsonFilePath
        $commonProperties = $env.namespaceDiscoveredDeviceTests.createTests.commonProperties
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        
        $result = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $jsonFilePath
        
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

    It 'CreateViaJsonString' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.createTests.CreateViaJsonString
        $commonProperties = $env.namespaceDiscoveredDeviceTests.createTests.commonProperties
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $jsonString = Get-Content -Path $jsonFilePath -Raw
        
        $result = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonString $jsonString
        
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
