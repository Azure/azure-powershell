### Example 1: Update a pool firewall rule
```powershell
Update-AzHorizonDbFirewallRule -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -Name 'example-firewall-rule-01' -StartIPAddress '10.0.0.1' -EndIPAddress '10.0.0.254' -Description 'Allow access from the corporate network' | Format-List -Property Name, StartIPAddress, EndIPAddress, Description, ProvisioningState
```

```output
Name              : example-firewall-rule-01
StartIPAddress    : 10.0.0.1
EndIPAddress      : 10.0.0.254
Description       : Allow access from the corporate network
ProvisioningState : Updating
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
