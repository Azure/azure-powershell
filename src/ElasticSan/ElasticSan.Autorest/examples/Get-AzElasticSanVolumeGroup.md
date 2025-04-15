### Example 1: Get all volume groups in an Elastic SAN
```powershell
Get-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup1
Name                          : myvolumegroup1
NetworkAclsVirtualNetworkRule : 
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 8/18/2022 8:43:35 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 8/18/2022 8:43:35 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                          : Microsoft.ElasticSan/ElasticSans

Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup2
Name                          : myvolumegroup2
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet4, 
                                /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/20/2022 2:37:33 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/20/2022 2:37:33 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                          : Microsoft.ElasticSan/ElasticSans
```

This command gets all the volume groups in the Elastic SAN myelasticsan. 

### Example 2: Get a specific volume group
```powershell
Get-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup
```

```output
Encryption                    : EncryptionAtRestWithPlatformKey
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup
Name                          : myvolumegroup
NetworkAclsVirtualNetworkRule : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2}
ProtocolType                  : iSCSI
ProvisioningState             : Succeeded
SystemDataCreatedAt           : 9/19/2022 7:05:47 AM
SystemDataCreatedBy           : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType       : Application
SystemDataLastModifiedAt      : 9/19/2022 7:05:47 AM
SystemDataLastModifiedBy      : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType  : Application
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                          : Microsoft.ElasticSan/ElasticSans
```

This command gets a specific volume group.

### Example 3: Get soft deleted volume groups in an Elastic SAN
```powershell
Get-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -AccessSoftDeletedResource true
```

```output
DeleteRetentionPolicyRetentionPeriodDay                : 7
DeleteRetentionPolicyState                             : Enabled
Encryption                                             : EncryptionAtRestWithPlatformKey
EncryptionIdentityEncryptionUserAssignedIdentity       :
EnforceDataIntegrityCheckForIscsi                      : True
Id                                                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup
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
ProvisioningState                                      : Deleted
ResourceGroupName                                      : myresourcegroup
SystemDataCreatedAt                                    : 4/8/2025 2:31:52 AM
SystemDataCreatedBy                                    : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType                                : User
SystemDataLastModifiedAt                               : 4/9/2025 3:22:04 AM
SystemDataLastModifiedBy                               : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType                           : User
Type                                                   : Microsoft.ElasticSan/elasticSans/volumeGroups
```

This command gets soft deleted volume groups in the Elastic SAN myelasticsan.
