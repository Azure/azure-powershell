### Example 1: List GroupQuota subscription allocations
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocation -ManagementGroupId "mgId" -SubscriptionId "{subId}" -GroupQuotaName "testlocation" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----   ------------------- ------------------- ----------------------- ------------------------
eastus
```

List all quota allocations for a specified subscription within a GroupQuota for a particular resource provider and location.

