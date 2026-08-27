if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDocumentDbPromoteMongoCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDocumentDbPromoteMongoCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDocumentDBPromoteMongoCluster' {
    BeforeAll {
        $rg = $env.promoteRg
        $cluster = $env.promoteCluster
        $replica = $env.promoteReplica
        $loc = $env.location
        $replicaLoc = $env.replicaLocation
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
        # A source cluster and a cross-region replica are the starting topology.
        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc | Out-Null
        New-AzDocumentDBReplica -Name $replica -ResourceGroupName $rg -Location $replicaLoc -SourceCluster $cluster | Out-Null
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'rejects a source cluster that does not match the replica source' {
        # The guard rejects a mismatched -SourceCluster before any switchover is attempted.
        { Invoke-AzDocumentDBPromoteMongoCluster -Name $replica -ResourceGroupName $rg `
            -SourceCluster 'wrong-source-cluster' -Mode Switchover -PromoteOption Forced } | Should -Throw
    }

    It 'promotes a replica to primary with a forced switchover' {
        # Promote the replica to primary. The former replica settles into the primary role.
        { Invoke-AzDocumentDBPromoteMongoCluster -Name $replica -ResourceGroupName $rg `
            -SourceCluster $cluster -Mode Switchover -PromoteOption Forced } | Should -Not -Throw

        $promoted = Get-AzDocumentDBMongoCluster -Name $replica -ResourceGroupName $rg
        $promoted.ProvisioningState | Should -Be 'Succeeded'
        $promoted.ReplicaRole | Should -Be 'Primary'
    }
}
