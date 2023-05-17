if(($null -eq $TestName) -or ($TestName -contains 'Move-AzRecoveryServicesRecoveryPoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzRecoveryServicesRecoveryPoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Move-AzRecoveryServicesRecoveryPoint' {
    It 'MoveExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Move' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MoveViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MoveViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
