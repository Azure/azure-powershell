### Example 1: Update a connected kubernetes
```powershell
Update-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Tag @{'key'='1'}
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command updates a connected kubernetes.

### Example 2: Update a connected kubernetes by object
```powershell
Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group | Update-AzConnectedKubernetes -Tag @{'key'='2'}
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command updates a connected kubernetes by object.