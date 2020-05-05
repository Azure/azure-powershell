### Example 1: Create a new MySql server replica
```powershell
PS C:\> Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | New-AzMySqlServerReplica -Name mysql-test-replica -ResourceGroupName PowershellMySqlTest

Name               Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----               -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test-replica eastus   mysql_test         5.7     10240                   GP_Gen5_4         GeneralPurpose Disabled
```

This cmdlet creates a new MySql server replica.