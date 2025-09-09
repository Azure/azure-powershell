# EXAMPLES

## Example 1: Get all quota allocations for a subscription in a GroupQuota
```
$subscriptionId = "0e745469-49f8-48c9-873b-24ca87143db1"
Get-AzQuotaGroupQuotaSubscriptionAllocation -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -SubscriptionId $subscriptionId
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------
eastus
```

This example gets all quota allocations for the subscription "$subscriptionId" in the group quota "ComputeGroupQuota01" for the "eastus" region and Microsoft.Compute resource provider.

## Example 2: Get all quota allocations for all subscriptions in a GroupQuota
```
Get-AzQuotaGroupQuotaSubscriptionAllocation -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute"
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------

```

This example gets all quota allocations for all subscriptions in the group quota "ComputeGroupQuota01" for the "eastus" region and Microsoft.Compute resource provider.

