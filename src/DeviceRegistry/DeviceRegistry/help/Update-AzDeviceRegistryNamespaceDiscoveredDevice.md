---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/update-azdeviceregistrynamespacediscovereddevice
schema: 2.0.0
---

# Update-AzDeviceRegistryNamespaceDiscoveredDevice

## SYNOPSIS
Update a NamespaceDiscoveredDevice

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeviceRegistryNamespaceDiscoveredDevice -DiscoveredDeviceName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Attribute <Hashtable>] [-DiscoveryId <String>]
 [-EndpointInbound <Hashtable>] [-ExternalDeviceId <String>] [-OperatingSystemVersion <String>]
 [-OutboundAssigned <Hashtable>] [-Tag <Hashtable>] [-Version <Int64>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDeviceRegistryNamespaceDiscoveredDevice -DiscoveredDeviceName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDeviceRegistryNamespaceDiscoveredDevice -DiscoveredDeviceName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityNamespaceExpanded
```
Update-AzDeviceRegistryNamespaceDiscoveredDevice -DiscoveredDeviceName <String>
 -NamespaceInputObject <IDeviceRegistryIdentity> [-Attribute <Hashtable>] [-DiscoveryId <String>]
 [-EndpointInbound <Hashtable>] [-ExternalDeviceId <String>] [-OperatingSystemVersion <String>]
 [-OutboundAssigned <Hashtable>] [-Tag <Hashtable>] [-Version <Int64>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject <IDeviceRegistryIdentity>
 [-Attribute <Hashtable>] [-DiscoveryId <String>] [-EndpointInbound <Hashtable>] [-ExternalDeviceId <String>]
 [-OperatingSystemVersion <String>] [-OutboundAssigned <Hashtable>] [-Tag <Hashtable>] [-Version <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a NamespaceDiscoveredDevice

## EXAMPLES

### Example 1: Update a Device Registry Namespace Discovered Device with expanded parameters
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
Update-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device" -OperatingSystemVersion "10.0.19041" -EndpointInbound $endpointsInbound
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
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
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
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
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
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
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

Updates a Device Registry Namespace Discovered Device using a JSON file containing the properties to update.

### Example 4: Update a Device Registry Namespace Discovered Device using namespace identity object
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
Update-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName "my-discovered-device" -OperatingSystemVersion "10.0.19041" -EndpointInbound $endpointsInbound
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
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
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
Update-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $discoveredDeviceObject -OperatingSystemVersion "10.0.19041" -EndpointInbound $endpointsInbound
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
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microso
                               ft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType         : CustomLocation
ExternalDeviceId             :
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredDevices/my-discovered-device
Location                     : eastus2
Manufacturer                 : Contoso
Model                        : foo123
Name                         : my-discovered-device
OperatingSystem              : Linux
OperatingSystemVersion       : 10.0.19041
OutboundAssigned             : {
                                 "myendpoint2": {
                                   "endpointType": "Microsoft.Devices/IoTHubs",
                                   "address": "https://myendpoint2.westeurope-1.iothub.azure.net"
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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Attribute
A set of key-value pairs that contain custom attributes.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DiscoveredDeviceName
The name of the discovered device.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiscoveryId
Identifier used to detect changes in the discovered device.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointInbound
Set of endpoints to connect to the device.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalDeviceId
A device ID that represents the device in a system external to Azure.
Unique within scope of an Azure tenant.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentityNamespaceExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperatingSystemVersion
Device operating system version.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutboundAssigned
Endpoints the device can connect to.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
An integer that is incremented each time the resource is modified.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredDevice

## NOTES

## RELATED LINKS
