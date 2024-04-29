if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMarketplacePrivateStoreUserOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMarketplacePrivateStoreUserOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMarketplacePrivateStoreUserOffer' {
    It 'QueryExpanded' {
        $response = Get-AzMarketplacePrivateStoreUserOffer -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -OfferId aumatics.azure_managedservices -SubscriptionId 1f58b5dd-313c-42ed-84fc-f1e351bba7fb
        $response | Should -Not -Be $null
        $response.Count | Should -Be 1
        $response[0].uniqueOfferId | Should -Be "aumatics.azure_managedservices"
    }
}
