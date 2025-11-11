### Example 1: List Namespace Assets in a namespace.
```powershell
Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace"
```

```output
Location Name                                          SystemDataCreatedAt   SystemDataCreatedBy                  SystemDataCreatedB
                                                                                                                  yType
-------- ----                                          -------------------   -------------------                  ------------------
eastus2  test-ns-asset-create-expanded                 7/22/2025 10:05:30 PM user@outlook.com                   User
eastus2  test-ns-asset-create-json-file-path           7/22/2025 10:29:04 PM user@outlook.com                   User
```

Lists all the Device Registry Namespace Assets within the parent Namespace.

### Example 2: Get Namespace Via Namespace Identity
```powershell
$namespaceIdentity = @{
  SubscriptionId = "my-subscription-id"
  ResourceGroupName = "my-resource-group"
  NamespaceName = "my-namespace"
}
Get-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName "my-asset"
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
DeviceRefDeviceName                  : myassetendpointprofile1
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : test-asset-123
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 63174c22-6858-4d69-b515-68b641ad537e
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/assets/my-asset
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
SystemDataCreatedAt                  : 7/25/2025 5:48:47 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 5:48:53 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 63174c22-6858-4d69-b515-68b641ad537e
Version                              : 2
```

Gets the details of a Namespace Asset using the parent Namespace's identity object.

### Example 3: Get Namespace Asset
```powershell
Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset"
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
DeviceRefDeviceName                  : myassetendpointprofile1
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : test-asset-123
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 63174c22-6858-4d69-b515-68b641ad537e
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/assets/my-asset
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
SystemDataCreatedAt                  : 7/25/2025 5:48:47 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 5:48:53 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 63174c22-6858-4d69-b515-68b641ad537e
Version                              : 2
```

Gets the details of a Namespace Asset under its parent Namespace.

### Example 4: Get Namespace Asset Via Identity
```powershell
$identity = @{
  SubscriptionId = "my-subscription"
  ResourceGroupName = "my-resource-group"
  NamespaceName = "my-namespace"
  AssetName = "my-asset"
}
Get-AzDeviceRegistryNamespaceAsset -InputObject $identity
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
DeviceRefDeviceName                  : myassetendpointprofile1
DeviceRefEndpointName                : primaryEndpoint
DiscoveredAssetRef                   :
DisplayName                          : test-asset-123
DocumentationUri                     :
Enabled                              : True
EventGroup                           :
ExtendedLocationName                 : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/adr-pwsh-test-rg/providers
                                       /Microsoft.ExtendedLocation/customLocations/location-mkzkq
ExtendedLocationType                 : CustomLocation
ExternalAssetId                      : 63174c22-6858-4d69-b515-68b641ad537e
HardwareRevision                     :
Id                                   : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/assets/my-asset
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
SystemDataCreatedAt                  : 7/25/2025 5:48:47 AM
SystemDataCreatedBy                  : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType              : Application
SystemDataLastModifiedAt             : 7/25/2025 5:48:53 AM
SystemDataLastModifiedBy             : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType         : Application
Tag                                  : {
                                       }
Type                                 : microsoft.deviceregistry/namespaces/assets
Uuid                                 : 63174c22-6858-4d69-b515-68b641ad537e
Version                              : 2
```

Gets a Namespace Asset via the asset's Identity object.
