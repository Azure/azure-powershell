if(($null -eq $TestName) -or ($TestName -contains 'Move-AzCdnProfileToAFD'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzCdnProfileToAFD.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Move-AzCdnProfileToAFD' {
    It 'MigrateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Migrate' {
        $subId = $env.SubscriptionId
        $cdnProfileName = 'cdn-migration-test-profile'
        Write-Host -ForegroundColor Green "Use CdnProfileName : $($cdnProfileName)"
        $profileSku = "Standard_Microsoft";
        New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        Move-AzCdnProfileToAFD -Subscription $subId -ProfileName $cdnProfileName -ResourceGroupName $env.ResourceGroupName -SkuName 'Premium_AzureFrontDoor'
        Start-Sleep 60
        Invoke-AzCdnAbortProfileToAFDMigration -Subscription $subId -ProfileName $cdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'MigrateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MigrateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
