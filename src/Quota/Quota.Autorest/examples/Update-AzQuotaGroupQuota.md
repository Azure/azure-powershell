# EXAMPLES

## Example 1: Update the display name of a GroupQuota
```
Update-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota01" -DisplayName "Updated Compute Quota"
```

```output
RequestId   Status     Name                 DisplayName
---------   ------     ----                 -----------
<guid>      Succeeded  ComputeGroupQuota01  Updated Compute Quota
```

This example updates the display name of the GroupQuota "ComputeGroupQuota01" in the management group "mg-demo".

## Example 2: Update a GroupQuota using a JSON file
```
Update-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota02" -JsonFilePath "../docs-data/update-groupquota.json"
```

```output
RequestId   Status     Name                 DisplayName
---------   ------     ----                 -----------
<guid>      Succeeded  ComputeGroupQuota02  Quota Updated via JSON
```

This example updates the GroupQuota "ComputeGroupQuota02" in the management group "mg-demo" using the configuration specified in the JSON file.

