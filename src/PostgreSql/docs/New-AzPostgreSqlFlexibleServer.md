---
external help file:
Module Name: Az.PostgreSql
online version: https://docs.microsoft.com/en-us/powershell/module/az.postgresql/new-azpostgresqlflexibleserver
schema: 2.0.0
---

# New-AzPostgreSqlFlexibleServer

## SYNOPSIS
Creates a new server.

## SYNTAX

```
New-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String>
 -AdministratorLoginPassword <SecureString> -AdministratorUserName <String> [-SubscriptionId <String>]
 [-BackupRetentionDay <Int32>] [-Location <String>] [-Sku <String>] [-SkuTier <String>] [-StorageInMb <Int32>]
 [-Tag <Hashtable>] [-Version <ServerVersion>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new server.

## EXAMPLES

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

The cmdlet generates a server with the given parameters and output important information in a visible format.
The server creation automatically generates vnet, subnet, and database in the resource group.

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

When no parameters are given, the cmdlet automatically generates necessary resources such as resource group, vnet, and database.
The SKU and storage profile are set to default values.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerAutoGenerated

## NOTES

ALIASES

## RELATED LINKS

