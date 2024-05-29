### Example 1: List all virtual network rule under a MariaDB
```powershell
Get-AzMariaDbVirtualNetworkRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-9pebvn
```

```output
Name            Type
----            ----
vnetrule-QdMJpU Microsoft.DBforMariaDB/servers/virtualNetworkRules
vnetrule-Adsefc Microsoft.DBforMariaDB/servers/virtualNetworkRules
```

This command lists all virtual network rule under a MariaDB.

### Example 2: Get virtual network rule under a MariaDB
```powershell
Get-AzMariaDbVirtualNetworkRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-9pebvn -Name vnetrule-QdMJpU
```

```output
Name            Type
----            ----
vnetrule-QdMJpU Microsoft.DBforMariaDB/servers/virtualNetworkRules
```

This command gets virtual network rule under a MariaDB.

