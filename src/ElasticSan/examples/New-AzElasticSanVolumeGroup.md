### Example 1: Create a volume group with network rule objects 
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -Tag @{tag1="value1";tag2="value2"} -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
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

This example creates two VirtualNetworkRule objects and then input the objects and other variables to create a volume group. 

### Example 2: Create a volume group with network rule JSON input 
```powershell
New-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -ProtocolType 'Iscsi' -Tag @{tag1="value1";tag2="value2"} `
            -NetworkAclsVirtualNetworkRule (
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1";
                    Action="Allow"},
                @{VirtualNetworkResourceId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2";
                    Action="Allow"})
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

This command creates a volume group with the NetworkAclsVirtualNetworkRule input in json format. 
