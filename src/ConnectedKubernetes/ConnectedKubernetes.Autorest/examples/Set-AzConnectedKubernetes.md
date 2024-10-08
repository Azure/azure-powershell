### Example 1: Disable gateway feature of a connected kubernetes.
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -DisableGateway
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernetes.

### Example 2: Enable gateway feature of connected kubernetes.
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -GatewayResourceId gatewayResourceId

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernetes.

