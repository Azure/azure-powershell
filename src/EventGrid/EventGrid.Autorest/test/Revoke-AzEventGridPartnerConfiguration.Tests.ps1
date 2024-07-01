if(($null -eq $TestName) -or ($TestName -contains 'Revoke-AzEventGridPartnerConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Revoke-AzEventGridPartnerConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Revoke-AzEventGridPartnerConfiguration' {
    It 'PartnerExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Partner' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PartnerViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PartnerViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
