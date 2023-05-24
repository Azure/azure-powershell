if(($null -eq $TestName) -or ($TestName -contains 'Deploy-AzDevCenterDevEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Deploy-AzDevCenterDevEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deploy-AzDevCenterDevEnvironment' {
    It 'ReplaceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Replace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReplaceViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReplaceViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
