if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzEventHubRejectFabricShortcut'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzEventHubRejectFabricShortcut.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzEventHubRejectFabricShortcut' {
    It 'Reject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RejectViaIdentityNamespace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RejectViaIdentityEventhub' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RejectViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
