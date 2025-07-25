if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubClusterNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubClusterNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubClusterNamespace' {
    It 'List'  {
        $listOfNamespaces = Get-AzEventHubClusterNamespace -SubscriptionId $env.clusterSubscriptionId -ResourceGroupName $env.clusterResourceGroup -ClusterName $env.createdCluster
        $listOfNamespaces.Count | Should -Be 2
    }
}
