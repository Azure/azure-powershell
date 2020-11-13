### Example 1: Update PostgreSql server by resource group and server name
```powershell
PS C:\> Update-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -Sku Standard_D4s_v3

Name                Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----               -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test-11 eastus   PostgreSql_test     12     5120                    Standard_D4s_v3 GeneralPurpose
```

This cmdlet updates PostgreSql server by resource group and server name.

### Example 2: Update PostgreSql server by identity.
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test | Update-AzPostgreSqlFlexibleServer -BackupRetentionDay 23 -StorageMb 10240

Name            Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----            -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test-11 eastus PostgreSql_test   12     10240                    Standard_D2ds_v4 GeneralPurpose
```

This cmdlet updates PostgreSql server by identity.
