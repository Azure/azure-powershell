### Example 1: List Schema Versions in a Schema
```powershell
Get-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema"
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLa
                                                                                                                        stModifiedBy
                                                                                                                        Type
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------ ------------
1    7/25/2025 1:21:15 AM user@outlook.com  User                    7/25/2025 1:21:15 AM     user@outlook.com       User
2    7/25/2025 1:21:16 AM user@outlook.com  User                    7/25/2025 1:21:16 AM     user@outlook.com       User
```

Lists all Schema Versions in a specified parent Schema.

### Example 2: Get Schema Version via Schema Registry Identity
```powershell
$schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -Name "my-schema-registry"
Get-AzDeviceRegistrySchemaVersion -SchemaRegistryInputObject $schemaRegistry -SchemaName "my-schema" -Name "my-schema-version"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Gets a Schema Version using the parent Schema Registry's (parent of the Schema Version's parent Schema resource) Identity object.

### Example 3: Get Schema Version via Schema Identity
```powershell
$schema = Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -Name "my-schema"
Get-AzDeviceRegistrySchemaVersion -SchemaInputObject $schema -Name "my-schema-version"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Gets a Schema Version using the parent Schema's Identity object.

### Example 4: Get Schema Version
```powershell
Get-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "my-schema-version"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Gets a specific Schema Version from a Schema.

### Example 5: Get Schema Version via Identity
```powershell
$identity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
    SchemaName = "my-schema"
    SchemaVersionName = "my-schema-version"
}
Get-AzDeviceRegistrySchemaVersion -InputObject $identity
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Gets a Schema Version using the schema version's Identity object.

