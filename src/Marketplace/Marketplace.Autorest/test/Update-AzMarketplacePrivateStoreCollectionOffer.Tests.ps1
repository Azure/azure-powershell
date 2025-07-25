if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMarketplacePrivateStoreCollectionOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMarketplacePrivateStoreCollectionOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMarketplacePrivateStoreCollectionOffer' {
    It 'UpdateExpanded' {

        $acc = @{Accessibility = "azure_managedservices_professional"}
	    New-AzMarketplacePrivateStoreCollectionOffer -CollectionId 8c7a91db-cd41-43b6-af47-2e869654126d -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6  -OfferId aumatics.azure_managedservices -Plan $acc

        $res = Update-AzMarketplacePrivateStoreCollectionOffer -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId 8c7a91db-cd41-43b6-af47-2e869654126d -OfferId "aumatics.azure_managedservices" -SpecificPlanIdLimitation $null
        $res | Should -Not -Be $null
    }
}
