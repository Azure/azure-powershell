# EXAMPLES

## Example 1: Update GroupQuota enforcement for Compute in eastus
```
Update-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -EnforcementEnabled "Enabled"
```

```output
Name                 Location   ResourceProviderName   EnforcementEnabled   Status
----                 --------   -------------------   -------------------  ------
ComputeGroupQuota01  eastus     Microsoft.Compute     Enabled              Succeeded
```

This example updates GroupQuota enforcement for the group quota "ComputeGroupQuota01" in the "eastus" region for the Microsoft.Compute resource provider.

## Example 2: Update GroupQuota enforcement using a JSON file
```
Update-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota02" -Location "westus" -ResourceProviderName "Microsoft.Compute" -JsonFilePath "../docs-data/update-groupquota-location.json"
```

```output
Name                 Location   ResourceProviderName   EnforcementEnabled   Status
----                 --------   -------------------   -------------------  ------
ComputeGroupQuota02  westus     Microsoft.Compute     Enabled              Succeeded
```

This example updates GroupQuota enforcement for the group quota "ComputeGroupQuota02" in the "westus" region for the Microsoft.Compute resource provider using the configuration specified in the JSON file.

