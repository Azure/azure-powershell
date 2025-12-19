if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateLocalServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateLocalServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateLocalServerReplication' {
    # See Test-AzMigrateLocalEndToEnd.Tests.ps1 for end to end tests.
    It 'ListByName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByMachineName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByItemID' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetBySDSID' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByInputObject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListById' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
