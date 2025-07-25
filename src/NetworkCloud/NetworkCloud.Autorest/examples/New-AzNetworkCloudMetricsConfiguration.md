### Example 1: Create Cluster's metrics configuration
```powershell
New-AzNetworkCloudMetricsConfiguration -ClusterName clusterName -MetricsConfigurationName default -ResourceGroupName resourceGroupName -CollectionInterval 15 -ExtendedLocationName extendedLocationId -ExtendedLocationType CustomLocation -Location eastus -SubscriptionId subscriptionId
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------      ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus   default 07/14/2023 17:09:29           user1                 User             07/14/2023 17:09:38      app1                                    Application                  resourceGroup
```

This command creates a metrics configuration for the provided Cluster.
