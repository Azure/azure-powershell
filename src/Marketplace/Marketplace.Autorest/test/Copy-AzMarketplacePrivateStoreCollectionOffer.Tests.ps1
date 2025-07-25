if(($null -eq $TestName) -or ($TestName -contains 'Copy-AzMarketplacePrivateStoreCollectionOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Copy-AzMarketplacePrivateStoreCollectionOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Copy-AzMarketplacePrivateStoreCollectionOffer' {
    It 'TransferExpanded'  {

        $acc = @{Accessibility = "azure_managedservices_professional"}
	    New-AzMarketplacePrivateStoreCollectionOffer -CollectionId a260d38c-96cf-492d-a340-404d0c4b3ad6 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6  -OfferId aumatics.azure_managedservices -Plan $acc

        $payload = @{OfferIdsList = "aumatics.azure_managedservices"; Operation = "Copy"; TargetCollection = "8c7a91db-cd41-43b6-af47-2e869654126d"}
        $res = Copy-AzMarketplacePrivateStoreCollectionOffer -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId a260d38c-96cf-492d-a340-404d0c4b3ad6 -Payload $payload
        $res.Succeeded.Count | Should -Be 1
    }
}
