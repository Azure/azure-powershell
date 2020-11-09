---
external help file:
Module Name: Az.MySql
online version: https://docs.microsoft.com/en-us/powershell/module/az.mysql/new-azmysqlflexibleserver
schema: 2.0.0
---

# New-AzMySqlFlexibleServer

## SYNOPSIS
Creates a new server.

## SYNTAX

```
New-AzMySqlFlexibleServer -Name <String> -ResourceGroupName <String>
 -AdministratorLoginPassword <SecureString> -AdministratorUserName <String> [-SubscriptionId <String>]
 [-BackupRetentionDay <Int32>] [-Location <String>] [-Sku <String>] [-SkuTier <String>] [-StorageInMb <Int32>]
 [-Tag <Hashtable>] [-Version <ServerVersion>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new server.

## EXAMPLES

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

The cmdlet generates a server with the given parameters and output important information in a visible format.
The server creation automatically generates vnet, subnet, and database in the resource group.

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

When no parameters are given, the cmdlet automatically generates necessary resources such as resource group, vnet, and database.
The SKU and storage profile are set to default values.

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

The cmdlet generates a server without given parameters and automatically generates necessary resources such as resource group, subnet, and database.
The SKU and storage profile are set to default values.

## PARAMETERS

### -AdministratorLoginPassword
The password of the administrator.
Minimum 8 characters and maximum 128 characters.
Password must contain characters from three of the following categories: English uppercase letters, English lowercase letters, numbers, and non-alphanumeric characters.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdministratorUserName
Administrator username for the server.
Once set, it cannot be changed.

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

### -AsJob
Run the command as a job.

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

### -BackupRetentionDay
Backup retention days for the server.
Day count is between 7 and 35.

```yaml
Type: System.Int32
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

### -Location
The location the resource resides in.

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

### -Name
The name of the server.

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

### -NoWait
Run the command asynchronously.

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

### -Sku
The name of the sku, typically, tier + family + cores, e.g.
Standard_B1ms, Standard_D2ds_v4.

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

### -SkuTier
Compute tier of the server.
Accepted values: Burstable, GeneralPurpose, Memory Optimized.
Default: Burstable.

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

### -StorageInMb
Max storage allowed for a server.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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
Default value: None
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

