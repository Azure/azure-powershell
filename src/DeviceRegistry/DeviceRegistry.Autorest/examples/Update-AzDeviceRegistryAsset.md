### Example 1: Update an asset by name and resource group.
```powershell
Update-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -Model ContosoModel2
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's `Model` property with value `ContosoModel2`. Note: the output response is only the operation status of the update command, not the patched asset.

### Example 2: UpdateViaIdentity for asset.
```powershell
$asset = @{ "ResourceGroupName" = "test-rg"; "AssetName" = "test-asset"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Update-AzDeviceRegistryAsset -InputObject $asset -Model ContosoModel2
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's `Model` property with value `ContosoModel2` via Identity input object. Note: the output response is only the operation status of the update command, not the patched asset.

### Example 3: Update an asset from a JSON file path
```powershell
Update-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\assetPatch.json"
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's property(ies) with new value(s) by specifying a JSON file path containing the patch body. Note: the output response is only the operation status of the update command, not the patched asset.

### Example 4: Update an asset from a stringified JSON
```powershell
$jsonStr = '{
    "properties": {
        "model": "ContosoModel2"
    }
}'
Update-AzDeviceRegistryAsset -Name test-asset -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
Attribute                    : {
                               }
Dataset                      :
DefaultDatasetsConfiguration :
DefaultEventsConfiguration   :
DefaultTopicPath             :
DefaultTopicRetain           :
Description                  :
DiscoveredAssetRef           :
DisplayName                  :
DocumentationUri             :
Enabled                      :
Ref           :
Event                        :
ExtendedLocationName         :
ExtendedLocationType         :
ExternalAssetId              :
HardwareRevision             :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                     :
Manufacturer                 :
ManufacturerUri              :
Model                        :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProductCode                  :
ProvisioningState            :
ResourceGroupName            :
SerialNumber                 :
SoftwareRevision             :
StatusDataset                :
StatusError                  :
StatusEvent                  :
StatusVersion                :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         :
Uuid                         :
Version                      :
```

This command updates an asset's `Model` property with new value `ContosoModel2` by specifying the patch as a stringified JSON body. Note: the output response is only the operation status of the update command, not the patched asset.