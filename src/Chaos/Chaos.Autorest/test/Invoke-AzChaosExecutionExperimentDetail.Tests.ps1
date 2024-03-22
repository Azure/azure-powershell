if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzChaosExecutionExperimentDetail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzChaosExecutionExperimentDetail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzChaosExecutionExperimentDetail' {
    It 'Execution' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExecutionViaIdentityExperiment' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExecutionViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
