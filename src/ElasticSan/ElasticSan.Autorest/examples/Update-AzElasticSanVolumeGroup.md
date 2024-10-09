### Example 1: Update a volume group
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Encryption                             : EncryptionAtRestWithPlatformKey
EnforceDataIntegrityCheckForIscsi      : True
Id                                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                                   : myvolumegroup
NetworkAclsVirtualNetworkRule          : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                           : iSCSI
ProvisioningState                      : Succeeded
SystemDataCreatedAt                    : 9/19/2022 7:05:47 AM
SystemDataCreatedBy                    : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType                : Application
SystemDataLastModifiedAt               : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy               : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType           : Application
Type                                   : Microsoft.ElasticSan/ElasticSans
```

This example updates the protocol type and virtual network rules of a volume gorup

### Example 2: Update a volume group virtual network rule with JSON input 
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi'`
            -NetworkAclsVirtualNetworkRule (
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1";
                    Action="Allow"},
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2";
                    Action="Allow"})
```

```output
Encryption                             : EncryptionAtRestWithPlatformKey
EnforceDataIntegrityCheckForIscsi      : True
Id                                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                                   : myvolumegroup
NetworkAclsVirtualNetworkRule          : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                           : iSCSI
ProvisioningState                      : Succeeded
SystemDataCreatedAt                    : 9/19/2022 7:05:47 AM
SystemDataCreatedBy                    : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType                : Application
SystemDataLastModifiedAt               : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy               : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType           : Application
Type                                   : Microsoft.ElasticSan/ElasticSans
```

This example updates the protocol type, virtual network rules, and tag of a volume group. It takes in the virtual network rules in JSON format.

### Example 3: Update a volume group from CMK to PMK 
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -Encryption EncryptionAtRestWithPlatformKey
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp :
KeyVaultPropertyCurrentVersionedKeyIdentifier          :
KeyVaultPropertyKeyName                                :
KeyVaultPropertyKeyVaultUri                            :
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               :
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 2:31:45 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:47:24 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```
This command updates a volume group from CMK to PMK. 

### Example 4: Update a volume group to a new user assigned identity
```powershell
$useridentity2 = Get-AzUserAssignedIdentity -ResourceGroupName myresoucegroup -Name myuai2

Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType UserAssigned -IdentityUserAssignedIdentityId $useridentity2.Id -EncryptionUserAssignedIdentity $useridentity2.Id
```

```output
Encryption                                             : EncryptionAtRestWithCustomerManagedKey
EncryptionIdentityEncryptionUserAssignedIdentity       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai2
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai2": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp : 1/1/1970 12:00:00 AM
KeyVaultPropertyCurrentVersionedKeyIdentifier          : https://mykeyvault.vault.azure.net/keys/mykey/37ec78b20f9e4a29b14a0d29d93cb79f
KeyVaultPropertyKeyName                                : mykey
KeyVaultPropertyKeyVaultUri                            : https://mykeyvault.vault.azure.net:443
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               : 10/7/2023 7:03:27 AM
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 6:32:27 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 7:03:27 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command updates a volume group's user assigned identity. 

### Example 5: Update a volume group to disable EnforceDataIntegrityCheckForIscsi
```powershell
Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -EnforceDataIntegrityCheckForIscsi $false
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
EnforceDataIntegrityCheckForIscsi                      : False
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           :
IdentityUserAssignedIdentity                           : {
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp :
KeyVaultPropertyCurrentVersionedKeyIdentifier          :
KeyVaultPropertyKeyName                                :
KeyVaultPropertyKeyVaultUri                            :
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               :
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 9/18/2024 3:20:40 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : User
SystemDataLastModifiedAt                               : 9/18/2024 3:23:34 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : User
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command disables EnforceDataIntegrityCheckForIscsi on a volume group.