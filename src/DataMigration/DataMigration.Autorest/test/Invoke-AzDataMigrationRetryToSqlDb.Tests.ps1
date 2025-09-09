if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDataMigrationRetryToSqlDb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDataMigrationRetryToSqlDb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDataMigrationRetryToSqlDb' {
    
    It 'Retry' {
        $targetPassword = ConvertTo-SecureString $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionPassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionPassword -AsPlainText -Force

        # Create a new migration (could be in failed state later)
        $instance = New-AzDataMigrationToSqlDb `
            -ResourceGroupName $env.TestRetryDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName `
            -MigrationService  $env.TestRetryDatabaseMigrationDb.MigrationService `
            -TargetSqlConnectionAuthentication $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionAuthentication `
            -TargetSqlConnectionDataSource $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionDataSource `
            -TargetSqlConnectionPassword $targetPassword `
            -TargetSqlConnectionUserName $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionUserName `
            -SourceSqlConnectionAuthentication $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionAuthentication `
            -SourceSqlConnectionDataSource $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionDataSource `
            -SourceSqlConnectionUserName $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionUserName `
            -SourceSqlConnectionPassword $sourcePassword `
            -SourceDatabaseName $env.TestRetryDatabaseMigrationDb.SourceDatabaseName `
            -TargetDbName $env.TestRetryDatabaseMigrationDb.TargetDbName `
            -Scope  $env.TestRetryDatabaseMigrationDb.Scope

        Start-TestSleep -Seconds 5

        # Invoke Retry
        $retryResult = Invoke-AzDataMigrationRetryToSqlDb `
            -ResourceGroupName $env.TestRetryDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName `
            -TargetDbName $env.TestRetryDatabaseMigrationDb.TargetDbName

        $retryResult | Should -Not -Be $null
    }

    It 'RetryExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetryViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RetryViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
