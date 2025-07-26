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
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/namespaces/test-namespace-update
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                                 }
                               }
Name                         : test-namespace-update
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SystemDataCreatedAt          : 7/22/2025 6:44:04 PM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/22/2025 7:03:27 PM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 80cfca37-a523-400a-bb9f-3c11b1ac18a0
```

This example updates a Device Registry Namespace by modifying its messaging endpoints. The command updates the namespace with a new messaging endpoint configuration that includes the resource ID, address, and endpoint type for an IoT Hub.

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
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/namespaces/test-namespace-update
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-r
                               g/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                                 }
                               }
Name                         : test-namespace-update
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SystemDataCreatedAt          : 7/22/2025 6:44:04 PM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/22/2025 7:03:27 PM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 80cfca37-a523-400a-bb9f-3c11b1ac18a0
```

This example updates a Device Registry Namespace using an identity object obtained from a previous operation. This approach is useful when you already have a namespace object from another cmdlet like Get-AzDeviceRegistryNamespace or New-AzDeviceRegistryNamespace.

