### Example 1: Create a new database on a PostgreSQL Flexible Server
```powershell
New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -DatabaseName "myapp_db"
```

```output
Name     : myapp_db
Charset  : UTF8
Collation: en_US.utf8
Id       : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/flexibleServers/myPostgreSqlServer/databases/myapp_db
```

Creates a new database with default UTF8 charset and en_US.utf8 collation.

### Example 2: Create a database with custom charset and collation
```powershell
New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -DatabaseName "analytics_db" -Charset "UTF8" -Collation "en_US.utf8"
```

```output
Name     : analytics_db
Charset  : UTF8
Collation: en_US.utf8
Id       : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/production-rg/providers/Microsoft.DBforPostgreSQL/flexibleServers/prod-postgresql-01/databases/analytics_db
```

Creates a new database with explicitly specified charset and collation settings.

