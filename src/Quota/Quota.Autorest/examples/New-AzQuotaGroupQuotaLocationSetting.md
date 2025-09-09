# EXAMPLES

## Example 1: Enable GroupQuota enforcement for Compute in eastus
```
New-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -EnforcementEnabled "Enabled"
```

```output
Name         Location   ResourceProviderName   EnforcementEnabled   Status
----         --------   -------------------   -------------------  ------
ComputeGroupQuota01 eastus     Microsoft.Compute        true                 Succeeded
```

This example enables GroupQuota enforcement for the group quota "ComputeGroupQuota01" in the "eastus" region for the Microsoft.Compute resource provider.

## Example 2: Enable GroupQuota enforcement using a JSON file
```
New-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota02" -Location "westus" -ResourceProviderName "Microsoft.Compute" -JsonFilePath "../docs-data/groupquota-location-setting.json"
```

```output
Name         Location   ResourceProviderName   EnforcementEnabled   Status
----         --------   -------------------   -------------------  ------
ComputeGroupQuota02 westus     Microsoft.Compute        true                 Succeeded
```

This example enables GroupQuota enforcement for the group quota "ComputeGroupQuota02" in the "westus" region for the Microsoft.Compute resource provider using the configuration specified in the JSON file.

