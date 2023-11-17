### Example 1: Update Layer 2 (L2) network
```powershell
Update-AzNetworkCloudL2Network -ResourceGroupName resourceGroupName -Name l2Network -Tag @{ tag1 = "tag1"; tag2 = "tag2" } -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----       ------------------- -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- ----                              -------------------
eastus   l2Network 05/25/2023 05:36:37 user1                 User                    05/25/2023 05:56:05      user2                    User                         microsoft.networkcloud/l2networks
```

This command updates tags of the existing layer 2 (L2) network.
