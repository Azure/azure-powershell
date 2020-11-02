---
external help file:
Module Name: Az.MySql
online version: https://docs.microsoft.com/en-us/powershell/module/az.mysql/new-azmysqlflexibleserver
schema: 2.0.0
---

# New-AzMySqlFlexibleServer

## Creates a new server. A server can be generated with all arguments optional.

## SYNTAX

```
New-AzMySqlFlexibleServer 
 [-ResourceGroupName <String>] [-Name <String> -Location <String>]
 [-SubscriptionId <String>] [-AdministratorUserName <String>] [-AdministratorLoginPassword <String>]
 [-HaEnabled <HaEnabledEnum>][-Sku <String>] [-SkuTier <SkuTier>][-BackupRetentionDay <Int32>]
 [-StorageInMb <Int32>] [-Tag <Hashtable>] [-Version <ServerVersion>]
 [-AddressPrefix [String]] [-PublicAccess [String]] [-SubnetPrefix [String]] [-VnetId [String]] [-SubnetId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new server. A server can be generated with all arguments optional. If no arguments were provided from a user, the powershell generates resource group, virtual network, and database. It also uses default values for server properties. 

## EXAMPLES

### Example 1: Create a new MySql flexible server with parameters
```powershell
PS C:\> New-AzMySqlFlexibleServer -Name mysql-test -ResourceGroupName PowershellMySqlTest \
-Location eastus -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable

Creating new vnet {vnetName} in resource group {resourceGroupName}...
Creating new subnet {subnetName} in resource group {resourceGroupName} and delegating it to "Microsoft.DBforMySQL/flexibleServers"...
Creating MySQL server {serverName} in group {resourceGroupName}...
Your server is using sku 'Standard_B1ms' (paid tier). Please refer to https://aka.ms/mysql-pricing for pricing details.
Creating MySQL database {dbname}...
"connectionString": "mysql {dbname} --host {host} --user {username} --password={password}",
"databaseName": "flexibleserverdb",
"host": "{servername}.mysql.database.azure.com",
"id": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}",
"location": "East US",
"version": "5.7",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_B1ms"
```

The cmdlet generates a server with the given parameters and output important information in a visible format. The server creation automatically generates vnet, subnet, and database in the resource group.

### Example 2: Create a new MySql flexible server without parameters
```powershell
PS C:\> New-AzMySqlFlexibleServer -Location eastus

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
"location": "East US",
"version": "5.7",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_B1ms"
```

When no parameters are given, the cmdlet automatically generates necessary resources such as resource group, vnet, and database. The SKU and storage profile are set to default values. 

### Example 3: Create a new MySql flexible server with public access to all IPs
```powershell
PS C:\> New-AzMySqlFlexibleServer -Location eastus -PublicAccess all

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
"location": "East US",
"version": "5.7",
"username": "{username}",
"password": "{password}",
"skuname": "Standard_B1ms"
```

The cmdlet generates a server without given parameters and automatically generates necessary resources such as resource group, subnet, and database. The SKU and storage profile are set to default values.


## PARAMETERS

### -AdministratorUserName
The administrator\'s login name of a server. Can only be specified when the server is being created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdministratorLoginPassword
The password of the administrator. Minimum 8 characters and maximum 128 characters. Password must contain characters from three of the following categories: English uppercase letters, English lowercase letters, numbers, and non-alphanumeric characters.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddressPrefixes
The IP address prefix to use when creating a new virtual network in CIDR format. Default value is 10.0.0.0/16.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
Availability zone into which to provision the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Resource ID of an existing subnet. Please note that the subnet will be delegated to Microsoft.DBforPostgreSQL/flexibleServers/Microsoft.DBforMySQL/flexibleServers.After delegation, this subnet cannot be used for any other type of Azure resources.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HaEnabled
Enable HA or not for a server.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location where the resource lives.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicAccess
Determines the public access. Enter single or range of IP addresses to be included in the allowed list of IPs. IP address ranges must be dash-separated and not contain any spaces. Specifying 0.0.0.0 allows public access from any resources deployed within Azure to access your server. Specifying no IP address sets the server in public access mode but does not create a firewall rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource, You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False

```

### -Name
The name of the server. The name can contain only lowercase letters, numbers, and the hyphen (-) character. Minimum 3 characters and maximum 63 characters.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The name of the compute SKU. Follows the convention Standard_{VM name}. Examples: Standard_B1ms, Standard_E16ds_v4.  Default: Standard_B1ms.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "Standard_B1ms"
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Compute tier of the server. Accepted values: Burstable, GeneralPurpose, Memory Optimized. Default: Burstable.
```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "Burstable"
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetPrefixes
The subnet IP address prefix to use when creating a new VNet in CIDR format. Default value is 10.0.0.0/24.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetId
Id of an existing virtual network or name of a new one to create. The name must be between 2 to 64 characters. The name must begin with a letter or number, end with a letter, number or underscore, and may contain only letters, numbers, underscores, periods, or hyphens.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupRetentionDay
Backup retention days for the server.
Day count is between 7 and 35.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 7
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageInMb
The storage capacity of the server. Minimum is 5 GiB and increases in 1 GiB increments. Max is 16 TiB.  Default: 10.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 10
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Application-specific metadata in the form of key-value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Server version.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "5.7"
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerAutoGenerated

## NOTES

ALIASES

## RELATED LINKS

