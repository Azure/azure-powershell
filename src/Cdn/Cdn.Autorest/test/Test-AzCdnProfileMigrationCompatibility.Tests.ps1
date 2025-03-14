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
        $cdnProfileName = 'cdn-migratipn-test-profile-compatibility'
        Write-Host -ForegroundColor Green "Use CdnProfileName : $($cdnProfileName)"
        $profileSku = "Standard_Microsoft";
        New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Test-AzCdnProfileMigrationCompatibility -Subscription $subId -ProfileName $cdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'CanViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
