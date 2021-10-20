### Example 1: Restore MySql server using PointInTime Restore
```powershell
PS C:\> $restorePointInTime = (Get-Date).AddMinutes(-10)
PS C:\> Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Restore-AzMySqlFlexibleServer -Name mysql-test-restore -ResourceGroupName PowershellMySqlTest -RestorePointInTime $restorePointInTime 

Name                 Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----                 --------  -------          -------        ------------------ ------- -------------
mysql-test-restore   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

These cmdlets restore MySql server using PointInTime Restore.


### Example 2: Restore public access MySql server to private access
```powershell
PS C:\> $restorePointInTime = (Get-Date).AddMinutes(-10)
PS C:\> Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Restore-AzMySqlFlexibleServer -Name mysql-test-restore -ResourceGroupName PowershellMySqlTest -RestorePointInTime $restorePointInTime -Subnet <SubnetId> -PrivateDnsZone <PrivateDnsZoneId>

Name                 Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----                 --------  -------          -------        ------------------ ------- -------------
mysql-test-restore   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

These cmdlets restore MySql server using PointInTime Restore from public access server to private access server.
