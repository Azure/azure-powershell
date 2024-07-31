if(($null -eq $TestName) -or ($TestName -contains 'Test-AzCdnProfileMigrationCompatibility'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCdnProfileMigrationCompatibility.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Playback only
Describe 'Test-AzCdnProfileMigrationCompatibility' {
    It 'Can' {
        $subId = $env.SubscriptionId
        Test-AzCdnProfileMigrationCompatibility -Subscription $subId -ProfileName cli-test-profile -ResourceGroupName cli-test-rg
    }

    It 'CanViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
