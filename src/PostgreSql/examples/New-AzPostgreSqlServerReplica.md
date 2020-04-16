### Example 1: Create a new PostgreSql server replica
```powershell
PS C:\> Get-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer | New-AzPostgreSqlServerReplica -Name PostgreSqlTestServerReplica -ResourceGroupName PostgreSqlTestRG

Name                        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----                        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
postgresqltestserverreplica eastus   pwsh               9.6     5120                    GP_Gen5_4         GeneralPurpose Enabled
```

This cmdlet creates a new PostgreSql server replica.