### Example 1: Get a specific subscription in a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscription -ManagementGroupId "mgId" -GroupQuotaName "testlocation" -SubscriptionId "{subId}"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----                                 ------------------- ------------------- -----------------------
00000000-0000-0000-0000-000000000000
```

Get details of a specific subscription within a GroupQuota.

### Example 2: List all subscriptions in a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscription -ManagementGroupId "mgId" -GroupQuotaName "testlocation"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----                                 ------------------- ------------------- -----------------------
00000000-0000-0000-0000-000000000000
11111111-1111-1111-1111-111111111111
```

List all subscriptions associated with a specified GroupQuota.

