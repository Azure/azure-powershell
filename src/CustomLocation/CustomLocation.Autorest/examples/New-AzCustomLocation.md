### Example 1: Creates or updates a Custom Location in the specified Subscription and Resource Group
```powershell
PS C:\> New-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster -Location eastus -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -Namespace arc

Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

Creates or updates a Custom Location in the specified Subscription and Resource Group