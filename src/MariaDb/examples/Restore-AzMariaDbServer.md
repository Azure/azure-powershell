### Example 1: Restore a PointInTime MariaDB by server name.
```powershell
PS C:\> Restore-AzMariaDbServer -Name restore-db01 -ServerName mariadb-test-usegeo -ResourceGroupName mariadb-test-4rih5z -UsePointInTimeRestore -RestorePointInTime $(Get-Date) -Location eastus

Name         Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----         -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
restore-db01 eastus   adminuser          10.2    5120                    GP_Gen5_4         GeneralPurpose Enabled
```

This command restore a PointInTime MariaDB by server name.

### Example 2: Restore a PointInTime MariaDB by server object
```powershell
PS C:\> $db = Get-AzMariaDbServer -Name mariadb-test-usegeo -ResourceGroupName mariadb-test-4rih5z
PS C:\>Restore-AzMariaDbServer -Name restore-db02 -InputObject $db -UsePointInTimeRestore -RestorePointInTime $(Get-Date) -Location eastus

Name         Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----         -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
restore-db02 eastus   adminuser          10.2    5120                    GP_Gen5_4         GeneralPurpose Enabled
```

This command restore a PointInTime MariaDB by server object.


