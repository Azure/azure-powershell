### Example 1: Add a new database to PostgreSQL server.
```powershell
New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql -Name testdb -Charset utf8 -Collation en_US.utf8
```

```output
Name   Charset Collation
----   ------- ---------
testdb UTF8    en_US.utf8
```

Add a new database to PostgreSQL server.
