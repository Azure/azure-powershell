### Example 1: Get a firewall rule of a mongo cluster
```powershell
Get-AzDocumentDBFirewallRule -Name allow-azure -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name         ProvisioningState StartIPAddress EndIPAddress
----         ----------------- -------------- ------------
allow-azure  Succeeded         0.0.0.0        0.0.0.0
```

Get a single firewall rule of a mongo cluster by name.

### Example 2: List the firewall rules of a mongo cluster
```powershell
Get-AzDocumentDBFirewallRule -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name         ProvisioningState StartIPAddress EndIPAddress
----         ----------------- -------------- ------------
allow-azure  Succeeded         0.0.0.0        0.0.0.0
```

List all firewall rules of a mongo cluster.
