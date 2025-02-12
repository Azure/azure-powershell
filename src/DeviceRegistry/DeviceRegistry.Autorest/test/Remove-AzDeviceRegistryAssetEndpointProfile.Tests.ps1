if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryAssetEndpointProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryAssetEndpointProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryAssetEndpointProfile' {
    It 'Delete' {
        $aepTestParams = $env.assetEndpointProfileTests.deleteTests.Delete
        $jsonFilePath = (Join-Path $PSScriptRoot $aepTestParams.jsonFilePath)

        $assetEndpointProfile = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        Remove-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup
        { Get-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $aepTestParams = $env.assetEndpointProfileTests.deleteTests.DeleteViaIdentity
        $jsonFilePath = (Join-Path $PSScriptRoot $aepTestParams.jsonFilePath)

        $assetEndpointProfile = New-AzDeviceRegistryAssetEndpointProfile -Name $aepTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        Remove-AzDeviceRegistryAssetEndpointProfile -InputObject $assetEndpointProfile
        { Get-AzDeviceRegistryAssetEndpointProfile -InputObject $assetEndpointProfile -ErrorAction Stop } | Should -Throw
    }
}
