### Example 1: Create a Redis Enterprise Cache
```powershell
PS C:\> New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "West US" -Sku "Enterprise_E10"

Location Name    Type                            Zone
-------- ----    ----                            ----
East US  MyCache Microsoft.Cache/redisEnterprise

ClientProtocol    : Encrypted
ClusteringPolicy  : OSSCluster
EvictionPolicy    : VolatileLRU
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default
Module            :
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases
```

This command creates a Redis Enterprise Cache. The cluster and database are returned.

### Example 2: Create a Redis Enterprise Cache using some optional parameters
```powershell
PS C:\> New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "Enterprise_E20" -Capacity 4 -Zones "1","2","3" -Modules "{name:RedisBloom, args:`"ERROR_RATE 0.00 INITIAL_SIZE 400`"}","{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RediSearch}" -ClientProtocol "Plaintext" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -Tags @{"tag" = "value"}

Location Name    Type                            Zone
-------- ----    ----                            ----
East US  MyCache Microsoft.Cache/redisEnterprise {1, 2, 3}

ClientProtocol    : Plaintext
ClusteringPolicy  : EnterpriseCluster
EvictionPolicy    : NoEviction
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default
Module            : {RedisBloom, RedisTimeSeries, RediSearch}
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases
```

This command creates a Redis Enterprise Cache using some optional parameters. The cluster and database are returned.

