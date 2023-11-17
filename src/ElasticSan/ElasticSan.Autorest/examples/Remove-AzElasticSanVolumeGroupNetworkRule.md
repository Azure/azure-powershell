### Example 1: Remove network rules by NetworkAclsVirtualNetworkRule objects  
```powershell
# Initialze network rule objects 
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow
$virtualNetworkRule3 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3" -Action Allow
# Add the network rule objects to the volume group
$rules = Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3

# Remove some of the network rules from the volume group
Remove-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3
```

This example adds 3 network rules to a volume group, and then remove 2 of the network rules from the volume group by inputting network rule objects. The command outputs all the network rule objects left in the volume group after the removal. 

### Example 2: Remove network rules by network rule resource Ids
```powershell
$virtualNetworkRule1 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
$virtualNetworkRule2 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2" -Action Allow
$virtualNetworkRule3 =  New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3" -Action Allow
$virtualNetworkRuleResourceId1 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1"
$virtualNetworkRuleResourceId2 = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet2"
# Update the volume group to contain the network rules 
$volGroup = Update-AzElasticSanVolumeGroup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -Name myvolumegroup -NetworkAclsVirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3

# Remove some of the network rules from the volume group
Remove-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -NetworkAclsVirtualNetworkResourceId $virtualNetworkRuleResourceId1,$virtualNetworkRuleResourceId2
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet3
```

This example adds 3 network rules to a volume group, and then remove 2 of the network rules from the volume group by inputting network rule resource Ids. The command outputs all the network rule objects left in the volume group after the removal. 

