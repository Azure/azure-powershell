### Example 1: Add a new database to PostgreSQL server.
```powershell
<<<<<<< HEAD
New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql -Name testdb -Charset utf8 -Collation en_US.utf8
=======
 New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql -Name testdb -Charset utf8 -Collation en_US.utf8
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name   Charset Collation
----   ------- ---------
testdb UTF8    en_US.utf8
```

Add a new database to PostgreSQL server.
