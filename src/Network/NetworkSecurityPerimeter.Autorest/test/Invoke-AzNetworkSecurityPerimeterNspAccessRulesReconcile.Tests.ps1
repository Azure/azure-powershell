if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkSecurityPerimeterNspAccessRulesReconcile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkSecurityPerimeterNspAccessRulesReconcile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkSecurityPerimeterNspAccessRulesReconcile' {
    It 'PostExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentityProfileExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentityNetworkSecurityPerimeterExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentityNetworkSecurityPerimeter' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Post' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PostViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
