### Example 1: Create a basic forwarding configuration object
```powershell
New-AzFrontDoorForwardingConfigurationObject -BackendPoolId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool" -ForwardingProtocol "MatchRequest"
```

```output
BackendPoolId        : /subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool
CacheConfiguration   : {
                       }
CustomForwardingPath :
ForwardingProtocol   : MatchRequest
OdataType            : #Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration
```

Create a basic forwarding configuration object that forwards requests to a backend pool using the same protocol as the incoming request.

### Example 2: Create a forwarding configuration object with cache and custom path
```powershell
$cacheConfig = New-AzFrontDoorCacheConfigurationObject -CacheDuration "0.12:00:00" -DynamicCompression "Enabled"
New-AzFrontDoorForwardingConfigurationObject -BackendPoolId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool" -ForwardingProtocol "HttpsOnly" -CustomForwardingPath "/api/v2" -CacheConfiguration $cacheConfig
```

```output
BackendPoolId        : /subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/backendPools/myBackendPool
CacheConfiguration   : {
                       }
CustomForwardingPath : /api/v2
ForwardingProtocol   : HttpsOnly
OdataType            : #Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration
```

Create a forwarding configuration object with caching enabled, custom forwarding path, and HTTPS-only forwarding protocol.

