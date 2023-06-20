---
external help file:
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/new-azredisenterprisecachedatabase
schema: 2.0.0
---

# New-AzRedisEnterpriseCacheDatabase

## SYNOPSIS
Creates a database for a Redis Enterprise cache.

## SYNTAX

```
New-AzRedisEnterpriseCacheDatabase -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AofPersistenceEnabled] [-AofPersistenceFrequency <AofFrequency>]
 [-ClientProtocol <Protocol>] [-ClusteringPolicy <ClusteringPolicy>] [-EvictionPolicy <EvictionPolicy>]
 [-GroupNickname <String>] [-LinkedDatabase <ILinkedDatabase[]>] [-Module <IModule[]>] [-Port <Int32>]
 [-RdbPersistenceEnabled] [-RdbPersistenceFrequency <RdbFrequency>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a database for a Redis Enterprise cache.

## EXAMPLES

### Example 1: Create a database for a Redis Enterprise cache
```powershell
New-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -Module "{name:RedisBloom, args:`"ERROR_RATE 0.00 INITIAL_SIZE 400`"}","{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RediSearch}" -ClientProtocol "Plaintext" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -Port 10000 -AofPersistenceEnabled -AofPersistenceFrequency "always"
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```

This command creates a database named default for a Redis Enterprise cache named MyCache.

### Example 2: Create a georeplicated database for a Redis Enterprise cache
```powershell
New-AzRedisEnterpriseCacheDatabase -Name "MyCache2" -ResourceGroupName "MyGroup" -ClientProtocol "Encrypted" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -GroupNickname "GroupNickname" -LinkedDatabase '{id:"/subscriptions/sub1/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache1/databases/default"}','{id:"/subscriptions/sub1/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache2/databases/default"}'
```

```output
Name    Type
----    ----
default Microsoft.Cache/redisEnterprise/databases

```

This command creates a georeplicated database named default for a Redis Enterprise cache named MyCache2.
This database is supposed to be linked with a database default of a preexisting cache MyCache1

## PARAMETERS

### -AofPersistenceEnabled
[Preview] Sets whether AOF persistence is enabled.
After enabling AOF persistence, you will be unable to disable it.
Support for disabling AOF persistence after enabling will be added at a later date.

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

### -AofPersistenceFrequency
[Preview] Sets the frequency at which data is written to disk if AOF persistence is enabled.
Allowed values: 1s, always

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency
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

### -ClientProtocol
Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols - default is Encrypted
Allowed values: Encrypted, Plaintext

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusteringPolicy
Clustering policy - default is OSSCluster
Specified at create time.
Allowed values: EnterpriseCluster, OSSCluster

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the Redis Enterprise cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
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

### -EvictionPolicy
Redis eviction policy - default is VolatileLRU
Allowed values: AllKeysLFU, AllKeysLRU, AllKeysRandom, VolatileLRU, VolatileLFU, VolatileTTL, VolatileRandom, NoEviction

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupNickname
Name for the group of linked database resources

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

### -LinkedDatabase
List of database resources to link with this database
To construct, see NOTES section for GEOREPLICATIONLINKEDDATABASE properties and create a hash table.
To construct, see NOTES section for LINKEDDATABASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILinkedDatabase[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Module
Optional set of redis modules to enable in this database - modules can only be added at create time.
To construct, see NOTES section for MODULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IModule[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -Port
TCP port of the database endpoint - defaults to an available port
Specified at create time.

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

### -RdbPersistenceEnabled
[Preview] Sets whether RDB persistence is enabled.
After enabling RDB persistence, you will be unable to disable it.
Support for disabling RDB persistence after enabling will be added at a later date.

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

### -RdbPersistenceFrequency
[Preview] Sets the frequency at which a snapshot of the database is created if RDB persistence is enabled.
Allowed values: 1h, 6h, 12h

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency
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
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IDatabase

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


LINKEDDATABASE <ILinkedDatabase[]>: List of database resources to link with this database To construct, see NOTES section for GEOREPLICATIONLINKEDDATABASE properties and create a hash table.
  - `[Id <String>]`: Resource ID of a database resource to link with this database.

MODULE <IModule[]>: Optional set of redis modules to enable in this database - modules can only be added at create time.
  - `Name <String>`: The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'
  - `[Arg <String>]`: Configuration options for the module, e.g. 'ERROR_RATE 0.01 INITIAL_SIZE 400'.

## RELATED LINKS

