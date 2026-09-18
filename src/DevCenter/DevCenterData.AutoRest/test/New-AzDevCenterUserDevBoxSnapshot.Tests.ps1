if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterUserDevBoxSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterUserDevBoxSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterUserDevBoxSnapshot' {
    It 'Capture' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CaptureViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CaptureByDevCenter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CaptureViaIdentityByDevCenter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
