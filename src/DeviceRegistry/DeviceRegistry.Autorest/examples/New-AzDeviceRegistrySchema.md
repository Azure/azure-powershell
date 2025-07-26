### Example 1: Create a schema with expanded parameters
```powershell
New-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-registry" -Name "my-schema" -DisplayName "My Device Schema" -Description "Schema for device data" -Format "JsonSchema/draft-07" -Tag @{"Environment" = "Production"}
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/fooschema
Name                         : fooschema
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
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

Creates a new schema in the specified registry with all parameters specified directly. This example shows how to create a schema with display name, description, format, and tags.

### Example 2: Create a schema using a JSON file
```powershell
New-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-registry" -Name "my-schema" -JsonFilePath "C:\path\to\schema-config.json"
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/fooschema
Name                         : fooschema
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
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

Creates a new schema using configuration from a JSON file. This approach is useful when you have complex schema configurations stored in files or when automating deployments with predefined configurations.

### Example 3: Create a schema using a JSON string
```powershell
$jsonString = Get-Content -Path "C:\path\to\schema-config.json" -Raw
New-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-registry" -Name "my-schema" -JsonString $jsonString
```

```output
Description                  : This is a test schema.
DisplayName                  : test-schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/schemaregistries/aio-sr-d179cdfcb7/schemas/fooschema
Name                         : fooschema
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
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

Creates a new schema using a JSON string containing the schema properties.

