### Example 1: Create Namespace Asset with Expanded Parameters
```powershell
New-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset" -Location "eastus" -ExtendedLocationName "my-extended-location" -ExtendedLocationType "CustomLocation" -DeviceRefDeviceName "my-device" -DeviceRefEndpointName "my-endpoint" -ExternalAssetId "my-external-asset-id" -DisplayName "My Asset Display Name" -Manufacturer "Contoso" -ManufacturerUri "https://www.contoso.com/manufacturerUri" -Model "ContosoModel" -ProductCode "SA34VDG" -SoftwareRevision "2.0" -HardwareRevision "1.0" -SerialNumber "64-103816-519918-8" -DocumentationUri "https://www.example.com/manual/"
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
Event                                :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 8e2ffbae-11d8-4fdf-bcf6-fc9afbdd764d
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /microsoft.deviceregistry/namespaces/adr-namespace/assets/fooasset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : fooasset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : adr-pwsh-test-rg
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEvent                          :
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

Creates a new Namespace Asset with expanded parameters including device reference, asset metadata, and documentation details.

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
Event                                :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 8e2ffbae-11d8-4fdf-bcf6-fc9afbdd764d
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /microsoft.deviceregistry/namespaces/adr-namespace/assets/fooasset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : fooasset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : adr-pwsh-test-rg
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEvent                          :
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

Creates a new Namespace Asset using a JSON file that contains the asset configuration including datasets, events, streams, and management groups.

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
Event                                :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-2pnh4
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 8e2ffbae-11d8-4fdf-bcf6-fc9afbdd764d
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /microsoft.deviceregistry/namespaces/adr-namespace/assets/fooasset
LastTransitionTime                   :
Location                             : eastus2
ManagementGroup                      :
Manufacturer                         :
ManufacturerUri                      :
Message                              :
Model                                :
Name                                 : fooasset
ProductCode                          :
ProvisioningState                    : Succeeded
ResourceGroupName                    : adr-pwsh-test-rg
SerialNumber                         :
SoftwareRevision                     :
StatusDataset                        :
StatusEvent                          :
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

Creates a new Namespace Asset using a JSON string that contains the asset configuration including datasets, events, streams, and management groups.

