if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkFabricNetworkToNetworkInterconnectNpbStaticRouteBfdAdministrativeState'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkFabricNetworkToNetworkInterconnectNpbStaticRouteBfdAdministrativeState.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkFabricNetworkToNetworkInterconnectNpbStaticRouteBfdAdministrativeState' {
    It 'UpdateExpanded' {
        {
            Update-AzNetworkFabricNetworkToNetworkInterconnectNpbStaticRouteBfdAdministrativeState -NetworkFabricName $global:config.fabric.name -NetworkToNetworkInterconnectName $global:config.nni.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityNetworkFabricExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityNetworkFabric' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
