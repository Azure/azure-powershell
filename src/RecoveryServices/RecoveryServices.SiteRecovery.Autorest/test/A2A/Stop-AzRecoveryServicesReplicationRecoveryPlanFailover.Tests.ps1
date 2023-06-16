if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzRecoveryServicesReplicationRecoveryPlanFailover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzRecoveryServicesReplicationRecoveryPlanFailover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzRecoveryServicesReplicationRecoveryPlanFailover' {
    It 'Cancel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
