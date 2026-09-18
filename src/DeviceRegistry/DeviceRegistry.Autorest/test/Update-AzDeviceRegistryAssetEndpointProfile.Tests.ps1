if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryAssetEndpointProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryAssetEndpointProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryAssetEndpointProfile' {
    It 'UpdateExpanded' {
        $aepCommonPatchConfig = $env.assetEndpointProfileTests.updateTests.commonPatchConfig
        $aepTestParams = $env.assetEndpointProfileTests.updateTests.UpdateExpanded
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $createJsonFilePath = (Join-Path $PSScriptRoot $aepCommonPatchConfig.createJsonFilePath)

        New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $createJsonFilePath
        Update-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -TargetAddress $aepCommonPatchConfig.targetAddress -AdditionalConfiguration $aepCommonPatchConfig.additionalConfiguration
        $assetEndpointProfile = Get-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup
        
        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonPatchConfig.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepCommonProperties.authenticationMethod
        $assetEndpointProfile.X509CredentialsCertificateSecretName | Should -Be $aepCommonProperties.x509CredentialsCertificateSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
        $assetEndpointProfile.DiscoveredAssetEndpointProfileRef | Should -Be $aepCommonProperties.discoveredAssetEndpointProfileRef
        $assetEndpointProfile.AdditionalConfiguration | Should -Be $aepCommonPatchConfig.additionalConfiguration
    }

    It 'UpdateViaJsonString' {
        $aepCommonPatchConfig = $env.assetEndpointProfileTests.updateTests.commonPatchConfig
        $aepTestParams = $env.assetEndpointProfileTests.updateTests.UpdateViaJsonString
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $createJsonFilePath = (Join-Path $PSScriptRoot $aepCommonPatchConfig.createJsonFilePath)
        $updateJsonString = Get-Content -Path (Join-Path $PSScriptRoot $aepCommonPatchConfig.updateJsonFilePath) -Raw

        New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $createJsonFilePath
        Update-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonString $updateJsonString
        $assetEndpointProfile = Get-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup

        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonPatchConfig.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepCommonProperties.authenticationMethod
        $assetEndpointProfile.X509CredentialsCertificateSecretName | Should -Be $aepCommonProperties.x509CredentialsCertificateSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
        $assetEndpointProfile.DiscoveredAssetEndpointProfileRef | Should -Be $aepCommonProperties.discoveredAssetEndpointProfileRef
        $assetEndpointProfile.AdditionalConfiguration | Should -Be $aepCommonPatchConfig.additionalConfiguration
    }

    It 'UpdateViaJsonFilePath' {
        $aepCommonPatchConfig = $env.assetEndpointProfileTests.updateTests.commonPatchConfig
        $aepTestParams = $env.assetEndpointProfileTests.updateTests.UpdateViaJsonFilePath
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $createJsonFilePath = (Join-Path $PSScriptRoot $aepCommonPatchConfig.createJsonFilePath)
        $updateJsonFilePath = (Join-Path $PSScriptRoot $aepCommonPatchConfig.updateJsonFilePath)

        New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $createJsonFilePath
        Update-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $updateJsonFilePath
        $assetEndpointProfile = Get-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup

        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonPatchConfig.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepCommonProperties.authenticationMethod
        $assetEndpointProfile.X509CredentialsCertificateSecretName | Should -Be $aepCommonProperties.x509CredentialsCertificateSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
        $assetEndpointProfile.DiscoveredAssetEndpointProfileRef | Should -Be $aepCommonProperties.discoveredAssetEndpointProfileRef
        $assetEndpointProfile.AdditionalConfiguration | Should -Be $aepCommonPatchConfig.additionalConfiguration
    }

    It 'UpdateViaIdentityExpanded' {
        $aepCommonPatchConfig = $env.assetEndpointProfileTests.updateTests.commonPatchConfig
        $aepTestParams = $env.assetEndpointProfileTests.updateTests.UpdateExpanded
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $createJsonFilePath = (Join-Path $PSScriptRoot $aepCommonPatchConfig.createJsonFilePath)

        New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $createJsonFilePath
        Update-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -TargetAddress $aepCommonPatchConfig.targetAddress -AdditionalConfiguration $aepCommonPatchConfig.additionalConfiguration
        $assetEndpointProfile = Get-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup
        
        $assetEndpointProfile.Name | Should -Be $aepTestParams.name
        $assetEndpointProfile.ResourceGroupName | Should -Be $env.resourceGroup
        $assetEndpointProfile.ExtendedLocationName | Should -Be $env.extendedLocationName
        $assetEndpointProfile.ExtendedLocationType | Should -Be $env.extendedLocationType
        $assetEndpointProfile.Location | Should -Be $env.location
        $assetEndpointProfile.TargetAddress | Should -Be $aepCommonPatchConfig.targetAddress
        $assetEndpointProfile.AuthenticationMethod | Should -Be $aepCommonProperties.authenticationMethod
        $assetEndpointProfile.X509CredentialsCertificateSecretName | Should -Be $aepCommonProperties.x509CredentialsCertificateSecretName
        $assetEndpointProfile.EndpointProfileType | Should -Be $aepCommonProperties.endpointProfileType
        $assetEndpointProfile.DiscoveredAssetEndpointProfileRef | Should -Be $aepCommonProperties.discoveredAssetEndpointProfileRef
        $assetEndpointProfile.AdditionalConfiguration | Should -Be $aepCommonPatchConfig.additionalConfiguration
    }
}
