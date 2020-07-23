### Example 1: Create a replica db for a MariaDB
```powershell
PS C:\> New-AzMariaDbServerReplica -ServerName mariadb-test-9pebvn -Name mariadb-test-9pebvn-rep01 -ResourceGroupName mariadb-test-qu5ov0

Name                      Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----                      -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mariadb-test-9pebvn-rep01 eastus   xpwjyfdgui         10.2    7168                    GP_Gen5_4         GeneralPurpose Enabled
```

This command creates a replica db for a MariaDB.

### Example 2: Create a replica db for a MariaDB
```powershell
PS C:\> Get-AzMariaDbServer -Name mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0 | New-AzMariaDbServerReplica -Name mariadb-test-9pebvn-rep02

Name                      Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----                      -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mariadb-test-9pebvn-rep02 eastus   xpwjyfdgui         10.2    7168                    GP_Gen5_4         GeneralPurpose Enabled
```

This command creates a replica db for a MariaDB.

### Example 3: Create a replica db for a MariaDB
```powershell
PS C:\> $mariaDb = Get-AzMariaDbServer -Name mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0 
PS C:\> New-AzMariaDbServerReplica -InputObject $mariaDb -Name mariadb-test-9pebvn-rep03

Name                      Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----                      -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mariadb-test-9pebvn-rep03 eastus   xpwjyfdgui         10.2    7168                    GP_Gen5_4         GeneralPurpose Enabled
```

This command with parameter inputobject creates a replica db with parameter inputobject for a MariaDB.

