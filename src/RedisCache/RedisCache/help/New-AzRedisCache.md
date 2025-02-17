---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
ms.assetid: 81179AFE-6524-4F59-8BC2-3E152F51D1DD
online version: https://learn.microsoft.com/powershell/module/az.rediscache/new-azrediscache
schema: 2.0.0
---

# New-AzRedisCache

## SYNOPSIS
Creates a Redis Cache.

## SYNTAX

```
New-AzRedisCache -ResourceGroupName <String> -Name <String> -Location <String> [-Size <String>] [-Sku <String>]
 [-RedisConfiguration <Hashtable>] [-EnableNonSslPort <Boolean>] [-TenantSettings <Hashtable>]
 [-ShardCount <Int32>] [-MinimumTlsVersion <String>] [-DisableAccessKeyAuthentication <Boolean>] [-SubnetId <String>] [-StaticIP <String>]
 [-Tag <Hashtable>] [-Zone <String[]>] [-RedisVersion <String>] [-UpdateChannel <String>] [-ZonalAllocationPolicy <String>]
 [-IdentityType <String>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzRedisCache** cmdlet creates an Azure Redis Cache.

## EXAMPLES

### Example 1: Create a Redis Cache
```powershell
New-AzRedisCache -ResourceGroupName "MyGroup" -Name "MyCache" -Location "North Central US"
```

```output
          PrimaryKey         : ******
          SecondaryKey       : ******
          ResourceGroupName  : MyGroup
          Id                 : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Cache/Redis/mycache
          Location           : North Central US
          Name               : MyCache
          Type               : Microsoft.Cache/Redis
          HostName           : mycache.redis.cache.windows.net
          Port               : 6379
          ProvisioningState  : creating
          SslPort            : 6380
          RedisConfiguration : {}
          EnableNonSslPort   : False
          RedisVersion       : 2.8
          Size               : 1GB
          Sku                : Standard
          Tag                : {}
          Zone               : []
```

This command creates a Redis Cache.

### Example 2: Create a Standard SKU Redis Cache
```powershell
New-AzRedisCache -ResourceGroupName "MyGroup" -Name "MyCache" -Location "North Central US" -Size 250MB -Sku "Standard" -RedisConfiguration @{"maxmemory-policy" = "allkeys-random"}
```

```output
          PrimaryKey         : ******
          SecondaryKey       : ******
          ResourceGroupName  : MyGroup
          Id                 : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Cache/Redis/MyCache
          Location           : North Central US
          Name               : mycache
          Type               : Microsoft.Cache/Redis
          HostName           : mycache.redis.cache.windows.net
          Port               : 6379
          ProvisioningState  : creating
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random]}
          EnableNonSslPort   : False
          RedisVersion       : 2.8
          Size               : 250MB
          Sku                : Standard
          Tag                : {}
          Zone               : []
```

This cmdlet creates a cache using Azure Cache for Redis.

### Example 3: Create a Zone Redundant Cache

```powershell
New-AzRedisCache -ResourceGroupName "MyGroup" -Name "MyCache" -Location "Central US" -Size P1 -Sku "Premium" -Zone @("1","2")
```

```output
          PrimaryKey         : ******
          SecondaryKey       : ******
          ResourceGroupName  : MyGroup
          Id                 : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Cache/Redis/MyCache
          Location           : Central US
          Name               : mycache
          Type               : Microsoft.Cache/Redis
          HostName           : mycache.redis.cache.windows.net
          Port               : 6379
          ProvisioningState  : creating
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300]...}
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          Tag                : {}
          Zone               : {1, 2}
```

This command creates Azure cache for Redis instance in mutliple zones.

### Example 4: Create a Virtual Network enable Cache

Requirements for creating Virtual Network enable cache.
1. Create the virtual network in same resource group in which you want to create your redis cache. You can create virtual network from [New-AzVirtualNetwork](/powershell/module/az.network/new-azvirtualnetwork) powershell command.
1. You will need SubnetID for VNET enable cache. Syntax of SubnetID is given below.

Format of SubnetID: /subscriptions/{subid}/resourceGroups/{resourceGroupName}/providers/Microsoft.ClassicNetwork/VirtualNetworks/{vnetName}/subnets/{subnetName}

```powershell
New-AzRedisCache -ResourceGroupName "MyGroup" -Name "MyCache" -Location "Central US" -Size P1 -Sku "Premium" -SubnetId "/subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Network/virtualNetworks/MyNet/subnets/MySubnet"
```

```output
          PrimaryKey         : ******
          SecondaryKey       : ******
          ResourceGroupName  : MyGroup
          Id                 : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Cache/Redis/MyCache
          Location           : Central US
          Name               : mycache
          Type               : Microsoft.Cache/Redis
          HostName           : mycache.redis.cache.windows.net
          Port               : 6379
          ProvisioningState  : creating
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300]...}
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          SubnetId           : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Network/virtualNetworks/MyNet/subnets/MySubnet
          StaticIP           : 10.0.0.4
          Tag                : {}
          Zone               : []
```

### Example 5: Configure data persistence for a Premium Azure Cache for Redis

Persistence writes Redis data into an Azure Storage account that you own and manage. So before configuring data persistence you need to have [storage account](https://learn.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-powershell) in same resource group. Choose a storage account in the same region and subscription as the cache, and a Premium Storage account is recommended because premium storage has higher throughput.

After creating a storage account, get the storage account connection string using this procedure.

1. Run this command **Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName** in powershell.
1. From the output of above, copy any key.
1. Put the storage account key and the storage account name in format below to get the connection string of your storage account.

Connection String Format :- "DefaultEndpointsProtocol=https;AccountName={storageAccountName};AccountKey={storageAccountKey};EndpointSuffix=mySuffix"</br>

You must have the specific Redis configuration settings to enable data persistence.

For RDB backup enable
-  rdb-backup-enabled (Set true or false)
-  rdb-storage-connection-string (Give connection string in above format.)
-  rdb-backup-frequency (Set a backup interval in minutes. You can only choose from - 15, 30, 60, 360, 720 and 1440 minutes.)



```powershell
New-AzRedisCache -ResourceGroupName "MyGroup" -Name "MyCache" -Location "Central US" -Size P1 -Sku "Premium" -RedisConfiguration @{"rdb-backup-enabled" = "true"; "rdb-storage-connection-string" = "DefaultEndpointsProtocol=https;AccountName=mystorageaccount;AccountKey=******;EndpointSuffix=mySuffix"; "rdb-backup-frequency" = "30"}
```

```output
          PrimaryKey         : ******
          SecondaryKey       : ******
          ResourceGroupName  : MyGroup
          Id                 : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Cache/Redis/MyCache
          Location           : Central US
          Name               : mycache
          Type               : Microsoft.Cache/Redis
          HostName           : mycache.redis.cache.windows.net
          Port               : 6379
          ProvisioningState  : creating
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300], [rdb-backup-enabled, true]....}
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          Tag                : {}
          Zone               : []
```

### Example 6: Configure data persistence for a Premium Azure Cache for Redis - AOF backup enabled

For AOF back up enabled.
-  aof-backup-enabled (Set true or false),
-  aof-storage-connection-string-0 (Give connection string in above format.)
-  aof-storage-connection-string-1 (You can optionally configure another storage account. If a second storage account is configured, the writes to the replica cache are written to this second storage account.)

```powershell
New-AzRedisCache -ResourceGroupName "MyGroup" -Name "MyCache" -Location "Central US" -Size P1 -Sku "Premium" -RedisConfiguration @{"aof-backup-enabled" = "true"; "aof-storage-connection-string-0" = "DefaultEndpointsProtocol=https;AccountName=mystorageaccount;AccountKey=******;EndpointSuffix=mySuffix"}
```

```output
          PrimaryKey         : ******
          SecondaryKey       : ******
          ResourceGroupName  : MyGroup
          Id                 : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Cache/Redis/MyCache
          Location           : Central US
          Name               : mycache
          Type               : Microsoft.Cache/Redis
          HostName           : mycache.redis.cache.windows.net
          Port               : 6379
          ProvisioningState  : creating
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300], [aof-backup-enabled, true]...}
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          Tag                : {}
          Zone               : []
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableNonSslPort
Indicates whether the non-SSL port is enabled.
The default value is $False (the non-SSL port is disabled).

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityType
Specifies the type of identity used for the Azure Cache for Redis. Valid values: "SystemAssigned" or "UserAssigned" or "SystemAssignedUserAssigned" or "None"

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies the location in which to create a Redis Cache.
Valid values are:
- North Central US
- South Central US
- Central US
- West Europe
- North Europe
- West US
- East US
- East US 2
- Japan East
- Japan West
- Brazil South
- Southeast Asia
- East Asia
- Australia East
- Australia Southeast

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MinimumTlsVersion
Specify the TLS version required by clients to connect to cache.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the Redis Cache to create.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RedisConfiguration
Specifies Redis configuration settings.
The acceptable values for this parameter are:
- rdb-backup-enabled.
Specifies that Redis data persistence is enabled.
Premium tier only.
- rdb-storage-connection-string.
Specifies the connection string to the Storage account for Redis data persistence.
Premium tier only.
- rdb-backup-frequency.
Specifies the backup frequency for Redis data persistence.
Premium tier only.
- maxmemory-reserved.
Configures the memory reserved for non-cache processes.
Standard and Premium tiers.
- maxmemory-policy.
Configures the eviction policy for the cache.
All pricing tiers.
- notify-keyspace-events.
Configures keyspace notifications.
Standard and premium tiers.
- hash-max-ziplist-entries.
Configures memory optimization for small aggregate data types.
Standard and Premium tiers.
- hash-max-ziplist-value.
Configures memory optimization for small aggregate data types.
Standard and Premium tiers.
- set-max-intset-entries.
Configures memory optimization for small aggregate data types.
Standard and Premium tiers.
- zset-max-ziplist-entries.
Configures memory optimization for small aggregate data types.
Standard and Premium tiers.
- zset-max-ziplist-value.
Configures memory optimization for small aggregate data types.
Standard and Premium tiers.
- databases.
Configures the number of databases.
This property can be configured only at cache creation.
Standard and Premium tiers.
For more information, see Manage Azure Redis Cache with Azure PowerShellhttp://go.microsoft.com/fwlink/?LinkId=800051 (http://go.microsoft.com/fwlink/?LinkId=800051).
- preferred-data-archive-auth-method
Preferred auth method to communicate to storage account used for data archive, specify SAS or ManagedIdentity, default value is SAS
- preferred-data-persistence-auth-method
Preferred auth method to communicate to storage account used for data persistence, specify SAS or ManagedIdentity, default value is SAS

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RedisVersion
Redis version. This should be in the form 'major[.minor]' (only 'major' is required) or the value 'latest' which refers to the latest stable Redis version that is available. Supported versions: 4.0, 6.0 (latest). Default value is 'latest'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group in which to create the Redis Cache.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ShardCount
Specifies the number of shards to create on a Premium cluster cache.
The acceptable values for this parameter are:
- 1
- 2
- 3
- 4
- 5
- 6
- 7
- 8
- 9
- 10

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Size
Specifies the size of the Redis Cache.
Valid values are:
- P1
- P2
- P3
- P4
- P5
- C0
- C1
- C2
- C3
- C4
- C5
- C6
- 250MB
- 1GB
- 2.5GB
- 6GB
- 13GB
- 26GB
- 53GB
The default value is 1GB or C1.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Sku
Specifies the SKU of the Redis Cache to create.
Valid values are:
- Basic
- Standard
- Premium
The default value is Standard.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Basic, Standard, Premium

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StaticIP
Specifies a unique IP address in the subnet for the Redis Cache.
If you do not specify a value for this parameter, this cmdlet chooses an IP address from the subnet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubnetId
The full resource ID of a subnet in a virtual network to deploy the Azure Cache for Redis in.
Example format: /subscriptions/{subid}/resourceGroups/{resourceGroupName}/Microsoft.{Network|ClassicNetwork}/VirtualNetworks/{vnetName}/subnets/{subnetName}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
A hash table which represents tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TenantSettings
This parameter has been deprecated.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UpdateChannel
Optional: Specifies the update channel for the monthly Redis updates your Redis Cache will receive. Caches using 'Preview' update channel get latest Redis updates at least 4 weeks ahead of 'Stable' channel caches. Default value is 'Stable'. Possible values include: 'Stable', 'Preview'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: Stable
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ZonalAllocationPolicy
Optional: Optional: Specifies how availability zones are allocated to the Redis cache. 'Automatic' enables zone redundancy and Azure will automatically select zones based on regional availability and capacity. 'UserDefined' will select availability zones passed in by you using the 'zones' parameter. 'NoZones' will produce a non-zonal cache. If 'zonalAllocationPolicy' is not passed, it will be set to 'UserDefined' when zones are passed in, otherwise, it will be set to 'Automatic' in regions where zones are supported and 'NoZones' in regions where zones are not supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserAssignedIdentity
Specifies one or more comma seperated user identities to be associated with the Azure Cache for Redis. The user identity references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
List of Azure regions with [Availability zones](https://learn.microsoft.com/en-us/azure/availability-zones/az-region#azure-services-supporting-availability-zones).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisableAccessKeyAuthentication
Optional: Authentication to Redis through access keys is disabled when set as true. Default value is false.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: false
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### System.Collections.Hashtable

### System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.RedisCache.Models.RedisCacheAttributesWithAccessKeys

## NOTES

## RELATED LINKS

[Get-AzRedisCache](./Get-AzRedisCache.md)

[Remove-AzRedisCache](./Remove-AzRedisCache.md)

[Set-AzRedisCache](./Set-AzRedisCache.md)


