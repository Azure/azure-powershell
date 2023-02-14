### Example 1: Restore a PointInTime MariaDB by server name.
```powershell
<<<<<<< HEAD
Restore-AzMariaDbServer -Name restore-db01 -ServerName mariadb-test-usegeo -ResourceGroupName mariadb-test-4rih5z -RestorePointInTime $(Get-Date) -Location eastus
```

```output
=======
PS C:\> Restore-AzMariaDbServer -Name restore-db01 -ServerName mariadb-test-usegeo -ResourceGroupName mariadb-test-4rih5z -UsePointInTimeRestore -RestorePointInTime $(Get-Date) -Location eastus

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name         Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----         -------- ------------------ ------- ----------------------- -------   -------        --------------
restore-db01 eastus   adminuser          10.2    5120                    GP_Gen5_4 GeneralPurpose Enabled
```

This command restore a PointInTime MariaDB by server name.

### Example 2: Restore a PointInTime MariaDB by server object
```powershell
<<<<<<< HEAD
$db = Get-AzMariaDbServer -Name mariadb-test-usegeo -ResourceGroupName mariadb-test-4rih5z
Restore-AzMariaDbServer -Name restore-db02 -InputObject $db -RestorePointInTime $(Get-Date) -Location eastus
```

```output
=======
PS C:\> $db = Get-AzMariaDbServer -Name mariadb-test-usegeo -ResourceGroupName mariadb-test-4rih5z
PS C:\>Restore-AzMariaDbServer -Name restore-db02 -InputObject $db -UsePointInTimeRestore -RestorePointInTime $(Get-Date) -Location eastus

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name         Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----         -------- ------------------ ------- ----------------------- -------   -------        --------------
restore-db02 eastus   adminuser          10.2    5120                    GP_Gen5_4 GeneralPurpose Enabled
```

This command restore a PointInTime MariaDB by server object.


