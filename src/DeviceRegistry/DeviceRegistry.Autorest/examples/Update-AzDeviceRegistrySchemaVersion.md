### Example 1: Update a Device Registry Schema Version with expanded parameters
```powershell
Update-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "my-schema-version" -Description "Updated schema version description"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
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

This example updates a Device Registry Schema Version by modifying its description using individual parameters. This approach is useful when you want to update specific properties of an existing schema version.

### Example 2: Update a Device Registry Schema Version using schema registry identity object
```powershell
$schemaRegistry = Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -Name "my-schema-registry"
Update-AzDeviceRegistrySchemaVersion -SchemaRegistryInputObject $schemaRegistry -SchemaName "my-schema" -Name "my-schema-version" -Description "Updated schema version description"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
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

This example updates a Device Registry Schema Version using a schema registry identity object. This approach is useful when you want to work with registry identity objects rather than specifying individual resource group and registry parameters.

### Example 3: Update a Device Registry Schema Version using schema identity object
```powershell
$schema = Get-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -Name "my-schema"
Update-AzDeviceRegistrySchemaVersion -SchemaInputObject $schema -Name "my-schema-version" -Description "Updated schema version description"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
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

This example updates a Device Registry Schema Version using a schema identity object. This approach is useful when you want to work with schema identity objects rather than specifying individual resource group, registry, and schema parameters.

### Example 4: Update a Device Registry Schema Version using schema version identity object
```powershell
Update-AzDeviceRegistrySchemaVersion -InputObject $schemaVersionObject -Description "Updated schema version description"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
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

This example updates a Device Registry Schema Version using a schema version identity object obtained from a previous operation. This approach is useful when you already have a schema version object from another cmdlet like Get-AzDeviceRegistrySchemaVersion or New-AzDeviceRegistrySchemaVersion.

