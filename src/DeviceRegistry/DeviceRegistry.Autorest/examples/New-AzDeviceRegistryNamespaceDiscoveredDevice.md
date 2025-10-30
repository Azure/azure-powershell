### Example 1: Create a discovered device with expanded parameters
```powershell
$outboundAssigned = @{
    "myendpoint2" = @{
        Address = "https://myendpoint2.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IoTHubs"
    }
}
$endpointInbound = @{
    "endpoint1" = @{
        Address = "https://myendpoint1.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        Version = "1.0"
    }
    "endpoint2" = @{
        Address = "https://myendpoint2.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        Version = "2.0"
    }
}

New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -Location "East US" -ExtendedLocationName "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq" -ExtendedLocationType "CustomLocation" -DiscoveryId "discovery-123" -Version "1.0.0" -Manufacturer "Contoso" -Model "Device-X1" -OperatingSystem "Linux" -OperatingSystemVersion "Ubuntu 20.04" -OutboundAssigned $outboundAssigned -EndpointInbound $endpointInbound
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

Creates a new discovered device in the specified namespace with expanded parameters.

### Example 2: Create a discovered device using a JSON file
```powershell
New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -JsonFilePath "C:\path\to\device-config.json"
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

Creates a new discovered device using configuration from a JSON file containing the discovered device's properties.

### Example 3: Create a discovered device using a JSON string
```powershell
$jsonString = Get-Content -Path "C:\path\to\device-config.json" -Raw
New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -JsonString $jsonString
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

Creates a new discovered device using a JSON string loaded from a file containing the discovered device's properties.

