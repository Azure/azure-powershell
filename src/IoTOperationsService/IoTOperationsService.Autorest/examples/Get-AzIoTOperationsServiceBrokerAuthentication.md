### Example 1: List Brokers Authentications
```powershell
Get-AzIoTOperationsServiceBrokerAuthentication -BrokerName  "default" -InstanceName "aio-3lrx4" -ResourceGroupName "aio-validation-117026523"
```

```output
AuthenticationMethod         : {{
                                 "serviceAccountTokenSettings": {
                                   "audiences": [ "test" ]
                                 },
                                 "method": "ServiceAccountToken"
                               }}
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Micr
                               osoft.ExtendedLocation/customLocations/location-3lrx4
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Micr
                               osoft.IoTOperations/instances/aio-3lrx4/brokers/default/authentications/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117026523
SystemDataCreatedAt          : 3/5/2025 5:08:08 PM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 3/5/2025 5:29:54 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/authentications
```

This command gets a list of broker authentications


