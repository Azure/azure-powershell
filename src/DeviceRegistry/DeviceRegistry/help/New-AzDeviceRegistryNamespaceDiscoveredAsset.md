---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/new-azdeviceregistrynamespacediscoveredasset
schema: 2.0.0
---

# New-AzDeviceRegistryNamespaceDiscoveredAsset

## SYNOPSIS
Create a NamespaceDiscoveredAsset

## SYNTAX

### CreateExpanded (Default)
```
New-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -ExtendedLocationName <String>
 -ExtendedLocationType <String> -Location <String> [-AssetTypeRef <String[]>] [-Attribute <Hashtable>]
 [-Dataset <INamespaceDiscoveredDataset[]>] [-DefaultDatasetsConfiguration <String>]
 [-DefaultDatasetsDestination <IDatasetDestination[]>] [-DefaultEventsConfiguration <String>]
 [-DefaultEventsDestination <IEventDestination[]>] [-DefaultManagementGroupsConfiguration <String>]
 [-DefaultStreamsConfiguration <String>] [-DefaultStreamsDestination <IStreamDestination[]>]
 [-Description <String>] [-DeviceRefDeviceName <String>] [-DeviceRefEndpointName <String>]
 [-DiscoveryId <String>] [-DisplayName <String>] [-DocumentationUri <String>]
 [-EventGroup <INamespaceDiscoveredEventGroup[]>] [-ExternalAssetId <String>] [-HardwareRevision <String>]
 [-ManagementGroup <INamespaceDiscoveredManagementGroup[]>] [-Manufacturer <String>]
 [-ManufacturerUri <String>] [-Model <String>] [-ProductCode <String>] [-SerialNumber <String>]
 [-SoftwareRevision <String>] [-Stream <INamespaceDiscoveredStream[]>] [-Tag <Hashtable>] [-Version <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDeviceRegistryNamespaceDiscoveredAsset -DiscoveredAssetName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a NamespaceDiscoveredAsset

## EXAMPLES

### Example 1: Create Namespace Discovered Asset with Expanded Parameters
```powershell
$eventGroups = @(
    @{
        name = "eventGroup1"
        dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/EventGroup1"
        eventGroupConfiguration = '{"publishingInterval":10,"samplingInterval":15,"queueSize":20}'
        typeRef = "eventGroup1TypeRef"
        events = @(
            @{
                name = "event1"
                dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt5"
                eventConfiguration = '{"publishingInterval":7,"samplingInterval":1,"queueSize":8}'
                destinations = @(
                    @{
                        target = "Mqtt"
                        configuration = @{
                            topic = "/contoso/testEvent1"
                            retain = "Keep"
                            qos = "Qos0"
                            ttl = 7200
                        }
                    }
                )
                typeRef = "event1Ref"
            }
        )
    },
    @{
        name = "eventGroup2"
        events = @(
            @{
                name = "event2"
                dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt8"
                eventConfiguration = '{"publishingInterval":7,"samplingInterval":1,"queueSize":8}'
                destinations = @(
                    @{
                        target = "Storage"
                        configuration = @{
                            path = "/tmp/event2"
                        }
                    }
                )
                typeRef = "event2Ref"
            }
        )
    }
)

$managementGroups = @(
    @{
        name = "managementGroup1"
        managementGroupConfiguration = '{"retryCount":10,"retryBackoffInterval":15}'
        typeRef = "managementGroup1TypeRef"
        defaultTopic = "/contoso/managementGroup1"
        defaultTimeoutInSeconds = 100
        actions = @(
            @{
                name = "action1"
                actionConfiguration = '{"retryCount":5,"retryBackoffInterval":5}'
                targetUri = "/onvif/device_service?ONVIFProfile=Profile1"
                typeRef = "action1TypeRef"
                topic = "/contoso/managementGroup1/action1"
                actionType = "Call"
                timeoutInSeconds = 60
            },
            @{
                name = "action2"
                actionConfiguration = '{"retryCount":5,"retryBackoffInterval":5}'
                targetUri = "/onvif/device_service?ONVIFProfile=Profile2"
                typeRef = "action2TypeRef"
                topic = "/contoso/managementGroup1/action2"
                actionType = "Call"
                timeoutInSeconds = 60
            }
        )
    }
)

$datasets = @(
    @{
        name = "dataset1"
        dataSource = "nsu=http://microsoft.com/Opc/OpcPlc"
    },
    @{
        name = "dataSet2"
        dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/Oven;i=5"
        typeRef = "dataset1TypeRef"
        datasetConfiguration = '{"publishingInterval":10,"samplingInterval":15,"queueSize":20}'
        destinations = @(
            @{
                target = "Mqtt"
                configuration = @{
                    topic = "/contoso/test2"
                    retain = "Keep"
                    qos = "Qos1"
                    ttl = 3600
                }
            }
        )
        dataPoints = @(
            @{
                name = "dataset1DataPoint1"
                dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt3"
                dataPointConfiguration = '{"publishingInterval":8,"samplingInterval":8,"queueSize":4}'
                typeRef = "dataset1DataPoint1TypeRef"
            },
            @{
                name = "dataset1DataPoint2"
                dataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt4"
                dataPointConfiguration = '{"publishingInterval":8,"samplingInterval":8,"queueSize":4}'
                typeRef = "dataset1DataPoint2TypeRef"
            }
        )
    }
)

$streams = @(
    @{
        name = "stream1"
        streamConfiguration = '{"publishingInterval":8,"samplingInterval":8,"queueSize":4}'
        typeRef = "stream1TypeRef"
        destinations = @(
            @{
                target = "Storage"
                configuration = @{
                    path = "/tmp/stream1"
                }
            }
        )
    },
    @{
        name = "stream2"
        streamConfiguration = '{"publishingInterval":8,"samplingInterval":8,"queueSize":4}'
        typeRef = "stream2TypeRef"
        destinations = @(
            @{
                target = "Mqtt"
                configuration = @{
                    topic = "/contoso/testStream2"
                    retain = "Never"
                    qos = "Qos0"
                    ttl = 7200
                }
            }
        )
    }
)

New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -Location "eastus" -ExtendedLocationName "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq" -ExtendedLocationType "CustomLocation" -DeviceRefDeviceName "my-device" -DeviceRefEndpointName "my-endpoint" -Manufacturer "Contoso123" -ManufacturerUri "https://www.contoso.com/manufacturerUri" -Model "ContosoModel" -ProductCode "SA34VDG" -SoftwareRevision "2.0" -SerialNumber "64-103816-519918-8" -DocumentationUri "https://www.example.com/manual/" -EventGroup $eventGroups -ManagementGroup $managementGroups -Dataset $datasets -Stream $streams
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
DeviceRefDeviceName                  : my-device
DeviceRefEndpointName                : my-endpoint
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
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredAssets/my-discovered-asset
Location                             : eastus
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

Creates a new Namespace Discovered Asset with expanded parameters.

### Example 2: Create Namespace Discovered Asset via JSON File Path
```powershell
New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -JsonFilePath "C:\path\to\discovered-asset.json"
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
DeviceRefDeviceName                  : my-device
DeviceRefEndpointName                : my-endpoint
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
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredAssets/my-discovered-asset
Location                             : eastus
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

Creates a new Namespace Discovered Asset using a JSON file that contains the discovered asset properties.

### Example 3: Create Namespace Discovered Asset via JSON String
```powershell
$jsonString = Get-Content -Path "C:\path\to\discovered-asset.json" -Raw
New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -JsonString $jsonString
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
DeviceRefDeviceName                  : my-device
DeviceRefEndpointName                : my-endpoint
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
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/discoveredAssets/my-discovered-asset
Location                             : eastus
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

Creates a new Namespace Discovered Asset using a JSON string that contains the discovered asset properties.

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

### -AssetTypeRef
URIs or type definition IDs.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dataset
Array of datasets that are part of the asset.
Each dataset spec describes the data points that make up the set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredDataset[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultDatasetsConfiguration
Stringified JSON that contains connector-specific default configuration for all datasets.
Each dataset can have its own configuration that overrides the default settings here.

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

### -DefaultDatasetsDestination
Default destinations for a dataset.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDatasetDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultEventsConfiguration
Stringified JSON that contains connector-specific default configuration for all events.
Each event can have its own configuration that overrides the default settings here.

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

### -DefaultEventsDestination
Default destinations for an event.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IEventDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultManagementGroupsConfiguration
Stringified JSON that contains connector-specific default configuration for all management groups.
Each management group can have its own configuration that overrides the default settings here.

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

### -DefaultStreamsConfiguration
Stringified JSON that contains connector-specific default configuration for all streams.
Each stream can have its own configuration that overrides the default settings here.

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

### -DefaultStreamsDestination
Default destinations for a stream.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IStreamDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Human-readable description of the asset.

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

### -DeviceRefDeviceName
Name of the device resource

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

### -DeviceRefEndpointName
The name of endpoint to use

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

### -DiscoveredAssetName
The name of the discovered asset.

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

### -DiscoveryId
Identifier used to detect changes in the asset.

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

### -DisplayName
Human-readable display name.

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

### -DocumentationUri
Asset documentation reference.

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

### -EventGroup
Array of event groups that are part of the asset.
Each event group can have per-event group configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredEventGroup[]
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

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalAssetId
Asset ID provided by the customer.

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

### -HardwareRevision
Asset hardware revision number.

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

### -ManagementGroup
Array of management groups that are part of the asset.
Each management group can have a per-group configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredManagementGroup[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manufacturer
Asset manufacturer.

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

### -ManufacturerUri
Asset manufacturer URI.

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
Asset model.

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

### -ProductCode
Asset product code.

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

### -SerialNumber
Asset serial number.

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

### -SoftwareRevision
Asset software revision number.

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

### -Stream
Array of streams that are part of the asset.
Each stream can have a per-stream configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredStream[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### -Version
An integer that is incremented each time the resource is modified.

```yaml
Type: System.Int64
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredAsset

## NOTES

## RELATED LINKS

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssetTypeRef
URIs or type definition IDs.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dataset
Array of datasets that are part of the asset.
Each dataset spec describes the data points that make up the set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredDataset[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultDatasetsConfiguration
Stringified JSON that contains connector-specific default configuration for all datasets.
Each dataset can have its own configuration that overrides the default settings here.

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

### -DefaultDatasetsDestination
Default destinations for a dataset.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDatasetDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultEventsConfiguration
Stringified JSON that contains connector-specific default configuration for all events.
Each event can have its own configuration that overrides the default settings here.

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

### -DefaultEventsDestination
Default destinations for an event.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IEventDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultManagementGroupsConfiguration
Stringified JSON that contains connector-specific default configuration for all management groups.
Each management group can have its own configuration that overrides the default settings here.

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

### -DefaultStreamsConfiguration
Stringified JSON that contains connector-specific default configuration for all streams.
Each stream can have its own configuration that overrides the default settings here.

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

### -DefaultStreamsDestination
Default destinations for a stream.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IStreamDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Human-readable description of the asset.

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

### -DeviceRefDeviceName
Name of the device resource

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

### -DeviceRefEndpointName
The name of endpoint to use

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

### -DiscoveredAssetName
The name of the discovered asset.

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

### -DiscoveryId
Identifier used to detect changes in the asset.

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

### -DisplayName
Human-readable display name.

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

### -DocumentationUri
Asset documentation reference.

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

### -EventGroup
Array of event groups that are part of the asset.
Each event group can have per-event group configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredEventGroup[]
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

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalAssetId
Asset ID provided by the customer.

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

### -HardwareRevision
Asset hardware revision number.

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

### -ManagementGroup
Array of management groups that are part of the asset.
Each management group can have a per-group configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredManagementGroup[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manufacturer
Asset manufacturer.

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

### -ManufacturerUri
Asset manufacturer URI.

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
Asset model.

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductCode
Asset product code.

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

### -SerialNumber
Asset serial number.

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

### -SoftwareRevision
Asset software revision number.

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

### -Stream
Array of streams that are part of the asset.
Each stream can have a per-stream configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.INamespaceDiscoveredStream[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Default value: None
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

### -Version
An integer that is incremented each time the resource is modified.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

## NOTES

## RELATED LINKS
