### Example 1: Create a Redis Enterprise cache
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "West US" -Sku "Enterprise_E10"
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```

This command creates a Redis Enterprise cache named MyCache with an associated database named default.

### Example 2: Create a Redis Enterprise cache using some optional parameters
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "Enterprise_E20" -Capacity 4 -MinimumTlsVersion "1.2" -Zone "1","2","3" -Tag @{"tag1" = "value1"} -Module "{name:RedisBloom, args:`"ERROR_RATE 0.00 INITIAL_SIZE 400`"}","{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RediSearch}" -ClientProtocol "Plaintext" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -AofPersistenceEnabled -AofPersistenceFrequency "1s"
```

```output
Location Name    Type                            Zone      Database
-------- ----    ----                            ----      --------
East US  MyCache Microsoft.Cache/redisEnterprise {1, 2, 3} {default}

```

This command creates a Redis Enterprise cache named MyCache with an associated database named default, using some optional parameters.

### Example 3: Advanced - Create a Redis Enterprise cache cluster without an associated database
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "EnterpriseFlash_F300" -NoDatabase
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
East US  MyCache Microsoft.Cache/redisEnterprise      {}

```

Warning: This command creates a Redis Enterprise cache cluster named MyCache without any associated database to hold data.

### Example 4: Create a Redis Enterprise cache with a georeplicated database
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "West US" -Sku "Enterprise_E10" -ClientProtocol "Encrypted" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -GroupNickname "GroupNickname" -LinkedDatabase '{id:"/subscriptions/6b9ac7d2-7f6d-4de4-962c-43fda44bc3f2/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default"}'
```

```output
Location Name      Type                            Zone Database
-------- ----      ----                            ---- --------
West US  MyCache   Microsoft.Cache/redisEnterprise      {default}

```

This command creates a cache name MyCache with a georeplicated database named default

### Example 5: Create a Redis Enterprise cache with a maintenance window
```powershell
New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "Balanced_B10" -PublicNetworkAccess "Enabled" -MaintenanceConfigurationMaintenanceWindow @(@{Type="Weekly"; ScheduleDayOfWeek="Saturday"; StartHourUtc=0; Duration="PT10H"}, @{Type="Weekly"; ScheduleDayOfWeek="Wednesday"; StartHourUtc=0; Duration="PT10H"})
```

```output
CustomerManagedKeyEncryptionKeyUrl                     :
HighAvailability                                       : Enabled
HostName                                               : MyCache.eastus.redis.azure.net
Id                                                     : /subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : None
IdentityUserAssignedIdentity                           : {
                                                         }
KeyEncryptionKeyIdentityType                           :
KeyEncryptionKeyIdentityUserAssignedIdentityResourceId :
Kind                                                   : v2
Location                                               : East US
MaintenanceConfigurationMaintenanceWindow              : {{
                                                           "schedule": {
                                                             "dayOfWeek": "Saturday"
                                                           },
                                                           "type": "Weekly",
                                                           "duration": "PT10H",
                                                           "startHourUtc": 0
                                                         }, {
                                                           "schedule": {
                                                             "dayOfWeek": "Wednesday"
                                                           },
                                                           "type": "Weekly",
                                                           "duration": "PT10H",
                                                           "startHourUtc": 0
                                                         }}
MigratedEndpoint                                       :
MinimumTlsVersion                                      : 1.2
Name                                                   : MyCache
PrivateEndpointConnection                              : {}
ProvisioningState                                      : Succeeded
PublicNetworkAccess                                    : Enabled
RedisVersion                                           :
RedundancyMode                                         : ZR
ResourceGroupName                                      : MyGroup
ResourceState                                          : Running
SkuCapacity                                            :
SkuName                                                : Balanced_B10
SystemDataCreatedAt                                    :
SystemDataCreatedBy                                    :
SystemDataCreatedByType                                :
SystemDataLastModifiedAt                               :
SystemDataLastModifiedBy                               :
SystemDataLastModifiedByType                           :
Tag                                                    : {
                                                         }
Type                                                   : Microsoft.Cache/redisEnterprise
Zone                                                   :
Database                                               : {[default, {
                                                           "id": "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default",
                                                           "name": "default",
                                                           "type": "Microsoft.Cache/redisEnterprise/databases",
                                                           "properties": {
                                                             "clientProtocol": "Encrypted",
                                                             "port": 10000,
                                                             "provisioningState": "Succeeded",
                                                             "resourceState": "Running",
                                                             "clusteringPolicy": "OSSCluster",
                                                             "evictionPolicy": "VolatileLRU",
                                                             "redisVersion": "7.4",
                                                             "deferUpgrade": "NotDeferred",
                                                             "accessKeysAuthentication": "Disabled",
                                                             "notifyKeyspaceEvents": ""
                                                           }
                                                         }]}
```

This command creates a Redis Enterprise cache named MyCache with custom maintenance windows on Saturdays and Wednesdays starting at midnight UTC for 10 hours. At least 2 maintenance windows are required.
