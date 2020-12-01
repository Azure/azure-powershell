### Example 1: Restore MySql server using PointInTime Restore
```powershell
PS C:\> $restorePointInTime = (Get-Date).AddMinutes(-10)
PS C:\> Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Restore-AzMySqlFlexibleServer -Name mysql-test-restore -ResourceGroupName PowershellMySqlTest -RestorePointInTime $restorePointInTime 

Name               Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier       
----               -------- ------------------ ------- ----------------------- -------   -------       
mysql-test-restore eastus   mysql_test         5.7     10240                   Standard_D2ds_v4 GeneralPurpose
```

These cmdlets restore MySql server using PointInTime Restore.
