if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusKey' {
    It 'NewExpandedNamespace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'NewExpandedQueue' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'NewExpandedTopic' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'NewExpandedEntity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
