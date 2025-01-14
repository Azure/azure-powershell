if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryAsset' {
    It 'Delete' {
        $assetTestParams = $env.assetTests.deleteTests.Delete
        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        Remove-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name
        { Get-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $assetTestParams = $env.assetTests.deleteTests.DeleteViaIdentity
        $asset = New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $assetTestParams.name -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -Location $env.location -AssetEndpointProfileRef $env.assetTests.assetEndpointProfileRef
        Remove-AzDeviceRegistryAsset -InputObject $asset
        { Get-AzDeviceRegistryAsset -InputObject $asset -ErrorAction Stop } | Should -Throw
    }
}
