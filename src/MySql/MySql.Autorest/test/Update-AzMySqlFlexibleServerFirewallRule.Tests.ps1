if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMySqlFlexibleServerFirewallRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMySqlFlexibleServerFirewallRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMySqlFlexibleServerFirewallRule' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ClientIPAddress' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ClientIPAddressViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
