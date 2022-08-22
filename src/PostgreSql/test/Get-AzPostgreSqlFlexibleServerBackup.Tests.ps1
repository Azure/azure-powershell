if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerBackup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerBackup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerBackup' {
    It 'List' {
        {
            $backups = Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $backups.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $backups = Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $backup = Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -BackupName $backups[0].Name
            $backup.Name | Should -Be $backups[0].Name
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $backups = Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $backup = Get-AzPostgreSqlFlexibleServerBackup -InputObject $backups[0].Id
            $backup.Id | Should -Be $backups[0].Id
        } | Should -Not -Throw
    }
}
