### Example 1: Create an instance
```powershell
New-AzIoTOperationsServiceInstance -Name "aio-instance-name" -ResourceGroupName "aio-validation-116116143" -ExtendedLocationName  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143"  -Location "eastus2" -Description test -SchemaRegistryRefResourceId  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.DeviceRegistry/schemaRegistries/aio-sr-dd5644c861" 
```

```output
Description                  : test
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-11
                               6116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-11
                               6116143/providers/Microsoft.IoTOperations/instances/aio-instance-name
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : aio-instance-name
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-116116143
SchemaRegistryRefResourceId  : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-11
                               6116143/providers/Microsoft.DeviceRegistry/schemaRegistries/aio-sr-dd5644c861
SystemDataCreatedAt          : 3/5/2025 9:40:43 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/5/2025 9:44:40 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.iotoperations/instances
Version                      : 1.0.15

```

Creates an instance

