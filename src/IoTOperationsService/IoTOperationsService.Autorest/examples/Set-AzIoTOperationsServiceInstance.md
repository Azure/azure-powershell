### Example 1: Update Instance
```powershell
Set-AzIoTOperationsServiceInstance -Name "aio-instance-name" -ResourceGroupName "aio-validation-116116143" -ExtendedLocationName  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143"  -Location "eastus2" -Description "new-description" -SchemaRegistryRefResourceId  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.DeviceRegistry/schemaRegistries/aio-sr-dd5644c861" 
```

```output
Description                  : new-description
ExtendedLocationName         :  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143" 
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.IoTOperations/instances/aio-instance-name
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : aio-instance-name
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-116116143
SchemaRegistryRefResourceId  :  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.DeviceRegistry/schemaRegistries/aio-sr-dd5644c861" 
SystemDataCreatedAt          : 3/6/2025 12:07:04 AM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/6/2025 12:10:57 AM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.iotoperations/instances
Version                      : 1.0.15
```

Updates an instance
