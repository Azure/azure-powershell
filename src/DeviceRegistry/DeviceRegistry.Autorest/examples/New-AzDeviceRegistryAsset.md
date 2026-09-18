### Example 1: Create or update an asset with the specified parameters
```powershell
$jsonString = '{
  "samplingInterval": 1000,
  "queueSize": 20,
  "publishingInterval": 10
}'
$dataSets = @(
  @{
    Name = "dataset1Foo"
    DatasetConfiguration = $jsonString
    Topic = @{
      Path = "/path/dataset1"
      Retain = "Keep"
    }
    DataPoint = @(
      @{
        Name = "datapoint1"
        DataSource = "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1"
        DataPointConfiguration = $jsonString
      }
    )
  }
)

New-AzDeviceRegistryAsset -Name testassetfrompwsh2 -ResourceGroupName test-rg -ExtendedLocationName "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/location-xxxxx" -ExtendedLocationType CustomLocation -Location eastus2 -SubscriptionId xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx -AssetEndpointProfileRef myAssetEndpointProfile -DisplayName testassetfrompwsh1 -Manufacturer Contoso123 -ManufacturerUri ContosoModel -ProductCode SA34VDG -Model ContosoModel -SoftwareRevision "2.0" -HardwareRevision "1.0" -SerialNumber "64-103816-519918-8" -DocumentationUri "https://www.example.com/manual" -DefaultTopicPath "/path/defaultTopic" -DefaultTopicRetain "Keep" -DefaultDatasetsConfiguration $jsonString -DefaultEventsConfiguration $jsonString -Dataset $dataSets
```

```output
Attribute                    : {
                               }
Dataset                      : {{
                                 "topic": {
                                   "path": "/path/dataset1",
                                   "retain": "Keep"
                                 },
                                 "name": "dataset1Foo",
                                 "dataPoints": [
                                   {
                                     "name": "datapoint1",
                                     "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                                     "observabilityMode": "None"
                                   }
                                 ]
                               }}
DefaultDatasetsConfiguration : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultEventsConfiguration   : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultTopicPath             : /path/defaultTopic
DefaultTopicRetain           : Keep
Description                  :
DiscoveredAssetRef           :
DisplayName                  : testassetfrompwsh1
DocumentationUri             : https://www.example.com/manual
Enabled                      : True
EndpointProfileRef           : myAssetEndpointProfile
Event                        :
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations
                               /location-xxxxx
ExtendedLocationType         : CustomLocation
ExternalAssetId              : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
HardwareRevision             : 1.0
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/assets/test-asset
Location                     : eastus2
Manufacturer                 : Contoso123
ManufacturerUri              : ContosoModel
Model                        : ContosoModel
Name                         : test-asset
ProductCode                  : SA34VDG
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
SerialNumber                 : 64-103816-519918-8
SoftwareRevision             : 2.0
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          : 12/18/2024 6:55:47 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/18/2024 7:19:47 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/assets
Uuid                         : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
Version                      : 4
```

Creates a new asset `test-asset` in resource group `test-rg`

### Example 2: Create or update an asset from a JSON file path
```powershell
New-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\asset.json"
```

```output
Attribute                    : {
                               }
Dataset                      : {{
                                 "topic": {
                                   "path": "/path/dataset1",
                                   "retain": "Keep"
                                 },
                                 "name": "dataset1Foo",
                                 "dataPoints": [
                                   {
                                     "name": "datapoint1",
                                     "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                                     "observabilityMode": "None"
                                   }
                                 ]
                               }}
DefaultDatasetsConfiguration : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultEventsConfiguration   : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultTopicPath             : /path/defaultTopic
DefaultTopicRetain           : Keep
Description                  :
DiscoveredAssetRef           :
DisplayName                  : testassetfrompwsh1
DocumentationUri             : https://www.example.com/manual
Enabled                      : True
EndpointProfileRef           : myAssetEndpointProfile
Event                        :
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations
                               /location-xxxxx
ExtendedLocationType         : CustomLocation
ExternalAssetId              : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
HardwareRevision             : 1.0
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/assets/test-asset
Location                     : eastus2
Manufacturer                 : Contoso123
ManufacturerUri              : ContosoModel
Model                        : ContosoModel
Name                         : test-asset
ProductCode                  : SA34VDG
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
SerialNumber                 : 64-103816-519918-8
SoftwareRevision             : 2.0
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          : 12/18/2024 6:55:47 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/18/2024 7:19:47 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/assets
Uuid                         : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
Version                      : 4
```

Creates a new asset `test-asset`in resource group `test-rg` from the provided json file at path `C:\Users\abc\Desktop\asset.json`

### Example 3: Create or update an asset from a stringified JSON
```powershell
$jsonStr = '{
    "location": "eastus2",
    "extendedLocation": {
        "type": "CustomLocation",
        "name": "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/location-xxxxx"
    },
    "properties": {
        "assetEndpointProfileRef": "myAssetEndpointProfile",
        "version": 73766,
        "manufacturer": "Contoso123",
        "manufacturerUri": "https://www.contoso.com/manufacturerUri",
        "model": "ContosoModel",
        "productCode": "SA34VDG",
        "softwareRevision": "2.0",
        "documentationUri": "https://www.example.com/manual",
        "serialNumber": "64-103816-519918-8",
        "defaultDatasetsConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":1000,\"queueSize\":20}",
        "defaultEventsConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":1000,\"queueSize\":20}",
        "defaultTopic": {
          "path": "/path/defaultTopic",
          "retain": "Keep"
        },
        "datasets": [
          {
            "name": "dataset1Foo",
            "datasetConfiguration": "{\"publishingInterval\":10,\"samplingInterval\":1000,\"queueSize\":20}",
            "topic": {
              "path": "/path/dataset1",
              "retain": "Keep"
            },
            "dataPoints": [
              {
                "name": "dataPoint1",
                "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                "dataPointConfiguration": "{\"publishingInterval\":8,\"samplingInterval\":1000,\"queueSize\":4}"
              }
            ]
          }
        ]
    }
}'
New-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
Attribute                    : {
                               }
Dataset                      : {{
                                 "topic": {
                                   "path": "/path/dataset1",
                                   "retain": "Keep"
                                 },
                                 "name": "dataset1Foo",
                                 "dataPoints": [
                                   {
                                     "name": "datapoint1",
                                     "dataSource": "nsu=http://microsoft.com/Opc/OpcPlc/;s=FastUInt1",
                                     "observabilityMode": "None"
                                   }
                                 ]
                               }}
DefaultDatasetsConfiguration : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultEventsConfiguration   : {
                                 "samplingInterval": 1000,
                                 "queueSize": 20,
                                 "publishingInterval": 10
                               }
DefaultTopicPath             : /path/defaultTopic
DefaultTopicRetain           : Keep
Description                  :
DiscoveredAssetRef           :
DisplayName                  : testassetfrompwsh1
DocumentationUri             : https://www.example.com/manual
Enabled                      : True
EndpointProfileRef           : myAssetEndpointProfile
Event                        :
ExtendedLocationName         : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations
                               /location-xxxxx
ExtendedLocationType         : CustomLocation
ExternalAssetId              : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
HardwareRevision             : 1.0
Id                           : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/assets/test-asset
Location                     : eastus2
Manufacturer                 : Contoso123
ManufacturerUri              : ContosoModel
Model                        : ContosoModel
Name                         : test-asset
ProductCode                  : SA34VDG
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
SerialNumber                 : 64-103816-519918-8
SoftwareRevision             : 2.0
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          : 12/18/2024 6:55:47 PM
SystemDataCreatedBy          : user@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/18/2024 7:19:47 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.deviceregistry/assets
Uuid                         : 94a7017e-2edd-4e72-b7b5-2a61a1b1c702
Version                      : 4
```

Creates a new asset `test-asset`in resource group `test-rg` from the provided stringified JSON.