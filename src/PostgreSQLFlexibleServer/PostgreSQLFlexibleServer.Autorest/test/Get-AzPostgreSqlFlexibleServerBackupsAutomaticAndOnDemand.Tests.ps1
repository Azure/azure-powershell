if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand' {
    It 'List' {
        $backups = Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        $backups | Should -Not -BeNullOrEmpty
        $backups.Count | Should -BeGreaterOrEqual 1
        $backups[0].Name | Should -Not -BeNullOrEmpty
        $backups[0].BackupType | Should -BeIn @('Full', 'Incremental')
        $backups[0].CompletedTime | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        # Get the list of backups first
        $backups = Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        $backups | Should -Not -BeNullOrEmpty
        
        # Get specific backup
        $firstBackup = $backups[0]
        $backup = Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $firstBackup.Name
        $backup | Should -Not -BeNullOrEmpty
        $backup.Name | Should -Be $firstBackup.Name
        $backup.BackupType | Should -Not -BeNullOrEmpty
        $backup.CompletedTime | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' {
        $backups = Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        $firstBackup = $backups[0]
        $backupViaIdentity = Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -InputObject $firstBackup
        $backupViaIdentity | Should -Not -BeNullOrEmpty
        $backupViaIdentity.Name | Should -Be $firstBackup.Name
    }

    It 'GetViaIdentityFlexibleServer' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $backups = Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -FlexibleServerInputObject $server
        $backups | Should -Not -BeNullOrEmpty
        $backups.Count | Should -BeGreaterOrEqual 1
        # Verify backup properties
        foreach ($backup in $backups) {
            $backup.Name | Should -Not -BeNullOrEmpty
            $backup.BackupType | Should -BeIn @('Full', 'Incremental')
        }
    }

    It 'FilterByBackupType' {
        $backups = Get-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        $fullBackups = $backups | Where-Object { $_.BackupType -eq 'Full' }
        if ($fullBackups.Count -gt 0) {
            $fullBackups[0].BackupType | Should -Be 'Full'
        }
    }
}
