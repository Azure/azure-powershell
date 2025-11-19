### Example 1: List GroupQuota usage for a resource provider and location
```powershell
Get-AzQuotaGroupQuotaUsage -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name              UsageValue Limit ProvisioningState
----              ---------- ----- -----------------
standardav2family 45         100   Succeeded
standardbsfamily  20         50    Succeeded
```

List quota usage for a specified GroupQuota, resource provider, and location. Note: This API is supported for enforced GroupQuotas only.

