### Example 1: List all databases on a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name        Charset Collation
----        ------- ---------
postgres    UTF8    en_US.utf8
myapp_db    UTF8    en_US.utf8
testdb      UTF8    en_US.utf8
```

Lists all databases on the specified PostgreSQL Flexible Server.

### Example 2: Get a specific database on a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -DatabaseName "myapp_db"
```

```output
Name     : myapp_db
Charset  : UTF8
Collation: en_US.utf8
Id       : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/flexibleServers/myPostgreSqlServer/databases/myapp_db
```

Retrieves detailed information about a specific database on the PostgreSQL Flexible Server.

