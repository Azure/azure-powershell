### Example 1: Restore PostgreSql server using PointInTime Restore
```powershell
PS C:\> $restorePointInTime = (Get-Date).AddMinutes(-10)
PS C:\> Restore-AzPostgreSqlFlexibleServer -Name PostgreSql-test-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -Location westus2 -RestorePointInTime $restorePointInTime 

Name               Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier       
----               -------- ------------------ ------- ----------------------- -------   -------       
PostgreSql-test-restore eastus   postgresql_test         5.7     10240                   Standard_D2s_v3 GeneralPurpose
```

These cmdlets restore PostgreSql server using PointInTime Restore.
