if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMarketplaceCollectionPrivateStoreToSubscriptionMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMarketplaceCollectionPrivateStoreToSubscriptionMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMarketplaceCollectionPrivateStoreToSubscriptionMapping' {
    It 'CollectionsExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Collections' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CollectionsViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CollectionsViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
