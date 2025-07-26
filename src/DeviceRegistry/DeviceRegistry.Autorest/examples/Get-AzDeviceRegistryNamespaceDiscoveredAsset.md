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

Lists all Namespace Discovered Assets in a specified Namespace.

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
Event                                : {{
                                         "name": "event1",
                                         "eventNotifier": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt5",
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
                                         "typeRef": "event1Ref",
                                         "dataPoints": [
                                           {
                                             "name": "event1DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt6",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           },
                                           {
                                             "name": "event1DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt7",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           }
                                         ]
                                       }, {
                                         "name": "event2",
                                         "eventNotifier": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt8",
                                         "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                         "destinations": [
                                           {
                                             "target": "Storage",
                                             "configuration": {
                                               "path": "/tmp/event2"
                                             }
                                           }
                                         ],
                                         "typeRef": "event2Ref",
                                         "dataPoints": [
                                           {
                                             "name": "event2DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt9",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           },
                                           {
                                             "name": "event2DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt10",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           }
                                         ]
                                       }}
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.DeviceRegistry/namespaces/adr-namespace/discoveredAssets/test-ns-dasset-get
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
Name                                 : test-ns-dasset-get
ProductCode                          : SA34VDG
ProvisioningState                    : Succeeded
ResourceGroupName                    : adr-pwsh-test-rg
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

Gets a Namespace Discovered Asset using the Namespace's Identity object.

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
Event                                : {{
                                         "name": "event1",
                                         "eventNotifier": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt5",
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
                                         "typeRef": "event1Ref",
                                         "dataPoints": [
                                           {
                                             "name": "event1DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt6",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           },
                                           {
                                             "name": "event1DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt7",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           }
                                         ]
                                       }, {
                                         "name": "event2",
                                         "eventNotifier": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt8",
                                         "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                         "destinations": [
                                           {
                                             "target": "Storage",
                                             "configuration": {
                                               "path": "/tmp/event2"
                                             }
                                           }
                                         ],
                                         "typeRef": "event2Ref",
                                         "dataPoints": [
                                           {
                                             "name": "event2DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt9",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           },
                                           {
                                             "name": "event2DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt10",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           }
                                         ]
                                       }}
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.DeviceRegistry/namespaces/adr-namespace/discoveredAssets/test-ns-dasset-get
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
Name                                 : test-ns-dasset-get
ProductCode                          : SA34VDG
ProvisioningState                    : Succeeded
ResourceGroupName                    : adr-pwsh-test-rg
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

Gets a specific Namespace Discovered Asset from a Namespace.

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
Event                                : {{
                                         "name": "event1",
                                         "eventNotifier": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt5",
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
                                         "typeRef": "event1Ref",
                                         "dataPoints": [
                                           {
                                             "name": "event1DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt6",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           },
                                           {
                                             "name": "event1DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt7",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           }
                                         ]
                                       }, {
                                         "name": "event2",
                                         "eventNotifier": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt8",
                                         "eventConfiguration": "{\"publishingInterval\":7,\"samplingInterval\":1,\"queueSize\":8}",
                                         "destinations": [
                                           {
                                             "target": "Storage",
                                             "configuration": {
                                               "path": "/tmp/event2"
                                             }
                                           }
                                         ],
                                         "typeRef": "event2Ref",
                                         "dataPoints": [
                                           {
                                             "name": "event2DataPoint1",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt9",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           },
                                           {
                                             "name": "event2DataPoint2",
                                             "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt10",
                                             "dataPointConfiguration":
                                       "{\"publishingInterval\":8,\"samplingInterval\":8,\"queueSize\":4}"
                                           }
                                         ]
                                       }}
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType                 : CustomLocation
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.DeviceRegistry/namespaces/adr-namespace/discoveredAssets/test-ns-dasset-get
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
Name                                 : test-ns-dasset-get
ProductCode                          : SA34VDG
ProvisioningState                    : Succeeded
ResourceGroupName                    : adr-pwsh-test-rg
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

