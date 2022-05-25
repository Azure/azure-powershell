### Example 1: Create a new PostgreSql flexible server with arguments
```powershell
New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -Location eastus -AdministratorUserName postgresqltest -AdministratorLoginPassword $password -Sku Standard_D2s_v3 -SkuTier GeneralPurpose -Version 12 -StorageInMb 131072 -PublicAccess none
```

```output
Checking the existence of the resource group PowershellPostgreSqlTest ...
Resource group PowershellPostgreSqlTest exists ? : True
Creating PostgreSQL server postgresql-test in group PostgreSqlTest...
Your server postgresql-test is using sku Standard_D2s_v3 (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

### Example 2: Create a new PostgreSql flexible server with default setting
```powershell
$server = New-AzPostgreSqlFlexibleServer
```

```output
Creating resource group group00000000...
Creating PostgreSQL server server00000000 in group group00000000...
Your server postgresql-test is using sku Standard_D2s_v3 (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet creates PostgreSql flexible server with default parameter values and provision the server with public access enabled. The default values of location is East US 2, Sku is Standard_D2s_v3, Sku tier is GeneralPurpose, and storage size is 128GiB.

If you want to find the auto-generated password for your server, use ConvertFrom-SecureString to convert 'SecuredPassword' property to plain text. (E.g., $server.SecuredPassword | ConvertFrom-SecureString -AsPlainText)

### Example 3: Create a new PostgreSql flexible server with existing Subnet
```powershell
$Subnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetworks/vnetname/subnets/subnetname'
$DnsZone = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/postgresqltest/providers/Microsoft.Network/privateDnsZones/testserver.private.postgres.database.azure.com'
New-AzPostgreSqlFlexibleServer  -ResourceGroupName postgresqltest -ServerName testserver -Subnet $Subnet -PrivateDnsZone $DnsZone
```

```output
Resource group PowershellPostgreSqlTest exists ? : True
You have supplied a subnet Id. Verifying its existence...
Creating PostgreSQL server testserver in group PowershellPostgreSqlTest...
Your server server00000000 is using sku Standard_D2s_v3 (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet creates PostgreSql flexible server with an existing Subnet Id provided by a user. The subnet will be delegated to PostgreSQL flexible server if not already delegated. You cannot use a subnet delegated to different services. the subnet can be in a different resource group.

### Example 4: Create a new PostgreSql flexible server with virtual network and subnet name
```powershell
New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -Vnet postgresql-vnet -Subnet postgresql-subnet -VnetPrefix 10.0.0.0/16 -SubnetPrefix 10.0.0.0/24 -PrivateDnsZone /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/privateDnsZones/postgresql-test.private.postgres.database.azure.com
```

```output
Resource group PowershellPostgreSqlTest exists ? : True
Creating new vnet postgresql-vnet in resource group PowershellPostgreSqlTest
Creating new subnet postgresql-subnet in resource group PowershellPostgreSqlTest and delegating it to Microsoft.DBforPostgreSQL/flexibleServers
Creating PostgreSQL server postgresql-test in group PowershellPostgreSqlTest...
Your server postgresql-test is using sku Standard_D2s_v3 (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet creates PostgreSql flexible server with vnet name, subnet name, vnet prefix, and subnet prefix. If the virtual network and subnet don't exist, the cmdlet creates one.

### Example 5: Create a new PostgreSql flexible server with virtual network
```powershell
$Vnet = 'vnetname'
New-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Vnet $Vnet -PrivateDnsZone /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/privateDnsZones/testserver.private.postgres.database.azure.com

# or

$Vnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetworks/vnetname'
New-AzPostgreSqlFlexibleServer  -ResourceGroupName PowershellPostgreSqlTest -Vnet $Vnet -PrivateDnsZone /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/privateDnsZones/testserver.private.postgres.database.azure.com
```

```output
Resource group PowershellPostgreSqlTest exists ? : True
You have supplied a vnet Id/name. Verifying its existence...
Creating new vnet vnetname in resource group PowershellPostgreSqlTest
Creating new subnet Subnetserver00000000 in resource group PowershellPostgreSqlTest and delegating it to Microsoft.DBforPostgreSQL/flexibleServers
Creating PostgreSQL server server00000000 in group PowershellPostgreSqlTest...
Your server server00000000 is using sku Standard_D2s_v3 (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet creates PostgreSql flexible server with vnet id or vnet name provided by a user. If the virtual network doesn't exist, the cmdlet creates one.

### Example 6: Create a new PostgreSql flexible server with public access to all IPs
```powershell
New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -PublicAccess All
```

```output
Resource group PowershellPostgreSqlTest exists ? : True
Creating PostgreSQL server postgresql-test in group PowershellPostgreSqlTest...
Your server postgresql-test is using sku Standard_D2s_v3 (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...
Configuring server firewall rule to accept connections from 0.0.0.0 to 255.255.255.255

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet creates PostgreSql flexible server open to all IP addresses.

### Example 7: Create a new PostgreSql flexible server with firewall
```powershell
New-AzPostgreSqlFlexibleServer -Name postgresql-test -ResourceGroupName PowershellPostgreSqlTest -PublicAccess 10.10.10.10-10.10.10.12
```

```output
Resource group PowershellPostgreSqlTest exists ? : True
Creating PostgreSQL server postgresql-test in group PowershellPostgreSqlTest...
Your server postgresql-test is using sku Standard_D2s_v3 (Paid Tier). Please refer to https://aka.ms/postgresql-pricing for pricing details
Creating database flexibleserverdb...
Configuring server firewall rule to accept connections from 10.10.10.10 to 10.10.10.12

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet creates PostgreSql flexible server open to specified IP addresses.
