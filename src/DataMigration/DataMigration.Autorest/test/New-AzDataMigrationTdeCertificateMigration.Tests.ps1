if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataMigrationTdeCertificateMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataMigrationTdeCertificateMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataMigrationTdeCertificateMigration' {
    It 'Throws with incomplete arguments' {
        { New-AzDataMigrationTdeCertificateMigration } | Should -Throw
        { New-AzDataMigrationTdeCertificateMigration -SourceSqlConnectionString "" -TargetSubscriptionId "" -TargetResourceGroupName "" -TargetManagedInstanceName "" -NetworkSharePath "" -NetworkShareDomain "" -NetworkShareUserName "" -NetworkSharePassword "" -DatabaseName "" } | Should -Throw
    }
}
