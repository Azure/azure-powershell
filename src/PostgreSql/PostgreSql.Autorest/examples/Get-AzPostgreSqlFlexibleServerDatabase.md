### Example 1: Get databases of a PostgreSql server
```powershell
Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test
```

```output
Name              Charset Collation
----              ------- ---------
azure_maintenance UTF8    en_US.utf8
postgres          UTF8    en_US.utf8
azure_sys         UTF8    en_US.utf8
flexibleserverdb  UTF8    en_US.utf8
```

Get databases of a flexible server

### Example 2: Get a database of a PostgreSql server
```powershell
Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -Name flexibleserverdb
```

```output
Name             Charset Collation
----             ------- ---------
flexibleserverdb UTF8    en_US.utf8
```

Get a database of a flexible server by name

### Example 3: Get a database of a PostgreSql server
```powershell
Get-AzPostgreSqlFlexibleServerDatabase -InputObject /subscriptions/0000000000-0000-0000-0000-000000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/databases/flexibleserverdb
```

```output
Name             Charset Collation
----             ------- ---------
flexibleserverdb UTF8    en_US.utf8
```

Get a database of a flexible server by resource Id

