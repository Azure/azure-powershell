### Example 1: Create a new MySql server
```powershell
PS C:\> $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzMySqlServer -Name mysql-test -ResourceGroupName mysql_test -Location eastus -AdministratorLogin mysql_test -AdministratorLoginPassword $password -SkuName GP_Gen5_4

Name        Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----        -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mysql-test0 eastus   mysql_test         5.7     5120                    GP_Gen5_4         GeneralPurpose Enabled
```

These cmdlets create a new MySql server.

