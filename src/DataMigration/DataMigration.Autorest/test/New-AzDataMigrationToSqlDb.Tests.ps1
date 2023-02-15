if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataMigrationToSqlDb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataMigrationToSqlDb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataMigrationToSqlDb' {
    It 'CreateExpanded' -skip {
        $targetPassword = ConvertTo-SecureString $env.TestNewDatabaseMigrationDb.TargetSqlConnectionPassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestNewDatabaseMigrationDb.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlDb -ResourceGroupName $env.TestNewDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestNewDatabaseMigrationDb.SqlDbInstanceName -MigrationService  $env.TestNewDatabaseMigrationDb.MigrationService -TargetSqlConnectionAuthentication $env.TestNewDatabaseMigrationDb.TargetSqlConnectionAuthentication -TargetSqlConnectionDataSource $env.TestNewDatabaseMigrationDb.TargetSqlConnectionDataSource -TargetSqlConnectionPassword $targetPassword -TargetSqlConnectionUserName $env.TestNewDatabaseMigrationDb.TargetSqlConnectionUserName -SourceSqlConnectionAuthentication $env.TestNewDatabaseMigrationDb.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestNewDatabaseMigrationDb.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestNewDatabaseMigrationDb.SourceSqlConnectionUserName -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestNewDatabaseMigrationDb.SourceDatabaseName -TargetDbName $env.TestNewDatabaseMigrationDb.TargetDbName -Scope  $env.TestNewDatabaseMigrationDb.Scope
        
        $assert = ($instance.Type -eq "Microsoft.DataMigration/databaseMigrations") -AND ($instance.Name -eq $env.TestNewDatabaseMigrationDb.TargetDbName) -AND ($instance.ProvisioningState -eq "Succeeded") -AND ($instance.Kind -eq "SqlDb")
        $assert | should be $true
    }
}
