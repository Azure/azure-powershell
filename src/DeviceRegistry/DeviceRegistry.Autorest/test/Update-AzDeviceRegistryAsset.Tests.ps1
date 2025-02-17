if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryAsset' {
    It 'UpdateExpanded' {
        $assetCommonPatchConfig = $env.assetTests.updateTests.commonPatchConfig
        $assetTestParams = $env.assetTests.updateTests.UpdateExpanded
        
        $asset = New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef

        Update-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -DocumentationUri $assetCommonPatchConfig.documentationUri -DisplayName $assetCommonPatchConfig.displayName
        
        $asset = Get-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name
        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.DocumentationUri | Should -Be $assetCommonPatchConfig.documentationUri
        $asset.DisplayName | Should -Be $assetCommonPatchConfig.displayName
    }

    It 'UpdateViaJsonString' {
        $assetCommonPatchConfig = $env.assetTests.updateTests.commonPatchConfig
        $assetTestParams = $env.assetTests.updateTests.UpdateViaJsonString
        $updateJsonString = Get-Content -Path (Join-Path $PSScriptRoot $assetTestParams.updateJsonFilePath) -Raw

        $asset = New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        Update-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -JsonString $updateJsonString

        $asset = Get-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name
        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.DocumentationUri | Should -Be $assetCommonPatchConfig.documentationUri
        $asset.DisplayName | Should -Be $assetCommonPatchConfig.displayName
    }

    It 'UpdateViaJsonFilePath' {
        $assetCommonPatchConfig = $env.assetTests.updateTests.commonPatchConfig
        $assetTestParams = $env.assetTests.updateTests.UpdateViaJsonFilePath
        $updateJsonFilePath = (Join-Path $PSScriptRoot $assetTestParams.updateJsonFilePath)

        $asset = New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        Update-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -JsonFilePath $updateJsonFilePath

        $asset = Get-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name
        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.DocumentationUri | Should -Be $assetCommonPatchConfig.documentationUri
        $asset.DisplayName | Should -Be $assetCommonPatchConfig.displayName
    }

    It 'UpdateViaIdentityExpanded' {
        $assetCommonPatchConfig = $env.assetTests.updateTests.commonPatchConfig
        $assetTestParams = $env.assetTests.updateTests.UpdateExpanded
        $asset = New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        Update-AzDeviceRegistryAsset -InputObject $asset -DocumentationUri $assetCommonPatchConfig.documentationUri -DisplayName $assetCommonPatchConfig.displayName

        $asset = Get-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name
        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.DocumentationUri | Should -Be $assetCommonPatchConfig.documentationUri
        $asset.DisplayName | Should -Be $assetCommonPatchConfig.displayName
    }
}
