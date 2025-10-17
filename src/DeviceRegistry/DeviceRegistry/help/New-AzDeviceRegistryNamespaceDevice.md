---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/new-azdeviceregistrynamespacedevice
schema: 2.0.0
---

# New-AzDeviceRegistryNamespaceDevice

## SYNOPSIS
Create a NamespaceDevice

## SYNTAX

### CreateExpanded (Default)
```
New-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-Attribute <Hashtable>] [-DiscoveredDeviceRef <String>]
 [-Enabled] [-EndpointsInbound <Hashtable>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-ExternalDeviceId <String>] [-Manufacturer <String>] [-Model <String>] [-OperatingSystem <String>]
 [-OperatingSystemVersion <String>] [-OutboundAssigned <Hashtable>] [-OutboundUnassigned <Hashtable>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDeviceRegistryNamespaceDevice -DeviceName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a NamespaceDevice

## EXAMPLES

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
A set of key-value pairs that contain custom attributes set by the customer.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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

### -DeviceName
The name of the device.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiscoveredDeviceRef
Reference to a device.
Populated only if the device had been created from discovery flow.
Discovered device name must be provided.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Indicates if the resource is enabled or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointsInbound
Set of endpoints to connect to the device.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The extended location name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The extended location type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalDeviceId
The Device ID provided by the customer.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manufacturer
Device manufacturer.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Model
Device model.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of the namespace.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -OperatingSystem
Device operating system.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutboundUnassigned
Set of most recently removed endpoints.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDevice

## NOTES

## RELATED LINKS
