### Example 1: Create a volume group with network rule objects 
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
SystemDataCreatedAt                                    : 9/19/2022 7:05:47 AM
SystemDataCreatedBy                                    : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy                               : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/ElasticSans
```

This example creates two VirtualNetworkRule objects and then input the objects and other variables to create a volume group. 

### Example 2: Create a volume group with network rule JSON input 
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' `
            -NetworkAclsVirtualNetworkRule (
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1";
                    Action="Allow"},
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2";
                    Action="Allow"})
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
SystemDataCreatedAt                                    : 9/19/2022 7:05:47 AM
SystemDataCreatedBy                                    : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy                               : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/ElasticSans
```

This command creates a volume group with the NetworkAclsVirtualNetworkRule input in json format. 

### Example 3: Create a volume group with platform-managed key and SystemAssigned identity type 
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType SystemAssigned -ProtocolType Iscsi -Encryption EncryptionAtRestWithPlatformKey
```

```output
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    : 00000000-0000-0000-0000-000000000000
IdentityTenantId                                       : 00000000-0000-0000-0000-000000000000
IdentityType                                           : SystemAssigned
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
SystemDataCreatedAt                                    : 10/7/2023 6:20:55 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:20:55 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command creates a volume group with identity type "SystemAssigned" and encryption type "platform-managed key".

### Example 4: Create a volume group with platform-managed key and SystemAssigned identity type 
```powershell
$useridentity = Get-AzUserAssignedIdentity -ResourceGroupName myresoucegroup -Name myuai

New-AzElasticSanVolumeGroup -ResourceGroupName myresoucegroup -ElasticSanName myelasticsan -Name myvolumegroup -IdentityType UserAssigned -IdentityUserAssignedIdentityId $useridentity.Id -Encryption EncryptionAtRestWithCustomerManagedKey -KeyName mykey -KeyVaultUri "https://mykeyvault.vault.azure.net:443" -EncryptionUserAssignedIdentity $useridentity.Id -ProtocolType Iscsi
```

```output
Encryption                                             : EncryptionAtRestWithCustomerManagedKey
EncryptionIdentityEncryptionUserAssignedIdentity       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : UserAssigned
IdentityUserAssignedIdentity                           : {
                                                           "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myuai": {
                                                           }
                                                         }
KeyVaultPropertyCurrentVersionedKeyExpirationTimestamp : 1/1/1970 12:00:00 AM
KeyVaultPropertyCurrentVersionedKeyIdentifier          : https://mykeyvault.vault.azure.net/keys/mykey/37ec78b20f9e4a29b14a0d29d93cb79f
KeyVaultPropertyKeyName                                : mykey
KeyVaultPropertyKeyVaultUri                            : https://mykeyvault.vault.azure.net:443
KeyVaultPropertyKeyVersion                             :
KeyVaultPropertyLastKeyRotationTimestamp               : 10/7/2023 6:32:28 AM
Name                                                   : myvolumegroup
NetworkAclsVirtualNetworkRule                          :
PrivateEndpointConnection                              :
ProtocolType                                           : iSCSI
ProvisioningState                                      : Succeeded
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 10/7/2023 6:32:27 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : Application
SystemDataLastModifiedAt                               : 10/7/2023 6:32:27 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : Application
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command creates a volume group with identity type "SystemAssigned" and encryption type "platform-managed key".

### Example 5: Create a volume group with EnforceDataIntegrityCheckForIscsi disabled
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresoucegroup -ElasticSanName myelasticsan -Name myvolumegroup -EnforceDataIntegrityCheckForIscsi $false
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
SystemDataCreatedAt                                    : 9/18/2024 3:45:01 AM
SystemDataCreatedBy                                    : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType                                : User
SystemDataLastModifiedAt                               : 9/18/2024 4:58:14 AM
SystemDataLastModifiedBy                               : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType                           : User
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command creates a volume group with EnforceDataIntegrityCheckForIscsi disabled.