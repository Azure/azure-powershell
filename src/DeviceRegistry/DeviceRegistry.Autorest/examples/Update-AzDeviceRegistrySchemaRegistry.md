### Example 1: Update a Device Registry Schema Registry with expanded parameters
```powershell
Update-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -DisplayName "My Updated Schema Registry" -Description "Updated schema registry description"
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

This example updates a Device Registry Schema Registry by modifying its display name and description using individual parameters. This approach is useful when you want to update specific properties of an existing schema registry.

### Example 2: Update a Device Registry Schema Registry using identity object
```powershell
Update-AzDeviceRegistrySchemaRegistry -InputObject $schemaRegistryObject -DisplayName "My Updated Schema Registry" -Description "Updated schema registry description"
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

This example updates a Device Registry Schema Registry using a schema registry identity object obtained from a previous operation. This approach is useful when you already have a schema registry object from another cmdlet like Get-AzDeviceRegistrySchemaRegistry or New-AzDeviceRegistrySchemaRegistry.

