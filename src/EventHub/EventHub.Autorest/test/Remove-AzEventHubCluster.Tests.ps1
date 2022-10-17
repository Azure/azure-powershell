if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHubCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHubCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHubCluster' {
    $cluster = Get-AzEventHubCluster -ResourceGroupName $env.clusterResourceGroup -Name $env.cluster2

    It 'Delete' {
        Remove-AzEventHubCluster -ResourceGroupName $env.clusterResourceGroup -Name $env.cluster2
        { Get-AzEventHubCluster -ResourceGroupName $env.clusterResourceGroup -Name $env.cluster2 } | Should -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { Remove-AzEventHubCluster -InputObject $cluster } | Should -Throw
    }
}
