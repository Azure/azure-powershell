### Example 1: Create or update an asset endpoint profile with the specified parameters
```powershell
New-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -ExtendedLocationName "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-custom-location" -ExtendedLocationType CustomLocation -Location eastus2 -TargetAddress "opc.tcp://foo" -AuthenticationMethod Certificate -X509CredentialsCertificateSecretName myCertificateRef -EndpointProfileType OpcUa -DiscoveredAssetEndpointProfileRef myDiscoveredAssetEndpointProfileRef
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          : Certificate
DiscoveredAssetEndpointProfileRef             : myDiscoveredAssetEndpointProfileRef
EndpointProfileType                           : OpcUa
ExtendedLocationName                          : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocatio
                                                n/customlocations/location-xxxxx
ExtendedLocationType                          : CustomLocation
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/
                                                assetEndpointProfiles/test-assetendpointprofile
Location                                      : eastus2
Name                                          : test-assetendpointprofile
ProvisioningState                             : Succeeded
ResourceGroupName                             : test-rg
StatusError                                   :
SystemDataCreatedAt                           : 12/19/2024 8:52:54 PM
SystemDataCreatedBy                           : user@outlook.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 12/19/2024 8:53:02 PM
SystemDataLastModifiedBy                      : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TargetAddress                                 : opc.tcp://foo
Type                                          : microsoft.deviceregistry/assetendpointprofiles
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          : 911bafe4-cc0e-439b-b3ee-135dba368024
X509CredentialsCertificateSecretName          : myCertificateRef
```

Creates a new asset endpoint profile `test-assetendpointprofile`in resource group `test-rg`

### Example 2: Create or update an asset endpoint profile from a JSON file path
```powershell
New-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonFilePath "C:\Users\abc\Desktop\assetEndpointProfile.json"
```

```output
AdditionalConfiguration                       :
AuthenticationMethod                          : Certificate
DiscoveredAssetEndpointProfileRef             : myDiscoveredAssetEndpointProfileRef
EndpointProfileType                           : OpcUa
ExtendedLocationName                          : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocatio
                                                n/customlocations/location-xxxxx
ExtendedLocationType                          : CustomLocation
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/
                                                assetEndpointProfiles/test-assetendpointprofile
Location                                      : eastus2
Name                                          : test-assetendpointprofile
ProvisioningState                             : Succeeded
ResourceGroupName                             : test-rg
StatusError                                   :
SystemDataCreatedAt                           : 12/19/2024 8:52:54 PM
SystemDataCreatedBy                           : user@outlook.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 12/19/2024 8:53:02 PM
SystemDataLastModifiedBy                      : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TargetAddress                                 : opc.tcp://foo
Type                                          : microsoft.deviceregistry/assetendpointprofiles
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          : 911bafe4-cc0e-439b-b3ee-135dba368024
X509CredentialsCertificateSecretName          : myCertificateRef
```

Creates a new asset endpoint profile `test-assetendpointprofile`in resource group `test-rg` from the provided json file at path `C:\Users\abc\Desktop\assetEndpointProfile.json`

### Example 3: Create or update an asset endpoint profile from a stringified JSON
```powershell
$jsonStr = '{
    "location": "eastus2",
    "extendedLocation": {
        "type": "CustomLocation",
        "name": "/subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-custom-location"
    },
    "tags": {
        "type": "opcua"
    },
    "properties": {
        "targetAddress": "opc.tcp://foo",
        "endpointProfileType": "OpcUa",
        "authentication": {
            "method": "Certificate",
            "x509Credentials": {
                "certificateSecretName": "myCertificateRef"
            }
        },
        "discoveredAssetEndpointProfileRef": "myDiscoveredAssetEndpointProfile",
        "additionalConfiguration": "{\"defaultPublishingInterval\": 200, \"defaultSamplingInterval\": 500, \"defaultQueueSize\": 10}"
    }
}'
New-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg -JsonString $jsonStr
```

```output
AdditionalConfiguration                       : "{\"defaultPublishingInterval\": 200, \"defaultSamplingInterval\": 500, \"defaultQueueSize\": 10}"
AuthenticationMethod                          : Certificate
DiscoveredAssetEndpointProfileRef             : myDiscoveredAssetEndpointProfileRef
EndpointProfileType                           : OpcUa
ExtendedLocationName                          : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourcegroups/test-rg/providers/microsoft.extendedlocatio
                                                n/customlocations/location-xxxxx
ExtendedLocationType                          : CustomLocation
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DeviceRegistry/
                                                assetEndpointProfiles/test-assetendpointprofile
Location                                      : eastus2
Name                                          : test-assetendpointprofile
ProvisioningState                             : Succeeded
ResourceGroupName                             : test-rg
StatusError                                   :
SystemDataCreatedAt                           : 12/19/2024 8:52:54 PM
SystemDataCreatedBy                           : user@outlook.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 12/19/2024 8:53:02 PM
SystemDataLastModifiedBy                      : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TargetAddress                                 : opc.tcp://foo
Type                                          : microsoft.deviceregistry/assetendpointprofiles
UsernamePasswordCredentialsPasswordSecretName :
UsernamePasswordCredentialsUsernameSecretName :
Uuid                                          : 911bafe4-cc0e-439b-b3ee-135dba368024
X509CredentialsCertificateSecretName          : myCertificateRef
```

Creates a new asset endpoint profile `test-assetendpointprofile`in resource group `test-rg` from the provided stringified JSON.