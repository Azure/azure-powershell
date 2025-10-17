---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/get-azdeviceregistrynamespacedevice
schema: 2.0.0
---

# Get-AzDeviceRegistryNamespaceDevice

## SYNOPSIS
Get a NamespaceDevice

## SYNTAX

### List (Default)
```
Get-AzDeviceRegistryNamespaceDevice -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceRegistryNamespaceDevice -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityNamespace
```
Get-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceInputObject <IDeviceRegistryIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a NamespaceDevice

## EXAMPLES

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

Lists the Namespace Devices in the parent Namespace.

### Example 2: Get Namespace Device via Namespace Identity
```powershell
$namespaceIdentity = @{
  SubscriptionId = "my-subscription"
  ResourceGroupName = "my-resource-group"
  NamespaceName = "my-namespace"
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
                                       "certificateSecretName": "mycertificate",
                                       "keySecretName": "mykeysecret",
                                       "intermediateCertificatesSecretName": "myintermediatecerts"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
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
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers/microso
                               ft.deviceregistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
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

Gets a Namespace Device using the parent Namespace's Identity object.

### Example 3: Get Namespace Device
```powershell
Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device"
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
                                       "certificateSecretName": "mycertificate",
                                       "keySecretName": "mykeysecret",
                                       "intermediateCertificatesSecretName": "myintermediatecerts"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
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
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/microso
                               ft.deviceregistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
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

Gets a Namespace Device from the parent Namespace.

### Example 4: Get Namespace Device Via Identity
```powershell
$identity = @{
  SubscriptionId = "my-subscription"
  ResourceGroupName = "my-resource-group"
  NamespaceName = "my-namespace"
  DeviceName = "my-device"
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
                                       "certificateSecretName": "mycertificate",
                                       "keySecretName": "mykeysecret",
                                       "intermediateCertificatesSecretName": "myintermediatecerts"
                                     },
                                     "method": "Certificate"
                                   },
                                   "endpointType": "Microsoft.Devices/IotHubs",
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
                                   "endpointType": "Microsoft.Devices/IotHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
                                 }
                               }
Etag                         : "170395e0-0000-0200-0000-68812dd00000"
ExtendedLocationName         : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             : 777f5f99-b81d-4db9-be6e-fcf0a325a085
Id                           : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers/microso
                               ft.deviceregistry/namespaces/my-namespace/devices/my-device
LastTransitionTime           : 7/23/2025 6:45:31 PM
Location                     : eastus2
Manufacturer                 : Contoso
Message                      :
Model                        : model123
Name                         : my-device
OperatingSystem              : Linux
OperatingSystemVersion       : 1000
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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceName
The name of the device.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: GetViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The name of the namespace.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDevice

## NOTES

## RELATED LINKS

