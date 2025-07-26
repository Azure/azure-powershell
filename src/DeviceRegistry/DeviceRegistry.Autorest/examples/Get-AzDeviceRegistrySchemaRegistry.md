### Example 1: List Schema Registries in a Resource Group
```powershell
Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group"
```

```output
Description                  :
DisplayName                  :
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

Lists all Schema Registries in a specified Resource Group.

### Example 2: Get Schema Registry via Resource Group Identity
```powershell
$resourceGroupIdentity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
}
Get-AzDeviceRegistrySchemaRegistry -ResourceGroupInputObject $resourceGroupIdentity -SchemaRegistryName "my-schema-registry"
```

```output
Description                  :
DisplayName                  :
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

Gets a Schema Registry using the Resource Group's Identity object.

### Example 3: Get Schema Registry
```powershell
Get-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry"
```

```output
Description                  :
DisplayName                  :
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

Gets a specific Schema Registry from a Resource Group.

### Example 4: Get Schema Registry via Identity
```powershell
$identity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    SchemaRegistryName = "my-schema-registry"
}
Get-AzDeviceRegistrySchemaRegistry -InputObject $identity
```

```output
Description                  :
DisplayName                  :
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

Gets a Schema Registry using the schema registry's Identity object.

