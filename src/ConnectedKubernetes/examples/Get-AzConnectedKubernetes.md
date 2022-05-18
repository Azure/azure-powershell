### Example 1: Get all connected kubernetes under a subscription
```powershell
Get-AzConnectedKubernetes
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus   azps_test_cluster  azps_test_group
eastus   azps_test_cluster1 azps_test_group
eastus   azps_test_cluster2 azps_test_group
```

This command gets all connected kubernetes under a subscription.

### Example 2: Get all connected kubernetes under the resource group
```powershell
Get-AzConnectedKubernetes -ResourceGroupName azps_test_group
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus   azps_test_cluster  azps_test_group
eastus   azps_test_cluster1 azps_test_group
eastus   azps_test_cluster2 azps_test_group
```

This command gets all connected kubernetes under the resource group.

### Example 3: Get a connected kubernetes
```powershell
Get-AzConnectedKubernetes -ResourceGroupName azps_test_group -Name azps_test_cluster
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command gets a connected kubernetes.

### Example 4: Get a connected kubernetes by object
```powershell
$conAks = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
Get-AzConnectedKubernetes -InputObject $conAks
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command gets a connected kubernetes by object.