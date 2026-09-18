### Example 1: List Schemas in a Schema Registry
```powershell
Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
```

```output
Name                                        SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModified
                                                                                                              At
----                                        -------------------   ------------------- ----------------------- ----------------------
test-schema-create-expanded                 7/25/2025 12:38:28 AM user@outlook.com  User                    7/25/2025 12:38:28 AM
fooschema                                   7/25/2025 12:33:31 AM user@outlook.com  User                    7/25/2025 12:33:31 AM
```

Lists all Schemas in a specified parent Schema Registry.

### Example 2: Get Schema via Schema Registry Identity
```powershell
$schemaRegistryIdentity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Get-AzDeviceRegistrySchema -SchemaRegistryInputObject $schemaRegistryIdentity -SchemaName "my-schema"
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/my-subscription/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 12:33:31 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 12:33:31 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sampleKey": "sampleValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 0ea44626-2ac8-488a-ac07-64566f99a308
```

Gets a Schema using the parent Schema Registry's Identity object.

### Example 3: Get Schema
```powershell
Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema"
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 12:33:31 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 12:33:31 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sampleKey": "sampleValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 0ea44626-2ac8-488a-ac07-64566f99a308
```

Gets a specific Schema from its parent Schema Registry.

### Example 4: Get Schema via Identity
```powershell
$identity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
    SchemaName = "my-schema"
}
Get-AzDeviceRegistrySchema -InputObject $identity
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/my-subscription/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/my-schema-registry/schemas/my-schema
Name                         : my-schema
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SchemaType                   : MessageSchema
SystemDataCreatedAt          : 7/25/2025 12:33:31 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 12:33:31 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sampleKey": "sampleValue"
                               }
Type                         : microsoft.deviceregistry/schemaregistries/schemas
Uuid                         : 0ea44626-2ac8-488a-ac07-64566f99a308
```

Gets a Schema using the schema's Identity object.

