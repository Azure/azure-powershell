if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryAssetEndpointProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryAssetEndpointProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryAssetEndpointProfile' {
    It 'CreateExpanded' {
        $aepTestParams = $env.assetEndpointProfileTests.createTests.CreateExpanded
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties

        # Create AssetEndpointProfile with Certificate Authentication
        $assetEndpointProfile = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -TargetAddress $aepCommonProperties.targetAddress -AuthenticationMethod $aepCommonProperties.authenticationMethod -X509CredentialsCertificateSecretName $aepCommonProperties.x509CredentialsCertificateSecretName -EndpointProfileType $aepCommonProperties.endpointProfileType -DiscoveredAssetEndpointProfileRef $aepCommonProperties.discoveredAssetEndpointProfileRef -AdditionalConfiguration $aepCommonProperties.additionalConfiguration
        
        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonProperties.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepCommonProperties.authenticationMethod
        $assetEndpointProfile.X509CredentialsCertificateSecretName | Should -Be $aepCommonProperties.x509CredentialsCertificateSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
        $assetEndpointProfile.DiscoveredAssetEndpointProfileRef | Should -Be $aepCommonProperties.discoveredAssetEndpointProfileRef
        $assetEndpointProfile.AdditionalConfiguration | Should -Be $aepCommonProperties.additionalConfiguration

        # Create AssetEndpointProfile with Anonymous Authentication
        $assetEndpointProfile = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -TargetAddress $aepCommonProperties.targetAddress -AuthenticationMethod $aepTestParams.anonymousAuthentication -EndpointProfileType $aepCommonProperties.endpointProfileType
        
        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonProperties.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepTestParams.anonymousAuthentication
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType

        # Create AssetEndpointProfile with UsernamePassword Authentication
        $assetEndpointProfile = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -TargetAddress $aepCommonProperties.targetAddress -AuthenticationMethod $aepTestParams.usernameAuthentication -UsernamePasswordCredentialsUsernameSecretName $aepTestParams.usernameSecretName -UsernamePasswordCredentialsPasswordSecretName $aepTestParams.passwordSecretName -EndpointProfileType $aepCommonProperties.endpointProfileType
        
        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonProperties.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepTestParams.usernameAuthentication
        $assetEndpointProfile.UsernamePasswordCredentialsUsernameSecretName | Should -Be $aepTestParams.usernameSecretName
        $assetEndpointProfile.UsernamePasswordCredentialsPasswordSecretName | Should -Be $aepTestParams.passwordSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
    }

    It 'CreateViaJsonFilePath' {
        $aepTestParams = $env.assetEndpointProfileTests.createTests.CreateViaJsonFilePath
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $jsonFilePath = (Join-Path $PSScriptRoot $aepTestParams.jsonFilePath)

        $assetEndpointProfile = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        
        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonProperties.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepCommonProperties.authenticationMethod
        $assetEndpointProfile.X509CredentialsCertificateSecretName | Should -Be $aepCommonProperties.x509CredentialsCertificateSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
        $assetEndpointProfile.DiscoveredAssetEndpointProfileRef | Should -Be $aepCommonProperties.discoveredAssetEndpointProfileRef
        $assetEndpointProfile.AdditionalConfiguration | Should -Be $aepCommonProperties.additionalConfiguration
    }

    It 'CreateViaJsonString' {
        $aepTestParams = $env.assetEndpointProfileTests.createTests.CreateViaJsonString
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $jsonString = Get-Content -Path (Join-Path $PSScriptRoot $aepTestParams.jsonStringFilePath) -Raw

        $assetEndpointProfile = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonString $jsonString
        
        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonProperties.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepCommonProperties.authenticationMethod
        $assetEndpointProfile.X509CredentialsCertificateSecretName | Should -Be $aepCommonProperties.x509CredentialsCertificateSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
        $assetEndpointProfile.DiscoveredAssetEndpointProfileRef | Should -Be $aepCommonProperties.discoveredAssetEndpointProfileRef
        $assetEndpointProfile.AdditionalConfiguration | Should -Be $aepCommonProperties.additionalConfiguration
    }
}
