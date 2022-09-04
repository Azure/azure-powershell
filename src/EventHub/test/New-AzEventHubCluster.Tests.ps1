if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubCluster' {
    It 'CreateExpanded' -skip {
        # Create Self-Serve Cluster
        $cluster = New-AzEventHubCluster -ResourceGroupName $env.clusterResourceGroup -Name $env.cluster -SupportsScaling -Capacity 2

        $cluster.Name | Should -Be $env.cluster
        $cluster.ResourceGroupName | Should -Be $env.clusterResourceGroup
        $cluster.SupportsScaling | Should -Be $true
        $cluster.Capacity | Should -Be 2
    }
}
