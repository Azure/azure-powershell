### Example 1: Update an asset endpoint profile by name and resource group.
```powershell
Update-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -TargetAddress "opc.tcp://bar"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's `TargetAddress` property with value `opc.tcp://bar`. Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

### Example 2: UpdateViaIdentity for asset endpoint profile.
```powershell
$assetEndpointProfile = @{ "ResourceGroupName" = "test-rg"; "AssetEndpointProfileName" = "test-assetendpointprofile"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Update-AzDeviceRegistryAssetEndpointProfile -InputObject $assetEndpointProfile -TargetAddress "opc.tcp://bar"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's `TargetAddress` property with value `opc.tcp://bar` via Identity input object. Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

### Example 3: Update an asset endpoint profile from a JSON file path
```powershell
Update-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\assetEndpointProfilePatch.json"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's property(ies) with new value(s) by specifying a JSON file path containing the patch body. Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

### Example 4: Update an asset endpoint profile from a stringified JSON
```powershell
$jsonStr = '{
    "properties": {
        "targetAddress": "opc.tcp://bar"
    }
}'
Update-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          :
DiscoveredAssetEndpointProfileRef             :
EndpointProfileType                           :
ExtendedLocationName                          :
ExtendedLocationType                          :
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
Location                                      :
Name                                          : 01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
ProvisioningState                             :
ResourceGroupName                             :
StatusError                                   :
SystemDataCreatedAt                           :
SystemDataCreatedBy                           :
SystemDataCreatedByType                       :
SystemDataLastModifiedAt                      :
SystemDataLastModifiedBy                      :
SystemDataLastModifiedByType                  :
Tag                                           : {
                                                }
TargetAddress                                 :
Type                                          :
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          :
X509CredentialsCertificateSecretName          :
```

This command updates an asset endpoint profile's `TargetAddress` property with new value `opc.tcp://bar` by specifying the patch as a stringified JSON body. Note: the output response is only the operation status of the update command, not the patched asset endpoint profile.

