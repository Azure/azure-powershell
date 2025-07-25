### Example 1: Create a new MySql flexible server with arguments
```powershell
$password = ConvertTo-SecureString -String "1234" -Force -AsPlainText
New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest -Location eastus -AdministratorUserName mysqltest -AdministratorLoginPassword $password -Sku Standard_D2ds_v4 -SkuTier Burstable -Version 12 -StorageInMb 20480 -PublicAccess none -Zone 1 -BackupRetentionDay 10 -StorageAutogrow Enabled -Iops 500 -HighAvailability ZoneRedundant
```

```output
Checking the existence of the resource group PowershellMySqlTest ...
Resource group PowershellMySqlTest exists ? : True
Creating MySQL server mysql-test in group MySqlTest...
Your server mysql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/mysql-pricing for pricing details

Name         Location  SkuName             SkuTier           AdministratorLogin  Version StorageSizeGb
----         --------  -------             -------           ------------------  ------- -------------
mysql-test   East US   Standard_D2ds_v4    GeneralPurpose    admin                5.7     20

```

### Example 2: Create a new MySql flexible server with default setting
```powershell
New-AzMySqlFlexibleServer
```

```output
Creating resource group group00000000...
Creating new vnet VNETserver00000000 in resource group group00000000
Creating new subnet Subnetserver00000000 in resource group group00000000 and delegating it to Microsoft.DBforMySQL/flexibleServers
Creating MySQL server server00000000 in group group00000000...
Your server mysql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/mysql-pricing for pricing details
Creating database flexibleserverdb...

Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_B1ms    Burstable      admin              5.7     32
```
This cmdlet creates MySql flexible server with default parameter values and provision the server inside a new virtual network and have a subnet delegated to the server. The default values of location is West US 2, Sku is Standard_B1ms, Sku tier is Burstable, and storage size is 10GiB. 

If you want to find the auto-generated password for your server, use ConvertFrom-SecureString to convert 'SecuredPassword' property to plain text. 
(E.g., $server.SecuredPassword | ConvertFrom-SecureString -AsPlainText)

### Example 3: Create a new MySql flexible server with existing Subnet
```powershell
$Subnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetworks/vnetname/subnets/subnetname'
$DnsZone = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/postgresqltest/providers/Microsoft.Network/privateDnsZones/testserver.private.mysql.database.azure.com'
New-AzMySqlFlexibleServer  -ResourceGroupName postgresqltest -ServerName testserver -Subnet $Subnet -PrivateDnsZone $DnsZone
```

```output
Resource group PowershellPostgreSqlTest exists ? : True
You have supplied a subnet Id. Verifying its existence...
Creating PostgreSQL server testserver in group PowershellPostgreSqlTest...
Your server server00000000 is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...

Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_B1ms    Burstable      admin              5.7     32

```
This cmdlet creates PostgreSql flexible server with an existing Subnet Id provided by a user. The subnet will be delegated to PostgreSQL flexible server if not already delegated. You cannot use a subnet delegated to different services.

### Example 4: Create a new MySql flexible server with virtual network and subnet name
```powershell
$DnsZone = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/postgresqltest/providers/Microsoft.Network/privateDnsZones/testserver.private.mysql.database.azure.com'
New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest -Vnet mysql-vnet -Subnet mysql-subnet -VnetPrefix 10.0.0.0/16 -SubnetPrefix 10.0.0.0/24 -PrivateDnsZone $DnsZone
```

```output
Resource group PowershellMySqlTest exists ? : True
Creating new vnet mysql-vnet in resource group PowershellMySqlTest
Creating new subnet mysql-subnet in resource group PowershellMySqlTest and delegating it to Microsoft.DBforMySQL/flexibleServers
Creating MySQL server mysql-test in group PowershellMySqlTest...
Your server mysql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/mysql-pricing for pricing details
Creating database flexibleserverdb...

Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_B1ms    Burstable      admin              5.7     32

```
This cmdlet creates MySql flexible server with vnet name, subnet name, vnet prefix, and subnet prefix. If the virtual network and subnet don't exist, the cmdlet creates one.


### Example 5: Create a new MySql flexible server with virtual network
```powershell
$Vnet = 'vnetname'
$DnsZone = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/postgresqltest/providers/Microsoft.Network/privateDnsZones/testserver.private.mysql.database.azure.com'
New-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Vnet $Vnet -PrivateDnsZone $DnsZone

# or

$Vnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellMySqlTest/providers/Microsoft.Network/virtualNetworks/vnetname'
New-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Vnet $Vnet -PrivateDnsZone $DnsZone
```

```output
Resource group PowershellMySqlTest exists ? : True
You have supplied a vnet Id/name. Verifying its existence...
Creating new vnet vnetname in resource group PowershellMySqlTest
Creating new subnet Subnetserver00000000 in resource group PowershellMySqlTest and delegating it to Microsoft.DBforMySQL/flexibleServers
Creating MySQL server server00000000 in group PowershellMySqlTest...
Your server server00000000 is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/mysql-pricing for pricing details
Creating database flexibleserverdb...

Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_B1ms    Burstable      admin              5.7     32

```
This cmdlet creates MySql flexible server with vnet id or vnet name provided by a user. If the virtual network doesn't exist, the cmdlet creates one.


### Example 6: Create a new MySql flexible server with public access to all IPs
```powershell
New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest -PublicAccess All
```

```output
Resource group PowershellMySqlTest exists ? : True
Creating MySQL server mysql-test in group PowershellMySqlTest...
Your server mysql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/mysql-pricing for pricing details
Creating database flexibleserverdb...
Configuring server firewall rule to accept connections from 0.0.0.0 to 255.255.255.255

Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_B1ms    Burstable      admin              5.7     32
```
This cmdlet creates MySql flexible server open to all IP addresses. 

### Example 7: Create a new MySql flexible server with firewall
```powershell
New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest -PublicAccess 10.10.10.10-10.10.10.12
```

```output
Resource group PowershellMySqlTest exists ? : True
Creating MySQL server mysql-test in group PowershellMySqlTest...
Your server mysql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/mysql-pricing for pricing details
Creating database flexibleserverdb...
Configuring server firewall rule to accept connections from 10.10.10.10 to 10.10.10.12

Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_B1ms    Burstable      admin              5.7     32

```
This cmdlet creates MySql flexible server open to specified IP addresses. 
