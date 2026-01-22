### Example 1: Update database charset and collation
```powershell
Update-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -DatabaseName "myapp_db" -Charset "UTF8" -Collation "en_US.utf8"
```

```output
Name     : myapp_db
Charset  : UTF8
Collation: en_US.utf8
Id       : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/flexibleServers/myPostgreSqlServer/databases/myapp_db
```

Updates the charset and collation settings for an existing database on the PostgreSQL Flexible Server.

### Example 2: Update database for internationalization
```powershell
Update-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "global-rg" -ServerName "global-postgresql-01" -DatabaseName "international_db" -Charset "UTF8" -Collation "C.UTF-8"
```

```output
Name     : international_db
Charset  : UTF8
Collation: C.UTF-8
Id       : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/global-rg/providers/Microsoft.DBforPostgreSQL/flexibleServers/global-postgresql-01/databases/international_db
```

Updates the database to use a more universal collation suitable for international applications.

