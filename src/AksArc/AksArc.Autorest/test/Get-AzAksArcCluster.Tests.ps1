if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksArcCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksArcCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksArcCluster' {
    It 'Get' {
        # Cluster should exist since it was created in utils.ps1.
        $cluster = Get-AzAksArcCluster -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $cluster | Should -Not -BeNullOrEmpty
        $cluster.Type | Should -be "microsoft.hybridcontainerservice/provisionedclusterinstances"
    }
}
