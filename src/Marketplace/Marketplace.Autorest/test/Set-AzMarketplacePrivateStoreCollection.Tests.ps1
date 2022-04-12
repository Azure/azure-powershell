if(($null -eq $TestName) -or ($TestName -contains 'Set-AzMarketplacePrivateStoreCollection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMarketplacePrivateStoreCollection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzMarketplacePrivateStoreCollection' {
    It 'UpdateExpanded'  {
        New-AzMarketplacePrivateStoreCollection -CollectionName setColltest -CollectionId 7f5402e4-e8f4-46bd-9bd1-8d27866a6065 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -SubscriptionsList 1052ff5a-aa43-4ca1-bd18-010399494ce5

	Set-AzMarketplacePrivateStoreCollection -CollectionId 7f5402e4-e8f4-46bd-9bd1-8d27866a6065 -CollectionName setColltest1 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -Enabled 

	$res = Get-AzMarketplacePrivateStoreCollection -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId 7f5402e4-e8f4-46bd-9bd1-8d27866a6065
	$res.Enabled | Should -be $true

    }
}
