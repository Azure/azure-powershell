if(($null -eq $TestName) -or ($TestName -contains 'Restore-AzDocumentDBMongoCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzDocumentDBMongoCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restore-AzDocumentDBMongoCluster' {
    BeforeAll {
        $rg = $env.restoreRg
        $cluster = $env.restoreCluster
        $restored = $env.restoredCluster
        $loc = $env.location
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc | Out-Null
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'PointInTimeRestore into a new cluster' {
        # Wait until the first backup produces a restore point (mirrors the CLI
        # 'wait --custom properties.backup.earliestRestoreTime!=null'), then restore into
        # a new cluster from that point in time.
        $restoreTime = $null
        foreach ($attempt in 1..30) {
            $source = Get-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg
            if ($source.BackupEarliestRestoreTime) {
                $restoreTime = [datetime]$source.BackupEarliestRestoreTime
                break
            }
            Start-TestSleep -Seconds 60
        }
        $restoreTime | Should -Not -BeNullOrEmpty

        $password = ConvertTo-SecureString 'CliTest2026!Pw' -AsPlainText -Force
        $result = Restore-AzDocumentDBMongoCluster -Name $restored -ResourceGroupName $rg -Location $loc `
            -SourceCluster $cluster -RestoreTime $restoreTime `
            -AdministratorUserName $env.adminUser -AdministratorPassword $password
        $result.Name | Should -Be $restored
        $result.ProvisioningState | Should -Be 'Succeeded'

        # Clean up the restored cluster.
        { Remove-AzDocumentDBMongoCluster -Name $restored -ResourceGroupName $rg } | Should -Not -Throw
    }
}
