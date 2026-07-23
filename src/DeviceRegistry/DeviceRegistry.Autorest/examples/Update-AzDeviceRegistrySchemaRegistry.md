### Example 1: Update a Device Registry Schema Registry with expanded parameters
```powershell
Update-AzDeviceRegistrySchemaRegistry -ResourceGroupName "my-resource-group" -SchemaRegistryName "my-schema-registry" -DisplayName "My Updated Schema Registry" -Description "Updated schema registry description"
```

```output
Description                  : Updated schema registry description
DisplayName                  : My Updated Schema Registry
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/schemaRegistries/my-schema-registry
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : my-schema-registry
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
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

Updates a Device Registry Schema Registry by modifying its properties using individual parameters.

### Example 2: Update a Device Registry Schema Registry using identity object
```powershell
$schemaRegistryObject = @{
  SubscriptionId = "xxxxx-xxxxx-xxxx-xxxxxxxx"
  ResourceGroupName = "my-resource-group"
  SchemaRegistryName = "my-schema-registry"
}
Update-AzDeviceRegistrySchemaRegistry -InputObject $schemaRegistryObject -DisplayName "My Updated Schema Registry" -Description "Updated schema registry description"
```

```output
Description                  : Updated schema registry description
DisplayName                  : My Updated Schema Registry
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/schemaRegistries/my-schema-registry
IdentityPrincipalId          : 8a3685e2-3ae4-42da-8920-8d169722f032
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
Location                     : eastus2
Name                         : my-schema-registry
Namespace                    : aio-sr-ns-d179cdfcb7
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
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

Updates a Device Registry Schema Registry using the schema registry's identity object.

