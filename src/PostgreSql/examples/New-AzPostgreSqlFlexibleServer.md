### Example 1: Create a new PostgreSql flexible server with parameters
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest \
-Location eastus -AdministratorUserName postgresqltest -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable

Creating new vnet {vnetName} in resource group {resourceGroupName}...
Creating new subnet {subnetName} in resource group {resourceGroupName} and delegating it to "Microsoft.DBforPostgreSQL/flexibleServers"...
Creating PostgreSql server {serverName} in group {resourceGroupName}...
Your server is using sku 'Standard_B1ms' (paid tier). Please refer to https://aka.ms/postgresql-pricing for pricing details.
Creating PostgreSql database {dbname}...
"connectionString": "postgresql://{username}:{password}@{servername}.postgres.database.azure.com/postgres?sslmode=require",
"databaseName": "{dbname}",
"host": "{servername}.PostgreSql.database.azure.com",
"id": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreS!L/flexibleServers/{serverName}",
"location": "East US",
"version": "12",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_B1ms"
```

The cmdlet generates a server with the given parameters and output important information in a visible format. The server creation automatically generates vnet, subnet, and database in the resource group.

### Example 2: Create a new PostgreSql flexible server without parameters
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer

Creating Resource Group {resourceGroupName}...
Creating new vnet {vnetName} in resource group {resourceGroupName}...
Creating new subnet {subnetName} in resource group {resourceGroupName} and delegating it to "Microsoft.DBforPostgreSql/flexibleServers"...
Creating PostgreSql server {serverName} in group {resourceGroupName}...
Your server is using sku 'Standard_D2s_v3' (paid tier). Please refer to https://aka.ms/postgresql-pricing for pricing details.
Creating PostgreSql database {dbname}...
"connectionString": "postgresql://{username}:{password}@{servername}.postgres.database.azure.com/postgres?sslmode=require",
"databaseName": "flexibleserverdb",
"host": "{servername}.PostgreSql.database.azure.com",
"id": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSql/flexibleServers/{serverName}",
"location": "East US",
"version": "12",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_D2s_v3"
```

When no parameters are given, the cmdlet automatically generates necessary resources such as resource group, vnet, and database. The SKU and storage profile are set to default values. 

### Example 3: Create a new PostgreSql flexible server with public access to all IPs
```powershell
PS C:\> New-AzPostgreSqlFlexibleServer -PublicAccess all

Creating Resource Group {resourceGroupName}...
Configurint server firewall rule to accept connections from '0.0.0.0' to '255.255.255.255'...
Creating PostgreSql server {serverName} in group {resourceGroupName}...
Your server is using sku 'Standard_D2s_v3' (paid tier). Please refer to https://aka.ms/postgresql-pricing for pricing details.
Creating PostgreSql database {dbname}...
"connectionString": "postgresql://{username}:{password}@{servername}.postgres.database.azure.com/postgres?sslmode=require",
"firewallName": "{firewallRuleName}",
"databaseName": "flexibleserverdb",
"host": "{serverName}.PostgreSql.database.azure.com",
"id": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}",
"location": "East US",
"version": "12",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_D2s_v3"
```

The cmdlet generates a server without given parameters and automatically generates necessary resources such as resource group, subnet, and database. The SKU and storage profile are set to default values.
