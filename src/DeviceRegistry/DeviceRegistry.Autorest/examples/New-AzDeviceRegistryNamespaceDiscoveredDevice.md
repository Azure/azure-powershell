### Example 1: Create a discovered device with expanded parameters
```powershell
$outboundAssigned = @{
    "endpoint1" = @{
        address = "opc.tcp://example.com:4840"
        endpointType = "OpcUa"
    }
}
$endpointInbound = @{
    "endpoint1" = @{
        Address = "opc.tcp://device.local:4840"
        EndpointType = "OpcUa"
        Version = "1.0"
    }
    "endpoint2" = @{
        Address = "http://device.local:8080"
        EndpointType = "Http"
        Version = "2.0"
    }
}

New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -Location "East US" -ExtendedLocationName "my-extended-location" -ExtendedLocationType "CustomLocation" -DiscoveryId "discovery-123" -Version "1.0.0" -Manufacturer "Contoso" -Model "Device-X1" -OperatingSystem "Linux" -OperatingSystemVersion "Ubuntu 20.04" -OutboundAssigned $outboundAssigned -EndpointInbound $endpointInbound
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
ExtendedLocationName         : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/foodevice
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : foodevice
OperatingSystem              : Linux
OperatingSystemVersion       : 2000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SystemDataCreatedAt          : 7/24/2025 9:38:24 PM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:34:19 PM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Creates a new discovered device in the specified namespace with all parameters specified directly. This example shows how to configure both inbound and outbound endpoints for device communication.

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
ExtendedLocationName         : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/foodevice
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : foodevice
OperatingSystem              : Linux
OperatingSystemVersion       : 2000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SystemDataCreatedAt          : 7/24/2025 9:38:24 PM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:34:19 PM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Creates a new discovered device using configuration from a JSON file. This approach is useful when you have complex device configurations stored in files or when automating deployments with predefined configurations.

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
ExtendedLocationName         : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.DeviceRegistry/namespaces/adr-namespace/discoveredDevices/foodevice
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : foodevice
OperatingSystem              : Linux
OperatingSystemVersion       : 2000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
SystemDataCreatedAt          : 7/24/2025 9:38:24 PM
SystemDataCreatedBy          : rylo@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:34:19 PM
SystemDataLastModifiedBy     : rylo@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1
```

Creates a new discovered device using a JSON string loaded from a file. This method provides flexibility to modify the JSON configuration programmatically before creating the device.

