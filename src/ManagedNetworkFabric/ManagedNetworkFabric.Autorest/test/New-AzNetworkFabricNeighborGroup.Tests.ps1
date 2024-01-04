if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricNeighborGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricNeighborGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricNeighborGroup' {
    It 'Create' {
        {
            $destination = @{
                Ipv4Address = @(
                    "10.10.10.10"
                )
                Ipv6Address = @(
                    "2F::/100"
                )
            }

            New-AzNetworkFabricNeighborGroup -SubscriptionId $global:config.common.subscriptionId -Name $global:config.neighborGroup.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -Destination $destination

        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
