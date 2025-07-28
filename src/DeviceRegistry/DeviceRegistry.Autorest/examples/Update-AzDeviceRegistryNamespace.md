### Example 1: Update a Device Registry Namespace with messaging endpoints
```powershell
$patchBody = @{
    "myendpoint1" = @{
        "resourceId" = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.IotHub/namespaces/my-iothub-namespace"
        "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
        "endpointType" = "Microsoft.Devices/IotHubs"
    }
}
Update-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -MessagingEndpoint $patchBody
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/test-namespace-update
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                                 }
                               }
Name                         : test-namespace-update
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 6:44:04 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/22/2025 7:03:27 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 80cfca37-a523-400a-bb9f-3c11b1ac18a0
```

Updates a Device Registry Namespace by specifying the properties to update.

### Example 2: Update a Device Registry Namespace using an identity object
```powershell
$patchBody = @{
    "myendpoint1" = @{
        "resourceId" = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.IotHub/namespaces/my-iothub-namespace"
        "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
        "endpointType" = "Microsoft.Devices/IotHubs"
    }
}
Update-AzDeviceRegistryNamespace -InputObject $namespaceIdentity -MessagingEndpoint $patchBody
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/test-namespace-update
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                                 }
                               }
Name                         : test-namespace-update
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 6:44:04 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/22/2025 7:03:27 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 80cfca37-a523-400a-bb9f-3c11b1ac18a0
```

Updates a Device Registry Namespace using its identity object.

