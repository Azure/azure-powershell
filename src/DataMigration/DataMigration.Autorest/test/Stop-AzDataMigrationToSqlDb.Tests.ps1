if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzDataMigrationToSqlDb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDataMigrationToSqlDb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzDataMigrationToSqlDb' {
    It 'CancelExpanded' -skip  {
        $targetPassword = ConvertTo-SecureString $env.TestStopDatabaseMigrationDb.TargetSqlConnectionPassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestStopDatabaseMigrationDb.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlDb -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -MigrationService  $env.TestStopDatabaseMigrationDb.MigrationService -TargetSqlConnectionAuthentication $env.TestStopDatabaseMigrationDb.TargetSqlConnectionAuthentication -TargetSqlConnectionDataSource $env.TestStopDatabaseMigrationDb.TargetSqlConnectionDataSource -TargetSqlConnectionPassword $targetPassword -TargetSqlConnectionUserName $env.TestStopDatabaseMigrationDb.TargetSqlConnectionUserName -SourceSqlConnectionAuthentication $env.TestStopDatabaseMigrationDb.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestStopDatabaseMigrationDb.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestStopDatabaseMigrationDb.SourceSqlConnectionUserName -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestStopDatabaseMigrationDb.SourceDatabaseName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName -Scope  $env.TestStopDatabaseMigrationDb.Scope
        
        $details =  Get-AzDataMigrationToSqlDb -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName

        Stop-AzDataMigrationToSqlDb -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName -MigrationOperationId $details.MigrationOperationId

        $details =  Get-AzDataMigrationToSqlDb -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName
        
        While($details.MigrationStatus -eq "Canceling")
        {
            $details =  Get-AzDataMigrationToSqlDb -SqlDbInstanceName $env.TestStopDatabaseMigrationDb.SqlDbInstanceName -ResourceGroupName $env.TestStopDatabaseMigrationDb.ResourceGroupName -TargetDbName $env.TestStopDatabaseMigrationDb.TargetDbName
            
        }
        $assert = ($details.MigrationStatus -eq "Canceled") 
        $assert | should be $true
    }
}
