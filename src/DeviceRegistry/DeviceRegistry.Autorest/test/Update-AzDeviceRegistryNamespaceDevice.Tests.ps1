if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryNamespaceDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryNamespaceDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryNamespaceDevice' {
    It 'UpdateExpanded' {
        $testConfig = $env.namespaceDeviceTests.updateTests.UpdateExpanded
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.updateTests.createJsonFilePath
        $commonProperties = $env.namespaceDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDeviceTests.updateTests.commonPatchConfig
        $endpointsInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                AuthenticationMethod = $commonPatchConfig.authenticationMethod1
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                AuthenticationMethod = $commonProperties.authenticationMethod2
                UsernamePasswordCredentialsUsernameSecretName = $commonProperties.usernameSecretName
                UsernamePasswordCredentialsPasswordSecretName = $commonProperties.passwordSecretName
            }
        }
        
        # Create test device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $createJsonFilePath

        # Update the device with expanded parameters
        Update-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -OperatingSystemVersion $commonPatchConfig.operatingSystemVersion -EndpointInbound $endpointsInbound

        $result = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointsInbound.Count | Should -Be 2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].AuthenticationMethod | Should -Be $commonPatchConfig.authenticationMethod1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsUsernameSecretName | Should -Be $commonProperties.usernameSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsPasswordSecretName | Should -Be $commonProperties.passwordSecretName
    }

    It 'UpdateViaJsonString' {
        $testConfig = $env.namespaceDeviceTests.updateTests.UpdateViaJsonString
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $commonProperties = $env.namespaceDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDeviceTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create test device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $createJsonFilePath

        # Prepare update JSON string
        $updateJson = Get-Content -Path $updateJsonFilePath -Raw
        
        # Update the device using JSON string
        Update-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonString $updateJson
        $result = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointsInbound.Count | Should -Be 2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].AuthenticationMethod | Should -Be $commonPatchConfig.authenticationMethod1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsUsernameSecretName | Should -Be $commonProperties.usernameSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsPasswordSecretName | Should -Be $commonProperties.passwordSecretName
    }

    It 'UpdateViaJsonFilePath' {
        $testConfig = $env.namespaceDeviceTests.updateTests.UpdateViaJsonFilePath
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $commonProperties = $env.namespaceDeviceTests.updateTests.commonProperties
        $commonPatchConfig = $env.namespaceDeviceTests.updateTests.commonPatchConfig
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.updateTests.createJsonFilePath
        $updateJsonFilePath = Join-Path $PSScriptRoot $testConfig.updateJsonFilePath
        
        # Create test device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $createJsonFilePath

        # Update the device using JSON file path
        Update-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $updateJsonFilePath
        $result = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name

        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointsInbound.Count | Should -Be 2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].AuthenticationMethod | Should -Be $commonPatchConfig.authenticationMethod1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsUsernameSecretName | Should -Be $commonProperties.usernameSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsPasswordSecretName | Should -Be $commonProperties.passwordSecretName
    }

    It 'UpdateViaIdentityNamespaceExpanded' {
        $testConfig = $env.namespaceDeviceTests.updateTests.UpdateViaIdentityNamespaceExpanded
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $commonProperties = $env.namespaceDeviceTests.updateTests.commonProperties
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.updateTests.createJsonFilePath
        $commonPatchConfig = $env.namespaceDeviceTests.updateTests.commonPatchConfig
        $endpointsInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                AuthenticationMethod = $commonPatchConfig.authenticationMethod1
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                AuthenticationMethod = $commonProperties.authenticationMethod2
                UsernamePasswordCredentialsUsernameSecretName = $commonProperties.usernameSecretName
                UsernamePasswordCredentialsPasswordSecretName = $commonProperties.passwordSecretName
            }
        }
        
        # Create test device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $createJsonFilePath

        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
        }
        
        # Update the device using namespace identity with expanded parameters
        Update-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName $testConfig.name -OperatingSystemVersion $commonPatchConfig.operatingSystemVersion -EndpointInbound $endpointsInbound
        $result = Get-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName $testConfig.name
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointsInbound.Count | Should -Be 2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].AuthenticationMethod | Should -Be $commonPatchConfig.authenticationMethod1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsCertificateSecretName | Should -Be $commonProperties.certificateSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsKeySecretName | Should -Be $commonProperties.keySecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].X509CredentialsIntermediateCertificatesSecretName | Should -Be $commonProperties.intermediateCertificatesSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsUsernameSecretName | Should -Be $commonProperties.usernameSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsPasswordSecretName | Should -Be $commonProperties.passwordSecretName
    }

    It 'UpdateViaIdentityExpanded' {
        $testConfig = $env.namespaceDeviceTests.updateTests.UpdateViaIdentityExpanded
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $extendedLocationName = $env.namespaceDeviceTests.extendedLocationName
        $location = $env.namespaceDeviceTests.location
        $commonProperties = $env.namespaceDeviceTests.updateTests.commonProperties
        $createJsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.updateTests.createJsonFilePath
        $commonPatchConfig = $env.namespaceDeviceTests.updateTests.commonPatchConfig
        $endpointsInbound = @{
            $commonProperties.inboundEndpointName1 = @{
                Address = $commonProperties.inboundAddress1
                EndpointType = $commonProperties.inboundEndpointType1
                AuthenticationMethod = $commonPatchConfig.authenticationMethod1
            }
            $commonProperties.inboundEndpointName2 = @{
                Address = $commonProperties.inboundAddress2
                EndpointType = $commonProperties.inboundEndpointType2
                AuthenticationMethod = $commonProperties.authenticationMethod2
                UsernamePasswordCredentialsUsernameSecretName = $commonProperties.usernameSecretName
                UsernamePasswordCredentialsPasswordSecretName = $commonProperties.passwordSecretName
            }
        }
        
        # Create test device to update
        $createdDevice = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $createJsonFilePath

        # Update the device using the device object as identity with expanded parameters
        Update-AzDeviceRegistryNamespaceDevice -InputObject $createdDevice -OperatingSystemVersion $commonPatchConfig.operatingSystemVersion -EndpointInbound $endpointsInbound
        $result = Get-AzDeviceRegistryNamespaceDevice -InputObject $createdDevice
        
        $result.Name | Should -Be $testConfig.name
        $result.Location | Should -Be $location
        $result.ExtendedLocationName | Should -Be $extendedLocationName
        $result.ExtendedLocationType | Should -Be $env.extendedLocationType
        $result.Enabled | Should -Be $commonProperties.enabled
        $result.Manufacturer | Should -Be $commonProperties.manufacturer
        $result.Model | Should -Be $commonProperties.model
        $result.OperatingSystem | Should -Be $commonProperties.operatingSystem
        $result.OperatingSystemVersion | Should -Be $commonPatchConfig.operatingSystemVersion
        $result.OutboundAssigned.Count | Should -Be 1
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].Address | Should -Be $commonProperties.outboundAddress
        $result.OutboundAssigned[$commonProperties.outboundEndpointName].EndpointType | Should -Be $commonProperties.outboundEndpointType
        $result.EndpointsInbound.Count | Should -Be 2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].Address | Should -Be $commonProperties.inboundAddress1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].EndpointType | Should -Be $commonProperties.inboundEndpointType1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName1].AuthenticationMethod | Should -Be $commonPatchConfig.authenticationMethod1
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].Address | Should -Be $commonProperties.inboundAddress2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].EndpointType | Should -Be $commonProperties.inboundEndpointType2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].AuthenticationMethod | Should -Be $commonProperties.authenticationMethod2
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsUsernameSecretName | Should -Be $commonProperties.usernameSecretName
        $result.EndpointsInbound[$commonProperties.inboundEndpointName2].UsernamePasswordCredentialsPasswordSecretName | Should -Be $commonProperties.passwordSecretName
    }
}
