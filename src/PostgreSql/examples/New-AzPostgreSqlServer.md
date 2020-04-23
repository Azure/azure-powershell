### Example 1: Create a new PostgreSql server
```powershell
PS C:\> New-AzPostgreSqlServer -Name PostgreSqlTestServer -ResourceGroupName PostgreSqlTestRG -Location eastus -AdministratorUserName pwsh -AdministratorLoginPassword $password -Sku GP_Gen5_4

Name                 Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----                 -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
postgresqltestserver eastus   pwsh               9.6     5120                    GP_Gen5_4         GeneralPurpose Enabled
```

These cmdlets create a new PostgreSql server.