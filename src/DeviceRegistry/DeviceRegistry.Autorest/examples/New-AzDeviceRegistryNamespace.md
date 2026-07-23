### Example 1: Create Namespace with Expanded Parameters
```powershell
$endpointsHashtable = @{
    "my-endpoint1" = @{
        "resourceId" = "/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.IotHub/namespaces/my-hub-namespace1"
        "address" = "https://my-endpoint1.westeurope-1.iothub.azure.net"
        "endpointType" = "Microsoft.Devices/IotHubs"
    }
    "my-endpoint2" = @{
        "resourceId" = "/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.IotHub/namespaces/my-hub-namespace2"
        "address" = "https://my-endpoint2.westeurope-1.iothub.azure.net"
        "endpointType" = "Microsoft.Devices/IotHubs"
    }
}

New-AzDeviceRegistryNamespace -Name "my-namespace" -ResourceGroupName "my-resource-group" -Location "eastus" -MessagingEndpoint $endpointsHashtable
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/my-namespace
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.EventGrid/namespaces/contoso-hub-namespace1"
                                 },
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.IotHub/namespaces/contoso-edge-namespace2"
                                 }
                               }
Name                         : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 5:15:28 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/23/2025 6:44:04 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 04aea28f-0906-4c2c-a716-23971af76d82
```

Creates a new Namespace using expanded parameters.

### Example 2: Create Namespace via JSON File Path
```powershell
New-AzDeviceRegistryNamespace -Name "my-namespace" -ResourceGroupName "my-resource-group" -JsonFilePath "C:\path\to\namespace.json"
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/my-namespace
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.EventGrid/namespaces/contoso-hub-namespace1"
                                 },
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.IotHub/namespaces/contoso-edge-namespace2"
                                 }
                               }
Name                         : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 5:15:28 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/23/2025 6:44:04 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 04aea28f-0906-4c2c-a716-23971af76d82
```

Creates a new namespace using a JSON file that contains the namespace properties.

### Example 3: Create Namespace via JSON String
```powershell
$jsonString = Get-Content -Path "C:\path\to\namespace.json" -Raw
New-AzDeviceRegistryNamespace -Name "my-namespace" -ResourceGroupName "my-resource-group" -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/my-namespace
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
Location                     : eastus2
MessagingEndpoint            : {
                                 "myendpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.EventGrid/namespaces/contoso-hub-namespace1"
                                 },
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "resourceId": "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.IotHub/namespaces/contoso-edge-namespace2"
                                 }
                               }
Name                         : my-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/22/2025 5:15:28 AM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/23/2025 6:44:04 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/namespaces
Uuid                         : 04aea28f-0906-4c2c-a716-23971af76d82
```

Creates a new Namespace using a JSON string that contains the namespace properties.

