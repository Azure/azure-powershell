if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksArcNodepool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksArcNodepool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksArcNodepool' {
    It 'List' {
        $nodepool = Get-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $nodepool | Should -Not -BeNullOrEmpty
        $nodepool.Count | Should -be 1
        $nodepool[0].StatusCurrentState | Should -be "Succeeded"
        $nodepool[0].Type | Should -be "microsoft.hybridcontainerservice/provisionedclusterinstances/agentpools"
    }

    It 'Get' {
        $nodepool = Get-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID `
            -Name "nodepool1" # Default name of node pool for New-AzAksArcCluster.
        $nodepool | Should -Not -BeNullOrEmpty
        $nodepool[0].StatusCurrentState | Should -be "Succeeded"
        $nodepool[0].Type | Should -be "microsoft.hybridcontainerservice/provisionedclusterinstances/agentpools"
    }
}
