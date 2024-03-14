if(($null -eq $TestName) -or ($TestName -contains 'Unregister-AzureExtendedZone'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Unregister-AzureExtendedZone.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Unregister-AzureExtendedZone' {
    It 'Unregister' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnregisterViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
