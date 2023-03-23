if(($null -eq $TestName) -or ($TestName -contains 'Test-AzKustoAttachedDatabaseConfigurationNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoAttachedDatabaseConfigurationNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzKustoAttachedDatabaseConfigurationNameAvailability' {
    It 'CheckExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr5
        
        $AttachedDatabaseConfigurationNameAvailability = Test-AzKustoAttachedDatabaseConfigurationNameAvailability -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $AttachedDatabaseConfigurationNameAvailability.Name | Should -Be $databaseName
        $AttachedDatabaseConfigurationNameAvailability.NameAvailable | Should -Be $true
    }

    It 'CheckViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
