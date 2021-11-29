### Example 1: Remove a connected kubernetes
```powershell
PS C:\> Remove-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group

```

This command removes a connected kubernetes

### Example 2: Remove a connected kubernetes by object
```powershell
PS C:\> Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group | Remove-AzConnectedKubernetes

```

This command removes a connected kubernetes by object