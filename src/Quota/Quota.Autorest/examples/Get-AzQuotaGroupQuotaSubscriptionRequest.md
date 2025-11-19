### Example 1: List GroupQuotasSubscriptionRequests for a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId"
```

```output
RequestId                            SubscriptionId                       ProvisioningState
---------                            --------------                       -----------------
00000000-0000-0000-0000-000000000000 11111111-1111-1111-1111-111111111111 Succeeded
22222222-2222-2222-2222-222222222222 33333333-3333-3333-3333-333333333333 InProgress
```

List all GroupQuotasSubscriptionRequests for a specified GroupQuota.

### Example 2: Get a specific GroupQuotasSubscriptionRequest by RequestId
```powershell
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -RequestId "00000000-0000-0000-0000-000000000000"
```

```output
RequestId                            SubscriptionId                       ProvisioningState
---------                            --------------                       -----------------
00000000-0000-0000-0000-000000000000 11111111-1111-1111-1111-111111111111 Succeeded
```

Get details of a specific GroupQuotasSubscriptionRequest by its request ID.

