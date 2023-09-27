if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert' {
    It 'OfferExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaIdentityPrivateStoreExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaIdentityPrivateStore' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Offer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaIdentityCollectionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaIdentityCollection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OfferViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
