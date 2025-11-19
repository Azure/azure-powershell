### Example 1: Get a specific subscription in a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscription -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -SubscriptionId "<subscription>"
```

```output
SubscriptionId                       ProvisioningState
--------------                       -----------------
00000000-0000-0000-0000-000000000000 Succeeded
```

Get details of a specific subscription within a GroupQuota.

### Example 2: List all subscriptions in a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscription -ManagementGroupId "mgId" -GroupQuotaName "groupquota1"
```

```output
SubscriptionId                       ProvisioningState
--------------                       -----------------
00000000-0000-0000-0000-000000000000 Succeeded
11111111-1111-1111-1111-111111111111 Succeeded
```

List all subscriptions associated with a specified GroupQuota.

