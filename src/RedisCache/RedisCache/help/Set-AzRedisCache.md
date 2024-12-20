---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
ms.assetid: 6234F211-6ED4-443F-9B83-DEB9AC51B763
online version: https://learn.microsoft.com/powershell/module/az.rediscache/set-azrediscache
schema: 2.0.0
---

# Set-AzRedisCache

## SYNOPSIS
Modifies an Azure Cache for Redis.

## SYNTAX

```
Set-AzRedisCache [-ResourceGroupName <String>] -Name <String> [-Size <String>] [-Sku <String>]
 [-RedisConfiguration <Hashtable>] [-EnableNonSslPort <Boolean>] [-TenantSettings <Hashtable>]
 [-ShardCount <Int32>] [-MinimumTlsVersion <String>] [-DisableAccessKeyAuthentication <Boolean>] [-RedisVersion <String>] [-UpdateChannel <String>]
 [-ZonalAllocationPolicy <String>] [-Tag <Hashtable>] [-IdentityType <String>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzRedisCache** cmdlet modifies an Azure Cache for Redis.

## EXAMPLES

### Example 1: Modify Azure Cache for Redis
```powershell
Set-AzRedisCache -ResourceGroupName "MyGroup" -Name "MyCache" -RedisConfiguration @{"maxmemory-policy" = "allkeys-random"}
```

```output
PrimaryKey         : ******
          SecondaryKey       : ******
          ResourceGroupName  : mygroup
          Id                 : /subscriptions/a559b6fd-3a84-40bb-a450-b0db5ed37dfe/resourceGroups/mygroup/providers/Microsoft.Cache/Redis/myCache
          Location           : North Central US
          Name               : MyCache
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

This command updates the maxmemory-policy for your Azure Cache fo Redis named *MyCache*.

### Example 2: Modify Azure Cache for Redis - If you want to Disable RDB or AOF Data Persistence.
```powershell
Set-AzRedisCache -Name "MyCache"  -RedisConfiguration @{"rdb-backup-enabled" = "false"}
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
          ProvisioningState  : Succeeded
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300], [rdb-backup-enabled, false]...} 
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          Tag                : {}
          Zone               : []
```

    

This cmdlet disables RDB backup data persistence for Azure Cache for Redis. You can also disable AOF backup persistent cache.

### Example 3: Modify Azure Cache for Redis - If you want to add data persistence after azure redis cache created.
```powershell
Set-AzRedisCache -Name "MyCache" -RedisConfiguration @{"rdb-backup-enabled" = "true"; "rdb-storage-connection-string" = "DefaultEndpointsProtocol=https;AccountName=mystorageaccount;AccountKey=******;EndpointSuffix=mySuffix"; "rdb-backup-frequency" = "30"}
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
          ProvisioningState  : Succeeded
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

This cmdlet enables rdb-backup persistence on an already existing cache. You can also enable aof-backup persistence.

### Example 4: Modify Azure Cache for Redis - If you want to change rdb back up frequency.

For example - Currently you are taking RDB snapshot in every 30 minute, but you want to change to take snapshot 15 minutes.

```powershell
Set-AzRedisCache -Name "MyCache" -RedisConfiguration @{"rdb-backup-frequency" = "15"}
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
          ProvisioningState  : Succeeded
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

### Example 5: Modify Azure Cache for Redis - If you want to change AOF back up data persistence to RDB back up.

```powershell
Set-AzRedisCache -Name "MyCache"  -RedisConfiguration @{"aof-backup-enabled"= "false"; "rdb-backup-enabled" = "true"; "rdb-storage-connection-string" = "DefaultEndpointsProtocol=https;AccountName=mystorageaccount;AccountKey=******;EndpointSuffix=mySuffix"; "rdb-backup-frequency" = "30"}
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
          ProvisioningState  : Succeeded
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

 
This cmdlet helps in changing persistence method.

### Example 6: Scale an Azure Cache for Redis Instance - Update to different size.

```powershell
Set-AzRedisCache -Name "MyCache" -Size "P2" -Sku "Premium"
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
          ProvisioningState  : Scaling
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300]....} 
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          Tag                : {}
          Zone               : []
```

This command increases or decreases the memory size of your instance.

### Example 7: Scale an Azure Cache for Redis Instance - Update to different tier.

```powershell
Set-AzRedisCache -Name "MyCache" -Size "P1" -Sku "Premium"
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
          ProvisioningState  : Scaling
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300]....} 
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 1GB
          Sku                : Standard
          Tag                : {}
          Zone               : []
```

This command helps you change the tier of your cache. You can change from Basic to Standard, or Standard to Premium.

### Example 8: Scale an Azure Cache for Redis Instance - Enable Redis Clustering.

```powershell
Set-AzRedisCache -Name "MyCache" -ShardCount 1
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
          ProvisioningState  : Scaling
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300]....} 
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          ShardCount         :
          Tag                : {}
          Zone               : []
```

This cmdlet helps you in enable clustering for your Azure Cache for Redis instance. For increasing the shard count, must enable clustering first.

### Example 9: Scale an Azure Cache for Redis Instance - Use Redis Cluster to scale in/out.

```powershell
Set-AzRedisCache -Name "MyCache" -ShardCount 2
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
          ProvisioningState  : Scaling
          SslPort            : 6380
          RedisConfiguration : {[maxmemory-policy, allkeys-random], [maxclients, 7500], [maxmemory-reserved, 200],
                                [maxfragmentationmemory-reserved, 300]....} 
          EnableNonSslPort   : False
          RedisVersion       : 4.0.14
          Size               : 6GB
          Sku                : Premium
          ShardCount         : 1
          Tag                : {}
          Zone               : []
```

This command increases or decreases the cluster size.

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
Specifies the name of the Azure Cache for Redis to update.

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
Specifies the name of the resource group that contains the Redis Cache.

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

### -ShardCount
Specifies the number of shards to create on a Premium cluster cache.

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
- 120GB
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
Default value: None
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

## OUTPUTS

### Microsoft.Azure.Commands.RedisCache.Models.RedisCacheAttributesWithAccessKeys

## NOTES

## RELATED LINKS

[Get-AzRedisCache](./Get-AzRedisCache.md)

[New-AzRedisCache](./New-AzRedisCache.md)

[Remove-AzRedisCache](./Remove-AzRedisCache.md)
