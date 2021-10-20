### Example 1: Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.
```powershell
PS C:\> Update-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster_1 -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -DisplayName azps_test_cluster_1 -Namespace arc

Location Name                Type
-------- ----                ----
eastus   azps_test_cluster_1 Microsoft.ExtendedLocation/customLocations
```

Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.