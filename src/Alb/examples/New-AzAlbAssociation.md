### Example 1: Create a new Application Gateway for Containers association resource
```powershell
New-AzAlbAssociation -Name test-association -AlbName test-alb -ResourceGroupName test-rg -Location NorthCentralUS -SubnetId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/vnet01/subnets/alb-subnet
```

```output
Name             ResourceGroupName Location       AssociationType SubnetId                                                                                                                                         ProvisioningState
----             ----------------- --------       --------------- --------                                                                                                                                         -----------------
test-association test-rg           NorthCentralUS subnets         /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/vnet01/subnets/alb-subnet Succeeded
```

This command creates a new Application Gateway for Containers association resource.
