### Example 1: Update cluster manager
```powershell
$tagUpdatedHash = @{
    tag1 = "tag1"
    tag2 = "tag1Update"
}

Update-AzNetworkCloudClusterManager -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Name clusterManagerName -Tag $tagUpdatedHash
```

```output
Location Name   SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----   ------------------- -------------------    ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   cmName 07/31/2023 17:38:44 <identity>             User                    07/31/2023 18:18:04      <identity>               User                         resourceGroupName
```

This command updates properties of a cluster manager.
