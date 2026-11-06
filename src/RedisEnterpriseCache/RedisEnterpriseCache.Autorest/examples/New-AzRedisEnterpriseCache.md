### Example 1: Create a Redis Enterprise cache
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "West US" -Sku "Enterprise_E10" -PublicNetworkAccess "Enabled"
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```

This command creates a Redis Enterprise cache named MyCache with an associated database named default.

### Example 2: Create a Redis Enterprise cache using some optional parameters
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "Enterprise_E20" -PublicNetworkAccess "Enabled" -Capacity 4 -MinimumTlsVersion "1.2" -Zone "1","2","3" -Tag @{"tag1" = "value1"} -Module "{name:RedisBloom, args:`"ERROR_RATE 0.00 INITIAL_SIZE 400`"}","{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RediSearch}" -ClientProtocol "Plaintext" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -AofPersistenceEnabled -AofPersistenceFrequency "1s"
```

```output
Location Name    Type                            Zone      Database
-------- ----    ----                            ----      --------
East US  MyCache Microsoft.Cache/redisEnterprise {1, 2, 3} {default}

```

This command creates a Redis Enterprise cache named MyCache with an associated database named default, using some optional parameters.

### Example 3: Advanced - Create a Redis Enterprise cache cluster without an associated database
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "EnterpriseFlash_F300" -PublicNetworkAccess "Enabled" -NoDatabase
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
East US  MyCache Microsoft.Cache/redisEnterprise      {}

```

Warning: This command creates a Redis Enterprise cache cluster named MyCache without any associated database to hold data.

### Example 4: Create a cache in a new active geo-replication group
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$cache1Database = "{id:`"/subscriptions/$subscriptionId/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/Cache1/databases/default`"}"
New-AzRedisEnterpriseCache -Name "Cache1" -ResourceGroupName "MyGroup" -Location "East US" -Sku "Balanced_B10" -PublicNetworkAccess "Enabled" -GroupNickname "replicationGroup" -LinkedDatabase $cache1Database
```

```output
Location Name   Type                            Zone Database
-------- ----   ----                            ---- --------
East US  Cache1 Microsoft.Cache/redisEnterprise      {default}

```

This command creates Cache1 and adds it to a new active geo-replication group. The `-LinkedDatabase` value must include Cache1's own default database resource ID.

### Example 5: Create a cache in an existing active geo-replication group
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$cache1Database = "{id:`"/subscriptions/$subscriptionId/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/Cache1/databases/default`"}"
$cache2Database = "{id:`"/subscriptions/$subscriptionId/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/Cache2/databases/default`"}"
New-AzRedisEnterpriseCache -Name "Cache2" -ResourceGroupName "MyGroup" -Location "West US" -Sku "Balanced_B10" -PublicNetworkAccess "Enabled" -GroupNickname "replicationGroup" -LinkedDatabase $cache1Database,$cache2Database
```

```output
Location Name   Type                            Zone Database
-------- ----   ----                            ---- --------
West US  Cache2 Microsoft.Cache/redisEnterprise      {default}
```

This command creates Cache2 and adds it to the active geo-replication group containing Cache1. The `-LinkedDatabase` value includes the default database resource IDs for both caches.

### Example 6: Create a Redis Enterprise cache with a maintenance window
```powershell
$windows = @(
    @{Type="Weekly"; ScheduleDayOfWeek="Saturday"; StartHourUtc=0; Duration="PT10H"}
    @{Type="Weekly"; ScheduleDayOfWeek="Wednesday"; StartHourUtc=0; Duration="PT10H"}
)
$cache = New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "Balanced_B10" -PublicNetworkAccess "Enabled" -MaintenanceConfigurationMaintenanceWindow $windows
$cache | Format-List Name, SkuName, ProvisioningState, ResourceState
$cache.MaintenanceConfigurationMaintenanceWindow | Format-Table Type, ScheduleDayOfWeek, StartHourUtc, Duration
```

```output
Name              : MyCache
SkuName           : Balanced_B10
ProvisioningState : Succeeded
ResourceState     : Running

Type   ScheduleDayOfWeek StartHourUtc Duration
----   ----------------- ------------ --------
Weekly Saturday                     0 PT10H
Weekly Wednesday                    0 PT10H
```

This command creates a Redis Enterprise cache named MyCache with custom maintenance windows on Saturdays and Wednesdays starting at midnight UTC for 10 hours. At least 2 maintenance windows are required.
