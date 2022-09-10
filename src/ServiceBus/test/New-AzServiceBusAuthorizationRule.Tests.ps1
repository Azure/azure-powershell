if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusAuthorizationRule' {
    It 'NewExpandedNamespace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'NewExpandedQueue' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'NewExpandedTopic' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
