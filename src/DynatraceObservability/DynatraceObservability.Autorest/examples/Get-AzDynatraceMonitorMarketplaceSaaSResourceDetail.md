### Example 1: get Marketplace SaaS resource details
```powershell
Get-AzDynatraceMonitorMarketplaceSaaSResourceDetail -TenantId 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
```

```output
MarketplaceSaaSResourceId            MarketplaceSubscriptionStatus PlanId
-------------------------            ----------------------------- ------
yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy Subscribed                    azureportalintegration_privatepreview
```

This command gets the Marketplace SaaS resource for a given tenant Id.
