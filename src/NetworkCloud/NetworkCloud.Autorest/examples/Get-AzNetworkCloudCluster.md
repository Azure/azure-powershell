### Example 1: List clusters by subscription
```powershell
Get-AzNetworkCloudCluster -SubscriptionId subscriptionId
```

```output
Location    Name                   SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifi
                                                                                                                                                                                  edByType
--------    ----                   ------------------- -------------------                  ----------------------- ------------------------ ------------------------             --------------------
eastus      clusterNames              12/22/2022 19:28:28 user                                      User             05/31/2023 04:29:54         user 								User
```

This command lists all clusters under a subscription.

### Example 2: Get cluster
```powershell
Get-AzNetworkCloudCluster -Name clusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGro
                                                                                                                                                                                           upName
-------- ----             ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------
eastus   clusterName        08/09/2023 18:33:54 user				            User              08/09/2023 20:05:43      user 		                            User			         RGName
```

This command gets a cluster by name.

### Example 3: List clusters by resource group
```powershell
Get-AzNetworkCloudCluster -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
-------- ----             ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ----------------------------
eastus   clusterNames        08/04/2023 22:38:51 user                                        User            08/07/2023 01:32:39             user                                   User
```

This command lists all clusters in a resource group.
