### Example 1: Add network rules to a volume group by NetworkAclsVirtualNetworkRule objects 
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow

Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2
```

This example creates two NetworkAclsVirtualNetworkRule objects using virtual network resource Ids, and then adds the network rules to a volume group. The command outputs all the network rule objects in the volume group after the addition operation.

### Example 2: Add network rules to a volume group by resource Ids
```powershell
$virtualNetworkResourceId1 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1"
$virtualNetworkResourceId2 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2"

Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkResourceId $virtualNetworkResourceId1,$virtualNetworkResourceId2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2
```

This example adds two virtual network rules to a volume group using the network rule resource Ids. The command outputs all the network rule objects in the volume group after the addition operation.

