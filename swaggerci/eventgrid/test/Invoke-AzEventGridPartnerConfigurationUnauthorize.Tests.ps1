if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzEventGridPartnerConfigurationUnauthorize'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzEventGridPartnerConfigurationUnauthorize.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzEventGridPartnerConfigurationUnauthorize' {
    It 'PartnerExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Partner' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PartnerViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PartnerViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
