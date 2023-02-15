if(($null -eq $TestName) -or ($TestName -contains 'New-AzMarketplacePrivateStoreCollectionOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMarketplacePrivateStoreCollectionOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMarketplacePrivateStoreCollectionOffer' {
    It 'CreateExpanded' {
        $acc = @{Accessibility = "azure_managedservices_professional"}
	 $res = New-AzMarketplacePrivateStoreCollectionOffer -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6  -OfferId aumatics.azure_managedservices -Plan $acc
	$res.UniqueOfferId | Should -be "aumatics.azure_managedservices"
    }
}
