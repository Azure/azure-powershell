### Example 1: List the details of the customLocation.
```powershell
PS C:\> Get-AzCustomLocation

Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

List the details of the customLocation.

### Example 2: List the details of the customLocation with a specified resource group.
```powershell
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group

Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

List the details of the customLocation with a specified resource group.

### Example 3: Gets the details of the customLocation with a specified resource group and name.
```powershell
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster

Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

Gets the details of the customLocation with a specified resource group and name.

### Example 4: Gets the details of the customLocation.
```powershell
PS C:\> New-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster -Location eastus -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -Namespace arc | Get-AzCustomLocation

Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

Gets the details of the customLocation.