if(($null -eq $TestName) -or ($TestName -contains 'New-AzDocumentDBReplica'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDocumentDBReplica.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDocumentDBReplica' {
    BeforeAll {
        $rg = $env.replicaRg
        $cluster = $env.replicaCluster
        $replica = $env.replicaName
        $loc = $env.location
        $replicaLoc = $env.replicaLocation
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc | Out-Null
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'Replica create/list' {
        # Create a cross-region read replica. A replica inherits the source configuration
        # and admin credentials, so no password is passed here.
        $created = New-AzDocumentDBReplica -Name $replica -ResourceGroupName $rg -Location $replicaLoc -SourceCluster $cluster
        $created.Name | Should -Be $replica
        $created.ProvisioningState | Should -Be 'Succeeded'
        $created.ReplicaRole | Should -Be 'GeoAsyncReplica'

        # The replica shows up in the source cluster's replica listing.
        @(Get-AzDocumentDBReplica -MongoClusterName $cluster -ResourceGroupName $rg | Where-Object { $_.Name -eq $replica }).Count | Should -Be 1

        # Delete the replica.
        { Remove-AzDocumentDBMongoCluster -Name $replica -ResourceGroupName $rg } | Should -Not -Throw
    }
}
