if(($null -eq $TestName) -or ($TestName -contains 'Get-AzChaosScenarioConfigurationValidation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzChaosScenarioConfigurationValidation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzChaosScenarioConfigurationValidation' {
    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityWorkspace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentitySubscription' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityScenario' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
