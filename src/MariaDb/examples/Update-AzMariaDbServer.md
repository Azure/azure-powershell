### Example 1: Update MariaDb
```powershell
PS C:\> Update-AzMariaDbServer -Name mariadb-test-4rmtig -ResourceGroupName mariadb-test-qu5ov0 -StorageInMb 8192

Name                Location AdministratorLogin Version StorageProfileStorageMb SkuName  SkuSize SkuTier SslEnforcement
----                -------- ------------------ ------- ----------------------- -------  ------- ------- --------------
mariadb-test-4rmtig eastus   xofavpndqj         10.2    8192                    B_Gen5_1         Basic   Enabled
```

This command updates a MariaDb.

### Example 2: Update MariaDb
```powershell
PS C:\> Get-AzMariaDbServer -Name mariadb-test-4rmtig -ResourceGroupName mariadb-test-qu5ov0 | Update-AzMariaDbServer -StorageInMb (8192+1024)

Name                Location AdministratorLogin Version StorageProfileStorageMb SkuName  SkuSize SkuTier SslEnforcement
----                -------- ------------------ ------- ----------------------- -------  ------- ------- --------------
mariadb-test-4rmtig eastus   xofavpndqj         10.2    9216                    B_Gen5_1         Basic   Enabled
```

This command updates a MariaDb.

