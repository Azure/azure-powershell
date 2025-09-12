# EXAMPLES

## Example 1: Get a specific GroupQuota by name
```
Get-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota01"
```

```output
Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----                ------------------- ------------------- ----------------------- ------------------------ -----------
ComputeGroupQuota01  
```

This example retrieves the GroupQuota named "ComputeGroupQuota01" for the management group "mg-demo".

## Example 2: List all GroupQuotas in a management group
```
Get-AzQuotaGroupQuota -ManagementGroupId "mg-demo"
```

```output
Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----                ------------------- ------------------- ----------------------- ------------------------ -----------
premiumgroup                                                                                          jsonquota                                                                                             jsonstringquota                                                                                       standardgroup                                                                                         computegroupquota01                                                                                   computegroupquota02  
```

This example lists all GroupQuotas for the management group "mg-demo".

