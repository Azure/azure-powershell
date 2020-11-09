### Example 1: Create a new MySql flexible server with parameters
```powershell
PS C:\> New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest \
-Location westus2 -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable

Creating new vnet {vnetName} in resource group {resourceGroupName}...
Creating new subnet {subnetName} in resource group {resourceGroupName} and delegating it to "Microsoft.DBforMySQL/flexibleServers"...
Creating MySQL server {serverName} in group {resourceGroupName}...
Your server is using sku 'Standard_B1ms' (paid tier). Please refer to https://aka.ms/mysql-pricing for pricing details.
Creating MySQL database {dbname}...
"connectionString": "mysql {dbname} --host {host} --user {username} --password={password}",
"databaseName": "flexibleserverdb",
"host": "{servername}.mysql.database.azure.com",
"id": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}",
"location": "West US 2",
"version": "5.7",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_B1ms"
```

The cmdlet generates a server with the given parameters and output important information in a visible format. The server creation automatically generates vnet, subnet, and database in the resource group.

### Example 2: Create a new MySql flexible server without parameters
```powershell
PS C:\> New-AzMySqlFlexibleServer

Creating Resource Group {resourceGroupName}...
Creating new vnet {vnetName} in resource group {resourceGroupName}...
Creating new subnet {subnetName} in resource group {resourceGroupName} and delegating it to "Microsoft.DBforMySQL/flexibleServers"...
Creating MySQL server {serverName} in group {resourceGroupName}...
Your server is using sku 'Standard_B1ms' (paid tier). Please refer to https://aka.ms/mysql-pricing for pricing details.
Creating MySQL database {dbname}...
"connectionString": "mysql {dbname} --host {host} --user {username} --password={password}",
"databaseName": "flexibleserverdb",
"host": "{servername}.mysql.database.azure.com",
"id": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}",
"location": "West US 2",
"version": "5.7",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_B1ms"
```

When no parameters are given, the cmdlet automatically generates necessary resources such as resource group, vnet, and database. The SKU and storage profile are set to default values. 

### Example 3: Create a new MySql flexible server with public access to all IPs
```powershell
PS C:\> New-AzMySqlFlexibleServer -PublicAccess all

Creating Resource Group {resourceGroupName}...
Configurint server firewall rule to accept connections from '0.0.0.0' to '255.255.255.255'...
Creating MySQL server {serverName} in group {resourceGroupName}...
Your server is using sku 'Standard_B1ms' (paid tier). Please refer to https://aka.ms/mysql-pricing for pricing details.
Creating MySQL database {dbname}...
"connectionString": "mysql {dbname} --host {host} --user {username} --password={password}",
"firewallName": "{firewallRuleName}",
"databaseName": "flexibleserverdb",
"host": "{serverName}.mysql.database.azure.com",
"id": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}",
"location": "West US 2",
"version": "5.7",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_B1ms"
```

The cmdlet generates a server without given parameters and automatically generates necessary resources such as resource group, subnet, and database. The SKU and storage profile are set to default values.
