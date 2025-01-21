if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzOracleSwitchoverAutonomousDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzOracleSwitchoverAutonomousDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzOracleSwitchoverAutonomousDatabase' {
    It 'SwitchoverExpanded' {
        {
            Invoke-AzOracleSwitchoverAutonomousDatabase -Autonomousdatabasename $env.adbsName -ResourceGroupName $env.resourceGroup -PeerDbId $env.adbsBackupId
        } | Should -Not -Throw
    }
}
