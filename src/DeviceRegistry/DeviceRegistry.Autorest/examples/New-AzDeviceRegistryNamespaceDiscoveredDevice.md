### Example 1: Create a discovered device with expanded parameters
```powershell
$outboundAssigned = @{
    "myendpoint2" = @{
        Address = "https://myendpoint2.westeurope-1.edge.azure.net"
        EndpointType = "azure-iot-edge"
    }
}
$endpointInbound = @{
    "endpoint1" = @{
        Address = "https://myendpoint1.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.IotHub"
        Version = "1.0"
    }
    "endpoint2" = @{
        Address = "https://myendpoint2.westeurope-1.iothub.azure.net"
        EndpointType = "Http"
        Version = "2.0"
    }
}

New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -Location "East US" -ExtendedLocationName "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-2pnh4" -ExtendedLocationType "CustomLocation" -DiscoveryId "discovery-123" -Version "1.0.0" -Manufacturer "Contoso" -Model "Device-X1" -OperatingSystem "Linux" -OperatingSystemVersion "Ubuntu 20.04" -OutboundAssigned $outboundAssigned -EndpointInbound $endpointInbound
```

```output
Attribute                    : {
                                 "deviceType": "sensor",
                                 "deviceOwner": "dev",
                                 "deviceCategory": 4000,
                                 "invalid": "foo",
                                 "x-ms-iothub-credential-id": ""
                               }
DiscoveryId                  : discovery-123
EndpointInbound              : {
                                 "endpoint1": {
                                   "authentication": {
                                     "x509Credentials": {
                                       "certificateSecretName": "mycertificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "myusername",
                                       "passwordSecretName": "mypassword"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : East US
Manufacturer                 : Contoso
Model                        : Device-X1
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : Ubuntu 20.04
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/24/2025 9:38:24 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:34:19 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1.0.0
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
                                   "authentication": {
                                     "x509Credentials": {
                                       "certificateSecretName": "mycertificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "myusername",
                                       "passwordSecretName": "mypassword"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : East US
Manufacturer                 : Contoso
Model                        : Device-X1
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : Ubuntu 20.04
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/24/2025 9:38:24 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:34:19 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1.0.0
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
                                   "authentication": {
                                     "x509Credentials": {
                                       "certificateSecretName": "mycertificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "myusername",
                                       "passwordSecretName": "mypassword"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.IotHub",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : East US
Manufacturer                 : Contoso
Model                        : Device-X1
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : Ubuntu 20.04
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 7/24/2025 9:38:24 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 10:34:19 PM
SystemDataLastModifiedBy     : user@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/discovereddevices
Version                      : 1.0.0
```

Creates a new discovered device using a JSON string loaded from a file containing the discovered device's properties.

