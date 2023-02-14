### Example 1: Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.
```powershell
<<<<<<< HEAD
Update-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster_1 -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -Namespace arc
```

```output
=======
PS C:\> Update-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster_1 -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -Namespace arc

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                Namespace
-------- ----                ----
eastus   azps_test_cluster_1 arc
```

Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.

### Example 2: Updates a Custom Location.
```powershell
<<<<<<< HEAD
Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster | Update-AzCustomLocation
```

```output
=======
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster | Update-AzCustomLocation

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                Namespace
-------- ----                ----
eastus   azps_test_cluster_1 arc
```

Updates a Custom Location.