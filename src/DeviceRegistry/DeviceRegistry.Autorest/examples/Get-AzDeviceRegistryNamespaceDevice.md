### Example 1: List Namespace Devices in a Namespace 
```powershell
Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace"
```

```output
Location Name                                           SystemDataCreatedAt   SystemDataCreatedBy                  SystemDataCreated
                                                                                                                   ByType
-------- ----                                           -------------------   -------------------                  -----------------
eastus2  adr-smart-device                               7/23/2025 6:45:31 PM  user@outlook.com                   User
eastus2  test-ns-device-create-json-file-path           7/24/2025 12:37:02 AM user@outlook.com                   User
```

Lists the Namespace Devices in a Namespace.

### Example 2: Get Namespace Device via Namespace Identity
```powershell
$namespaceIdentity = @{
  SubscriptionId = "mysubscription"
  ResourceGroupName = "myresourcegroup"
  NamespaceName = "mynamespace"
}
Get-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName "my-device"
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
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/namespaces/adr-namespace/devices/adr-smart-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : adr-smart-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
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

Gets a Namespace Device using the Namespace's Identity object.

### Example 3: Get Namespace Device
```pwsh
Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName "myresourcegroup" -NamespaceName "namespaceName" -DeviceName "deviceName"
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
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/namespaces/adr-namespace/devices/adr-smart-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : adr-smart-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
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

Gets a Namespace Device from a Namespace.


### Example 4: Get Namespace Device Via Identity
```pwsh
$identity = @{
  SubscriptionId = "mysubscription"
  ResourceGroupName = "myresourcegroup"
  NamespaceName = "mynamespace"
  DeviceName = "mydevice"
}
Get-AzDeviceRegistryNamespaceDevice -InputObject $identity
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
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microso
                               ft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/microso
                               ft.deviceregistry/namespaces/adr-namespace/devices/adr-smart-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : adr-smart-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "azure-iot-edge",
                                   "address": "https://myendpoint2.westeurope-1.edge.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : adr-pwsh-test-rg
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

Gets a Namespace Device with the device's Identity object.