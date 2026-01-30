### Example 1: Remove a database from PostgreSQL Flexible Server
```powershell
Remove-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -DatabaseName "old_database"
```

Removes the specified database from the PostgreSQL Flexible Server. This operation permanently deletes the database and all its data.

### Example 2: Remove a database without confirmation prompt
```powershell
Remove-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName "development-rg" -ServerName "dev-postgresql-01" -DatabaseName "temp_testdb" -Force
```

Removes the database immediately without prompting for confirmation. Use with extreme caution as this operation cannot be undone.

