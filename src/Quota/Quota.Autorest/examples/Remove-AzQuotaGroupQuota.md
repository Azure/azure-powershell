# EXAMPLES

## Example 1: Remove a GroupQuota by name
```
$mgId = "mg-demo"
$groupQuotaName = "ComputeGroupQuota01"
Remove-AzQuotaGroupQuota -ManagementGroupId $mgId -Name $groupQuotaName -Confirm
```

```output
<Empty>
```

This example deletes the group quota "$groupQuotaName" in the management group "$mgId".

## Example 2: Remove a GroupQuota and return success status
```
$mgId = "mg-demo"
$groupQuotaName = "ComputeGroupQuota02"
Remove-AzQuotaGroupQuota -ManagementGroupId $mgId -Name $groupQuotaName -PassThru
```

```output
True
```

This example deletes the group quota "$groupQuotaName" in the management group "$mgId" and returns the success status.

