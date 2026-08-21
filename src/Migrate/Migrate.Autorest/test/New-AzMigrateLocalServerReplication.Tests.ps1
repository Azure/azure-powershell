if(($null -eq $TestName) -or ($TestName -contains 'New-AzMigrateLocalServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateLocalServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMigrateLocalServerReplication' {
    # See Test-AzMigrateLocalEndToEnd.Tests.ps1 for end to end tests.
    It 'ByIdDefaultUser' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByIdPowerUser' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
