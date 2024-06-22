if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzOracleDatabaseResourceManagerSwitchoverAutonomousDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzOracleDatabaseResourceManagerSwitchoverAutonomousDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzOracleDatabaseResourceManagerSwitchoverAutonomousDatabase' {
    It 'SwitchoverExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwitchoverViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwitchoverViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Switchover' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwitchoverViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwitchoverViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
