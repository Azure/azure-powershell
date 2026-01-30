### Example 1: Restart a PostgreSQL Flexible Server
```powershell
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

Restarts the specified PostgreSQL Flexible Server. This is required after certain configuration changes or to apply patches.

### Example 2: Restart a server with specific restart type
```powershell
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -RestartWithFailover
```

Restarts the PostgreSQL Flexible Server with failover enabled. This ensures high availability during the restart process for servers configured with zone redundancy.

