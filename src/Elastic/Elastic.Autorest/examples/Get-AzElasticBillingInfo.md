### Example 1: Get marketplace info mapped to the given monitor.
```powershell
Get-AzElasticBillingInfo -ResourceGroupName elastic-rg-3eytki -MonitorName elastic-rhqz1v
```

```output
MarketplaceSaaInfoBilledAzureSubscriptionId   : 11111111-2222-3333-4444-123456789101
MarketplaceSaaInfoMarketplaceResourceId       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/elastic-rg-3eytki/providers/Microsoft.SaaS/resources/AzElastic_11111111-2222-3333-4444-123456789102_elastic-rhqz1v
MarketplaceSaaInfoMarketplaceStatus           : Subscribed
MarketplaceSaaInfoMarketplaceSubscriptionId   : 00000000-0000-0000-0000-000000000000
MarketplaceSaaInfoMarketplaceSubscriptionName : AzElastic_11111111-2222-3333-4444-123456789102_elastic-rhqz1v
PartnerBillingEntityOrganizationId            : 11111111-2222-3333-4444-123456789103
PartnerBillingEntityOrganizationName          : 11111111-2222-3333-4444-123456789103
```

This command gets marketplace info mapped to the given monitor.

