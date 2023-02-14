### Example 1: Restore PostgreSql server using PointInTime Restore
```powershell
$restorePointInTime = (Get-Date).AddMinutes(-10)
<<<<<<< HEAD
Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -RestorePointInTime $restorePointInTime 
=======
Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -Location eastus -RestorePointInTime $restorePointInTime 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name           Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----           --------  -------         -------        ------------------ -------------
pg-restore     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

These cmdlets restore PostgreSql server using PointInTime Restore.

### Example 1: Restore PostgreSql server using PointInTime Restore with different network resource
```powershell

$Subnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetworks/vnetname/subnets/subnetname'
$DnsZone = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/postgresqltest/providers/Microsoft.Network/privateDnsZones/testserver.private.postgres.database.azure.com'
<<<<<<< HEAD
$restorePointInTime = (Get-Date).AddMinutes(-10)
Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -RestorePointInTime $restorePointInTime -Subnet $subnet -PrivateDnsZone $DnsZone
=======
 $restorePointInTime = (Get-Date).AddMinutes(-10)
 Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -Location eastus -RestorePointInTime $restorePointInTime -Subnet $subnet -PrivateDnsZone $DnsZone
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name           Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----           --------  -------         -------        ------------------ -------------
pg-restore     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

These cmdlets restore PostgreSql server using PointInTime Restore.
