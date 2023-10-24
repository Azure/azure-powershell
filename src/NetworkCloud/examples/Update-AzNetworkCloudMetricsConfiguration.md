### Example 1: Update Cluster's metrics configuration
```powershell
Update-AzNetworkCloudMetricsConfiguration -ClusterName clusterName -ResourceGroupName resourceGroupName -Name metricsConfigName -CollectionInterval 10 -EnabledMetric @("metric1", "metric2") -Tag @{tag1="tag1"}
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------      ----------------------- ------------------------ ------------------------    ---------------------------- ---------------
eastus   default 07/14/2023 17:09:29   user1                    User                    07/18/2023 22:10:29      app1                        Application                  resourceGroupName
```

This command update tags associated with the metrics configuration of the provided Cluster.
