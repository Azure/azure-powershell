if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkFabricResyncNeighborGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkFabricResyncNeighborGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkFabricResyncNeighborGroup' {
    It 'Resync' {
        {
            Invoke-AzNetworkFabricResyncNeighborGroup -NeighborGroupName $global:config.neighborGroup.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'ResyncViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
