### Example 1: Create a connected kubernetes
```powershell
PS C:\> New-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command creates a connected kubernetes.

### Example 1: Create a connected kubernetes with parameters kubeConfig and kubeContext
```powershell
PS C:\> New-AzConnectedKubernetes -ClusterName azps_test_cluster1 -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01

Location Name               ResourceGroupName
-------- ----               -----------------
eastus   azps_test_cluster1 azps_test_group
```

This command creates a connected kubernetes with parameters kubeConfig and kubeContext.