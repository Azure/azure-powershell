### Example 1: Add a subscription to a GroupQuota
```powershell
New-AzQuotaGroupQuotaSubscription -ManagementGroupId "mg-demo" -GroupQuotaName "groupquota1" -SubscriptionId "{subId}"
```

```output
New-AzQuotaGroupQuotaSubscription_Create: The subscription {subId} is already registered for a Quota Group, please select another subscription and try again.
```

Add a subscription to an existing GroupQuota. Note: If the subscription is already registered, an error will be returned.

