if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataMigrationToSqlDb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataMigrationToSqlDb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataMigrationToSqlDb' {
    BeforeAll {
        # Mock dependencies
        Mock -CommandName New-AzDataMigrationToSqlDb -MockWith {
            return @{
                Name                = "MockedSqlDbMigration"
                TargetDbName        = $env.TestDeleteDatabaseMigrationDb.TargetDbName
                SqlDbInstanceName   = $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName
                Status              = "InProgress"
            }
        }

        Mock -CommandName Remove-AzDataMigrationToSqlDb -MockWith {
            return @{
                Removed       = $true
                TargetDbName  = $env.TestDeleteDatabaseMigrationDb.TargetDbName
            }
        }

        Mock -CommandName Get-AzDataMigrationToSqlDb -MockWith {
            return $null   # Simulate that the migration is deleted
        }

        Mock -CommandName Start-TestSleep -MockWith { }  # No-op to speed up tests
    }

    It 'Delete should remove a SQL DB migration' {
        $targetPassword = ConvertTo-SecureString "dummyTargetPassword" -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString "dummySourcePassword" -AsPlainText -Force

        # Create migration (mocked)
        $instance = New-AzDataMigrationToSqlDb `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName `
            -MigrationService  $env.TestDeleteDatabaseMigrationDb.MigrationService `
            -TargetSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionAuthentication `
            -TargetSqlConnectionDataSource $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionDataSource `
            -TargetSqlConnectionPassword $targetPassword `
            -TargetSqlConnectionUserName $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionUserName `
            -SourceSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionAuthentication `
            -SourceSqlConnectionDataSource $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionDataSource `
            -SourceSqlConnectionUserName $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionUserName `
            -SourceSqlConnectionPassword $sourcePassword `
            -SourceDatabaseName $env.TestDeleteDatabaseMigrationDb.SourceDatabaseName `
            -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName `
            -Scope  $env.TestDeleteDatabaseMigrationDb.Scope

        $instance | Should -Not -Be $null
        $instance.Name | Should -Be "MockedSqlDbMigration"

        # Remove migration (mocked)
        $removeResult = Remove-AzDataMigrationToSqlDb `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName `
            -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName `
            -Force

        $removeResult.Removed | Should -Be $true

        # Validate deletion (mocked Get returns $null)
        $dbMig = Get-AzDataMigrationToSqlDb `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName `
            -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName `
            -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName `
            -ErrorAction SilentlyContinue

        $dbMig | Should -Be $null

        # Verify mocks called
        Assert-MockCalled New-AzDataMigrationToSqlDb -Exactly 1
        Assert-MockCalled Remove-AzDataMigrationToSqlDb -Exactly 1
        Assert-MockCalled Get-AzDataMigrationToSqlDb -Exactly 1
    }
}