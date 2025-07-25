if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzKustoClusterMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoClusterMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzKustoClusterMigration' {
    It 'MigrateExpanded' -skip {
        # TODO this test is skip due to a temp error in kusto backend side, the request is sent correctly, renable once the issue is fixed 
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoMigrationClusterName
        $targetClusterResourceId = $env.kustoClusterResourceId

        Invoke-AzKustoClusterMigration -Name $clusterName -ResourceGroupName $resourceGroupName -ClusterResourceId $targetClusterResourceId 
    }

    It 'Migrate' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MigrateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MigrateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
