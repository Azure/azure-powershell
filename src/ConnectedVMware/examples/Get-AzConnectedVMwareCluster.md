### Example 1: List clusters in current subscription
```powershell
Get-AzConnectedVMwareCluster
```

```output
{{ Add output here }}
```

This command lists clusters in current subscription.

### Example 2: List clusters in a resource group
```powershell
Get-AzConnectedVMwareCluster -ResourceGroupName test-rg
```

```output
{{ Add output here }}
```

This command lists clusters in a resource group named `test-rg`.

### Example 3: Get a specific cluster
```powershell
Get-AzConnectedVMwareCluster -Name test-cluster -ResourceGroupName test-rg
```

```output
{{ Add output here }}
```

This command gets a cluster named `test-cluster` in a resource group named `test-rg`.