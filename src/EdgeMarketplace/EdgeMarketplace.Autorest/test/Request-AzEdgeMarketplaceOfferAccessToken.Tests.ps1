if(($null -eq $TestName) -or ($TestName -contains 'Request-AzEdgeMarketplaceOfferAccessToken'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Request-AzEdgeMarketplaceOfferAccessToken.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Request-AzEdgeMarketplaceOfferAccessToken' -Tag 'LiveOnly' {
    It 'Request' {
        $result = Request-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -EdgeMarketplaceRegion $env.EdgeMarketplaceRegion -HypervGeneration $env.HypervGeneration -MarketplaceSku $env.MarketplaceSku -MarketplaceSkuVersion $env.MarketPlaceSkuVersion
        $result | Should -Not -BeNullOrEmpty
        $result.AccessToken | Should -Not -BeNullOrEmpty
    }
}
