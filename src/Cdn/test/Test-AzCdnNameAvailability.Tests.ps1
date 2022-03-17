if(($null -eq $TestName) -or ($TestName -contains 'Test-AzCdnNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCdnNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzCdnNameAvailability' {
    It 'CheckExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckExpanded1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Check1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Check' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
