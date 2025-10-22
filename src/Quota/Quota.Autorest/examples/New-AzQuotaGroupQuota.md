# EXAMPLES

## Example 1: Create a new Compute GroupQuota with basic parameters
```
New-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota01" -DisplayName "Demo Compute Quota"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- -------------------
<guid>
```

This example creates a new GroupQuota named "ComputeGroupQuota01" for the management group "mg-demo" with the display name "Demo Compute Quota".

## Example 2: Create a new Compute GroupQuota using a JSON file
```
New-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota02" -JsonFilePath "../docs-data/compute-groupquota.json"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- -------------------
<guid>
```

This example creates a new GroupQuota named "ComputeGroupQuota02" for the management group "mg-demo" using the configuration specified in the JSON file located at "../docs-data/compute-groupquota.json".

