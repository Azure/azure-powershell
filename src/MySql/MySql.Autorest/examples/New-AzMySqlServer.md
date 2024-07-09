### Example 1: Create a new MySql server
```powershell
$password = ConvertTo-SecureString -String "1234" -Force -AsPlainText
New-AzMySqlServer -Name mysql-test -ResourceGroupName PowershellMySqlTest -Location eastus -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku GP_Gen5_4
```

```output
Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        ------------
mysql-test    eastus   mysql_test         5.7     5120                    GP_Gen5_4 GeneralPurpose Enabled
```

These cmdlets create a new MySql server.
