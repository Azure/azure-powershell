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
    It 'Delete' -skip{
        $srcPassword   = ConvertTo-SecureString $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionPassword -AsPlainText -Force
        $tgtPassword   = ConvertTo-SecureString $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlDb `
        -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName `
        -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName `
        -Kind $env.TestDeleteDatabaseMigrationDb.Kind `
        -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName `
        -MigrationService $env.TestDeleteDatabaseMigrationDb.MigrationService `
        -Scope $env.TestDeleteDatabaseMigrationDb.Scope `
        -SourceDatabaseName $env.TestDeleteDatabaseMigrationDb.SourceDatabaseName `
        -SourceSqlConnectionDataSource $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionDataSource `
        -SourceSqlConnectionUserName $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionUserName `
        -SourceSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionAuthentication `
        -SourceSqlConnectionPassword $srcPassword `
        -TargetSqlConnectionDataSource $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionDataSource `
        -TargetSqlConnectionUserName $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionUserName `
        -TargetSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionAuthentication `
        -TargetSqlConnectionPassword $tgtPassword `
        -TableList "[dbo].[Departments]", "[dbo].[Employees]"

        Start-TestSleep -Seconds 5

        Remove-AzDataMigrationToSqlDb -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName -Force

        Start-TestSleep -Seconds 5

        $dbMig = Get-AzDataMigrationToSqlDb -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName -ErrorAction SilentlyContinue

        $assert =  ($dbMig.MigrationStatus -eq "Dropping")
        $assert | Should be $true

    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
