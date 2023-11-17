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
        $nodepoolId = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/aks-test/providers/Microsoft.ContainerService/managedClusters/aks/agentPools/default"
        $Snapshot = New-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1' -Location $env.location -SnapshotType 'NodePool' -CreationDataSourceResourceId $nodepoolId
        Remove-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1'
    }

    It 'DeleteViaIdentity' {
         $nodepoolId = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/aks-test/providers/Microsoft.ContainerService/managedClusters/aks/agentPools/default"
        $Snapshot = New-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1' -Location $env.location -SnapshotType 'NodePool' -CreationDataSourceResourceId $nodepoolId
        Remove-AzAksSnapshot -InputObject $Snapshot
    }
}
