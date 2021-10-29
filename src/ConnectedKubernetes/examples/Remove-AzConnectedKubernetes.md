### Example 1: Remove a connected kubernetes
```powershell
PS C:\> Remove-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group

```

This command removes a connected kubernetes

### Example 2: Remove a connected kubernetes by object
```powershell
PS C:\> $connaks = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group
PS C:\> Remove-AzConnectedKubernetes -InputObject $connaks

```

This command removes a connected kubernetes by object