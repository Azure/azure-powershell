### Example 1: Update Redis Enterprise cache
```powershell
Update-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -MinimumTlsVersion "1.2" -Tag @{"tag1" = "value1"}
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```

This command updates the minimum TLS version and adds a tag to the Redis Enterprise cache named MyCache.

### Example 2: Update maintenance window on a Redis Enterprise cache
```powershell
Update-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -MaintenanceConfigurationMaintenanceWindow @(@{Type="Weekly"; ScheduleDayOfWeek="Monday"; StartHourUtc=6; Duration="PT10H"}, @{Type="Weekly"; ScheduleDayOfWeek="Thursday"; StartHourUtc=6; Duration="PT10H"})
```

```output
CustomerManagedKeyEncryptionKeyUrl                     :
HighAvailability                                       : Enabled
HostName                                               : MyCache.westus.redis.azure.net
Id                                                     : /subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : None
IdentityUserAssignedIdentity                           : {
                                                         }
KeyEncryptionKeyIdentityType                           :
KeyEncryptionKeyIdentityUserAssignedIdentityResourceId :
Kind                                                   : v2
Location                                               : West US
MaintenanceConfigurationMaintenanceWindow              : {{
                                                           "schedule": {
                                                             "dayOfWeek": "Monday"
                                                           },
                                                           "type": "Weekly",
                                                           "duration": "PT10H",
                                                           "startHourUtc": 6
                                                         }, {
                                                           "schedule": {
                                                             "dayOfWeek": "Thursday"
                                                           },
                                                           "type": "Weekly",
                                                           "duration": "PT10H",
                                                           "startHourUtc": 6
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
Database                                               :
```

This command updates the maintenance windows on the Redis Enterprise cache named MyCache to Mondays and Thursdays at 6:00 AM UTC for 10 hours. At least 2 maintenance windows are required.