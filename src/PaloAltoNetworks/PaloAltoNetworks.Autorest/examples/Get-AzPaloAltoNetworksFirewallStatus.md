### Example 1: Get a FirewallStatusResource.
```powershell
Get-AzPaloAltoNetworksFirewallStatus -FirewallName azps-firewall -ResourceGroupName azps_test_group_pan
```

```output
IsPanoramaManaged HealthStatus ProvisioningState ResourceGroupName
----------------- ------------ ----------------- -----------------
FALSE             GREEN        Succeeded
```

Get a FirewallStatusResource.