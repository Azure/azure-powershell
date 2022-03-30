if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataMigrationDatabaseMigrationsSqlDb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataMigrationDatabaseMigrationsSqlDb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataMigrationDatabaseMigrationsSqlDb' {
    It 'Get'  {
        $instance = Get-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName $env.TestDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestDatabaseMigrationDb.TargetDbName
        $assert = ($instance.Name -eq $env.TestDatabaseMigrationDb.TargetDbName) -AND ($instance.Kind -eq 'SqlDb')
        $assert | Should be $true
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
