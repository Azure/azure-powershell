### Example 1: Create a firewall rule on a mongo cluster
```powershell
New-AzDocumentDBFirewallRule -Name allow-azure -MongoClusterName myCluster -ResourceGroupName myResourceGroup `
    -StartIPAddress 0.0.0.0 -EndIPAddress 0.0.0.0
```

```output
Name         ProvisioningState StartIPAddress EndIPAddress
----         ----------------- -------------- ------------
allow-azure  Succeeded         0.0.0.0        0.0.0.0
```

Create a firewall rule on a mongo cluster. The `0.0.0.0-0.0.0.0` range is the
convention that allows access from other Azure services.
