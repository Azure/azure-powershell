 $rgname = "rgtest"
 $ergwName = "ergw"
 $vnetName = "vnet"
 $publicIpName = "publicip1"
 $erIpConfigName = "eripconfig"
 $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
 $location = "West US"
 $erConnName = "erconn"
 $publicIpName3 = "publicip3"
 $publicIpName4 = "publicip4"
 $vpnGatewayName = "vpngw"
 $sku = "VPNGW5AZ"
 $vpngwConfigName1 = "vpnipconfig1"
 $vpngwConfigName2 = "vpnipconfig2"
 
 try 
 {
   
   # Create the resource group
   $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "PS testing" } 

   # Create the Virtual Network
   $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
   $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
   $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
   $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

   # Create the publicip
   $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

    # Create ipconfig
   $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $erIpConfigName -PublicIpAddress $publicip -Subnet $subnet
 
   # Create ExpressRoute gateway
   $expected = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $ergwName -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku UltraPerformance
   $erGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $ergwName
   Assert-NotNull $erGateway

 # Get Circuit
 $circuit = Get-AzExpressRouteCircuit -Name "er-ckt-1271"
 Assert-AreEqual 1 @($circuit).Count
	
 # Create & Get VirtualNetworkGatewayConnection
 $conn = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $erConnName -location $location -VirtualNetworkGateway1 $erGateway  -ConnectionType ExpressRoute -RoutingWeight 3 -PeerId $circuit.Id -ExpressRouteGatewayBypass -EnablePrivateLinkFastPath
 $erConn = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $erConnName
 Assert-NotNull $erConn

$publicIP1 = New-AzPublicIpAddress -ResourceGroupName $rgname -Location $location -Name $publicIpName3 -AllocationMethod Static -Sku Standard
$publicIP2 = New-AzPublicIpAddress -ResourceGroupName $rgname -Location $location -Name $publicIpName4 -AllocationMethod Static -Sku Standard

# Create Gateway IP Configurations
$gwIpConfig1 = New-AzVirtualNetworkGatewayIpConfig -Name $vpngwConfigName1 -Subnet $subnet -PublicIpAddress $publicIP1
$gwIpConfig2 = New-AzVirtualNetworkGatewayIpConfig -Name $vpngwConfigName2 -Subnet $subnet -PublicIpAddress $publicIP2

 # Create high bandwidth VPN Gateway
 $vpnGateway = New-AzVirtualNetworkGateway -Name $vpnGatewayName -ResourceGroupName $rgName -Location $location -IpConfigurations $gwIpConfig1, $gwIpConfig2 -GatewayType Vpn -VpnType RouteBased -EnableActiveActiveFeature -EnableAdvancedConnectivity -GatewaySku $sku

$gateway = Get-AzVirtualNetworkGateway -Name $vpnGatewayName -ResourceGroupName $rgName
Assert-NotNull $vpnGateway
Assert-NotNull $vpnGateway.EnableAdvancedConnectivity
Assert-AreEqual $vpnGateway.EnableAdvancedConnectivity true

 }
  finally
  {
     # Cleanup
     Remove-AzResourceGroup $rgname
  }