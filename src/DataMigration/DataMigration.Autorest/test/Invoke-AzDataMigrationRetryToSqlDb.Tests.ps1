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
    
    It 'Retry' -skip{
        $srcPassword   = ConvertTo-SecureString $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionPassword -AsPlainText -Force
        $tgtPassword   = ConvertTo-SecureString $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlDb `
        -ResourceGroupName $env.TestRetryDatabaseMigrationDb.ResourceGroupName `
        -SqlDbInstanceName $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName `
        -Kind $env.TestRetryDatabaseMigrationDb.Kind `
        -TargetDbName $env.TestRetryDatabaseMigrationDb.TargetDbName `
        -MigrationService $env.TestRetryDatabaseMigrationDb.MigrationService `
        -Scope $env.TestRetryDatabaseMigrationDb.Scope `
        -SourceDatabaseName $env.TestRetryDatabaseMigrationDb.SourceDatabaseName `
        -SourceSqlConnectionDataSource $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionDataSource `
        -SourceSqlConnectionUserName $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionUserName `
        -SourceSqlConnectionAuthentication $env.TestRetryDatabaseMigrationDb.SourceSqlConnectionAuthentication `
        -SourceSqlConnectionPassword $srcPassword `
        -TargetSqlConnectionDataSource $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionDataSource `
        -TargetSqlConnectionUserName $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionUserName `
        -TargetSqlConnectionAuthentication $env.TestRetryDatabaseMigrationDb.TargetSqlConnectionAuthentication `
        -TargetSqlConnectionPassword $tgtPassword `
        -TableList "[dbo].[Departments]", "[dbo].[Employees]"
     
        $details =  Get-AzDataMigrationToSqlDB -SqlDbInstanceName $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName -ResourceGroupName $env.TestRetryDatabaseMigrationDb.ResourceGroupName -TargetDbName $env.TestRetryDatabaseMigrationDb.TargetDbName
        Start-TestSleep -Seconds 5

        # Invoke Retry
        $retryResult = Invoke-AzDataMigrationRetryToSqlDb `
            -ResourceGroupName $env.TestRetryDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName `
            -TargetDbName $env.TestRetryDatabaseMigrationDb.TargetDbName `
            -MigrationoperationId $details.MigrationOperationId

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
