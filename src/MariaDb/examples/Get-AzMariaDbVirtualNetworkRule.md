### Example 1: List all virtual network rule under a MariaDB
```powershell
<<<<<<< HEAD
Get-AzMariaDbVirtualNetworkRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-9pebvn
```

```output
=======
PS C:\> Get-AzMariaDbVirtualNetworkRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-9pebvn

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name            Type
----            ----
vnetrule-QdMJpU Microsoft.DBforMariaDB/servers/virtualNetworkRules
vnetrule-Adsefc Microsoft.DBforMariaDB/servers/virtualNetworkRules
```

This command lists all virtual network rule under a MariaDB.

### Example 2: Get virtual network rule under a MariaDB
```powershell
<<<<<<< HEAD
Get-AzMariaDbVirtualNetworkRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-9pebvn -Name vnetrule-QdMJpU
```

```output
=======
PS C:\> Get-AzMariaDbVirtualNetworkRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-9pebvn -Name vnetrule-QdMJpU

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name            Type
----            ----
vnetrule-QdMJpU Microsoft.DBforMariaDB/servers/virtualNetworkRules
```

This command gets virtual network rule under a MariaDB.

