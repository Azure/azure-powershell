if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRelayCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRelayCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRelayCluster' {
    BeforeAll {
        $clusterName = 'RelayClusterTestE2E2026'
        $resourceGroupName = 'PPGTest'
    }

    It 'Get' {
        $cluster = Get-AzRelayCluster -Name $clusterName -ResourceGroupName $resourceGroupName
        $cluster | Should -Not -BeNullOrEmpty
        $cluster.Name | Should -Be $clusterName
        $cluster.ResourceGroupName | Should -Be $resourceGroupName
        $cluster.Type | Should -Be 'microsoft.relay/clusters'
        $cluster.SkuName | Should -Be 'Dedicated'
        $cluster.ProvisioningState | Should -Be 'Succeeded'
        $cluster.Status | Should -Be 'Active'
        $cluster.ZoneRedundant | Should -Be $true
    }

    It 'List' {
        $clusters = Get-AzRelayCluster -ResourceGroupName $resourceGroupName
        $clusters | Should -Not -BeNullOrEmpty
        ($clusters | Where-Object { $_.Name -eq $clusterName }) | Should -Not -BeNullOrEmpty
    }

    It 'List1' {
        $clusters = Get-AzRelayCluster
        $clusters | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' {
        $cluster = Get-AzRelayCluster -Name $clusterName -ResourceGroupName $resourceGroupName
        $result = Get-AzRelayCluster -InputObject $cluster
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $clusterName
    }
}
