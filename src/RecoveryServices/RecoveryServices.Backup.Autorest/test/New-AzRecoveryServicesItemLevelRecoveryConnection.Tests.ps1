if(($null -eq $TestName) -or ($TestName -contains 'New-AzRecoveryServicesItemLevelRecoveryConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRecoveryServicesItemLevelRecoveryConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRecoveryServicesItemLevelRecoveryConnection' {
    It 'ProvisionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Provision' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ProvisionViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ProvisionViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
