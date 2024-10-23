if(($null -eq $TestName) -or ($TestName -contains 'Restore-AzOracleAutonomousDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzOracleAutonomousDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restore-AzOracleAutonomousDatabase' {
    It 'RestoreExpanded' {
        {
            $timeStamp = Get-Date
            Restore-AzOracleAutonomousDatabase -NoWait -Name $env.adbsName -ResourceGroupName $env.resourceGroup -Timestamp $timeStamp
        } | Should -Not -Throw
    }
}
