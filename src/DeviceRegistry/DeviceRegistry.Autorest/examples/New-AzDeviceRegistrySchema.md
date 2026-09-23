### Example 1: Create a schema with expanded parameters
```powershell
New-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-registry" -Name "my-schema" -DisplayName "My Device Schema" -Description "Schema for device data" -Format "JsonSchema/draft-07" -Tag @{"sampleKey" = "sampleValue"}
```

```output
Description                  : Schema for device data
DisplayName                  : My Device Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-registry/schemas/my-schema
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

Creates a new schema in the specified schema registry with expanded parameters.

### Example 2: Create a schema using a JSON file
```powershell
New-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-registry" -Name "my-schema" -JsonFilePath "C:\path\to\schema-config.json"
```

```output
Description                  : Schema for device data
DisplayName                  : My Device Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-registry/schemas/my-schema
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

Creates a new schema under the specified schema registry using configuration from a JSON file containing the schema's properties.

### Example 3: Create a schema using a JSON string
```powershell
$jsonString = Get-Content -Path "C:\path\to\schema-config.json" -Raw
New-AzDeviceRegistrySchema -ResourceGroupName "my-resource-group" -RegistryName "my-registry" -Name "my-schema" -JsonString $jsonString
```

```output
Description                  : Schema for device data
DisplayName                  : My Device Schema
Format                       : JsonSchema/draft-07
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourcegroups/my-resource-group/providers/microsoft.deviceregistry/schemaregistries/my-registry/schemas/my-schema
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

Creates a new schema using a JSON string containing the schema properties.

