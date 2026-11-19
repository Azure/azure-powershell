if(($null -eq $TestName) -or ($TestName -contains 'Get-AzHorizonDbNode'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzHorizonDbNode.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzHorizonDbNode' {
    It 'List' {
        $nodes = @(Get-AzHorizonDbNode -ResourceGroupName $env.sharedResourceGroup -ClusterName $env.sharedClusterName -PoolName $env.sharedPoolName -SubscriptionId $env.SubscriptionId -ErrorAction Stop)

        $nodes.Count | Should -Be 1
        $nodes[0].Name | Should -Be $env.sharedNodeName
        $nodes[0].Id | Should -Be $env.sharedNodeId
        $nodes[0].ResourceGroupName | Should -Be $env.sharedResourceGroup
        $nodes[0].Role | Should -Be 'ReadWrite'
    }

    It 'Get' {
        $node = Get-AzHorizonDbNode -ResourceGroupName $env.sharedResourceGroup -ClusterName $env.sharedClusterName -PoolName $env.sharedPoolName -Name $env.sharedNodeName -SubscriptionId $env.SubscriptionId -ErrorAction Stop

        $node.Name | Should -Be $env.sharedNodeName
        $node.Id | Should -Be $env.sharedNodeId
        $node.ResourceGroupName | Should -Be $env.sharedResourceGroup
        $node.Role | Should -Be 'ReadWrite'
    }

    It 'GetViaIdentityPool' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityCluster' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
