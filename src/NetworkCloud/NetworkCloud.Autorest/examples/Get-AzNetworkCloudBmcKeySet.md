### Example 1: List Cluster's baseboard management controller key sets
```powershell
Get-AzNetworkCloudBmcKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -Name baseboardMgtControllerKeySetName -SubscriptionId subscriptionId
```
```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupNam
                                                                                                                                                                                      e
-------- ----        ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- ----------------
eastus   baseboardmgtcontrollerkeysetname  07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                  RG-name
```

This command gets a baseboard management controller key set of the provided cluster.

### Example 2: Get Cluster's baseboard management controller key set
```powershell
Get-AzNetworkCloudBmcKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```
```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupNam
                                                                                                                                                                                      e
-------- ----        ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- ----------------
eastus   baseboardmgtcontrollerkeysetname  07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                  RG-name
eastus   baseboardmgtcontrollerkeysetname  07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                  RG-name
```

This command lists all baseboard management controller key sets of the provided cluster.
