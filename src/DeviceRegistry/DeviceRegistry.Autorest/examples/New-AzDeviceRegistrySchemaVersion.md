### Example 1: Create a schema version with expanded parameters
```powershell
New-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1.0.0" -Description "Initial version of the device schema" -SchemaContent '{"type":"object","properties":{"deviceId":{"type":"string"},"temperature":{"type":"number"}}}'
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Creates a new schema version with all parameters specified directly. This example shows how to create a schema version with description and schema content for defining device data structure.

### Example 2: Create a schema version using a JSON file
```powershell
New-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1.0.0" -JsonFilePath "C:\path\to\schema-version-config.json"
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Creates a new schema version using configuration from a JSON file. This approach is useful when you have complex schema version configurations stored in files or when automating deployments with predefined configurations.

### Example 3: Create a schema version using a JSON string
```powershell
$jsonString = Get-Content -Path "C:\path\to\schema-version-config.json" -Raw
New-AzDeviceRegistrySchemaVersion -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -SchemaName "my-schema" -Name "1.0.0" -JsonString $jsonString
```

```output
Description                  : Schema version 1
Hash                         : d62557cd31b6297be0142a2800f7df7055d04cf047295d17ddbc864209893938
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/myschema/schemaversions/1
Name                         : 1
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SchemaContent                : {"$schema": "http://json-schema.org/draft-07/schema#","type": "object","properties": {"humidity":
                               {"type": "string"},"temperature": {"type":"number"}}}
SystemDataCreatedAt          : 7/25/2025 1:21:15 AM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/25/2025 1:21:15 AM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.deviceregistry/schemaregistries/schemas/schemaversions
Uuid                         : c59ca7f5-fcff-4cd5-ac7e-a21c508d6819
```

Creates a new schema version using a JSON string loaded from a file. This method provides flexibility to modify the JSON configuration programmatically before creating the schema version.

