if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryAsset' {
    It 'List' {
        $assetTestParams = $env.assetTests.getTests.List
        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name1 -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name2 -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef

        $listOfAssets = Get-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup

        # The resource group should contain at least 2 assets
        $listOfAssets.Count -ge 2 | Should -Be $true
    }

    It 'Get' {
        $assetTestParams = $env.assetTests.getTests.Get
        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        $asset = Get-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name
        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.EndpointProfileRef | Should -Be $env.assetTests.assetEndpointProfileRef
    }

    It 'GetViaIdentity' {
        $assetTestParams = $env.assetTests.getTests.GetViaIdentity
        $assetIdentity = New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        $asset = Get-AzDeviceRegistryAsset -InputObject $assetIdentity
        $asset.Name | Should -Be $assetTestParams.name
        $asset.ResourceGroupName | Should -Be $env.resourceGroup
        $asset.ExtendedLocationName | Should -Be $env.extendedLocationName
        $asset.ExtendedLocationType | Should -Be $env.extendedLocationType
        $asset.Location | Should -Be $env.location
        $asset.EndpointProfileRef | Should -Be $env.assetTests.assetEndpointProfileRef
    }
}
