### Example 1: Delete a firewall rule of a mongo cluster
```powershell
Remove-AzDocumentDBFirewallRule -Name allow-azure -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

Delete a firewall rule from a mongo cluster by name.
