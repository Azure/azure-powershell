if(($null -eq $TestName) -or ($TestName -contains 'New-AzAksSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAksSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAksSnapshot' {
    It 'CreateExpanded' {
        $nodepoolId = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/agentPools/default"
        $Snapshot = New-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1' -Location $env.location -SnapshotType 'NodePool' -CreationDataSourceResourceId $nodepoolId
        
        $Snapshot.CreationDataSourceResourceId | Should -Be $nodepoolId
        $Snapshot.KubernetesVersion | Should -Be '1.32.7'
        $Snapshot.Location | Should -Be $env.location
        $Snapshot.Name | Should -Be 'snapshot1'
        $Snapshot.NodeImageVersion | Should -Be 'AKSUbuntu-2204containerd-202510.19.1'
        $Snapshot.OSSku | Should -Be 'Ubuntu'
        $Snapshot.OSType | Should -Be 'Linux'
        $Snapshot.SnapshotType | Should -Be 'NodePool'
        $Snapshot.SystemDataCreatedByType | Should -Be 'User'
        $Snapshot.SystemDataLastModifiedByType | Should -Be 'User'
        $Snapshot.VMSize | Should -Be 'standard_a2_v2'

        Remove-AzAksSnapshot -InputObject $Snapshot
    }
}
