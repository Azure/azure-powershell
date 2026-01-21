### Example 1: Get marketplace info mapped to the given monitor.
```powershell
Get-AzDatadogBillingInfo -ResourceGroupName datadog-rg-3eytki -MonitorName datadog-rhqz1v
```

```output
MarketplaceSaaInfoBilledAzureSubscriptionId   : 11111111-2222-3333-4444-123456789101
MarketplaceSaaInfoMarketplaceResourceId       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/datadog-rg-3eytki/providers/Microsoft.SaaS/resources/AzDatadog_11111111-2222-3333-4444-123456789102_datadog-rhqz1v
MarketplaceSaaInfoMarketplaceStatus           : Subscribed
MarketplaceSaaInfoMarketplaceSubscriptionId   : 00000000-0000-0000-0000-000000000000
MarketplaceSaaInfoMarketplaceSubscriptionName : AzDatadog_11111111-2222-3333-4444-123456789102_datadog-rhqz1v
PartnerBillingEntityOrganizationId            : 11111111-2222-3333-4444-123456789103
PartnerBillingEntityOrganizationName          : 11111111-2222-3333-4444-123456789103
```

Retrieved marketplace and organization billing information mapped to the given Datadog monitor resource.
