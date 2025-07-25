### Example 1: list all asset endpoint profiles from a specified subscription.
```powershell
Get-AzDeviceRegistryAssetEndpointProfile -SubscriptionId xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx
```

```output
Location Name                        SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
-------- -------------------------   -------------------   ------------------- ----------------------- ------------------------ ------------------------             ----------------------------
eastus2  test-assetendpointprofile   12/18/2024 7:36:44 PM user@outlook.com    User                    12/18/2024 7:43:58 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
eastus2  test-assetendpointprofile2  12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
westus2  test-assetendpointprofile3  12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
```

This command lists all the asset endpoint profiles in subscription `xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx`

### Example 2: list all asset endpoint profiles from a specified resource group.
```powershell
Get-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName test-rg
```

```output
Location Name                        SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
-------- -------------------------   -------------------   ------------------- ----------------------- ------------------------ ------------------------             ----------------------------
eastus2  test-assetendpointprofile   12/18/2024 7:36:44 PM user@outlook.com    User                    12/18/2024 7:43:58 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
eastus2  test-assetendpointprofile2  12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
```

This command lists all the asset endpoint profiles in resource group `test-rg`

### Example 3: get an asset endpoint profile by name and resource group.
```powershell
Get-AzDeviceRegistryAssetEndpointProfile -Name test-assetendpointprofile -ResourceGroupName test-rg
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

This command gets a single asset endpoint profile named `test-assetendpointprofile` in resource group `test-rg`

### Example 4: GetViaIdentity for asset endpoint profile.
```powershell
$assetEndpointProfile = @{ "ResourceGroupName" = "test-rg"; "AssetEndpointProfileName" = "test-assetendpointprofile"; "SubscriptionId" = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx"; }
Get-AzDeviceRegistryAssetEndpointProfile -InputObject $assetEndpointProfile
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

This command gets a single asset endpoint profile named `test-assetendpointprofile` in resource group `test-rg` via Identity input object.
