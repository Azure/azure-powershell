if(($null -eq $TestName) -or ($TestName -contains 'Debug-AzNotificationHubsNotificationHubSend'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Debug-AzNotificationHubsNotificationHubSend.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Debug-AzNotificationHubsNotificationHubSend' {
    It 'DebugExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Debug' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DebugViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DebugViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
