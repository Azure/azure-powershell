### Example 1: Create Namespace Device with Expanded Parameters
```powershell
$outboundAssigned = @{
    "my-outbound-endpoint" = @{
        address = "https://my-outbound-endpoint.westeurope-1.edge.azure.net"
        EndpointType = "Microsoft.Devices/IoTHubs"
    }
}
$endpointsInbound = @{
    "my-inbound-endpoint1" = @{
        Address = "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "Certificate"
        X509CredentialsCertificateSecretName = "my-certificate"
    }
    "my-inbound-endpoint2" = @{
        Address = "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "UsernamePassword"
        UsernamePasswordCredentialsUsernameSecretName = "my-username"
        UsernamePasswordCredentialsPasswordSecretName = "my-password"
    }
}

New-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device" -Location "eastus" -ExtendedLocationName "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq" -ExtendedLocationType "CustomLocation" -Manufacturer "Contoso" -Model "model123" -OperatingSystem "Linux" -OperatingSystemVersion "1000" -OutboundAssigned $outboundAssigned -EndpointsInbound $endpointsInbound -Enabled
```

```output
Attribute                    : {
                                 "deviceType": "sensor",
                                 "deviceOwner": "dev",
                                 "deviceCategory": 4000,
                                 "invalid": "foo",
                                 "x-ms-iothub-credential-id": ""
                               }
Code                         :
ConfigLastTransitionTime     :
ConfigVersion                :
Detail                       :
DiscoveredDeviceRef          :
Enabled                      : True
EndpointsInbound             : {
                                 "my-inbound-endpoint1": {
                                   "authentication": {
                                     "x509Credentials": {
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "my-inbound-endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username",
                                       "passwordSecretName": "my-password"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/microsoft.deviceregistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "my-outbound-endpoint": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://my-outbound-endpoint.westeurope-1.edge.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/23/2025 6:45:31 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/23/2025 6:45:36 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Version                      : 1
```

Creates a new Namespace Device with expanded parameters.

### Example 2: Create Namespace Device via JSON File Path
```powershell
New-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device" -JsonFilePath "C:\path\to\device.json"
```

```output
Attribute                    : {
                                 "deviceType": "sensor",
                                 "deviceOwner": "dev",
                                 "deviceCategory": 4000,
                                 "invalid": "foo",
                                 "x-ms-iothub-credential-id": ""
                               }
Code                         :
ConfigLastTransitionTime     :
ConfigVersion                :
Detail                       :
DiscoveredDeviceRef          :
Enabled                      : True
EndpointsInbound             : {
                                 "my-inbound-endpoint1": {
                                   "authentication": {
                                     "x509Credentials": {
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "my-inbound-endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username",
                                       "passwordSecretName": "my-password"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/microsoft.deviceregistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "my-outbound-endpoint": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://my-outbound-endpoint.westeurope-1.edge.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/23/2025 6:45:31 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/23/2025 6:45:36 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Version                      : 1
```

Creates a new Namespace Device using a JSON file that contains the device properties.

### Example 3: Create Namespace Device via JSON String
```powershell
$jsonString = Get-Content -Path "C:\path\to\device.json" -Raw
New-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device" -JsonString $jsonString
```

```output
Attribute                    : {
                                 "deviceType": "sensor",
                                 "deviceOwner": "dev",
                                 "deviceCategory": 4000,
                                 "invalid": "foo",
                                 "x-ms-iothub-credential-id": ""
                               }
Code                         :
ConfigLastTransitionTime     :
ConfigVersion                :
Detail                       :
DiscoveredDeviceRef          :
Enabled                      : True
EndpointsInbound             : {
                                 "my-inbound-endpoint1": {
                                   "authentication": {
                                     "x509Credentials": {
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "my-inbound-endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username",
                                       "passwordSecretName": "my-password"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/microsoft.deviceregistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "my-outbound-endpoint": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://my-outbound-endpoint.westeurope-1.edge.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/23/2025 6:45:31 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/23/2025 6:45:36 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Version                      : 1
```

Creates a new Namespace Device using a JSON string that contains the device properties.

