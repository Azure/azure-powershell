### Example 1: Update a Device Registry Namespace Device with expanded parameters
```powershell
$endpointsInbound = @{
    "endpoint1" = @{
        Address = "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "Certificate"
        X509CredentialsCertificateSecretName = "my-certificate"
    }
    "endpoint2" = @{
        Address = "https://myendpoint2.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "UsernamePassword"
        UsernamePasswordCredentialsUsernameSecretName = "my-username-secret"
        UsernamePasswordCredentialsPasswordSecretName = "my-password-secret"
    }
}
Update-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device" -OperatingSystemVersion "10.0.19041" -EndpointInbound $endpointsInbound
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
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username-secret",
                                       "passwordSecretName": "my-password-secret"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "44035f1d-0000-0200-0000-688285890000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/24/2025 7:12:02 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : foo123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/24/2025 6:37:13 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 7:12:09 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Version                      : 8
```

Updates a Device Registry Namespace Device by modifying its properties using individual parameters.

### Example 2: Update a Device Registry Namespace Device using JSON string
```powershell
$updateJson = '{
  "properties": {
    "operatingSystemVersion": "10.0.19041",
    "endpointsInbound": {
      "endpoint1": {
        "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net",
        "endpointType": "Microsoft.Devices/IotHubs",
        "authentication": {
          "method": "Certificate",
          "x509Credentials": {
            "certificateSecretName": "my-certificate"
          }
        }
      },
      "endpoint2": {
        "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net",
        "endpointType": "Microsoft.Devices/IotHubs",
        "authentication": {
          "method": "UsernamePassword",
          "usernamePasswordCredentials": {
            "usernameSecretName": "my-username-secret",
            "passwordSecretName": "my-password-secret"
          }
        }
      }
    }
  }
}'
Update-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device" -JsonString $updateJson
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
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username-secret",
                                       "passwordSecretName": "my-password-secret"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "44035f1d-0000-0200-0000-688285890000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/24/2025 7:12:02 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : foo123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/24/2025 6:37:13 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 7:12:09 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Version                      : 8
```

Updates a Device Registry Namespace Device using a JSON string containing the properties to update.

### Example 3: Update a Device Registry Namespace Device using JSON file path
```powershell
Update-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device" -JsonFilePath "C:\path\to\update-device.json"
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
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username-secret",
                                       "passwordSecretName": "my-password-secret"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "44035f1d-0000-0200-0000-688285890000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/24/2025 7:12:02 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : foo123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/24/2025 6:37:13 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 7:12:09 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Version                      : 8
```

Updates a Device Registry Namespace Device using a JSON file containing the properties to update.

### Example 4: Update a Device Registry Namespace Device using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
$endpointsInbound = @{
    "endpoint1" = @{
        Address = "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "Certificate"
        X509CredentialsCertificateSecretName = "my-certificate"
    }
    "endpoint2" = @{
        Address = "https://myendpoint2.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "UsernamePassword"
        UsernamePasswordCredentialsUsernameSecretName = "my-username-secret"
        UsernamePasswordCredentialsPasswordSecretName = "my-password-secret"
    }
}
Update-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName "my-device" -OperatingSystemVersion "10.0.19041" -EndpointInbound $endpointsInbound
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
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username-secret",
                                       "passwordSecretName": "my-password-secret"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "44035f1d-0000-0200-0000-688285890000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/24/2025 7:12:02 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : foo123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/24/2025 6:37:13 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 7:12:09 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Version                      : 8
```

Updates a Device Registry Namespace Device using the namespace's identity object.

### Example 5: Update a Device Registry Namespace Device using device identity object
```powershell
$endpointsInbound = @{
    "endpoint1" = @{
        Address = "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "Certificate"
        X509CredentialsCertificateSecretName = "my-certificate"
    }
    "endpoint2" = @{
        Address = "https://myendpoint2.westeurope-1.iothub.azure.net"
        EndpointType = "Microsoft.Devices/IotHubs"
        AuthenticationMethod = "UsernamePassword"
        UsernamePasswordCredentialsUsernameSecretName = "my-username-secret"
        UsernamePasswordCredentialsPasswordSecretName = "my-password-secret"
    }
}
Update-AzDeviceRegistryNamespaceDevice -InputObject $deviceObject -OperatingSystemVersion "10.0.19041" -EndpointInbound $endpointsInbound
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
                                       "certificateSecretName": "my-certificate"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint1.westeurope-1.iothub.azure.net"
                                 },
                                 "endpoint2": {
                                   "authentication": {
                                     "usernamePasswordCredentials": {
                                       "usernameSecretName": "my-username-secret",
                                       "passwordSecretName": "my-password-secret"
                                     },
                                     "method": "UsernamePassword"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://my-inbound-endpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "44035f1d-0000-0200-0000-688285890000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/24/2025 7:12:02 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : foo123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
OutboundUnassigned           : {
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
StatusEndpointsInbound       : {
                               }
SystemDataCreatedAt          : 7/24/2025 6:37:13 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/24/2025 7:12:09 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "sensor": "temperature,humidity"
                               }
Type                         : microsoft.deviceregistry/namespaces/devices
Uuid                         : 78bc3246-208f-4df4-8aeb-1ddfa5e0e762
Version                      : 8
```

Updates a Device Registry Namespace Device using the device's identity object.

