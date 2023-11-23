### Example 1: Create a new MySql server replica
```powershell
Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | New-AzMySqlFlexibleServerReplica -Replica mysql-test-replica -ResourceGroupName PowershellMySqlTest
```

```output
Name                 Location  SkuName             SkuTier          AdministratorLogin Version StorageSizeGb
----                 --------  -------             -------          ------------------ ------- -------------
mysql-test-replica   West US 2 Standard_D2ds_v4    GeneralPurpose   admin              5.7     32
```

This cmdlet creates a new MySql server replica.

### Example 2: Create a new MySql server replica
```powershell
$mysql = Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
New-AzMySqlFlexibleServerReplica -Master $mysql -Replica mysql-test-replica -ResourceGroupName PowershellMySqlTest
```

```output
Name                 Location  SkuName             SkuTier          AdministratorLogin Version StorageSizeGb
----                 --------  -------             -------          ------------------ ------- -------------
mysql-test-replica   West US 2 Standard_D2ds_v4    GeneralPurpose   admin              5.7     32
```

This cmdlet with parameter master(inputobject) creates a new MySql server replica.
