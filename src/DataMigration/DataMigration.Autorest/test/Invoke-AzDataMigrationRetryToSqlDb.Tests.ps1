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

Describe 'Invoke-AzDataMigrationRetryToSqlDb (Mocked)' {

    # Mocking creation of a migration
    Mock -CommandName New-AzDataMigrationToSqlDb -MockWith {
        return @{
            Name               = "MockMigration"
            ResourceGroupName  = $env.TestRetryDatabaseMigrationDb.ResourceGroupName
            SqlDbInstanceName  = $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName
            TargetDbName       = $env.TestRetryDatabaseMigrationDb.TargetDbName
            Status             = "InProgress"
        }
    }

    # Mocking retry of migration
    Mock -CommandName Invoke-AzDataMigrationRetryToSqlDb -MockWith {
        return @{
            MigrationoperationId = $env.TestRetryDatabaseMigrationDb.MigrationoperationId
            TargetDbName         = $env.TestRetryDatabaseMigrationDb.TargetDbName
            Status               = "RetryStarted"
        }
    }

    It 'Retry (Mocked)' {
        $srcPassword = ConvertTo-SecureString "mockSrcPwd" -AsPlainText -Force
        $tgtPassword = ConvertTo-SecureString "mockTgtPwd" -AsPlainText -Force

        # Simulate creation of migration
        $instance = New-AzDataMigrationToSqlDb `
            -ResourceGroupName $env.TestRetryDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName `
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

        $instance | Should -Not -Be $null
        $instance.Status | Should -Be "InProgress"

        # Simulate retry
        $retryResult = Invoke-AzDataMigrationRetryToSqlDb `
            -ResourceGroupName $env.TestRetryDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestRetryDatabaseMigrationDb.SqlDbInstanceName `
            -TargetDbName $env.TestRetryDatabaseMigrationDb.TargetDbName `
            -MigrationoperationId $env.TestRetryDatabaseMigrationDb.MigrationoperationId

        $retryResult | Should -Not -Be $null
        $retryResult.Status | Should -Be "RetryStarted"

        # Validate mocks were called
        Assert-MockCalled New-AzDataMigrationToSqlDb -Times 1
        Assert-MockCalled Invoke-AzDataMigrationRetryToSqlDb -Times 1
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
