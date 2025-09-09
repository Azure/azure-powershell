# EXAMPLES

## Example 1: Get the status of a quota allocation request for a subscription
```
$allocationId = "a1b2c3d4-e5f6-7890-abcd-1234567890ab"
$subscriptionId = "0e745469-49f8-48c9-873b-24ca87143db1"
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId $allocationId -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -ResourceProviderName "Microsoft.Compute" -SubscriptionId $subscriptionId
```

```output
TODO
```

This example gets the status of a quota allocation request for the subscription "$subscriptionId" using the allocation ID "$allocationId" in the group quota "ComputeGroupQuota01".

## Example 2: List all quota allocation requests for a GroupQuota with a filter
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -ResourceProviderName "Microsoft.Compute" -Filter "location eq eastus"
```

```output
TODO
```

This example lists all quota allocation requests for the group quota "ComputeGroupQuota01" in the management group "mg-demo" for the Microsoft.Compute resource provider, filtered by location "eastus".

