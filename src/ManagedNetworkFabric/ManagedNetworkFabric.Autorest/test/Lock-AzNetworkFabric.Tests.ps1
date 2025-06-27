if(($null -eq $TestName) -or ($TestName -contains 'Lock-AzNetworkFabric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Lock-AzNetworkFabric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Lock-AzNetworkFabric' {
    It 'LockExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LockViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LockViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Lock' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LockViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LockViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
