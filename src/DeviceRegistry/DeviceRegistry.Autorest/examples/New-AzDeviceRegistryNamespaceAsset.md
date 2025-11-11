### Example 1: Create Namespace Asset with Expanded Parameters
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

New-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset" -Location "eastus" -ExtendedLocationName "/subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.ExtendedLocation/customLocations/location-mkzkq" -ExtendedLocationType "CustomLocation" -DeviceRefDeviceName "my-device" -DeviceRefEndpointName "my-endpoint" -ExternalAssetId "my-external-asset-id" -DisplayName "My Asset Display Name" -Manufacturer "Contoso" -ManufacturerUri "https://www.contoso.com/manufacturerUri" -Model "ContosoModel" -ProductCode "SA34VDG" -SoftwareRevision "2.0" -HardwareRevision "1.0" -SerialNumber "64-103816-519918-8" -DocumentationUri "https://www.example.com/manual/" -EventGroup $eventGroups -ManagementGroup $managementGroups -Dataset $datasets -Stream $streams
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Code                                 :
ConfigLastTransitionTime             :
ConfigVersion                        :
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
DefaultDatasetsConfiguration         :
DefaultDatasetsDestination           :
DefaultEventsConfiguration           :
DefaultEventsDestination             :
DefaultManagementGroupsConfiguration :
DefaultStreamsConfiguration          :
DefaultStreamsDestination            :
Description                          :
Detail                               :
DeviceRefDeviceName                  : my-device
DeviceRefEndpointName                : my-endpoint
DiscoveredAssetRef                   :
DisplayName                          : My Asset Display Name
DocumentationUri                     : https://www.example.com/manual/
Enabled                              : True
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
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : my-external-asset-id
HardwareRevision                     : 1.0
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers
                                       /microsoft.deviceregistry/namespaces/my-namespace/assets/my-asset
LastTransitionTime                   :
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
Manufacturer                         : Contoso
ManufacturerUri                      : https://www.contoso.com/manufacturerUri
Message                              :
Model                                : ContosoModel
Name                                 : my-asset
ProductCode                          : SA34VDG
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         : 64-103816-519918-8
SoftwareRevision                     : 2.0
StatusDataset                        :
StatusEventGroup                     :
StatusManagementGroup                :
StatusStream                         :
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
SystemDataCreatedAt                  : 7/25/2025 4:15:11 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 4:15:15 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : my-external-asset-id
Version                              : 2
```

Creates a new Namespace Asset with expanded parameters.

### Example 2: Create Namespace Asset via JSON File Path
```powershell
New-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset" -JsonFilePath "C:\path\to\asset.json"
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Code                                 :
ConfigLastTransitionTime             :
ConfigVersion                        :
Dataset                              :
DefaultDatasetsConfiguration         :
DefaultDatasetsDestination           :
DefaultEventsConfiguration           :
DefaultEventsDestination             :
DefaultManagementGroupsConfiguration :
DefaultStreamsConfiguration          :
DefaultStreamsDestination            :
Description                          :
Detail                               :
DeviceRefDeviceName                  : myaepref
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : fooasset
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 8e2ffbae-11d8-4fdf-bcf6-fc9afbdd764d
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers
                                       /microsoft.deviceregistry/namespaces/my-namespace/assets/my-asset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : my-asset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEventGroup                     :
StatusManagementGroup                :
StatusStream                         :
Stream                               :
SystemDataCreatedAt                  : 7/25/2025 4:15:11 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 4:15:15 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 8e2ffbae-11d8-4fdf-bcf6-fc9afbdd764d
Version                              : 2
```

Creates a new Namespace Asset using a JSON file that contains the asset properties.

### Example 3: Create Namespace Asset via JSON String
```powershell
$jsonString = Get-Content -Path "C:\path\to\asset.json" -Raw
New-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset" -JsonString $jsonString
```

```output
AssetTypeRef                         :
Attribute                            : {
                                       }
Code                                 :
ConfigLastTransitionTime             :
ConfigVersion                        :
Dataset                              :
DefaultDatasetsConfiguration         :
DefaultDatasetsDestination           :
DefaultEventsConfiguration           :
DefaultEventsDestination             :
DefaultManagementGroupsConfiguration :
DefaultStreamsConfiguration          :
DefaultStreamsDestination            :
Description                          :
Detail                               :
DeviceRefDeviceName                  : myaepref
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : fooasset
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 8e2ffbae-11d8-4fdf-bcf6-fc9afbdd764d
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers
                                       /microsoft.deviceregistry/namespaces/my-namespace/assets/my-asset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : my-asset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : my-resource-group
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEventGroup                     :
StatusManagementGroup                :
StatusStream                         :
Stream                               :
SystemDataCreatedAt                  : 7/25/2025 4:15:11 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 4:15:15 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 8e2ffbae-11d8-4fdf-bcf6-fc9afbdd764d
Version                              : 2
```

Creates a new Namespace Asset using a JSON string that contains the asset properties.

