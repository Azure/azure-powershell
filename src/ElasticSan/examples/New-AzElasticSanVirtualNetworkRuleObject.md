### Example 1: Create a virtual network rule object 
```powershell
New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId  "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1" -Action Allow
```

```output
Action State VirtualNetworkResourceId                                                                                                                       
------ ----- ------------------------                                                                                                                       
Allow        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/myvnet/subnets/subnet1
```

This command creates a new virtual network rule object using the virtual network resource Id.
