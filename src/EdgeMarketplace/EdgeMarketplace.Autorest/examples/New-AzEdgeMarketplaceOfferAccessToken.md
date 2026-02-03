### Example 1: Generating new requestId or access token using GenerateExpanded (Default)
```powershell
New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion 17763.7314.250509
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```

This command used for generating new access token using expanded parameters.

### Example 2: (Generate) Generate access token with request body as parameter.
```powershell
$requestBody = @{
    "EdgeMarketplaceRegion" = "eastus";
    "HypervGeneration" = "1";
    "MarketplaceSku" = "2019-datacenter";
    "MarketplaceSkuVersion" = "17763.7314.250509";
}

New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -Body $requestBody

```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```

This command used for generating new access token with request body parameter.

### Example 3: (GenerateViaIdentity) Generate access token with Identity and Body parameter
```powershell
$requestBody = @{
    "EdgeMarketplaceRegion" = "eastus";
    "HypervGeneration" = "1";
    "MarketplaceSku" = "2019-datacenter";
    "MarketplaceSkuVersion" = "17763.7314.250509";
}

$offerIdentity = @{
    "ResourceUri" = "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation"
    "OfferId" = "microsoftwindowsserver:windowsserver"
}

New-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -Body $requestBody
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token with input object and body parameter

### Example 4: (GenerateViaIdentityExpanded) Generate access token with Identity and expanded parameters
```powershell
$offerIdentity = @{
    "ResourceUri" = "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation"
    "OfferId" = "microsoftwindowsserver:windowsserver"
}

New-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion 17763.7314.250509
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token with input object and expanded parameters

### Example 5: (GenerateViaJsonFilePath) Generate access token using Json file path
```powershell
New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -JsonFilePath "path/to/file/new-offerAccessToken.json"
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token using json file path

### Example 6: (GenerateViaJsonString) Generate Access Token using Json string
```powershell
New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -JsonString '{"edgeMarketPlaceRegion": "eastus","hypervGeneration": "1","marketPlaceSku": "2019-datacenter","marketPlaceSkuVersion": "17763.7314.250509"}'
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token using json string 