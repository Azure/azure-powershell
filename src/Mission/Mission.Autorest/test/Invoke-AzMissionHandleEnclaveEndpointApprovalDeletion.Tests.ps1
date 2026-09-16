if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMissionHandleEnclaveEndpointApprovalDeletion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMissionHandleEnclaveEndpointApprovalDeletion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMissionHandleEnclaveEndpointApprovalDeletion' {
    It 'HandleExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HandleViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HandleViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HandleViaIdentityVirtualEnclaveExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HandleViaIdentityVirtualEnclave' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Handle' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HandleViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HandleViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
