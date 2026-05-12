### Example 1: Remove a subscription from a GroupQuota
```powershell
Remove-AzQuotaGroupQuotaSubscription -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -SubscriptionId "<subscription>"
```

Remove a subscription from an existing GroupQuota. This command returns no output on success.

