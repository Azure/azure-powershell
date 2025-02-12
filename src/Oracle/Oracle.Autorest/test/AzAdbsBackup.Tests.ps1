if(($null -eq $TestName) -or ($TestName -contains 'AzAdbsBackup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzAdbsBackup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzAdbsBackup' {
    It 'CreateAdbsBackup' {
        {
            New-AzOracleAutonomousDatabaseBackup -NoWait -Adbbackupid $env.adbsBackupId -Autonomousdatabasename $env.adbsName -ResourceGroupName $env.resourceGroup -RetentionPeriodInDay 90
        } | Should -Not -Throw
    }
    It 'ListAdbsBackups' {
        {
            Get-AzOracleAutonomousDatabaseBackup -Autonomousdatabasename $env.adbsName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
    It 'DeleteAdbsBackup' {
        {
            Remove-AzOracleAutonomousDatabaseBackup -NoWait -Adbbackupid $env.adbsBackupId -Autonomousdatabasename $env.adbsName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
