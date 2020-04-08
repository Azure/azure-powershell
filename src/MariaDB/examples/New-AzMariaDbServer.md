### Example 1: Create a new MariaDB
```powershell
PS C:\> New-AzMariaDbServer -Name mariadb-aassd-01 -ResourceGroupName lucas-manual-test -Sku 'B_Gen5_1' -Location eastus
cmdlet New-AzMariaDbServer at command pipeline position 1
Supply values for the following parameters:
AdministratorUsername: adminuser
AdministratorLoginPassword: ************

Name             Location AdministratorLogin Version StorageProfileStorageMb SkuName  SkuSize SkuTier SslEnforcement
----             -------- ------------------ ------- ----------------------- -------  ------- ------- --------------
mariadb-aassd-01 eastus   adminuser          10.2    5120                    B_Gen5_1         Basic   Enabled
```

This command creates a new MariaDB.


