### Example 1: Get a specified Application Gateway for Containers association resource
```powershell
Get-AzAlbAssociation -Name association1 -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name                ResourceGroupName Location       AssociationType SubnetId                                                                                                                                                       Provisioni
                                                                                                                                                                                                                                    ngState
----                ----------------- --------       --------------- --------                                                                                                                                                       ----------
association1        test-rg           NorthCentralUS subnets         /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/primary-VNET/subnets/alb-primary-subnet Succeeded
```

This command shows a specific Application Gateway for Containers association resource.

### Example 2: List associations for a given Application Gateway for Containers resource
```powershell
Get-AzAlbAssociation -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name                ResourceGroupName Location       AssociationType SubnetId                                                                                                                                                       Provisioni
                                                                                                                                                                                                                                    ngState
----                ----------------- --------       --------------- --------                                                                                                                                                       ----------
association1        test-rg           NorthCentralUS subnets         /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/primary-VNET/subnets/alb-primary-subnet Succeeded
```

This command lists all Application Gateway for Containers association resources belonging to a specific Application Gateway for Containers resource.
