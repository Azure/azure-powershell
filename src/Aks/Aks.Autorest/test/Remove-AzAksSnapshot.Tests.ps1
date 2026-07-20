if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAksSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAksSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAksSnapshot' {
    It 'Delete' {
        $nodepoolId = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/agentPools/default"
        $Snapshot = New-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1' -Location $env.location -SnapshotType 'NodePool' -CreationDataSourceResourceId $nodepoolId
        Remove-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1'
    }

    It 'DeleteViaIdentity' {
         $nodepoolId = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/agentPools/default"
        $Snapshot = New-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1' -Location $env.location -SnapshotType 'NodePool' -CreationDataSourceResourceId $nodepoolId
        Remove-AzAksSnapshot -InputObject $Snapshot
    }
}
