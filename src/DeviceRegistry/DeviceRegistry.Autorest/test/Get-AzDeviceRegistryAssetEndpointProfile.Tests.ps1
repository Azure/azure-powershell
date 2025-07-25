if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryAssetEndpointProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryAssetEndpointProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryAssetEndpointProfile' {
    It 'List' {
        $aepTestParams = $env.assetEndpointProfileTests.getTests.List
        $jsonFilePath = (Join-Path $PSScriptRoot $aepTestParams.jsonFilePath)
        $aepTestParams.names | ForEach-Object {
            New-AzDeviceRegistryAssetEndpointProfile -Name $_ -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        }

        $listOfAeps = Get-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName $env.resourceGroup
        
        # the count of listOfAeps should be at least the count of names in the test parameters
        $listOfAeps.Count -ge $aepTestParams.names.Count | Should -Be $true
    }

    It 'Get' {
        $aepTestParams = $env.assetEndpointProfileTests.getTests.Get
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $jsonFilePath = (Join-Path $PSScriptRoot $aepTestParams.jsonFilePath)

        New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        $assetEndpointProfile = Get-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup

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

    It 'GetViaIdentity' {
        $aepTestParams = $env.assetEndpointProfileTests.getTests.GetViaIdentity
        $aepCommonProperties = $env.assetEndpointProfileTests.CommonProperties
        $jsonFilePath = (Join-Path $PSScriptRoot $aepTestParams.jsonFilePath)

        $aepInputObject = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath

        $assetEndpointProfile = Get-AzDeviceRegistryAssetEndpointProfile -InputObject $aepInputObject
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
