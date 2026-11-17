### Example 1: Delete a pool firewall rule
```powershell
Remove-AzHorizonDbFirewallRule -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -Name 'example-firewall-rule-01'
```

Deletes the specified firewall rule after confirmation.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
