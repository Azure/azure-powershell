if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryNamespaceDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryNamespaceDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryNamespaceDevice' {
    It 'CreateExpanded' {
        $testConfig = $env.namespaceDeviceTests.createTests.CreateExpanded
        $commonProperties = $env.namespaceDeviceTests.createTests.commonProperties
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $outboundAssigned = @{
            $commonProperties.outboundEndpointName = @{
                address = $commonProperties.outboundAddress
                endpointType = $commonProperties.outboundEndpointType
            }
        }
        $endpointsInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                AuthenticationMethod = $commonProperties.authenticationMethod1
                X509CredentialsCertificateSecretName = $commonProperties.certificateSecretName
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                AuthenticationMethod = $commonProperties.authenticationMethod2
                UsernamePasswordCredentialsUsernameSecretName = $commonProperties.usernameSecretName
                UsernamePasswordCredentialsPasswordSecretName = $commonProperties.passwordSecretName
            }
        }

        $result = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -Location $location -ExtendedLocationName $extendedLocationName -ExtendedLocationType $env.extendedLocationType -Manufacturer $commonProperties.manufacturer -Model $commonProperties.model -OperatingSystem $commonProperties.operatingSystem -OperatingSystemVersion $commonProperties.operatingSystemVersion -OutboundAssigned $outboundAssigned -EndpointsInbound $endpointsInbound -Enabled

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
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsCertificateSecretName | Should -Be $commonProperties.certificateSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
    }

    It 'CreateViaJsonFilePath' {
        $testConfig = $env.namespaceDeviceTests.createTests.CreateViaJsonFilePath
        $commonProperties = $env.namespaceDeviceTests.createTests.commonProperties
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath

        $result = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $jsonFilePath

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
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsCertificateSecretName | Should -Be $commonProperties.certificateSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsKeySecretName | Should -Be $commonProperties.keySecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsIntermediateCertificatesSecretName | Should -Be $commonProperties.intermediateCertificatesSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
    }

    It 'CreateViaJsonString' {
        $testConfig = $env.namespaceDeviceTests.createTests.CreateViaJsonString
        $commonProperties = $env.namespaceDeviceTests.createTests.commonProperties
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath
        $jsonString = Get-Content -Path $jsonFilePath -Raw

        $result = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonString $jsonString
        
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
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsCertificateSecretName | Should -Be $commonProperties.certificateSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsKeySecretName | Should -Be $commonProperties.keySecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsIntermediateCertificatesSecretName | Should -Be $commonProperties.intermediateCertificatesSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
    }
}
