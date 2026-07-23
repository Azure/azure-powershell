### Example 1: Get Instance
```powershell
Get-AzIoTOperationsServiceInstance -Name "aio-3lrx4"  -ResourceGroupName  "aio-validation-117026523"
```

```output
Description                  : An AIO instance.
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Microsoft.ExtendedLo
                               cation/customLocations/location-3lrx4
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Microsoft.IoTOperati
                               ons/instances/aio-3lrx4
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : aio-3lrx4
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117026523
SchemaRegistryRefResourceId  : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Microsoft.DeviceRegi
                               stry/schemaRegistries/aio-sr-c7fa257132
SystemDataCreatedAt          : 3/5/2025 5:04:40 PM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 3/5/2025 5:07:18 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.iotoperations/instances
Version                      : 1.1.0-main.20250227.13
```

This command gets an instance