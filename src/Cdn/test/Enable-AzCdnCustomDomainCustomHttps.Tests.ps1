if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzCdnCustomDomainCustomHttps'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzCdnCustomDomainCustomHttps.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzCdnCustomDomainCustomHttps' {
    It 'EnableExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Enable' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
