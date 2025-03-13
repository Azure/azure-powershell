### Example 1: Creates a New Broker Authorization
```powershell 
New-AzIoTOperationsServiceBrokerAuthorization `
  -AuthorizationName "my-authz" `
  -BrokerName "default" `
  -InstanceName "aio-117832708" `
  -ResourceGroupName "aio-validation-117832708" `
  -ExtendedLocationName "subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/location-117832708" `
  -AuthorizationPolicyCache "Enabled" `
  -AuthorizationPolicyRule @(
    @{
      principals = @{
        clientIds  = @("my-client-id")
        attributes = @(
          @{
            floor = "floor1"
            site  = "site1"
          }
        )
      }
      brokerResources = @(
        @{ method = "Connect" },
        @{
          method = "Subscribe"
          topics = @("topic", "topic/with/wildcard/#")
        }
      )
      stateStoreResources = @(
        @{
          method  = "ReadWrite"
          keyType = "Pattern"
          keys    = @("*")
        }
      )
    }
  )

```

```output
AuthorizationPolicyCache     : Enabled
AuthorizationPolicyRule      : {}
ExtendedLocationName         : subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/locatio
                               n-117832708
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.IoTOperations/instances/aio-117832708/b
                               rokers/default/authorizations/my-authz
Name                         : my-authz
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117832708
SystemDataCreatedAt          : 3/13/2025 4:37:19 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/13/2025 4:37:26 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/authorizations

```
Create a broker authz
