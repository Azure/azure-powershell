if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkFabricNeighborGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkFabricNeighborGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkFabricNeighborGroup' {
    It 'Update' {
        {
            $destination = @{
                Ipv4Address = @(
                    "10.11.10.11"
                )
                Ipv6Address = @(
                    "2FF::/101"
                )
            }

            Update-AzNetworkFabricNeighborGroup -SubscriptionId $global:config.common.subscriptionId -Name $global:config.neighborGroup.name -ResourceGroupName $global:config.common.resourceGroupName -Destination $destination

        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
