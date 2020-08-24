New-AzDedicatedHsm -Name yeminghsm -ResourceGroupName yemingtemp -Location eastus -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yemingtemp/providers/Microsoft.Network/virtualNetworks/myHSM-vnet/subnets/hsmsubnet" -NetworkProfileNetworkInterface @{PrivateIPAddress = "10.6.0.200" }

New-AzDedicatedHsm -Name yeminghsm -ResourceGroupName yemingtemp -Location eastus -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yemingtemp/providers/Microsoft.Network/virtualNetworks/myHSM-vnet/subnets/hsmsubnet"

New-AzDedicatedHsm -Name yeminghsm -ResourceGroupName yemingtemp -Location eastus -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yemingtemp/providers/Microsoft.Network/virtualNetworks/myHSM-vnet/subnets/hsmsubnet"

# CLI

az network vnet create --name myHSM-vnet --resource-group yemingtemp --address-prefix 10.2.0.0/16 --subnet-name compute --subnet-prefix 10.2.0.0/24

az network vnet subnet create --vnet-name myHSM-vnet --resource-group yemingtemp --name hsmsubnet --address-prefixes 10.2.1.0/24 --delegations Microsoft.HardwareSecurityModules/dedicatedHSMs

az network vnet subnet create --vnet-name myHSM-vnet --resource-group yemingtemp --name GatewaySubnet --address-prefixes 10.2.255.0/26

# PowerShell

```powershell
$compute = New-AzVirtualNetworkSubnetConfig   -Name compute   -AddressPrefix 10.2.0.0/24

$delegation = New-AzDelegation   -Name "myDelegation"   -ServiceName "Microsoft.HardwareSecurityModules/dedicatedHSMs"

$hsmsubnet = New-AzVirtualNetworkSubnetConfig   -Name hsmsubnet   -AddressPrefix 10.2.1.0/24   -Delegation $delegation

$gwsubnet = New-AzVirtualNetworkSubnetConfig   -Name GatewaySubnet   -AddressPrefix 10.2.255.0/26

New-AzVirtualNetwork   -Name myHSM-vnet   -ResourceGroupName yemingtemp   -Location eastus   -AddressPrefix 10.2.0.0/16   -Subnet $compute, $hsmsubnet, $gwsubnet
```
