if(($null -eq $TestName) -or ($TestName -contains 'Start-AzAksCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzAksCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzAksCluster' {
    It 'Start' {
        Stop-AzAksCluster -ResourceGroupName $env.ResourceGroupName -Name $env.AksName
        Start-AzAksCluster -ResourceGroupName $env.ResourceGroupName -Name $env.AksName
    }

    It 'StartViaIdentity' {
        $aks = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)" }
        $aks | Stop-AzAksCluster
        $aks | Start-AzAksCluster
    }
}
