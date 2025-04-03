### Example 1: list all assets from a specified subscription
```powershell
Get-AzDeviceRegistryAsset -SubscriptionId xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx
```

```output
Location Name                        SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
-------- -------------------------   -------------------   ------------------- ----------------------- ------------------------ ------------------------             ----------------------------
eastus2  test-asset   12/18/2024 7:36:44 PM user@outlook.com    User                    12/18/2024 7:43:58 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
eastus2  test-asset2  12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
westus2  test-asset3  12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
```

This command lists all the assets in subscription `xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx`

### Example 1: list all assets from a specified resource group
```powershell
Get-AzDeviceRegistryAsset -ResourceGroupName test-rg
```

```output
Location Name                        SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
-------- -------------------------   -------------------   ------------------- ----------------------- ------------------------ ------------------------             ----------------------------
eastus2  test-asset   12/18/2024 7:36:44 PM user@outlook.com    User                    12/18/2024 7:43:58 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
eastus2  test-asset2  12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
```

This command lists all the assets in resource group `test-rg`



### Example 3: get an asset by name and resource group
```powershell
Get-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg
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

This command gets a single asset named `test-asset` in resource group `test-rg`

### Example 4: GetViaIdentity for asset.
```powershell
$asset = @{ "ResourceGroupName" = "test-rg"; "AssetName" = "test-asset"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Get-AzDeviceRegistryAsset -InputObject $asset
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

This command gets a single asset named `test-asset` in resource group `test-rg` via Identity input object.