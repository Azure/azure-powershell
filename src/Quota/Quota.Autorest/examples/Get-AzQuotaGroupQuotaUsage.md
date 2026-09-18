### Example 1: Get GroupQuota usage for a resource provider and location
```powershell
Get-AzQuotaGroupQuotaUsage -ManagementGroupId "admintest"  -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```

```output
Name               UsageValue Unit  IsQuotaApplicable
----               ---------- ----  -----------------
standardDSv3Family 10         Count True
standardFSv2Family 5          Count True
cores              15         Count True
```

This command gets the current usage of compute resources within a GroupQuota for the specified resource provider and location. Note that the location must be enforced for the GroupQuota before usage data is available.

