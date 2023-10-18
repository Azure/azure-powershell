if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageAccountMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageAccountMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageAccountMigration' {
    It 'Get' {
        $migration = Get-AzStorageAccountMigration -ResourceGroupName $env.ResourceGroupName -AccountName $env.AccountName 
        $migration.Name | Should -Be "default"
        $migration.ResourceGroupName | Should -Be "testaccountmigrationrg"
        $migration.DetailMigrationStatus | Should -Be "SubmittedForConversion"
        $migration.DetailTargetSkuName | Should -Be "Standard_ZRS"
    }
}
