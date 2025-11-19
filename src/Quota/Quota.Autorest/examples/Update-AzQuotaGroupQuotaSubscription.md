### Example 1: Update a subscription in a GroupQuota
```powershell
Update-AzQuotaGroupQuotaSubscription -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -SubscriptionId "<subscription>"
```

```output
SubscriptionId                       ProvisioningState
--------------                       -----------------
00000000-0000-0000-0000-000000000000 Succeeded
```

Update a subscription's association with an existing GroupQuota using PATCH operation.

