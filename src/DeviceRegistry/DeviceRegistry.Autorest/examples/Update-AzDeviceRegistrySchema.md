### Example 1: Update a Device Registry Schema with expanded parameters
```powershell
Update-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-schema-registry" -Name "my-schema" -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"updatedKey" = "updatedValue"}
```

```output
Description                  : Updated schema description
DisplayName                  : My Updated Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

Updates a Device Registry Schema by modifying its properties using individual parameters.

### Example 2: Update a Device Registry Schema using schema registry identity object
```powershell
$registryIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Update-AzDeviceRegistrySchema -SchemaRegistryInputObject $registryIdentity -Name "my-schema" -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"updatedKey" = "updatedValue"}
```

```output
Description                  : Updated schema description
DisplayName                  : My Updated Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

Updates a Device Registry Schema using the parent schema registry's identity object.

### Example 3: Update a Device Registry Schema using schema identity object
```powershell
Update-AzDeviceRegistrySchema -InputObject $schemaObject -DisplayName "My Updated Schema" -Description "Updated schema description" -Tag @{"updatedKey" = "updatedValue"}
```

```output
Description                  : Updated schema description
DisplayName                  : My Updated Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 1:00:57 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:00:57 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "updatedKey": "updatedValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 775ae13e-3732-4940-a8c9-bb860c9b243e
```

Updates a Device Registry Schema using the schema's identity object.

