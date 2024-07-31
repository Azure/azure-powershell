### Example 1: Get marketplace info mapped to the given monitor.
```powershell
Get-AzNewRelicBillingInfo -MonitorName test-01 -ResourceGroupName group-test
```

```output
MarketplaceSaaInfoBilledAzureSubscriptionId   : 11111111-2222-3333-4444-123456789101
MarketplaceSaaInfoMarketplaceResourceId       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group-test/providers/Microsoft.SaaS/resources/AzNewRelic_11111111-2222-3333-4444-123456789102_test-01
MarketplaceSaaInfoMarketplaceStatus           : Subscribed
MarketplaceSaaInfoMarketplaceSubscriptionId   : 00000000-0000-0000-0000-000000000000
MarketplaceSaaInfoMarketplaceSubscriptionName : AzNewRelic_11111111-2222-3333-4444-123456789102_test-01
PartnerBillingEntityOrganizationId            : 11111111-2222-3333-4444-123456789103
PartnerBillingEntityOrganizationName          : 11111111-2222-3333-4444-123456789103
```

This command gets marketplace info mapped to the given monitor.

