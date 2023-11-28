if(($null -eq $TestName) -or ($TestName -contains 'Clear-AzRedisEnterpriseCacheDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Clear-AzRedisEnterpriseCacheDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Clear-AzRedisEnterpriseCacheDatabase' {
    It 'FlushExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Flush' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FlushViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FlushViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
