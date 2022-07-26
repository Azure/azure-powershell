---
external help file:
Module Name: Az.MySql
online version: https://docs.microsoft.com/powershell/module/az.mysql/new-azmysqlflexibleserver
schema: 2.0.0
---

# New-AzMySqlFlexibleServer

## SYNOPSIS
Creates a new MySQL flexible server.

## SYNTAX

```
New-AzMySqlFlexibleServer [-Name <String>] [-ResourceGroupName <String>] [-SubscriptionId <String>]
 [-AdministratorLoginPassword <SecureString>] [-AdministratorUserName <String>] [-BackupRetentionDay <Int32>]
 [-HighAvailability <String>] [-Iops <Int32>] [-Location <String>] [-PrivateDnsZone <String>]
 [-PublicAccess <String>] [-Sku <String>] [-SkuTier <String>] [-StorageAutogrow <StorageAutogrow>]
 [-StorageInMb <Int32>] [-Subnet <String>] [-SubnetPrefix <String>] [-Tag <Hashtable>]
 [-Version <ServerVersion>] [-Vnet <String>] [-VnetPrefix <String>] [-Zone <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new MySQL flexible server.

## EXAMPLES

### Example 1: Create a new MySql flexible server with arguments
```powershell
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

This cmdlet creates MySql flexible server with default parameter values and provision the server inside a new virtual network and have a subnet delegated to the server.
The default values of location is West US 2, Sku is Standard_B1ms, Sku tier is Burstable, and storage size is 10GiB.


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

This cmdlet creates PostgreSql flexible server with an existing Subnet Id provided by a user.
The subnet will be delegated to PostgreSQL flexible server if not already delegated.
You cannot use a subnet delegated to different services.

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

This cmdlet creates MySql flexible server with vnet name, subnet name, vnet prefix, and subnet prefix.
If the virtual network and subnet don't exist, the cmdlet creates one.

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

This cmdlet creates MySql flexible server with vnet id or vnet name provided by a user.
If the virtual network doesn't exist, the cmdlet creates one.

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

## PARAMETERS

### -AdministratorLoginPassword
The password of the administrator.
Minimum 8 characters and maximum 128 characters.
Password must contain characters from three of the following categories: English uppercase letters, English lowercase letters, numbers, and non-alphanumeric characters.

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

### -AdministratorUserName
Administrator username for the server.
Once set, it cannot be changed.

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
Day count is between 1 and 35.

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

### -HighAvailability
Enable or disable high availability feature.
Allowed values are 'ZoneRedundant', 'SameZone', and 'Disabled'.
Default value is Disabled.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: HaEnabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Iops
Number of IOPS to be allocated for this server.
You will get certain amount of free IOPS based on compute and storage provisioned.
The default value for IOPS is free IOPS.

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

Required: False
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

### -PrivateDnsZone
The id of an existing private dns zone.
The suffix of dns zone has to be same as that of fully qualified domain of the server.

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

### -PublicAccess
Determines the public access.
Allowed values: All, None, IP address range (e.g., 1.1.1.1-1.1.1.5, 1.1.1.1) Specifying 0.0.0.0 allows public access from any resources deployed within Azure to access your server.
Specifying no IP address sets the server in public access mode but does not create a firewall rule.

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

Required: False
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

### -StorageAutogrow
Enable or disable Storage Auto Grow.
The default value is Disabled

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow
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

### -Subnet
The Name or Id of an existing Subnet or name of a new one to create.
Use resource ID if you want to use a subnet from different resource group.
Please note that the subnet will be delegated to Microsoft.DBforMySQL/flexibleServers.
After delegation, this subnet cannot be used for any other type of Azure resources.

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

### -SubnetPrefix
The subnet IP address prefix to use when creating a new vnet in CIDR format.
Default value is 10.0.0.0/24.

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

### -Vnet
The Name or Id of an existing virtual network or name of a new one to create.
The name must be between 2 to 64 characters.
The name must begin with a letter or number, end with a letter, number or underscore, and may contain only letters, numbers, underscores, periods, or hyphens.

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

### -VnetPrefix
The IP address prefix to use when creating a new vnet in CIDR format.
Default value is 10.0.0.0/16.

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

### -Zone
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

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20210501.IServerAutoGenerated

## NOTES

ALIASES

## RELATED LINKS

