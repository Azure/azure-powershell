if(($null -eq $TestName) -or ($TestName -contains 'Restore-AzElasticSanVolume'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzElasticSanVolume.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restore-AzElasticSanVolume' {
    It 'Restore' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentityVolumegroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentityElasticSan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
