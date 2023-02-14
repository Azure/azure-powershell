### Example 1: Update MariaDB configuration
```powershell
<<<<<<< HEAD
Update-AzMariaDbConfiguration -Name delayed_insert_timeout -Value 200 -ServerName mariadb-test-h3pame -ResourceGroupName mariadb-test-qu5ov0 
```

```output
=======
PS C:\> Update-AzMariaDbConfiguration -Name delayed_insert_timeout -Value 200 -ServerName mariadb-test-h3pame -ResourceGroupName mariadb-test-qu5ov0 

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                   Type
----                   ----
delayed_insert_timeout Microsoft.DBforMariaDB/servers/configurations
```

This command updates a MariaDB configuration.
