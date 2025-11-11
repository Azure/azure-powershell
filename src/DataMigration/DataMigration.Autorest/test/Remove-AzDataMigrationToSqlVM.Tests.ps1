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
    It 'Delete' -skip{
       $sourcePassword = ConvertTo-SecureString $env.TestDeleteDatabaseMigrationVm.SourceSqlConnectionPassword -AsPlainText -Force

        # Create a SQL VM migration
        $vmMigration = New-AzDataMigrationToSqlVM `
        -ResourceGroupName $env.TestDeleteDatabaseMigrationVm.ResourceGroupName `
        -SqlVirtualMachineName $env.TestDeleteDatabaseMigrationVm.SqlVirtualMachineName `
        -TargetDbName $env.TestDeleteDatabaseMigrationVm.TargetDbName `
        -Kind $env.TestDeleteDatabaseMigrationVm.Kind `
        -Scope $env.TestDeleteDatabaseMigrationVm.Scope `
        -MigrationService $env.TestDeleteDatabaseMigrationVm.MigrationService `
        -AzureBlobStorageAccountResourceId $env.TestDeleteDatabaseMigrationVm.AzureBlobStorageAccountResourceId `
        -AzureBlobAccountKey $env.TestDeleteDatabaseMigrationVm.AzureBlobAccountKey `
        -AzureBlobContainerName $env.TestDeleteDatabaseMigrationVm.AzureBlobContainerName `
        -SourceSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationVm.SourceSqlConnectionAuthentication `
        -SourceSqlConnectionDataSource $env.TestDeleteDatabaseMigrationVm.SourceSqlConnectionDataSource `
        -SourceSqlConnectionUserName $env.TestDeleteDatabaseMigrationVm.SourceSqlConnectionUserName `
        -SourceSqlConnectionPassword $sourcePassword `
        -SourceDatabaseName $env.TestDeleteDatabaseMigrationVm.SourceDatabaseName

        Start-TestSleep -Seconds 5

        # Delete the SQL VM migration
        Remove-AzDataMigrationToSqlVM `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationVm.ResourceGroupName `
            -SqlVirtualMachineName $env.TestDeleteDatabaseMigrationVm.SqlVirtualMachineName `
            -TargetDbName $env.TestDeleteDatabaseMigrationVm.TargetDbName `
            -Force

        Start-TestSleep -Seconds 5

        # Validate deletion
        $dbMig = Get-AzDataMigrationToSqlVM `
            -ResourceGroupName $env.TestDeleteDatabaseMigrationVm.ResourceGroupName `
            -SqlVirtualMachineName $env.TestDeleteDatabaseMigrationVm.SqlVirtualMachineName `
            -TargetDbName $env.TestDeleteDatabaseMigrationVm.TargetDbName `
            -ErrorAction SilentlyContinue

        $assert =  ($dbMig.MigrationStatus -eq "Delete")
        $assert | Should -Be $true
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
