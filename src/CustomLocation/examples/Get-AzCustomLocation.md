### Example 1: List the details of the customLocation.
```powershell
<<<<<<< HEAD
Get-AzCustomLocation
```

```output
=======
PS C:\> Get-AzCustomLocation

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

List the details of the customLocation.

### Example 2: List the details of the customLocation with a specified resource group.
```powershell
<<<<<<< HEAD
Get-AzCustomLocation -ResourceGroupName azps_test_group
```

```output
=======
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

List the details of the customLocation with a specified resource group.

### Example 3: Gets the details of the customLocation with a specified resource group and name.
```powershell
<<<<<<< HEAD
Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster
```

```output
=======
PS C:\> Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

Gets the details of the customLocation with a specified resource group and name.

### Example 4: Gets the details of the customLocation.
```powershell
<<<<<<< HEAD
New-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster -Location eastus -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -Namespace arc | Get-AzCustomLocation
```

```output
=======
PS C:\> New-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster -Location eastus -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -Namespace arc | Get-AzCustomLocation

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

Gets the details of the customLocation.