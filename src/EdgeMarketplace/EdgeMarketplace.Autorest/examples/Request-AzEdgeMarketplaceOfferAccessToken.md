### Example 1: Request access token
```powershell
Request-AzEdgeMarketplaceOfferAccessToken -OfferId offerId -ResourceUri resourceUri -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion xxxxx.xxxx.xxxxxxx
```

```output
AccessToken               DiskId            Status
-----------               ------            ------
https://accesstokenlink   publisher:offer   Succeeded
```

This command used to request access token using expanded parameters.

### Example 2: Request access token with Timeout parameter
```powershell
Request-AzEdgeMarketplaceOfferAccessToken -OfferId offerId -ResourceUri resourceUri -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion xxxxx.xxxx.xxxxxxx -Timeout 45
```

```output
AccessToken               DiskId            Status
-----------               ------            ------
https://accesstokenlink   publisher:offer   Succeeded
```

This command used to request access token using expanded parameters and customised timeout parameter.
