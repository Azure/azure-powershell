---
external help file:
Module Name: Az.Redis
online version: https://docs.microsoft.com/en-us/powershell/module/az.redis/update-azredis
schema: 2.0.0
---

# Update-AzRedis

## SYNOPSIS
Update an existing Redis cache.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRedis -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-EnableNonSslPort]
 [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-MinimumTlsVersion <TlsVersion>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-RedisConfiguration <IRedisCommonPropertiesRedisConfiguration>] [-RedisVersion <String>]
 [-ReplicasPerMaster <Int32>] [-ReplicasPerPrimary <Int32>] [-ShardCount <Int32>] [-SkuCapacity <Int32>]
 [-SkuFamily <SkuFamily>] [-SkuName <SkuName>] [-Tag <Hashtable>] [-TenantSetting <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzRedis -InputObject <IRedisIdentity> [-EnableNonSslPort] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MinimumTlsVersion <TlsVersion>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-RedisConfiguration <IRedisCommonPropertiesRedisConfiguration>]
 [-RedisVersion <String>] [-ReplicasPerMaster <Int32>] [-ReplicasPerPrimary <Int32>] [-ShardCount <Int32>]
 [-SkuCapacity <Int32>] [-SkuFamily <SkuFamily>] [-SkuName <SkuName>] [-Tag <Hashtable>]
 [-TenantSetting <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an existing Redis cache.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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

### -EnableNonSslPort
Specifies whether the non-ssl Redis server port (6379) is enabled.

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.IRedisIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MinimumTlsVersion
Optional: requires clients to use a specified TLS version (or higher) to connect (e,g, '1.0', '1.1', '1.2')

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Support.TlsVersion
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Redis cache.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
Whether or not public endpoint access is allowed for this cache.
Value is optional but if passed in, must be 'Enabled' or 'Disabled'.
If 'Disabled', private endpoints are the exclusive access method.
Default value is 'Enabled'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedisConfiguration
All Redis Settings.
Few possible keys: rdb-backup-enabled,rdb-storage-connection-string,rdb-backup-frequency,maxmemory-delta,maxmemory-policy,notify-keyspace-events,maxmemory-samples,slowlog-log-slower-than,slowlog-max-len,list-max-ziplist-entries,list-max-ziplist-value,hash-max-ziplist-entries,hash-max-ziplist-value,set-max-intset-entries,zset-max-ziplist-entries,zset-max-ziplist-value etc.
To construct, see NOTES section for REDISCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.Api20210601.IRedisCommonPropertiesRedisConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedisVersion
Redis version.
Only major version will be used in PUT/PATCH request with current valid values: (4, 6)

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

### -ReplicasPerMaster
The number of replicas to be created per primary.

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

### -ReplicasPerPrimary
The number of replicas to be created per primary.

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShardCount
The number of shards to be created on a Premium Cluster Cache.

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

### -SkuCapacity
The size of the Redis cache to deploy.
Valid values: for C (Basic/Standard) family (0, 1, 2, 3, 4, 5, 6), for P (Premium) family (1, 2, 3, 4).

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

### -SkuFamily
The SKU family to use.
Valid values: (C, P).
(C = Basic/Standard, P = Premium).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Support.SkuFamily
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The type of Redis cache to deploy.
Valid values: (Basic, Standard, Premium)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Redis.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### -TenantSetting
A dictionary of tenant settings

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

### Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.IRedisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Redis.Models.Api20210601.IRedisResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IRedisIdentity>: Identity Parameter
  - `[CacheName <String>]`: The name of the Redis cache.
  - `[Default <DefaultName?>]`: Default string modeled as parameter for auto generation to work correctly.
  - `[Id <String>]`: Resource identity path
  - `[LinkedServerName <String>]`: The name of the linked server that is being added to the Redis cache.
  - `[Location <String>]`: The location at which operation was triggered
  - `[Name <String>]`: The name of the Redis cache.
  - `[OperationId <String>]`: The ID of asynchronous operation
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RuleName <String>]`: The name of the firewall rule.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

REDISCONFIGURATION <IRedisCommonPropertiesRedisConfiguration>: All Redis Settings. Few possible keys: rdb-backup-enabled,rdb-storage-connection-string,rdb-backup-frequency,maxmemory-delta,maxmemory-policy,notify-keyspace-events,maxmemory-samples,slowlog-log-slower-than,slowlog-max-len,list-max-ziplist-entries,list-max-ziplist-value,hash-max-ziplist-entries,hash-max-ziplist-value,set-max-intset-entries,zset-max-ziplist-entries,zset-max-ziplist-value etc.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[AofStorageConnectionString0 <String>]`: First storage account connection string
  - `[AofStorageConnectionString1 <String>]`: Second storage account connection string
  - `[MaxfragmentationmemoryReserved <String>]`: Value in megabytes reserved for fragmentation per shard
  - `[MaxmemoryDelta <String>]`: Value in megabytes reserved for non-cache usage per shard e.g. failover.
  - `[MaxmemoryPolicy <String>]`: The eviction strategy used when your data won't fit within its memory limit.
  - `[MaxmemoryReserved <String>]`: Value in megabytes reserved for non-cache usage per shard e.g. failover.
  - `[RdbBackupEnabled <String>]`: Specifies whether the rdb backup is enabled
  - `[RdbBackupFrequency <String>]`: Specifies the frequency for creating rdb backup
  - `[RdbBackupMaxSnapshotCount <String>]`: Specifies the maximum number of snapshots for rdb backup
  - `[RdbStorageConnectionString <String>]`: The storage account connection string for storing rdb file

## RELATED LINKS

