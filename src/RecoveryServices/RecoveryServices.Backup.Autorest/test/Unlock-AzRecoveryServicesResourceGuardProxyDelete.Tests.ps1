if(($null -eq $TestName) -or ($TestName -contains 'Unlock-AzRecoveryServicesResourceGuardProxyDelete'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Unlock-AzRecoveryServicesResourceGuardProxyDelete.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Unlock-AzRecoveryServicesResourceGuardProxyDelete' {
    It 'UnlockExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Unlock' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnlockViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnlockViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
