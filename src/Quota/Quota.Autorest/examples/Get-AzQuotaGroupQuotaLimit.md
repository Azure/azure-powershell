# EXAMPLES

## Example 1: Get GroupQuota limits for a specific quota group in eastus
```
Get-AzQuotaGroupQuotaLimit -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute"
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------
```

This example gets the quota limits for the group quota "ComputeGroupQuota01" in the "eastus" region for the Microsoft.Compute resource provider.

