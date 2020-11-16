### Example 1: Create a new MySql server replica
```powershell
PS C:\> Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | New-AzMySqlFlexibleServerReplica -Replica mysql-test-replica -ResourceGroupName PowershellMySqlTest

Name               Location AdministratorLogin Version StorageProfileStorageMb SkuName       SkuTier        
----               -------- ------------------ ------- ----------------------- -------       -------        
mysql-test-replica westus2   mysql_test         5.7     10240                   Standard_B1ms Burstable
```

This cmdlet creates a new MySql server replica.

### Example 2: Create a new MySql server replica
```powershell
PS C:\> $mysql = Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
PS C:\> New-AzMySqlFlexibleServerReplica -Master $mysql -Replica mysql-test-replica -ResourceGroupName PowershellMySqlTest

Name               Location AdministratorLogin Version StorageProfileStorageMb SkuName       SkuTier        
----               -------- ------------------ ------- ----------------------- -------       -------        
mysql-test-replica westus2   mysql_test         5.7     10240                   Standard_B1ms Burstable
```

This cmdlet with parameter master(inputobject) creates a new MySql server replica.
