if(($null -eq $TestName) -or ($TestName -contains 'Get-AzHorizonDbPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzHorizonDbPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzHorizonDbPool' {
    It 'List' {
        $pools = @(Get-AzHorizonDbPool -ResourceGroupName $env.sharedResourceGroup -ClusterName $env.sharedClusterName -SubscriptionId $env.SubscriptionId -ErrorAction Stop)

        $pools.Count | Should -Be 1
        $pools[0].Name | Should -Be $env.sharedPoolName
        $pools[0].ResourceGroupName | Should -Be $env.sharedResourceGroup
    }

    It 'Get' {
        $pool = Get-AzHorizonDbPool -ResourceGroupName $env.sharedResourceGroup -ClusterName $env.sharedClusterName -Name $env.sharedPoolName -SubscriptionId $env.SubscriptionId -ErrorAction Stop

        $pool.Name | Should -Be $env.sharedPoolName
        $pool.ResourceGroupName | Should -Be $env.sharedResourceGroup
        $pool.ComputeModelType | Should -Be 'Provisioned'
        $pool.ComputeModelComputeProcessor | Should -Be 'Intel'
        $pool.ComputeModelComputeGeneration | Should -Be 1
        $pool.NodeCount | Should -Be 1
        $pool.HighAvailabilityMode | Should -Be 'Disabled'
        $pool.State | Should -Be 'Ready'
        $pool.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'GetViaIdentityCluster' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
