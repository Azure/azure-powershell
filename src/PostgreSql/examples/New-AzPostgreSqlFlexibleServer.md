### Example 1: Create a new PostgreSql flexible server with arguments
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest \
-Location eastus -AdministratorUserName mysqltest -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable -Version 12 -StorageInMb 10240 -PublicAccess none

Checking the existence of the resource group PowershellPostgreSqlTest ...
Resource group PowershellPostgreSqlTest exists ? : True
Creating MySQL server postgresql-test in group PostgreSqlTest...
Your server postgresql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details


"databaseName": "flexibleserverdb",
"id": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test",
"location": "westus2",
"password": "***************",
"resourceGroup": "PostgreSqlTest",
"skuname": "Standard_B1ms",
"username": "mysqltest",
"version": "5.7"

```


### Example 2: Create a new PostgreSql flexible server with default setting
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer

Creating resource group group00000000...
Creating new vnet VNETserver00000000 in resource group group00000000
Creating new subnet Subnetserver00000000 in resource group group00000000 and delegating it to Microsoft.DBforMySQL/flexibleServers
Creating MySQL server server00000000 in group group00000000...
Your server postgresql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...

"databaseName": "flexibleserverdb",
"id": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/group00000000/providers/Microsoft.DBForPostgreSql/flexibleServers/server00000000",
"location": "westus2",
"password": "***************",
"resourceGroup": "group00000000",
"skuname": "Standard_B1ms",
"username": "seemlyHyena2",
"version": "5.7"
```
This cmdlet creates PostgreSql flexible server with default parameter values and provision the server inside a new virtual network and have a subnet delegated to the server. The default values of location is West US 2, Sku is Standard_B1ms, Sku tier is Burstable, and storage size is 10GiB. 

### Example 3: Create a new PostgreSql flexible server with virtual network
```powershell
PS C:\> $Vnet = 'vnetname'
PS C:\> New-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Vnet $Vnet

or

PS C:\> $Vnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetworks/vnetname'
PS C:\> New-AzPostgreSqlFlexibleServer  -ResourceGroupName PowershellPostgreSqlTest -Vnet $Vnet

Resource group PowershellPostgreSqlTest exists ? : True
You have supplied a vnet Id/name. Verifying its existence...
Creating new vnet vnetname in resource group PowershellPostgreSqlTest
Creating new subnet Subnetserver00000000 in resource group PowershellPostgreSqlTest and delegating it to Microsoft.DBforMySQL/flexibleServers
Creating MySQL server server00000000 in group PowershellPostgreSqlTest...
Your server server00000000 is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...

"databaseName": "flexibleserverdb",
"id": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test",
"location": "westus2",
"password": "***************",
"resourceGroup": "PowershellPostgreSqlTest",
"skuname": "Standard_B1ms",
"username": "seemlyHyena2",
"version": "5.7"
"subnetId": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetwork/vnetname/subnets/Subnetserver00000000"

```
This cmdlet creates PostgreSql flexible server with vnet id or vnet name provided by a user. If the virtual network doesn't exist, the cmdlet creates one.

### Example 4: Create a new PostgreSql flexible server with virtual network and subnet name
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -Vnet postgresql-vnet -Subnet postgresql-subnet -VnetPrefix 10.0.0.0/16 -SubnetPrefix 10.0.0.0/24

Resource group PowershellPostgreSqlTest exists ? : True
Creating new vnet postgresql-vnet in resource group PowershellPostgreSqlTest
Creating new subnet postgresql-subnet in resource group PowershellPostgreSqlTest and delegating it to Microsoft.DBforMySQL/flexibleServers
Creating MySQL server postgresql-test in group PowershellPostgreSqlTest...
Your server postgresql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...

"databaseName": "flexibleserverdb",
"id": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test",
"location": "westus2",
"password": "***************",
"resourceGroup": "PowershellPostgreSqlTest",
"skuname": "Standard_B1ms",
"username": "seemlyHyena2",
"version": "5.7"
"subnetId": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetwork/postgresql-vnet/subnets/postgresql-subnet"

```
This cmdlet creates PostgreSql flexible server with vnet name, subnet name, vnet prefix, and subnet prefix. If the virtual network and subnet don't exist, the cmdlet creates one.

### Example 7: Create a new PostgreSql flexible server with public access to all IPs
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -PublicAccess All

Resource group PowershellPostgreSqlTest exists ? : True
Creating MySQL server postgresql-test in group PowershellPostgreSqlTest...
Your server postgresql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...
Configuring server firewall rule to accept connections from 0.0.0.0 to 255.255.255.255

"databaseName": "flexibleserverdb",
"id": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test",
"location": "westus2",
"password": "***************",
"resourceGroup": "PowershellPostgreSqlTest",
"skuname": "Standard_B1ms",
"username": "seemlyHyena2",
"version": "5.7"
"firewallName": "AllowAll_2020_00_00-00_00-00-00"
```
This cmdlet creates PostgreSql flexible server open to all IP addresses. 

### Example 8: Create a new PostgreSql flexible server with firewall
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -PublicAccess 10.10.10.10-10.10.10.12

Resource group PowershellPostgreSqlTest exists ? : True
Creating MySQL server postgresql-test in group PowershellPostgreSqlTest...
Your server postgresql-test is using sku Standard_B1ms (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...
Configuring server firewall rule to accept connections from 10.10.10.10 to 10.10.10.12

"databaseName": "flexibleserverdb",
"id": "/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test",
"location": "westus2",
"password": "***************",
"resourceGroup": "PowershellPostgreSqlTest",
"skuname": "Standard_B1ms",
"username": "seemlyHyena2",
"version": "5.7"
"firewallName": "FirewallIPAddress__2020_00_00-00_00-00-00"

```
This cmdlet creates PostgreSql flexible server open to specified IP addresses. 
