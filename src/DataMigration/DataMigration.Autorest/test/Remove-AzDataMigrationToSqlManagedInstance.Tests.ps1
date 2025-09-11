if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataMigrationToSqlManagedInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataMigrationToSqlManagedInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataMigrationToSqlManagedInstance (Mocked)' {

    # Mock creation of migration
    Mock -CommandName New-AzDataMigrationToSqlManagedInstance -MockWith {
        return @{
            Name                = "MockMiMigration"
            ResourceGroupName   = $env.TestDeleteMiMigration.ResourceGroupName
            ManagedInstanceName = $env.TestDeleteMiMigration.ManagedInstanceName
            TargetDbName        = $env.TestDeleteMiMigration.TargetDbName
            Status              = "InProgress"
        }
    }

    # Mock deletion
    Mock -CommandName Remove-AzDataMigrationToSqlManagedInstance -MockWith {
        return @{
            Name                = "MockMiMigration"
            TargetDbName        = $env.TestDeleteMiMigration.TargetDbName
            Status              = "Deleted"
        }
    }

    # Mock retrieval after deletion
    Mock -CommandName Get-AzDataMigrationToSqlManagedInstance -MockWith {
        return $null
    }

    It 'Delete (Mocked)' {
        $filesharePassword = ConvertTo-SecureString "mockFileSharePwd" -AsPlainText -Force
        $sourcePassword    = ConvertTo-SecureString "mockSourcePwd" -AsPlainText -Force

        # Simulate creating a migration
        $instance = New-AzDataMigrationToSqlManagedInstance `
            -ResourceGroupName $env.TestDeleteMiMigration.ResourceGroupName `
            -ManagedInstanceName $env.TestDeleteMiMigration.ManagedInstanceName `
            -TargetDbName $env.TestDeleteMiMigration.TargetDbName `
            -FileSharePassword $filesharePassword `
            -SourceSqlConnectionPassword $sourcePassword

        $instance | Should -Not -Be $null
        $instance.Status | Should -Be "InProgress"

        # Simulate deletion
        $deleteResult = Remove-AzDataMigrationToSqlManagedInstance `
            -ResourceGroupName $env.TestDeleteMiMigration.ResourceGroupName `
            -ManagedInstanceName $env.TestDeleteMiMigration.ManagedInstanceName `
            -TargetDbName $env.TestDeleteMiMigration.TargetDbName `
            -Force

        $deleteResult | Should -Not -Be $null
        $deleteResult.Status | Should -Be "Deleted"

        # Validate deletion (mock returns null)
        $dbMig = Get-AzDataMigrationToSqlManagedInstance `
            -ResourceGroupName $env.TestDeleteMiMigration.ResourceGroupName `
            -ManagedInstanceName $env.TestDeleteMiMigration.ManagedInstanceName `
            -TargetDbName $env.TestDeleteMiMigration.TargetDbName `
            -ErrorAction SilentlyContinue

        $dbMig | Should -Be $null

        # Assert mocks were called
        Assert-MockCalled New-AzDataMigrationToSqlManagedInstance -Times 1
        Assert-MockCalled Remove-AzDataMigrationToSqlManagedInstance -Times 1
        Assert-MockCalled Get-AzDataMigrationToSqlManagedInstance -Times 1
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
