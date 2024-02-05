if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMarketplacePrivateStoreStopSellOfferPlanNotification'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMarketplacePrivateStoreStopSellOfferPlanNotification.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMarketplacePrivateStoreStopSellOfferPlanNotification' {
    It 'List' -Skip {
        $response = Get-AzMarketplacePrivateStoreStopSellOfferPlanNotification -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -Subscription 1f58b5dd-313c-42ed-84fc-f1e351bba7fb
        $response | Should -Not -Be $null
	    $response.Count | Should -BeGreaterThan 0
    }
}
