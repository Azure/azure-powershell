### Example 1: Trigger the execution of a runtime protection scan to detect and remediate detected issues, in accordance with the cluster configuration
```powershell
Invoke-AzNetworkCloudScanClusterRuntime -ResourceGroupName resourceGroupName -ClusterName clusterName -SubscriptionId subscriptionId -ScanActivity "Scan"
```

This command triggers the execution of a runtime protection scan to detect and remediate detected issues, in accordance with the cluster configuration.