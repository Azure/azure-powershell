if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryNamespaceDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryNamespaceDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryNamespaceDevice' {
    It 'List' {
        $testConfig = $env.namespaceDeviceTests.getTests.List
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.getTests.jsonFilePath
        New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name1 -JsonFilePath $jsonFilePath
        New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name2 -JsonFilePath $jsonFilePath

        $result = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterOrEqual 2
        $deviceNames = $result | ForEach-Object { $_.Name }
        $deviceNames | Should -Contain $testConfig.name1
        $deviceNames | Should -Contain $testConfig.name2
    }

    It 'GetViaIdentityNamespace' {
        $testConfig = $env.namespaceDeviceTests.getTests.GetViaIdentityNamespace
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $commonProperties = $env.namespaceDeviceTests.createTests.commonProperties
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.getTests.jsonFilePath
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $jsonFilePath
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
        }
        
        $result = Get-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonProperties.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.EndpointsInbound.Count | Should -Be 2
    }

    It 'Get' {
        $testConfig = $env.namespaceDeviceTests.getTests.Get
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $commonProperties = $env.namespaceDeviceTests.createTests.commonProperties
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.getTests.jsonFilePath
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $jsonFilePath

        $result = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonProperties.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointsInbound.Count | Should -Be 2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
    }

    It 'GetViaIdentity' {
        $testConfig = $env.namespaceDeviceTests.getTests.GetViaIdentity
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $commonProperties = $env.namespaceDeviceTests.createTests.commonProperties
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.getTests.jsonFilePath
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $jsonFilePath
        $identity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
            DeviceName = $testConfig.name
        }
        
        $result = Get-AzDeviceRegistryNamespaceDevice -InputObject $identity
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonProperties.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointsInbound.Count | Should -Be 2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
    }
}
