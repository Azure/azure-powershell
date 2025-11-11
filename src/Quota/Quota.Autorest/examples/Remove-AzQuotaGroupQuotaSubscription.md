# EXAMPLES

## Example 1: Remove a subscription from a GroupQuota
```
$groupQuotaName = "ComputeGroupQuota01"
$mgId = "mg-demo"
$subscriptionId = "0e745469-49f8-48c9-873b-24ca87143db1"
Remove-AzQuotaGroupQuotaSubscription -GroupQuotaName $groupQuotaName -ManagementGroupId $mgId -SubscriptionId $subscriptionId -Confirm
```

```output
<Empty>
```

This example removes the subscription "$subscriptionId" from the group quota "$groupQuotaName" in the management group "$mgId".

## Example 2: Remove a subscription from a GroupQuota and return success status
```
$groupQuotaName = "ComputeGroupQuota02"
$mgId = "mg-demo"
$subscriptionId = "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"
Remove-AzQuotaGroupQuotaSubscription -GroupQuotaName $groupQuotaName -ManagementGroupId $mgId -SubscriptionId $subscriptionId -PassThru
```

```output
<Empty>
```

This example removes the subscription "$subscriptionId" from the group quota "$groupQuotaName" in the management group "$mgId" and returns the success status.

