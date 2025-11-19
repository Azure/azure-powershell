### Example 1: Add a subscription to a GroupQuota
```powershell
New-AzQuotaGroupQuotaSubscription -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -SubscriptionId "<subscription>"
```

```output
SubscriptionId                       ProvisioningState
--------------                       -----------------
00000000-0000-0000-0000-000000000000 Succeeded
```

Add a subscription to an existing GroupQuota.

