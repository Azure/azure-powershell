### Example 1: List GroupQuota limits for a resource provider and location
```powershell
Get-AzQuotaGroupQuotaLimit -ManagementGroupId "mgId" -GroupQuotaName "test2" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------
```

List all quota limits for a specified GroupQuota, resource provider, and location.

