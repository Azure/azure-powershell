### Example 1: List GroupQuotasLimitsRequests for a GroupQuota
```powershell
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "testlocation" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -Filter "location eq 'eastus'"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- ------------------------
a56329ce-785c-4d38-8554-ab3cca466705
6ab338d4-69ed-42a4-8402-cde6edebc3af
c58a2ef0-8606-4dc1-999a-8c18c2be9f4c
a7e67697-3b38-4c32-a491-cc8ad20c471e
```

List all GroupQuotasLimitsRequests for a specified GroupQuota and resource provider filtered by location.

### Example 2: Get a specific GroupQuotasLimitsRequest by RequestId
```powershell
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "testlocation" -ManagementGroupId "mgId" -RequestId "a56329ce-785c-4d38-8554-ab3cca466705"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- ------------------------
a56329ce-785c-4d38-8554-ab3cca466705
```

Get details of a specific GroupQuotasLimitsRequest by its request ID.

