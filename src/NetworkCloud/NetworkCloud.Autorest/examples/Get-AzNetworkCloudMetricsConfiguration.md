### Example 1: List Cluster's metrics configuration
```powershell
Get-AzNetworkCloudMetricsConfiguration -ClusterName clusterName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------      ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus   default 07/14/2023 17:09:29    user1                           User            07/14/2023 17:09:38      app1                                   Application              resourceGroupName
```

This command lists all metrics configurations of the provided Cluster.

### Example 2: Get Cluster's metrics configuration
```powershell
Get-AzNetworkCloudMetricsConfiguration -ClusterName clusterName -ResourceGroupName resourceGroupName -Name metricsConfigName -SubscriptionId subscriptionId
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------      ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus   default 07/14/2023 17:09:29    user1                    User                  07/14/2023 17:09:38      app1                                     Application              resourceGroupName
```

This command gets details of a specific metrics configuration for the provided Cluster.
