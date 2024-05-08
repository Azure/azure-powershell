if(($null -eq $TestName) -or ($TestName -contains 'Grant-AzEventGridPartnerConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Grant-AzEventGridPartnerConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Grant-AzEventGridPartnerConfiguration' {
    It 'AuthorizeExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Authorize' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AuthorizeViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AuthorizeViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
