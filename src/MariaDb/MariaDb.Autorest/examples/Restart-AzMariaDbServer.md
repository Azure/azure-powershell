### Example 1: Restart a MariaDB
```powershell
Restart-AzMariaDbServer -Name mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0
```

This command restart a MariaDB.

### Example 2: Restart a MariaDB
```powershell
Get-AzMariaDbServer -Name mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0 | Restart-AzMariaDbServer
```

This command restart a MariaDB.

