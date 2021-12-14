if(($null -eq $TestName) -or ($TestName -contains 'Move-AzMarketplacePrivateStoreCollectionOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzMarketplacePrivateStoreCollectionOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Move-AzMarketplacePrivateStoreCollectionOffer' {
    It 'TransferExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Transfer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TransferViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TransferViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
