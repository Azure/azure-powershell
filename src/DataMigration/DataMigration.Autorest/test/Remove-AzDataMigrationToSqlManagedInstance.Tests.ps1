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

Describe 'Remove-AzDataMigrationToSqlManagedInstance' {
    It 'Delete' -skip{
        $sourcePassword = ConvertTo-SecureString $env.TestDeleteMiMigration.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlManagedInstance `
        -ResourceGroupName $env.TestDeleteMiMigration.ResourceGroupName `
        -ManagedInstanceName $env.TestDeleteMiMigration.ManagedInstanceName `
        -TargetDbName $env.TestDeleteMiMigration.TargetDbName `
        -Kind  $env.TestDeleteMiMigration.Kind `
        -Scope $env.TestDeleteMiMigration.Scope `
        -MigrationService $env.TestDeleteMiMigration.MigrationService `
        -AzureBlobStorageAccountResourceId $env.TestDeleteMiMigration.AzureBlobStorageAccountResourceId `
        -AzureBlobAccountKey $env.TestDeleteMiMigration.AzureBlobAccountKey `
        -AzureBlobContainerName $env.TestDeleteMiMigration.AzureBlobContainerName `
        -SourceSqlConnectionAuthentication $env.TestDeleteMiMigration.SourceSqlConnectionAuthentication `
        -SourceSqlConnectionDataSource $env.TestDeleteMiMigration.SourceSqlConnectionDataSource `
        -SourceSqlConnectionUserName $env.TestDeleteMiMigration.SourceSqlConnectionUserName `
        -SourceSqlConnectionPassword $sourcePassword `
        -SourceDatabaseName "CompanyDB8"

        Start-TestSleep -Seconds 5

        Remove-AzDataMigrationToSqlManagedInstance `
            -ResourceGroupName $env.TestDeleteMiMigration.ResourceGroupName `
            -ManagedInstanceName $env.TestDeleteMiMigration.ManagedInstanceName `
            -TargetDbName $env.TestDeleteMiMigration.TargetDbName `
            -Force

        Start-TestSleep -Seconds 5

        # Validate deletion
        $dbMig = Get-AzDataMigrationToSqlManagedInstance `
            -ResourceGroupName $env.TestDeleteMiMigration.ResourceGroupName `
            -ManagedInstanceName $env.TestDeleteMiMigration.ManagedInstanceName `
            -TargetDbName $env.TestDeleteMiMigration.TargetDbName `
            -ErrorAction SilentlyContinue

        #$assert = ($dbMig -eq $null)
        #$assert | Should -Be $false
        $assert =  ($dbMig.MigrationStatus -eq "Dropping")
        $assert | Should -Be $true
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
