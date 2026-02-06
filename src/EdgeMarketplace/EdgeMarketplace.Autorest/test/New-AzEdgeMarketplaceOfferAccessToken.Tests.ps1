if(($null -eq $TestName) -or ($TestName -contains 'New-AzEdgeMarketplaceOfferAccessToken'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEdgeMarketplaceOfferAccessToken.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEdgeMarketplaceOfferAccessToken' {
    It 'GenerateExpanded' {
        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -EdgeMarketplaceRegion $env.EdgeMarketplaceRegion -HypervGeneration $env.HypervGeneration -MarketplaceSku $env.MarketplaceSku -MarketplaceSkuVersion $env.MarketPlaceSkuVersion
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be 'Succeeded'
    }

    It 'GenerateViaJsonString' {
        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -JsonString '{"edgeMarketPlaceRegion": "eastus","hypervGeneration": "1","marketPlaceSku": "2019-datacenter","marketPlaceSkuVersion": "17763.7314.250509"}'
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be 'Succeeded'
    }

    It 'GenerateViaJsonFilePath' {
        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -JsonFilePath (Join-Path $PSScriptRoot './jsonFiles/CreateOfferAccessToken.json')
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be 'Succeeded'
    }

    It 'Generate' {
        $requestBody = @{
            "EdgeMarketplaceRegion" = $env.EdgeMarketplaceRegion;
            "HypervGeneration" = $env.HypervGeneration;
            "MarketplaceSku" = $env.MarketplaceSku;
            "MarketplaceSkuVersion" = $env.MarketplaceSkuVersion;
        }

        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -Body $requestBody
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be 'Succeeded'
    }

    It 'GenerateViaIdentityExpanded' {
        $offerIdentity = @{
            "ResourceUri" = $env.ResourceUri;
            "OfferId" = $env.OfferId;
        }

        $result = New-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -EdgeMarketplaceRegion $env.EdgeMarketplaceRegion -HypervGeneration $env.HypervGeneration -MarketplaceSku $env.MarketplaceSku -MarketplaceSkuVersion $env.MarketplaceSkuVersion
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be 'Succeeded'
    }

    It 'GenerateViaIdentity' {
        $offerIdentity = @{
            "ResourceUri" = $env.ResourceUri;
            "OfferId" = $env.OfferId;
        }

        $requestBody = @{
            "EdgeMarketplaceRegion" = $env.EdgeMarketplaceRegion;
            "HypervGeneration" = $env.HypervGeneration;
            "MarketplaceSku" = $env.MarketplaceSku;
            "MarketplaceSkuVersion" = $env.MarketplaceSkuVersion;
        }

        $result = New-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -Body $requestBody
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be 'Succeeded'
    }
}
