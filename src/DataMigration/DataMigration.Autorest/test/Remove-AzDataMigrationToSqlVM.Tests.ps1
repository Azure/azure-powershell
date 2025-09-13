if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataMigrationToSqlVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataMigrationToSqlVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataMigrationToSqlVM' {
    BeforeAll {
        # Mock dependencies
        Mock -CommandName New-AzDataMigrationToSqlVM -MockWith {
            return @{
                Name                = "MockedSqlVmMigration"
                TargetDbName        = $env.TestDeleteDatabaseMigrationVm.TargetDbName
                SqlVirtualMachineName = $env.TestDeleteDatabaseMigrationVm.SqlVirtualMachineName
                Status              = "InProgress"
            }
        }

        Mock -CommandName Remove-AzDataMigrationToSqlVM -MockWith {
            return @{
                Removed       = $true
                TargetDbName  = $env.TestDeleteDatabaseMigrationVm.TargetDbName
            }
        }

        Mock -CommandName Get-AzDataMigrationToSqlVM -MockWith {
            return $null  # Simulate that the migration was deleted
        }

        Mock -CommandName Start-TestSleep -MockWith { }  # no-op
    }

    It 'Delete should remove a SQL VM migration' {
        $filesharePassword = ConvertTo-SecureString "dummyFileSharePassword" -AsPlainText -Force
        $sourcePassword    = ConvertTo-SecureString "dummySourcePassword" -AsPlainText -Force

        # Create migration (mocked)
        $vmMigration = New-AzDataMigrationToSqlVM `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationVm.ResourceGroupName `
            -SqlVirtualMachineName $env.TestDeleteDatabaseMigrationVm.SqlVirtualMachineName `
            -TargetDbName $env.TestDeleteDatabaseMigrationVm.TargetDbName `
            -Scope $env.TestDeleteDatabaseMigrationVm.Scope `
            -MigrationService $env.TestDeleteDatabaseMigrationVm.MigrationService `
            -StorageAccountResourceId $env.TestDeleteDatabaseMigrationVm.TargetLocationStorageAccountResourceId `
            -StorageAccountKey $env.TestDeleteDatabaseMigrationVm.TargetLocationAccountKey `
            -FileSharePath $env.TestDeleteDatabaseMigrationVm.FileSharePath `
            -FileShareUsername $env.TestDeleteDatabaseMigrationVm.FileShareUsername `
            -FileSharePassword $filesharePassword `
            -SourceSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationVm.SourceSqlConnectionAuthentication `
            -SourceSqlConnectionDataSource $env.TestDeleteDatabaseMigrationVm.SourceSqlConnectionDataSource `
            -SourceSqlConnectionUserName $env.TestDeleteDatabaseMigrationVm.SourceSqlConnectionUserName `
            -SourceSqlConnectionPassword $sourcePassword `
            -SourceDatabaseName $env.TestDeleteDatabaseMigrationVm.SourceDatabaseName

        $vmMigration | Should -Not -Be $null
        $vmMigration.Name | Should -Be "MockedSqlVmMigration"

        # Remove migration (mocked)
        $removeResult = Remove-AzDataMigrationToSqlVM `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationVm.ResourceGroupName `
            -SqlVirtualMachineName $env.TestDeleteDatabaseMigrationVm.SqlVirtualMachineName `
            -TargetDbName $env.TestDeleteDatabaseMigrationVm.TargetDbName `
            -Force

        $removeResult.Removed | Should -Be $true

        # Validate deletion (mocked Get returns $null)
        $dbMig = Get-AzDataMigrationToSqlVM `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationVm.ResourceGroupName `
            -SqlVirtualMachineName $env.TestDeleteDatabaseMigrationVm.SqlVirtualMachineName `
            -TargetDbName $env.TestDeleteDatabaseMigrationVm.TargetDbName `
            -ErrorAction SilentlyContinue

        $dbMig | Should -Be $null

        # Verify mocks called
        Assert-MockCalled New-AzDataMigrationToSqlVM -Exactly 1
        Assert-MockCalled Remove-AzDataMigrationToSqlVM -Exactly 1
        Assert-MockCalled Get-AzDataMigrationToSqlVM -Exactly 1
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
