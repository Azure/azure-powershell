if(($null -eq $TestName) -or ($TestName -contains 'Start-AzHdInsightOnAksClusterJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzHdInsightOnAksClusterJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzHdInsightOnAksClusterJob' {
    It 'RunExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityClusterpoolExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityClusterpool' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Run' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
