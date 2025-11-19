### Example 1: List GroupQuota limits for a resource provider and location
```powershell
Get-AzQuotaGroupQuotaLimit -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name              Limit ProvisioningState
----              ----- -----------------
standardav2family 100   Succeeded
standardbsfamily  50    Succeeded
```

List all quota limits for a specified GroupQuota, resource provider, and location.

