### Example 1: Update MariaDb configuration
```powershell
PS C:\> Update-AzMariaDbConfiguration -Name delayed_insert_timeout -ServerName mariadb-test-h3pame -ResourceGroupName mariadb-test-qu5ov0 -Value 200

Name                   Type
----                   ----
delayed_insert_timeout Microsoft.DBforMariaDB/servers/configurations
```

This command updates a MariaDb configuration.
