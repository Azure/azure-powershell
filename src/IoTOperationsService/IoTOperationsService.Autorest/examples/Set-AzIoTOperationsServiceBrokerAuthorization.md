### Example 1: Update Broker Authorizations
```powershell
Set-AzIoTOperationsServiceBrokerAuthorization -BrokerName "default" -InstanceName "aio-117832708" -ResourceGroupName "aio-validation-117832708"
```

```output
AuthorizationPolicyCache     : Enabled
AuthorizationPolicyRule      :
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/locati
                               on-117832708
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.IoTOperations/instances/aio-117832708/b
                               rokers/default/authorizations/test-authorization
Name                         : test-authorization
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117832708
SystemDataCreatedAt          : 3/13/2025 4:24:20 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/13/2025 4:24:26 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/authorizations
```

Update broker authorizations
