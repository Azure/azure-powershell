if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkFabricNetworkBootstrapDeviceConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkFabricNetworkBootstrapDeviceConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkFabricNetworkBootstrapDeviceConfiguration' {
    It 'Refresh' {
        {
            Update-AzNetworkFabricNetworkBootstrapDeviceConfiguration -NetworkBootstrapDeviceName $global:config.networkBootstrapDevice.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'RefreshViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
