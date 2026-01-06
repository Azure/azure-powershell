##TODO## Address error: Unable to verify that the user that sent this request is the original caller of the asynchronous operation being polled. Please refer to https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/async-operations for more information.

### Example 1: List GroupQuotasSubscriptionRequests for a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName "testlocation" -ManagementGroupId "mgId"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----                                 ------------------- ------------------- -----------------------
00000000-0000-0000-0000-000000000000
22222222-2222-2222-2222-222222222222
```

List all GroupQuotasSubscriptionRequests for a specified GroupQuota.

