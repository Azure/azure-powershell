### Example 1: Create a broker authentication
```powershell
New-AzIoTOperationsServiceBrokerAuthentication `
  -AuthenticationName "my-authn" `
  -BrokerName "default" `
  -InstanceName "aio-117832708" `
  -ResourceGroupName "aio-validation-117832708" `
  -ExtendedLocationName "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/location-117832708" `
  -AuthenticationMethod @(
      @{
          method = "X509"
          x509Settings = @{
              trustedClientCaCert = "client-ca"
          }
      }
  )


```

```output
AuthenticationMethod         : {{
                                 "x509Settings": {
                                   "trustedClientCaCert": "client-ca"
                                 },
                                 "method": "X509"
                               }}
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/location-11783270
                               8
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.IoTOperations/instances/aio-117832708/brokers/defa
                               ult/authentications/test-authentication
Name                         : test-authentication
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117832708
SystemDataCreatedAt          : 3/13/2025 4:24:46 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/13/2025 4:24:54 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/authentications

```

Create a broker auth

