### Example 1: Create an in-memory object for AzureCDN DeliveryRuleCacheExpirationAction
```powershell
New-AzCdnDeliveryRuleCacheExpirationActionObject -Name CacheExpiration -ParameterCacheBehavior SetIfMissing -ParameterCacheDuration 0.01:30:00
```

```output
Name
----
CacheExpiration
```

Create an in-memory object for AzureCDN DeliveryRuleCacheExpirationAction
