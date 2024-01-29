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
    It 'Delete' {
        $targetPassword = ConvertTo-SecureString $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionPassword -AsPlainText -Force
        $sourcePassword = ConvertTo-SecureString $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionPassword -AsPlainText -Force

        $instance = New-AzDataMigrationToSqlDb -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName -MigrationService  $env.TestDeleteDatabaseMigrationDb.MigrationService -TargetSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionAuthentication -TargetSqlConnectionDataSource $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionDataSource -TargetSqlConnectionPassword $targetPassword -TargetSqlConnectionUserName $env.TestDeleteDatabaseMigrationDb.TargetSqlConnectionUserName -SourceSqlConnectionAuthentication $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionAuthentication -SourceSqlConnectionDataSource $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionDataSource -SourceSqlConnectionUserName $env.TestDeleteDatabaseMigrationDb.SourceSqlConnectionUserName -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName $env.TestDeleteDatabaseMigrationDb.SourceDatabaseName -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName -Scope  $env.TestDeleteDatabaseMigrationDb.Scope
        
        Start-Sleep -Seconds 5

        Remove-AzDataMigrationToSqlDb -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName -Force

        Start-Sleep -Seconds 5
        
        
        $dbMig = Get-AzDataMigrationToSqlDb -ResourceGroupName $env.TestDeleteDatabaseMigrationDb.ResourceGroupName -SqlDbInstanceName $env.TestDeleteDatabaseMigrationDb.SqlDbInstanceName -TargetDbName $env.TestDeleteDatabaseMigrationDb.TargetDbName -ErrorAction SilentlyContinue
        

        $assert =  ($dbMig -eq $null)
        $assert | Should be $true

    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
