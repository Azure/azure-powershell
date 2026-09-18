if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricNetworkBootstrapDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricNetworkBootstrapDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricNetworkBootstrapDevice' {
    It 'CreateExpanded' {
        {
            New-AzNetworkFabricNetworkBootstrapDevice -Name $global:config.networkBootstrapDevice.name -Location $global:config.common.location -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId -SerialNumber $global:config.networkBootstrapDevice.serialNumber -NetworkDeviceSku $global:config.networkBootstrapDevice.networkDeviceSku -HostName $global:config.networkBootstrapDevice.hostName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
