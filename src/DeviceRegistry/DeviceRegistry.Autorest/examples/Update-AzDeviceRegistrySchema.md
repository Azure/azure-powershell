### Example 1: Update a Device Registry Schema with expanded parameters
```powershell
Update-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-schema-registry" -Name "my-schema" -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"environment" = "production"}
```

```output
Description                  : Updated schema description
DisplayName                  : Updated schema display name
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/test-schema-update
Name                         : test-schema-update
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

This example updates a Device Registry Schema by modifying its display name, description, and tags using individual parameters. This approach is useful when you want to update specific properties of an existing schema.

### Example 2: Update a Device Registry Schema using schema registry identity object
```powershell
$registryIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Update-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name "my-schema" -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"environment" = "production"}
```

```output
Description                  : Updated schema description
DisplayName                  : Updated schema display name
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/test-schema-update
Name                         : test-schema-update
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

This example updates a Device Registry Schema using a schema registry identity object. This approach is useful when you want to work with registry identity objects rather than specifying individual resource group and registry parameters.

### Example 3: Update a Device Registry Schema using schema identity object
```powershell
Update-AzDeviceRegistrySchema -InputObject $schemaObject -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"environment" = "production"}
```

```output
Description                  : Updated schema description
DisplayName                  : Updated schema display name
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/test-schema-update
Name                         : test-schema-update
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

This example updates a Device Registry Schema using a schema identity object obtained from a previous operation. This approach is useful when you already have a schema object from another cmdlet like Get-AzDeviceRegistrySchema or New-AzDeviceRegistrySchema.

