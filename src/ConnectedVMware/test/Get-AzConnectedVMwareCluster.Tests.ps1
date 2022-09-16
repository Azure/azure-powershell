if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedVMwareCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedVMwareCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedVMwareCluster' {
    It 'List' {
        $clusters = Get-AzConnectedVMwareCluster
        $clusters.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $cluster = Get-AzConnectedVMwareCluster -ResourceGroupName $env.ResourceGroupName -Name $env.clusterName
        $cluster.Name | Should -Be $env.clusterName
    }

    It 'List1' {
        $clusters = Get-AzConnectedVMwareCluster -ResourceGroupName $env.ResourceGroupName
        $clusters.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $cluster1 = Get-AzConnectedVMwareCluster -ResourceGroupName $env.ResourceGroupName -Name $env.clusterName
        $cluster2 = Get-AzConnectedVMwareCluster -InputObject $cluster1
        $cluster2.Name | Should -Be $env.clusterName
    }
}
