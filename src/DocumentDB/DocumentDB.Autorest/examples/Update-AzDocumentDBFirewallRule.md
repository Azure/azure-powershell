### Example 1: Update a firewall rule of a mongo cluster
```powershell
Update-AzDocumentDBFirewallRule -Name allow-azure -MongoClusterName myCluster -ResourceGroupName myResourceGroup `
    -StartIPAddress 0.0.0.0 -EndIPAddress 255.255.255.255
```

```output
Name         ProvisioningState StartIPAddress EndIPAddress
----         ----------------- -------------- ---------------
allow-azure  Succeeded         0.0.0.0        255.255.255.255
```

Update the address range of an existing firewall rule on a mongo cluster.
