### Example 1: Create a schema registry with expanded parameters
```powershell
New-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -Location "East US" -Namespace "my-namespace" -DisplayName "My Schema Registry" -Description "Registry for device schemas" -StorageAccountContainerUrl "https://mystorageaccount.blob.core.windows.net/schemas"
```

```output
Description                  : Registry for device schemas
DisplayName                  : My Schema Registry
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/schemaRegistries/aio-sr-d179cdfcb7
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : aio-sr-d179cdfcb7
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
StorageAccountContainerUrl   : https://aiosrsad179cdfcb7.blob.core.windows.net/schemas
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

Creates a new schema registry with all parameters specified directly. This example shows how to configure a schema registry with display name, description, namespace, and storage account container URL for schema storage.

### Example 2: Create a schema registry using a JSON file
```powershell
New-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -JsonFilePath "C:\path\to\schema-registry-config.json"
```

```output
Description                  : Registry for device schemas
DisplayName                  : My Schema Registry
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/schemaRegistries/aio-sr-d179cdfcb7
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : aio-sr-d179cdfcb7
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
StorageAccountContainerUrl   : https://aiosrsad179cdfcb7.blob.core.windows.net/schemas
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

Creates a new schema registry using configuration from a JSON file. This approach is useful when you have complex schema registry configurations stored in files or when automating deployments with predefined configurations.

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
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/schemaRegistries/aio-sr-d179cdfcb7
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : aio-sr-d179cdfcb7
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
StorageAccountContainerUrl   : https://aiosrsad179cdfcb7.blob.core.windows.net/schemas
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

Creates a new schema registry using a JSON string constructed from a PowerShell object containing the Schema Registry properties.

