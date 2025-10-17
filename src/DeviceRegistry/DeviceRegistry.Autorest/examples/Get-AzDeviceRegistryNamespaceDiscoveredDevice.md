### Example 1: List Namespace Discovered Devices in a Namespace
```powershell
Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace"
```

```output
Location Name                                            SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDat
                                                                                                                           aLastModi
                                                                                                                           fiedAt
-------- ----                                            -------------------   ------------------- ----------------------- ---------
eastus2  foodevice                                       7/24/2025 9:38:24 PM  user@outlook.com  User                    7/24/202…
eastus2  test-ns-ddevice-create-json-file-path           7/24/2025 9:46:05 PM  user@outlook.com  User                    7/24/202…
```

Lists all Namespace Discovered Devices in a specified parent Namespace.

### Example 2: Get Namespace Discovered Device via Namespace Identity
```powershell
$namespaceIdentity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Get-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName "my-discovered-device"
```

```output

Attribute                    : {
                                 "deviceType": "sensor",
                                 "deviceOwner": "dev",
                                 "deviceCategory": 4000,
                                 "invalid": "foo",
                                 "x-ms-iothub-credential-id": ""
                               }
DiscoveryId                  : myDiscoveryId
EndpointInbound              : {
                                 "endpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "version": "1.0"
                                 },
                                 "endpoint2": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "version": "2.0"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxxx/resourceGroups/my-resource-group/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/test-ns-ddevice-create-json-file-path
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : test-ns-ddevice-create-json-file-path
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 10/17/2025 12:09:47 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/17/2025 12:09:47 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Gets a Namespace Discovered Device using the parent Namespace's Identity object.

### Example 3: Get Namespace Discovered Device
```powershell
Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device"
```

```output

Attribute                    : {
                                 "deviceType": "sensor",
                                 "deviceOwner": "dev",
                                 "deviceCategory": 4000,
                                 "invalid": "foo",
                                 "x-ms-iothub-credential-id": ""
                               }
DiscoveryId                  : myDiscoveryId
EndpointInbound              : {
                                 "endpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "version": "1.0"
                                 },
                                 "endpoint2": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "version": "2.0"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxxx/resourceGroups/my-resource-group/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/test-ns-ddevice-create-json-file-path
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : test-ns-ddevice-create-json-file-path
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 10/17/2025 12:09:47 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/17/2025 12:09:47 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Gets a specific Namespace Discovered Device from its parent Namespace.

### Example 4: Get Namespace Discovered Device via Identity
```powershell
$identity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
    DiscoveredDeviceName = "my-discovered-device"
}
Get-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $identity
```

```output

Attribute                    : {
                                 "deviceType": "sensor",
                                 "deviceOwner": "dev",
                                 "deviceCategory": 4000,
                                 "invalid": "foo",
                                 "x-ms-iothub-credential-id": ""
                               }
DiscoveryId                  : myDiscoveryId
EndpointInbound              : {
                                 "endpoint1": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "version": "1.0"
                                 },
                                 "endpoint2": {
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "version": "2.0"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxxx/resourceGroups/my-resource-group/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/test-ns-ddevice-create-json-file-path
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : test-ns-ddevice-create-json-file-path
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 10/17/2025 12:09:47 AM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/17/2025 12:09:47 AM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Gets a Namespace Discovered Device using the discovered device's Identity object.

