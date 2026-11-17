if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzHorizonDbPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzHorizonDbPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzHorizonDbPool' {
    It 'Stop' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentityCluster' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
