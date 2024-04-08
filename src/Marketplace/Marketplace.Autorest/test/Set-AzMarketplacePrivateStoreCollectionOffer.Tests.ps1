if(($null -eq $TestName) -or ($TestName -contains 'Set-AzMarketplacePrivateStoreCollectionOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMarketplacePrivateStoreCollectionOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzMarketplacePrivateStoreCollectionOffer' {
    It 'UpdateExpanded' {
        New-AzMarketplacePrivateStoreCollection -CollectionName test134 -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa0188 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -SubscriptionsList 1052ff5a-aa43-4ca1-bd18-010399494ce5
        $acc = @{Accessibility = "azure_managedservices_professional"}
        New-AzMarketplacePrivateStoreCollectionOffer -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa0188 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6  -OfferId aumatics.azure_managedservices -Plan $acc

        
        $res = Get-AzMarketplacePrivateStoreCollectionOffer -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa0188 -OfferId aumatics.azure_managedservices 
        $res.UniqueOfferId | Should -Be "aumatics.azure_managedservices"
    }
}
