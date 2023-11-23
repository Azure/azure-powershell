if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNewRelicHostMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNewRelicHostMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNewRelicHostMonitor' {
    It 'Host' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HostViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
