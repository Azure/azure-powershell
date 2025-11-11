if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryNamespaceDiscoveredDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryNamespaceDiscoveredDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryNamespaceDiscoveredDevice' {
    It 'UpdateExpanded' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.updateTests.UpdateExpanded
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredDeviceTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.updateTests.createJsonFilePath
        $endpointInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                Version = $commonPatchConfig.inboundVersion1
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                Version = $commonProperties.inboundVersion2
            }
        }

        # Create device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update device properties
        $result = Update-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -OperatingSystemVersion $commonPatchConfig.operatingSystemVersion -DiscoveryId $commonProperties.discoveryId -EndpointInbound $endpointInbound
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointInbound.Count | Should -Be 2
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Version | Should -Be $commonPatchConfig.inboundVersion1
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Version | Should -Be $commonProperties.inboundVersion2
    }

    It 'UpdateViaJsonString' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.updateTests.UpdateViaJsonString
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredDeviceTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Read update JSON as string
        $jsonString = Get-Content -Path $updateJsonFilePath -Raw
        
        # Update device using JSON string
        $result = Update-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonString $jsonString
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointInbound.Count | Should -Be 2
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Version | Should -Be $commonPatchConfig.inboundVersion1
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Version | Should -Be $commonProperties.inboundVersion2
    }

    It 'UpdateViaJsonFilePath' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.updateTests.UpdateViaJsonFilePath
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredDeviceTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update device using JSON file path
        $result = Update-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $updateJsonFilePath
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointInbound.Count | Should -Be 2
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Version | Should -Be $commonPatchConfig.inboundVersion1
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Version | Should -Be $commonProperties.inboundVersion2
    }

    It 'UpdateViaIdentityNamespaceExpanded' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.updateTests.UpdateViaIdentityNamespaceExpanded
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredDeviceTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.updateTests.createJsonFilePath
        $endpointInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                Version = $commonPatchConfig.inboundVersion1
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                Version = $commonProperties.inboundVersion2
            }
        }
        
        # Create device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
        }
        
        # Update device using namespace identity
        $result = Update-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName $testConfig.name -OperatingSystemVersion $commonPatchConfig.operatingSystemVersion -EndpointInbound $endpointInbound -DiscoveryId $commonProperties.discoveryId

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointInbound.Count | Should -Be 2
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Version | Should -Be $commonPatchConfig.inboundVersion1
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Version | Should -Be $commonProperties.inboundVersion2
    }

    It 'UpdateViaIdentityExpanded' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.updateTests.UpdateViaIdentityExpanded
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $commonProperties = $env.namespaceDiscoveredDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDiscoveredDeviceTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.updateTests.createJsonFilePath
        $endpointInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                Version = $commonPatchConfig.inboundVersion1
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                Version = $commonProperties.inboundVersion2
            }
        }

        # Create device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $createJsonFilePath
        
        # Update device using device object as identity
        $result = Update-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $createdDevice -OperatingSystemVersion $commonPatchConfig.operatingSystemVersion -DiscoveryId $commonProperties.discoveryId -EndpointInbound $endpointInbound
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $env.location
        $result.ExtendedLocationName | Should -Be $env.extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.DiscoveryId | Should -Be $commonProperties.discoveryId
        $result.Version | Should -Be $commonProperties.version
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointInbound.Count | Should -Be 2
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointInbound[$commonProperties.inboundEndpointName1].Version | Should -Be $commonPatchConfig.inboundVersion1
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointInbound[$commonProperties.inboundEndpointName2].Version | Should -Be $commonProperties.inboundVersion2
    }
}
