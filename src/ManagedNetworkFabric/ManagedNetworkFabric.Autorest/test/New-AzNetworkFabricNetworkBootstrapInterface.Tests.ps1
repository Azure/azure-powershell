if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricNetworkBootstrapInterface'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricNetworkBootstrapInterface.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricNetworkBootstrapInterface' {
    It 'CreateExpanded' {
        {
            New-AzNetworkFabricNetworkBootstrapInterface -NetworkBootstrapDeviceName $global:config.networkBootstrapDevice.name -Name $global:config.networkBootstrapInterface.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId -SerialNumber $global:config.networkBootstrapInterface.serialNumber
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityNetworkBootstrapDeviceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityNetworkBootstrapDevice' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
