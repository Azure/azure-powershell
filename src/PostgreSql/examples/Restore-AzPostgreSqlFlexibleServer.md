### Example 1: Restore PostgreSql server using PointInTime Restore
```powershell
PS C:\> $restorePointInTime = (Get-Date).AddMinutes(-10)
PS C:\> Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -Location eastus -RestorePointInTime $restorePointInTime 

Name           Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----           --------  -------         -------        ------------------ -------------
pg-restore     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

These cmdlets restore PostgreSql server using PointInTime Restore.

### Example 1: Restore PostgreSql server using PointInTime Restore with different network resource
```powershell

PS C:\> $Subnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetworks/vnetname/subnets/subnetname'
PS C:\> $DnsZone = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/postgresqltest/providers/Microsoft.Network/privateDnsZones/testserver.private.postgres.database.azure.com'
PS C:\> $restorePointInTime = (Get-Date).AddMinutes(-10)
PS C:\> Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -Location eastus -RestorePointInTime $restorePointInTime -Subnet $subnet -PrivateDnsZone $DnsZone

Name           Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----           --------  -------         -------        ------------------ -------------
pg-restore     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

These cmdlets restore PostgreSql server using PointInTime Restore.
