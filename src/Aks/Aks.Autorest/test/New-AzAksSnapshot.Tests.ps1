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
        $nodepoolId = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/aks-test/providers/Microsoft.ContainerService/managedClusters/aks/agentPools/default"
        $Snapshot = New-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1' -Location $env.location -SnapshotType 'NodePool' -CreationDataSourceResourceId $nodepoolId
        
        $Snapshot.CreationDataSourceResourceId | Should -Be $nodepoolId
        $Snapshot.KubernetesVersion | Should -Be '1.24.9'
        $Snapshot.Location | Should -Be $env.location
        $Snapshot.Name | Should -Be 'snapshot1'
        $Snapshot.NodeImageVersion | Should -Be 'AKSUbuntu-1804containerd-202303.13.0'
        $Snapshot.OSSku | Should -Be 'Ubuntu'
        $Snapshot.OSType | Should -Be 'Linux'
        $Snapshot.SnapshotType | Should -Be 'NodePool'
        $Snapshot.SystemDataCreatedByType | Should -Be 'User'
        $Snapshot.SystemDataLastModifiedByType | Should -Be 'User'
        $Snapshot.VMSize | Should -Be 'Standard_D2_v2'

        Remove-AzAksSnapshot -InputObject $Snapshot
    }
}
