### Example 1: Create a cluster manager
```powershell
$tagHash = @{
     tag1 = "true"
     tag2 = "false"
}

New-AzNetworkCloudClusterManager -Name cnName -Location location -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -AnalyticsWorkspaceId "" -ManagedResourceGroupConfigurationName mrgName -FabricControllerId fabricControllerID -Tag $tagHash
```

```output
Location Name   SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----   ------------------- -------------------    ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   cmName 07/31/2023 17:38:44 <identity>             User                    07/31/2023 17:38:44      <identity>               User                         resourceGroupName

```

This command creates a cluster manager.
