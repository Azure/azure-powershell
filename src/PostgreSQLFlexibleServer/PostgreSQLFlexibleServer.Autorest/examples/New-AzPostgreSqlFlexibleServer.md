### Example 1: Create a new PostgreSQL Flexible Server with basic configuration
```powershell
New-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -Location "East US" -AdministratorUserName "myadmin" -AdministratorLoginPassword (ConvertTo-SecureString "MySecurePassword123!" -AsPlainText -Force)
```

```output
Name               : myPostgreSqlServer
ResourceGroupName  : myResourceGroup
Location           : East US
SkuName            : Standard_D2s_v3
SkuTier            : GeneralPurpose
StorageSizeGb      : 128
Version            : 13
State              : Ready
FullyQualifiedDomainName : myPostgreSqlServer.postgres.database.azure.com
```

Creates a new PostgreSQL Flexible Server with default settings in the East US region.

### Example 2: Create a PostgreSQL Flexible Server with custom configuration
```powershell
$password = ConvertTo-SecureString "MyComplexPassword123!" -AsPlainText -Force
New-AzPostgreSqlFlexibleServer -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -Location "West Europe" -AdministratorUserName "pgadmin" -AdministratorLoginPassword $password -SkuName "Standard_D4s_v3" -SkuTier "GeneralPurpose" -StorageSizeGb 256 -Version "14" -BackupRetentionDay 30
```

```output
Name               : prod-postgresql-01
ResourceGroupName  : production-rg
Location           : West Europe
SkuName            : Standard_D4s_v3
SkuTier            : GeneralPurpose
StorageSizeGb      : 256
Version            : 14
State              : Ready
BackupRetentionDay : 30
FullyQualifiedDomainName : prod-postgresql-01.postgres.database.azure.com
```

Creates a production PostgreSQL Flexible Server with custom SKU, storage size, PostgreSQL version, and backup retention settings.

