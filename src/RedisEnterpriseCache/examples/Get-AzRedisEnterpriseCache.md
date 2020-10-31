### Example 1: Get a Redis Enterprise Cache by name
```powershell
PS C:\> Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup" -Name "MyCache"

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

This command gets the Redis Enterprise Cache named MyCache. The cluster and database are returned.

### Example 2: Get every Redis Enterprise Cache in a resource group
```powershell
PS C:\> Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup"

Location Name     Type                            Zone
-------- ----     ----                            ----
East US  MyCache1 Microsoft.Cache/redisEnterprise

ClientProtocol    : Encrypted
ClusteringPolicy  : OSSCluster
EvictionPolicy    : VolatileLRU
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache1/databases/default
Module            :
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases

East US  MyCache2 Microsoft.Cache/redisEnterprise {1, 2, 3}

ClientProtocol    : Plaintext
ClusteringPolicy  : EnterpriseCluster
EvictionPolicy    : NoEviction
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache2/databases/default
Module            : {RedisBloom, RedisTimeSeries, RediSearch}
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases
```

This command gets every Redis Enterprise Cache in the specified resource group. The cluster and database are returned for each cache.

