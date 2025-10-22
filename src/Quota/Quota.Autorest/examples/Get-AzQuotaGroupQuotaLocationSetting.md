# EXAMPLES

## Example 1: Get GroupQuota enforcement settings for a specific location
```
Get-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute"
```

```output
Name                 Location   ResourceProviderName   EnforcementEnabled   Status
----                 --------   -------------------   -------------------  ------
ComputeGroupQuota01  eastus     Microsoft.Compute     Enabled              Succeeded
```

This example retrieves the GroupQuota enforcement settings for the group quota "ComputeGroupQuota01" in the "eastus" region for the Microsoft.Compute resource provider.

## Example 2: List all GroupQuota enforcement settings for a resource provider
```
Get-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -ResourceProviderName "Microsoft.Compute"
```

```output
Name                 Location   ResourceProviderName   EnforcementEnabled   Status
----                 --------   -------------------   -------------------  ------
ComputeGroupQuota01  eastus     Microsoft.Compute     Enabled              Succeeded
ComputeGroupQuota01  westus     Microsoft.Compute     Disabled             Succeeded
```

This example lists all GroupQuota enforcement settings for the group quota "ComputeGroupQuota01" across all locations for the Microsoft.Compute resource provider.

