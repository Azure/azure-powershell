# EXAMPLES

## Example 1: List all subscriptions associated with a GroupQuota
```
Get-AzQuotaGroupQuotaSubscription -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01"
```

```output
```

This example lists all subscriptions associated with the group quota "ComputeGroupQuota01" in the management group "mg-demo".

## Example 2: Get the provisioning state for a specific subscription in a GroupQuota

```powershell
$subscriptionId = "0e745469-49f8-48c9-873b-24ca87143db1"
Get-AzQuotaGroupQuotaSubscription -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -SubscriptionId $subscriptionId
```

```output
```

This example gets the provisioning state for the subscription "0e745469-49f8-48c9-873b-24ca87143db1" in the group quota "ComputeGroupQuota01" under management group "mg-demo".

