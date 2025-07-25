### Example 1: Get Cluster's bare metal machine key set
```powershell
Get-AzNetworkCloudBareMetalMachineKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -Name bareMetalMachineKeySetName -SubscriptionId subscriptionId
```
```output
Location Name                          SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                     AzureAsyncOperation
-------- ----                         ------------------- -------------------     ----------------------- ------------------------  ------------------------             ---------------------------- ----                                                     -------------------
EastUs   baremetalmachinekeysetname    05/30/2023 16:31:47 user1                   User                    05/30/2023 16:53:31      user1                                User                         microsoft.networkcloud/clusters/baremetalmachinekeysets
```

This command gets a bare metal machine key set of the provided cluster.

### Example 2: Get Cluster's bare metal machine key sets
```powershell
Get-AzNetworkCloudBareMetalMachineKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```
```output
Location Name                            SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                     AzureAsyncOperation
-------- ----                            ------------------- -------------------     ----------------------- ------------------------  ------------------------             ---------------------------- ----                                                     -------------------
EastUs   baremetalmachinekeysetname      05/30/2023 16:31:47 user1                   User                    05/30/2023 16:53:31      user1                                User                         microsoft.networkcloud/clusters/baremetalmachinekeysets
EastUs   baremetalmachinekeysetname1     05/30/2023 16:31:47 user1                   User                    05/30/2023 16:53:31      user1                                User                         microsoft.networkcloud/clusters/baremetalmachinekeysets
```

This command lists all bare metal machine key sets of the provided cluster.
