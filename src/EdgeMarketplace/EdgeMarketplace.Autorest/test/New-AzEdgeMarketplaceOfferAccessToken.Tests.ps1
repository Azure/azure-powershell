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
        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion 17763.7314.250509
    }

    It 'GenerateViaJsonString' {
        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -JsonString '{"edgeMarketPlaceRegion": "eastus","hypervGeneration": "1","marketPlaceSku": "2019-datacenter","marketPlaceSkuVersion": "17763.7314.250509"}'
    }

    It 'GenerateViaJsonFilePath' {
        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -JsonFilePath (Join-Path $PSScriptRoot './jsonFiles/CreateOfferAccessToken.json')
    }

    It 'Generate' {
        $requestBody = @{
            "EdgeMarketplaceRegion" = $env.EdgeMarketplaceRegion;
            "HypervGeneration" = $env.HypervGeneration;
            "MarketplaceSku" = $env.MarketplaceSku;
            "MarketplaceSkuVersion" = $env.MarketplaceSkuVersion;
        }

        $result = New-AzEdgeMarketplaceOfferAccessToken -OfferId $env.OfferId -ResourceUri $env.ResourceUri -Body $requestBody
    }

    It 'GenerateViaIdentityExpanded' {
        $offerIdentity = @{
            "ResourceUri" = $env.ResourceUri;
            "OfferId" = $env.OfferId;
        }

        $result = New-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -EdgeMarketplaceRegion $env.EdgeMarketplaceRegion -HypervGeneration $env.HypervGeneration -MarketplaceSku $env.MarketplaceSku -MarketplaceSkuVersion $env.MarketplaceSkuVersion
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
    }
}
