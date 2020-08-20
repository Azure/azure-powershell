new-azdedicatedhsm -Name yeminghsm -ResourceGroupName yemingtemp -Location eastus -Sku "SafeNet Luna Network HSM A790" -SubnetId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yemingtemp/providers/Microsoft.Network/virtualNetworks/yemingvn/subnets/default" -StampId stamp1

get-azdedicatedhsm -Name yeminghsm -ResourceGroupName yemingtemp