# EXAMPLES

## Example 1: Update GroupQuota limits for a specific group quota
```
Update-AzQuotaGroupQuotaLimitsRequest -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -Value @(@{resourceName="standardDSv3Family"; limit=20; unit="Count"})
```

```output
RequestId   Status     GroupQuotaName         Location   ResourceProviderName   ResourceName        Limit   Unit
---------   ------     -------------         --------   -------------------   ------------        -----   ----
<guid>      Succeeded  ComputeGroupQuota01    eastus     Microsoft.Compute      standardDSv3Family  20      Count
```

This example updates the quota limit for the family "standardDSv3Family" in the group quota "ComputeGroupQuota01" for the "eastus" region.

## Example 2: Update GroupQuota limits using a JSON file
```
Update-AzQuotaGroupQuotaLimitsRequest -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota02" -Location "westus" -ResourceProviderName "Microsoft.Compute" -JsonFilePath "../docs-data/groupquota-limits.json"
```

```output
RequestId   Status     GroupQuotaName         Location   ResourceProviderName   ResourceName        Limit   Unit
---------   ------     -------------         --------   -------------------   ------------        -----   ----
<guid>      Succeeded  ComputeGroupQuota02    westus     Microsoft.Compute      standardDSv3Family  15      Count
```

This example updates the quota limit for the family "standardDSv3Family" in the group quota "ComputeGroupQuota02" for the "westus" region using the configuration specified in the JSON file.

