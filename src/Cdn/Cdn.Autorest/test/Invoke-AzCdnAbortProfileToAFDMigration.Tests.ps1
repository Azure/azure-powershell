if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzCdnAbortProfileToAFDMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCdnAbortProfileToAFDMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Playback only
Describe 'Invoke-AzCdnAbortProfileToAFDMigration' {
    It 'Abort' {
        $subId = $env.SubscriptionId
        $map1 = New-AzCdnMigrationEndpointMappingObject -MigratedFrom maxtestendpointcli-test-profile1.azureedge.net -MigratedTo maxtestendpointcli-test-profile2
        Move-AzCdnProfileToAFD -Subscription $subId -ProfileName cli-test-profile -ResourceGroupName cli-test-rg -SkuName Premium_AzureFrontDoor -MigrationEndpointMapping @($map1)
        Invoke-AzCdnAbortProfileToAFDMigration -Subscription $subId -ProfileName cli-test-profile -ResourceGroupName cli-test-rg
    }

    It 'AbortViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
