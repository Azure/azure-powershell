### Example 1: Update MariaDB virtual network rule
```powershell
$vnet = Get-AzVirtualNetwork -Name vnet -ResourceGroupName mariadb-test-qu5ov0
Update-AzMariaDbVirtualNetworkRule -ServerName mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0 -Name vnetrule-QdMJpU -SubnetId $vnet.Subnets[0].Id -IgnoreMissingVnetServiceEndpoint
```

```output
Name            Type
----            ----
vnetrule-QdMJpU Microsoft.DBforMariaDB/servers/virtualNetworkRules
```

This command updates a virtual network rule.


