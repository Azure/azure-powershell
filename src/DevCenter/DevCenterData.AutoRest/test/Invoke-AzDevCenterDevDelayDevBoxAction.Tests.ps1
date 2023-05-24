if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDevCenterDevDelayDevBoxAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDevCenterDevDelayDevBoxAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDevCenterDevDelayDevBoxAction' {
    It 'Delay1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Delay' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DelayViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DelayViaIdentityByDevCenter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Delay1ByDevCenter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DelayByDevCenter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
