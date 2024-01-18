### Example 1: Get the quota and actual usage of the CDN profiles under the given subscription
```powershell
Get-AzCdnSubscriptionResourceUsage
```

```output
CurrentValue Limit ResourceType Unit
------------ ----- ------------ ----
13           25    profile      count
29           500   afdprofile   count
```

Get the quota and actual usage of the CDN profiles under the given subscription

