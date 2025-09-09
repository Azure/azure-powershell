# EXAMPLES

## Example 1: Get GroupQuota usage for a specific quota group in eastus
```
$groupQuotaName = "ComputeGroupQuota01"
$location = "eastus"
$mgId = "mg-demo"
$resourceProvider = "Microsoft.Compute"
Get-AzQuotaGroupQuotaUsage -GroupQuotaName $groupQuotaName -Location $location -ManagementGroupId $mgId -ResourceProviderName $resourceProvider
```

```output
ResourceName         CurrentValue   Limit   Unit
------------         ------------   -----   ----
standardDSv3Family   8              10      Count
```

This example gets the usage and limits for the group quota "$groupQuotaName" in the "$location" region for the "$resourceProvider" resource provider.

## Example 2: Get GroupQuota usage for a different quota group in westus
```
$groupQuotaName = "ComputeGroupQuota02"
$location = "westus"
$mgId = "mg-demo"
$resourceProvider = "Microsoft.Compute"
Get-AzQuotaGroupQuotaUsage -GroupQuotaName $groupQuotaName -Location $location -ManagementGroupId $mgId -ResourceProviderName $resourceProvider
```

```output
ResourceName         CurrentValue   Limit   Unit
------------         ------------   -----   ----
standardDSv3Family   5              8       Count
```

This example gets the usage and limits for the group quota "$groupQuotaName" in the "$location" region for the "$resourceProvider" resource provider.

