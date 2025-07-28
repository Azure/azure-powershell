### Example 1: Update a Device Registry Namespace Discovered Device with expanded parameters
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -HardwareRevision "Rev2.0" -SoftwareRevision "v2.1.0"
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
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "version": "1.1"
                                 },
                                 "endpoint2": {
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "version": "2.0"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/test-ns-ddevice-update
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : test-ns-ddevice-update
OperatingSystem              : Linux
OperatingSystemVersion       : 2000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/24/2025 10:22:51 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:41:40 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Updates a Device Registry Namespace Discovered Device by modifying its properties using individual parameters.

### Example 2: Update a Device Registry Namespace Discovered Device using JSON string
```powershell
$updateJson = '{
  "properties": {
    "hardwareRevision": "Rev2.0",
    "softwareRevision": "v2.1.0"
  }
}'
Update-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -JsonString $updateJson
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
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "version": "1.1"
                                 },
                                 "endpoint2": {
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "version": "2.0"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/test-ns-ddevice-update
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : test-ns-ddevice-update
OperatingSystem              : Linux
OperatingSystemVersion       : 2000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/24/2025 10:22:51 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:41:40 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Updates a Device Registry Namespace Discovered Device using a JSON string containing the properties to update.

### Example 3: Update a Device Registry Namespace Discovered Device using JSON file path
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -JsonFilePath "C:\path\to\update-discovered-device.json"
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

Updates a Device Registry Namespace Discovered Device using a JSON file containing the properties to update.

### Example 4: Update a Device Registry Namespace Discovered Device using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Update-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName "my-discovered-device" -HardwareRevision "Rev2.0" -SoftwareRevision "v2.1.0"
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
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "version": "1.1"
                                 },
                                 "endpoint2": {
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "version": "2.0"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/test-ns-ddevice-update
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : test-ns-ddevice-update
OperatingSystem              : Linux
OperatingSystemVersion       : 2000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/24/2025 10:22:51 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:41:40 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Updates a Device Registry Namespace Discovered Device using the parent namespace's identity object.

### Example 5: Update a Device Registry Namespace Discovered Device using discovered device identity object
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $discoveredDeviceObject -HardwareRevision "Rev2.0" -SoftwareRevision "v2.1.0"
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
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net",
                                   "version": "1.1"
                                 },
                                 "endpoint2": {
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net",
                                   "version": "2.0"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/test-ns-ddevice-update
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : test-ns-ddevice-update
OperatingSystem              : Linux
OperatingSystemVersion       : 2000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/24/2025 10:22:51 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:41:40 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Updates a Device Registry Namespace Discovered Device using the discovered device identity object.

