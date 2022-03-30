if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzDataMigrationDatabaseMigrationsSqlDb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDataMigrationDatabaseMigrationsSqlDb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzDataMigrationDatabaseMigrationsSqlDb' {
    It 'CancelExpanded' {
        $instance = New-AzDataMigrationDatabaseMigrationSqlDb -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -MigrationService  $env.TestStopDatabaseMigrationDb.MigrationService -TargetSqlConnectionAuthentication $env.TestStopDatabaseMigrationDb.TargetSqlConnectionAuthentication -TargetSqlConnectionDataSource $env.TestStopDatabaseMigrationDb.TargetSqlConnectionDataSource -TargetSqlConnectionPassword $env.TestStopDatabaseMigrationDb.TargetSqlConnectionPassword -TargetSqlConnectionUserName $env.TestStopDatabaseMigrationDb.TargetSqlConnectionUserName -SourceSqlConnectionAuthentication $env.TestStopDatabaseMigrationDb.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestStopDatabaseMigrationDb.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestStopDatabaseMigrationDb.SourceSqlConnectionUsername -SourceSqlConnectionPassword $env.TestStopDatabaseMigrationDb.SourceSqlConnectionPassword -SourceDatabaseName $env.TestStopDatabaseMigrationDb.SourceDatabaseName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName -Scope  $env.TestStopDatabaseMigrationDb.Scope

        Stop-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName -MigrationOperationId $instance.MigrationOperationId

        

        $details = Get-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName

        While($details.MigrationStatus -eq "Canceling")
        {
            $details = Get-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName
            
        }
        $assert = ($details.MigrationStatus -eq "Canceled") 
        $assert | should be $true
    }
}
