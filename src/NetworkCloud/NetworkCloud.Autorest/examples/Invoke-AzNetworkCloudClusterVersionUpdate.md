### Example 1: Update cluster's version
```powershell
Invoke-AzNetworkCloudClusterVersionUpdate -ClusterName clusterName -ResourceGroupName resourceGroup -TargetClusterVersion targetClusterVersion -SubscriptionId subscriptionId -NoWait
```

```output
Target
------
https://asyncOperationStatusResponseUrl
```

This command updates the provided cluster's version to an available supported version.
