# EXAMPLES

## Example 1: Assign quota to a specific subscription using variables
```
$subscriptionId = "0e745469-49f8-48c9-873b-24ca87143db1"
$familyName = "standardDSv3Family"
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -SubscriptionId $subscriptionId -Value @(@{resourceName=$familyName; limit=10; unit="Count"})
```

```output
RequestId   Status     SubscriptionId                          ResourceName        Limit   Unit
---------   ------     --------------                          ------------        -----   ----
<guid>      Succeeded  0e745469-49f8-48c9-873b-24ca87143db1    standardDSv3Family  10      Count
```

This example assigns a quota of 10 standardDSv3Family resources to the subscription in the group quota "ComputeGroupQuota01" using variables for the subscription ID and family name.

## Example 2: Assign quota to a subscription using a JSON file and variables
```
$subscriptionId = "0e745469-49f8-48c9-873b-24ca87143db1"
$familyName = "standardDSv3Family"
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota02" -Location "westus" -ResourceProviderName "Microsoft.Compute" -SubscriptionId $subscriptionId -JsonFilePath "../docs-data/subscription-allocation.json"
```

```output
RequestId   Status     SubscriptionId                          ResourceName        Limit   Unit
---------   ------     --------------                          ------------        -----   ----
<guid>      Succeeded  0e745469-49f8-48c9-873b-24ca87143db1    standardDSv3Family  5       Count
```

This example assigns a quota of 5 standardDSv3Family resources to the subscription in the group quota "ComputeGroupQuota02" using variables and the configuration specified in the JSON file.

