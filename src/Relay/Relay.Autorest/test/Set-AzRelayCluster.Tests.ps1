if(($null -eq $TestName) -or ($TestName -contains 'Set-AzRelayCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzRelayCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzRelayCluster' {
    BeforeAll {
        $clusterName = 'RelayClusterTestE2E2026'
        $resourceGroupName = 'PPGTest'
    }

    It 'SetExpanded' {
        $tag = @{ dadasdadaddadassas = 'dasdxaxadasdczx' }
        $cluster = Set-AzRelayCluster -Name $clusterName -ResourceGroupName $resourceGroupName -Tag $tag
        $cluster | Should -Not -BeNullOrEmpty
        $cluster.Name | Should -Be $clusterName
        $cluster.ResourceGroupName | Should -Be $resourceGroupName
        $cluster.Type | Should -Be 'microsoft.relay/clusters'
        $cluster.SkuName | Should -Be 'Dedicated'
        $cluster.ProvisioningState | Should -Be 'Succeeded'
        $cluster.Status | Should -Be 'Active'
        $cluster.ZoneRedundant | Should -Be $true
        $cluster.Tag['dadasdadaddadassas'] | Should -Be 'dasdxaxadasdczx'

        $updated = Get-AzRelayCluster -Name $clusterName -ResourceGroupName $resourceGroupName
        $updated.Tag['dadasdadaddadassas'] | Should -Be 'dasdxaxadasdczx'
    }

    It 'SetViaIdentityExpanded' {
        $cluster = Get-AzRelayCluster -Name $clusterName -ResourceGroupName $resourceGroupName
        $tag = @{ env = 'prod'; team = 'messaging' }
        $result = Set-AzRelayCluster -InputObject $cluster -Tag $tag
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $clusterName
        $result.Tag['env'] | Should -Be 'prod'
        $result.Tag['team'] | Should -Be 'messaging'
    }
}
