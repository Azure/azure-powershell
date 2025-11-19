### Example 1: List GroupQuotasSubscriptionAllocationRequest for a GroupQuota and Subscription
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "testlocation" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -SubscriptionId "{subId}" -Filter "location eq eastus"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- ------------------------
af428d0f-52e8-4c47-ba83-534a27f2d9bb
e5a41235-6a37-4466-b744-306c4873237d
9187e498-dea8-43e1-98a8-3f90a9cc1653
```

List all GroupQuotasSubscriptionAllocationRequests for a specified GroupQuota, resource provider, and subscription filtered by location.

### Example 2: Get a specific GroupQuotasSubscriptionAllocationRequest by AllocationId
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "testlocation" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -SubscriptionId "{subId}" -AllocationId "af428d0f-52e8-4c47-ba83-534a27f2d9bb"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- ------------------------
af428d0f-52e8-4c47-ba83-534a27f2d9bb
```

Get details of a specific GroupQuotasSubscriptionAllocationRequest by its allocation ID.

