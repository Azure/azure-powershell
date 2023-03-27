$RG = 'yemingdhsm'
$Location = 'eastus'
$GWName = 'GW'
$GwIpName = 'GWIP'
$GwIpConfName = 'gwipconf'
$VNetName = 'myHSM-vnet'
$hsmSubnetName = 'hsmsubnet'
$hsmName = 'yeminghsm'

# Prerequisite 1: A vnet and subnets
$computeSubnet = New-AzVirtualNetworkSubnetConfig   -Name compute   -AddressPrefix 10.2.0.0/24
$delegation = New-AzDelegation   -Name "myDelegation"   -ServiceName "Microsoft.HardwareSecurityModules/dedicatedHSMs"
$hsmSubnet = New-AzVirtualNetworkSubnetConfig   -Name $hsmSubnetName   -AddressPrefix 10.2.1.0/24   -Delegation $delegation
$gatewaySubnet = New-AzVirtualNetworkSubnetConfig   -Name GatewaySubnet   -AddressPrefix 10.2.255.0/26 # gateway subnet name MUST be "GatewaySubnet"
New-AzVirtualNetwork   -Name $VNetName   -ResourceGroupName $RG   -Location $Location   -AddressPrefix 10.2.0.0/16   -Subnet $computeSubnet, $hsmSubnet, $gatewaySubnet

# Prerequisite 2: An ExpressRoute gateway
# follow "Configure a virtual network gateway for ExpressRoute using PowerShell"
# https://learn.microsoft.com/azure/expressroute/expressroute-howto-add-gateway-resource-manager
$vnet = Get-AzVirtualNetwork -Name $VNetName -ResourceGroupName $RG
$gatewaySubnet = Get-AzVirtualNetworkSubnetConfig -Name 'GatewaySubnet' -VirtualNetwork $vnet
$pip = New-AzPublicIpAddress -Name $GwIpName  -ResourceGroupName $RG -Location $Location -AllocationMethod Dynamic
$ipConfig = New-AzVirtualNetworkGatewayIpConfig -Name $GwIpConfName -Subnet $gatewaySubnet -PublicIpAddress $pip
New-AzVirtualNetworkGateway -Name $GWName -ResourceGroupName $RG -Location $Location -IpConfigurations $ipConfig -GatewayType ExpressRoute -GatewaySku Standard

# Create a dedicated HSM
$hsmSubnet = Get-AzVirtualNetworkSubnetConfig -Name $hsmSubnetName -VirtualNetwork $vnet
New-AzDedicatedHsm -Name $hsmName -ResourceGroupName $RG -Location $Location -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId $hsmSubnet.Id -NetworkProfileNetworkInterface @{PrivateIPAddress = '10.2.1.120' }
# after creating, the provisioning state of dedicated hsm is not successful yet
# need to wait ~30 minutes and call get- to make sure it's done
Get-AzDedicatedHsm -Name $hsmName -ResourceGroupName $RG
