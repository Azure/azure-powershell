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

