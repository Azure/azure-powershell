### Example 1: Create a schema registry with expanded parameters
```powershell
New-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -Location "East US" -Namespace "my-namespace" -DisplayName "My Schema Registry" -Description "Registry for device schemas" -StorageAccountContainerUrl "https://mystorageaccount.blob.core.windows.net/schemas"
```

```output
Description                  : Registry for device schemas
DisplayName                  : My Schema Registry
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/schemaRegistries/my-schema-registry
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : East US
Name                         : my-schema-registry
Namespace                    : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StorageAccountContainerUrl   : https://mystorageaccount.blob.core.windows.net/schemas
SystemDataCreatedAt          : 7/22/2025 5:15:05 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/22/2025 5:15:05 AM
SystemDataLastModifiedBy     : 739f5293-922a-4616-b106-3662530ef99f
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/schemaregistries
Uuid                         : cef95c04-3309-4ae5-84cd-a3df9dc6a154
```

Creates a new schema registry with expanded parameters.

### Example 2: Create a schema registry using a JSON file
```powershell
New-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -JsonFilePath "C:\path\to\schema-registry-config.json"
```

```output
Description                  : Registry for device schemas
DisplayName                  : My Schema Registry
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/schemaRegistries/my-schema-registry
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : East US
Name                         : my-schema-registry
Namespace                    : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StorageAccountContainerUrl   : https://mystorageaccount.blob.core.windows.net/schemas
SystemDataCreatedAt          : 7/22/2025 5:15:05 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/22/2025 5:15:05 AM
SystemDataLastModifiedBy     : 739f5293-922a-4616-b106-3662530ef99f
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/schemaregistries
Uuid                         : cef95c04-3309-4ae5-84cd-a3df9dc6a154
```

Creates a new schema registry using configuration from a JSON file containing the schema registry properties.

### Example 3: Create a schema registry using a JSON string
```powershell
$jsonObject = @{
    location = "East US"
    properties = @{
        namespace = "my-namespace"
        displayName = "My Schema Registry"
        description = "Registry for device schemas"
        storageAccountContainerUrl = "https://mystorageaccount.blob.core.windows.net/schemas"
    }
}
$jsonString = $jsonObject | ConvertTo-Json -Depth 10

New-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -JsonString $jsonString
```

```output
Description                  : Registry for device schemas
DisplayName                  : My Schema Registry
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/schemaRegistries/my-schema-registry
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : East US
Name                         : my-schema-registry
Namespace                    : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StorageAccountContainerUrl   : https://mystorageaccount.blob.core.windows.net/schemas
SystemDataCreatedAt          : 7/22/2025 5:15:05 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/22/2025 5:15:05 AM
SystemDataLastModifiedBy     : 739f5293-922a-4616-b106-3662530ef99f
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/schemaregistries
Uuid                         : cef95c04-3309-4ae5-84cd-a3df9dc6a154
```

Creates a new schema registry using a JSON string containing the Schema Registry properties.

