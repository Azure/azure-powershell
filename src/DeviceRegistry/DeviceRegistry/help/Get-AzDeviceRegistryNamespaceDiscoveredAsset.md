---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/get-azdeviceregistrynamespacediscoveredasset
schema: 2.0.0
---

# Get-AzDeviceRegistryNamespaceDiscoveredAsset

## SYNOPSIS
Get a NamespaceDiscoveredAsset

## SYNTAX

### List (Default)
```
Get-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityNamespace
```
Get-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String>
 -NamespaceInputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject <IDeviceRegistryIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a NamespaceDiscoveredAsset

## EXAMPLES

### Example 1: List Namespace Discovered Assets in a Namespace
```powershell
Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace"
```

```output
Location Name                                           SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataL
                                                                                                                         astModified
                                                                                                                         At
-------- ----                                           -------------------  ------------------- ----------------------- -----------
eastus2  test-ns-dasset-update                          7/23/2025 4:57:03 AM user@outlook.com  User                    7/23/2025 …
```

Lists all Namespace Discovered Assets in the specified parent Namespace.

### Example 2: Get Namespace Discovered Asset via Namespace Identity
```powershell
$namespaceIdentity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Get-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName "my-discovered-asset"
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Dataset                              : {{
                                         "name": "dataset1",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc"
                                       }, {
                                         "name": "dataSet2",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/Oven;i=5",
                                         "typeRef": "dataset1TypeRef",
                                         "datasetConfiguration":
                                       "{\"publishingInterval\":10,\"samplingInterval\":15,\"queueSize\":20}",
                                         "destinations": [
                                           {
                                             "target": "Mqtt",
                                             "configuration": {
                                               "topic": "/contoso/test2",
                                               "retain": "Keep",
                                               "qos": "Qos1",
                                               "ttl": 3600
                                             }
                                           }
                                         ],
                                         "dataPoints": [
                                           {
                                             "name": "dataset1DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt3",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                             "typeRef": "dataset1DataPoint1TypeRef"
                                           },
                                           {
                                             "name": "dataset1DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt4",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                             "typeRef": "dataset1DataPoint2TypeRef"
                                           }
                                         ]
                                       }}
DefaultDatasetsConfiguration         : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultDatasetsDestination           : {{
                                         "target": "BrokerStateStore",
                                         "configuration": {
                                           "key": "defaultValue"
                                         }
                                       }}
DefaultEventsConfiguration           : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultEventsDestination             : {{
                                         "target": "Storage",
                                         "configuration": {
                                           "path": "/tmp"
                                         }
                                       }}
DefaultManagementGroupsConfiguration : {"retryCount":10,"retryBackoffInterval":15}
DefaultStreamsConfiguration          : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultStreamsDestination            : {{
                                         "target": "Mqtt",
                                         "configuration": {
                                           "topic": "/contoso/test",
                                           "retain": "Never",
                                           "qos": "Qos0",
                                           "ttl": 3600
                                         }
                                       }}
DeviceRefDeviceName                  : myDeviceName
DeviceRefEndpointName                : myEndpointName
DiscoveryId                          : myDiscoveryId
DocumentationUri                     : https://www.example.com/manual/
EventGroup                           : {{
                                         "name": "eventGroup1",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/EventGroup1",
                                         "eventGroupConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":15,\"queueSize\":20}",
                                         "typeRef": "eventGroup1TypeRef",
                                         "events": [
                                           {
                                             "name": "event1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt5",
                                             "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                             "destinations": [
                                               {
                                                 "target": "Mqtt",
                                                 "configuration": {
                                                   "topic": "/contoso/testEvent1",
                                                   "retain": "Keep",
                                                   "qos": "Qos0",
                                                   "ttl": 7200
                                                 }
                                               }
                                             ],
                                             "typeRef": "event1Ref"
                                           }
                                         ]
                                       }, {
                                         "name": "eventGroup2",
                                         "events": [
                                           {
                                             "name": "event2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt8",
                                             "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                             "destinations": [
                                               {
                                                 "target": "Storage",
                                                 "configuration": {
                                                   "path": "/tmp/event2"
                                                 }
                                               }
                                             ],
                                             "typeRef": "event2Ref"
                                           }
                                         ]
                                       }}
ExtendedLocationName                 : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers
                                       /Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredAssets/my-discovered-asset
Location                             : eastus2
ManagementGroup                      : {{
                                         "name": "managementGroup1",
                                         "managementGroupConfiguration": "{\"retryCount\":10,\"retryBackoffInterval\":15}",
                                         "typeRef": "managementGroup1TypeRef",
                                         "defaultTopic": "/contoso/managementGroup1",
                                         "defaultTimeoutInSeconds": 100,
                                         "actions": [
                                           {
                                             "name": "action1",
                                             "actionConfiguration": "{\"retryCount\":5,\"retryBackoffInterval\":5}",
                                             "targetUri": "/onvif/device_service?ONVIFProfile=Profile1",
                                             "typeRef": "action1TypeRef",
                                             "topic": "/contoso/managementGroup1/action1",
                                             "actionType": "Call",
                                             "timeoutInSeconds": 60
                                           },
                                           {
                                             "name": "action2",
                                             "actionConfiguration": "{\"retryCount\":5,\"retryBackoffInterval\":5}",
                                             "targetUri": "/onvif/device_service?ONVIFProfile=Profile2",
                                             "typeRef": "action2TypeRef",
                                             "topic": "/contoso/managementGroup1/action2",
                                             "actionType": "Call",
                                             "timeoutInSeconds": 60
                                           }
                                         ]
                                       }}
Manufacturer                         : Contoso123
ManufacturerUri                      : https://www.contoso.com/manufacturerUri
Model                                : ContosoModel
Name                                 : my-discovered-asset
ProductCode                          : SA34VDG
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         : 64-103816-519918-8
SoftwareRevision                     : 2.0
Stream                               : {{
                                         "name": "stream1",
                                         "streamConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                         "typeRef": "stream1TypeRef",
                                         "destinations": [
                                           {
                                             "target": "Storage",
                                             "configuration": {
                                               "path": "/tmp/stream1"
                                             }
                                           }
                                         ]
                                       }, {
                                         "name": "stream2",
                                         "streamConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                         "typeRef": "stream2TypeRef",
                                         "destinations": [
                                           {
                                             "target": "Mqtt",
                                             "configuration": {
                                               "topic": "/contoso/testStream2",
                                               "retain": "Never",
                                               "qos": "Qos0",
                                               "ttl": 7200
                                             }
                                           }
                                         ]
                                       }}
SystemDataCreatedAt                  : 7/23/2025 6:20:48 AM
SystemDataCreatedBy                  : user@outlook.com
SystemDataCreatedByType              : User
SystemDataLastModifiedAt             : 7/23/2025 6:26:10 AM
SystemDataLastModifiedBy             : user@outlook.com
SystemDataLastModifiedByType         : User
Tag                                  : {
                                         "sensor": "temperature,humidity,pressure"
                                       }
Type                                 : microsoft.deviceregistry/namespaces/discoveredassets
Version                              : 1
```

Gets a Namespace Discovered Asset using the parent Namespace's Identity object.

### Example 3: Get Namespace Discovered Asset
```powershell
Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset"
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Dataset                              : {{
                                         "name": "dataset1",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc"
                                       }, {
                                         "name": "dataSet2",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/Oven;i=5",
                                         "typeRef": "dataset1TypeRef",
                                         "datasetConfiguration":
                                       "{\"publishingInterval\":10,\"samplingInterval\":15,\"queueSize\":20}",
                                         "destinations": [
                                           {
                                             "target": "Mqtt",
                                             "configuration": {
                                               "topic": "/contoso/test2",
                                               "retain": "Keep",
                                               "qos": "Qos1",
                                               "ttl": 3600
                                             }
                                           }
                                         ],
                                         "dataPoints": [
                                           {
                                             "name": "dataset1DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt3",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                             "typeRef": "dataset1DataPoint1TypeRef"
                                           },
                                           {
                                             "name": "dataset1DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt4",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                             "typeRef": "dataset1DataPoint2TypeRef"
                                           }
                                         ]
                                       }}
DefaultDatasetsConfiguration         : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultDatasetsDestination           : {{
                                         "target": "BrokerStateStore",
                                         "configuration": {
                                           "key": "defaultValue"
                                         }
                                       }}
DefaultEventsConfiguration           : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultEventsDestination             : {{
                                         "target": "Storage",
                                         "configuration": {
                                           "path": "/tmp"
                                         }
                                       }}
DefaultManagementGroupsConfiguration : {"retryCount":10,"retryBackoffInterval":15}
DefaultStreamsConfiguration          : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultStreamsDestination            : {{
                                         "target": "Mqtt",
                                         "configuration": {
                                           "topic": "/contoso/test",
                                           "retain": "Never",
                                           "qos": "Qos0",
                                           "ttl": 3600
                                         }
                                       }}
DeviceRefDeviceName                  : myDeviceName
DeviceRefEndpointName                : myEndpointName
DiscoveryId                          : myDiscoveryId
DocumentationUri                     : https://www.example.com/manual/
EventGroup                           : {{
                                         "name": "eventGroup1",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/EventGroup1",
                                         "eventGroupConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":15,\"queueSize\":20}",
                                         "typeRef": "eventGroup1TypeRef",
                                         "events": [
                                           {
                                             "name": "event1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt5",
                                             "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                             "destinations": [
                                               {
                                                 "target": "Mqtt",
                                                 "configuration": {
                                                   "topic": "/contoso/testEvent1",
                                                   "retain": "Keep",
                                                   "qos": "Qos0",
                                                   "ttl": 7200
                                                 }
                                               }
                                             ],
                                             "typeRef": "event1Ref"
                                           }
                                         ]
                                       }, {
                                         "name": "eventGroup2",
                                         "events": [
                                           {
                                             "name": "event2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt8",
                                             "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                             "destinations": [
                                               {
                                                 "target": "Storage",
                                                 "configuration": {
                                                   "path": "/tmp/event2"
                                                 }
                                               }
                                             ],
                                             "typeRef": "event2Ref"
                                           }
                                         ]
                                       }}
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers
                                       /Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredAssets/my-discovered-asset
Location                             : eastus2
ManagementGroup                      : {{
                                         "name": "managementGroup1",
                                         "managementGroupConfiguration": "{\"retryCount\":10,\"retryBackoffInterval\":15}",
                                         "typeRef": "managementGroup1TypeRef",
                                         "defaultTopic": "/contoso/managementGroup1",
                                         "defaultTimeoutInSeconds": 100,
                                         "actions": [
                                           {
                                             "name": "action1",
                                             "actionConfiguration": "{\"retryCount\":5,\"retryBackoffInterval\":5}",
                                             "targetUri": "/onvif/device_service?ONVIFProfile=Profile1",
                                             "typeRef": "action1TypeRef",
                                             "topic": "/contoso/managementGroup1/action1",
                                             "actionType": "Call",
                                             "timeoutInSeconds": 60
                                           },
                                           {
                                             "name": "action2",
                                             "actionConfiguration": "{\"retryCount\":5,\"retryBackoffInterval\":5}",
                                             "targetUri": "/onvif/device_service?ONVIFProfile=Profile2",
                                             "typeRef": "action2TypeRef",
                                             "topic": "/contoso/managementGroup1/action2",
                                             "actionType": "Call",
                                             "timeoutInSeconds": 60
                                           }
                                         ]
                                       }}
Manufacturer                         : Contoso123
ManufacturerUri                      : https://www.contoso.com/manufacturerUri
Model                                : ContosoModel
Name                                 : my-discovered-asset
ProductCode                          : SA34VDG
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         : 64-103816-519918-8
SoftwareRevision                     : 2.0
Stream                               : {{
                                         "name": "stream1",
                                         "streamConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                         "typeRef": "stream1TypeRef",
                                         "destinations": [
                                           {
                                             "target": "Storage",
                                             "configuration": {
                                               "path": "/tmp/stream1"
                                             }
                                           }
                                         ]
                                       }, {
                                         "name": "stream2",
                                         "streamConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                         "typeRef": "stream2TypeRef",
                                         "destinations": [
                                           {
                                             "target": "Mqtt",
                                             "configuration": {
                                               "topic": "/contoso/testStream2",
                                               "retain": "Never",
                                               "qos": "Qos0",
                                               "ttl": 7200
                                             }
                                           }
                                         ]
                                       }}
SystemDataCreatedAt                  : 7/23/2025 6:20:48 AM
SystemDataCreatedBy                  : user@outlook.com
SystemDataCreatedByType              : User
SystemDataLastModifiedAt             : 7/23/2025 6:26:10 AM
SystemDataLastModifiedBy             : user@outlook.com
SystemDataLastModifiedByType         : User
Tag                                  : {
                                         "sensor": "temperature,humidity,pressure"
                                       }
Type                                 : microsoft.deviceregistry/namespaces/discoveredassets
Version                              : 1
```

Gets a specific Namespace Discovered Asset from its parent Namespace.

### Example 4: Get Namespace Discovered Asset via Identity
```powershell
$identity = @{
    SubscriptionId = "my-subscription"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
    DiscoveredAssetName = "my-discovered-asset"
}
Get-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $identity
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Dataset                              : {{
                                         "name": "dataset1",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc"
                                       }, {
                                         "name": "dataSet2",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/Oven;i=5",
                                         "typeRef": "dataset1TypeRef",
                                         "datasetConfiguration":
                                       "{\"publishingInterval\":10,\"samplingInterval\":15,\"queueSize\":20}",
                                         "destinations": [
                                           {
                                             "target": "Mqtt",
                                             "configuration": {
                                               "topic": "/contoso/test2",
                                               "retain": "Keep",
                                               "qos": "Qos1",
                                               "ttl": 3600
                                             }
                                           }
                                         ],
                                         "dataPoints": [
                                           {
                                             "name": "dataset1DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt3",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                             "typeRef": "dataset1DataPoint1TypeRef"
                                           },
                                           {
                                             "name": "dataset1DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt4",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                             "typeRef": "dataset1DataPoint2TypeRef"
                                           }
                                         ]
                                       }}
DefaultDatasetsConfiguration         : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultDatasetsDestination           : {{
                                         "target": "BrokerStateStore",
                                         "configuration": {
                                           "key": "defaultValue"
                                         }
                                       }}
DefaultEventsConfiguration           : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultEventsDestination             : {{
                                         "target": "Storage",
                                         "configuration": {
                                           "path": "/tmp"
                                         }
                                       }}
DefaultManagementGroupsConfiguration : {"retryCount":10,"retryBackoffInterval":15}
DefaultStreamsConfiguration          : {"defaultPublishingInterval": 200, "defaultSamplingInterval": 500, "defaultQueueSize": 10}
DefaultStreamsDestination            : {{
                                         "target": "Mqtt",
                                         "configuration": {
                                           "topic": "/contoso/test",
                                           "retain": "Never",
                                           "qos": "Qos0",
                                           "ttl": 3600
                                         }
                                       }}
DeviceRefDeviceName                  : myDeviceName
DeviceRefEndpointName                : myEndpointName
DiscoveryId                          : myDiscoveryId
DocumentationUri                     : https://www.example.com/manual/
EventGroup                           : {{
                                         "name": "eventGroup1",
                                         "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/EventGroup1",
                                         "eventGroupConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":15,\"queueSize\":20}",
                                         "typeRef": "eventGroup1TypeRef",
                                         "events": [
                                           {
                                             "name": "event1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt5",
                                             "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                             "destinations": [
                                               {
                                                 "target": "Mqtt",
                                                 "configuration": {
                                                   "topic": "/contoso/testEvent1",
                                                   "retain": "Keep",
                                                   "qos": "Qos0",
                                                   "ttl": 7200
                                                 }
                                               }
                                             ],
                                             "typeRef": "event1Ref"
                                           }
                                         ]
                                       }, {
                                         "name": "eventGroup2",
                                         "events": [
                                           {
                                             "name": "event2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt8",
                                             "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                             "destinations": [
                                               {
                                                 "target": "Storage",
                                                 "configuration": {
                                                   "path": "/tmp/event2"
                                                 }
                                               }
                                             ],
                                             "typeRef": "event2Ref"
                                           }
                                         ]
                                       }}
ExtendedLocationName                 : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/my-subscription/resourceGroups/my-resource-group/providers
                                       /Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredAssets/my-discovered-asset
Location                             : eastus2
ManagementGroup                      : {{
                                         "name": "managementGroup1",
                                         "managementGroupConfiguration": "{\"retryCount\":10,\"retryBackoffInterval\":15}",
                                         "typeRef": "managementGroup1TypeRef",
                                         "defaultTopic": "/contoso/managementGroup1",
                                         "defaultTimeoutInSeconds": 100,
                                         "actions": [
                                           {
                                             "name": "action1",
                                             "actionConfiguration": "{\"retryCount\":5,\"retryBackoffInterval\":5}",
                                             "targetUri": "/onvif/device_service?ONVIFProfile=Profile1",
                                             "typeRef": "action1TypeRef",
                                             "topic": "/contoso/managementGroup1/action1",
                                             "actionType": "Call",
                                             "timeoutInSeconds": 60
                                           },
                                           {
                                             "name": "action2",
                                             "actionConfiguration": "{\"retryCount\":5,\"retryBackoffInterval\":5}",
                                             "targetUri": "/onvif/device_service?ONVIFProfile=Profile2",
                                             "typeRef": "action2TypeRef",
                                             "topic": "/contoso/managementGroup1/action2",
                                             "actionType": "Call",
                                             "timeoutInSeconds": 60
                                           }
                                         ]
                                       }}
Manufacturer                         : Contoso123
ManufacturerUri                      : https://www.contoso.com/manufacturerUri
Model                                : ContosoModel
Name                                 : my-discovered-asset
ProductCode                          : SA34VDG
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         : 64-103816-519918-8
SoftwareRevision                     : 2.0
Stream                               : {{
                                         "name": "stream1",
                                         "streamConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                         "typeRef": "stream1TypeRef",
                                         "destinations": [
                                           {
                                             "target": "Storage",
                                             "configuration": {
                                               "path": "/tmp/stream1"
                                             }
                                           }
                                         ]
                                       }, {
                                         "name": "stream2",
                                         "streamConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}",
                                         "typeRef": "stream2TypeRef",
                                         "destinations": [
                                           {
                                             "target": "Mqtt",
                                             "configuration": {
                                               "topic": "/contoso/testStream2",
                                               "retain": "Never",
                                               "qos": "Qos0",
                                               "ttl": 7200
                                             }
                                           }
                                         ]
                                       }}
SystemDataCreatedAt                  : 7/23/2025 6:20:48 AM
SystemDataCreatedBy                  : user@outlook.com
SystemDataCreatedByType              : User
SystemDataLastModifiedAt             : 7/23/2025 6:26:10 AM
SystemDataLastModifiedBy             : user@outlook.com
SystemDataLastModifiedByType         : User
Tag                                  : {
                                         "sensor": "temperature,humidity,pressure"
                                       }
Type                                 : microsoft.deviceregistry/namespaces/discoveredassets
Version                              : 1
```

Gets a Namespace Discovered Asset using the discovered asset's Identity object.

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

### -DiscoveredAssetName
The name of the discovered asset.

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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredAsset

## NOTES

## RELATED LINKS

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

### -DiscoveredAssetName
The name of the discovered asset.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityNamespace, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

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

## NOTES

## RELATED LINKS
