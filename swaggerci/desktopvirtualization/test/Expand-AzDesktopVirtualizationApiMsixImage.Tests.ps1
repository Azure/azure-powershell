if(($null -eq $TestName) -or ($TestName -contains 'Expand-AzDesktopVirtualizationApiMsixImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Expand-AzDesktopVirtualizationApiMsixImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Expand-AzDesktopVirtualizationApiMsixImage' {
    It 'ExpandExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Expand' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExpandViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ExpandViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
