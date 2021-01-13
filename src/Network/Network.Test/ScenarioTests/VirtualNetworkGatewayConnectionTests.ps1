# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Virtual network express route gateway connection tests
This is a special case which need a provisioned circuit
If you need to re-record this case, please contact express route team
#>
function Test-VirtualNetworkeExpressRouteGatewayConnectionCRUD
{
    # Setup
    $rgname = "onesdkTestConnection"
    $vnetConnectionName = Get-ResourceName
    $location = Get-ProviderLocation "Microsoft.Network/vpnGateways" "West US"

    try 
     {
        # Get the resource group
        $resourceGroup = Get-AzResourceGroup -Name $rgname  
        Assert-NotNull $resourceGroup
        # Get Gateway
        $gw = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname
        Assert-AreEqual 1 @($gw).Count
        # Get Circuit
        $circuit = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
        Assert-AreEqual 1 @($circuit).Count
	
        # Create & Get VirtualNetworkGatewayConnection
        $actual = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $gw  -ConnectionType ExpressRoute -RoutingWeight 3 -PeerId $circuit.Id
        $expected = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Name $actual.Name	
        Assert-AreEqual "ExpressRoute" $expected.ConnectionType
        Assert-AreEqual "3" $expected.RoutingWeight
        Assert-AreEqual $False $expected.ExpressRouteGatewayBypass

        $list = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -Name "*"
        Assert-True { $list.Count -ge 0 }

		#get routes 
		Get-AzExpressRouteCircuitARPTable -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary

        # Delete VirtualNetworkGatewayConnection
        $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
        Assert-AreEqual true $delete
        $list = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count

        # Now Create a Virtual Network Gateway Connection with ExpressRouteGatewayBypass enabled
        $connection = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $gw  -ConnectionType ExpressRoute -RoutingWeight 3 -PeerId $circuit.Id -ExpressRouteGatewayBypass
        $getConnection = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
        Assert-AreEqual $getConnection.ResourceGroupName $connection.ResourceGroupName
        Assert-AreEqual $getConnection.Name $connection.Name
        Assert-AreEqual "ExpressRoute" $getConnection.ConnectionType
        Assert-AreEqual "3" $getConnection.RoutingWeight
        Assert-AreEqual $True $getConnection.ExpressRouteGatewayBypass

        # Delete VirtualNetworkGatewayConnection
        $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
        Assert-AreEqual true $delete
        $list = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count
     }
     finally
     {
      # Cleanup
      
     }
}

<#
.SYNOPSIS
Virtual network gateway connection tests
#>
function Test-VirtualNetworkGatewayConnectionWithBgpCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $localnetName = Get-ResourceName
    $vnetConnectionName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

	  # Also test overriding the gateway ASN
      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard -Asn 55000
      $vnetGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.BgpSettings.Asn $actual.BgpSettings.Asn	
    
      # Create LocalNetworkGateway    
      $actual = New-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10 -Asn 1337 -BgpPeeringAddress "192.168.1.1" -PeerWeight 5
      $localnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.BgpSettings.Asn $actual.BgpSettings.Asn
	  Assert-AreEqual $localnetGateway.BgpSettings.BgpPeeringAddress $actual.BgpSettings.BgpPeeringAddress
      Assert-AreEqual $localnetGateway.BgpSettings.PeerWeight $actual.BgpSettings.PeerWeight

      # Create & Get VirtualNetworkGatewayConnection
      $actual = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -EnableBgp $true
      $connection = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $connection.EnableBgp $actual.EnableBgp
    
      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
      Assert-AreEqual true $delete

     }
     finally
     {
      # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway connection tests
#>
function Test-VirtualNetworkGatewayConnectionWithTrafficSelector
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $localnetName = Get-ResourceName
    $vnetConnectionName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet
	  $trafficSelector = New-AzIpsecTrafficSelectorPolicy -LocalAddressRange ("20.20.0.0/16") -RemoteAddressRange ("10.10.0.0/16")

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

	  # Also test overriding the gateway ASN
      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard -Asn 55000
      $vnetGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.BgpSettings.Asn $actual.BgpSettings.Asn	
    
      # Create LocalNetworkGateway    
      $actual = New-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10
      $localnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName

      # Create & Get VirtualNetworkGatewayConnection
      $actual = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -TrafficSelectorPolicy ($trafficSelector)
      $connection = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
	  Assert-NotNull $connection;
	  Assert-NotNull $connection.TrafficSelectorPolicies;
	  Assert-AreEqual $connection.TrafficSelectorPolicies.Count 1
	  
	  $connectionTrafficSelector = $connection.TrafficSelectorPolicies[0];
	  Assert-AreEqual $trafficSelector.LocalAddressRanges[0] $connectionTrafficSelector.LocalAddressRanges[0];
	  Assert-AreEqual $trafficSelector.RemoteAddressRanges[0] $connectionTrafficSelector.RemoteAddressRanges[0];
    
      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
      Assert-AreEqual true $delete

     }
     finally
     {
      # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway connection tests with Ipsec Policies and policy-based TS
#>
function Test-VirtualNetworkGatewayConnectionWithIpsecPoliciesCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $localnetName = Get-ResourceName
    $vnetConnectionName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent

	try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
      $vnetGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

      # Create LocalNetworkGateway    
      $actual = New-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10
      $localnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName

	  # Create IpsecPolicy and test defaults creation
	  $ipsecPolicy = New-AzIpsecPolicy -IpsecEncryption "GCMAES256" -IpsecIntegrity "GCMAES256" -IkeEncryption "AES256" -IkeIntegrity "SHA256" -DhGroup "DHGroup14" -PfsGroup "PFS2048"
	  Assert-AreEqual $ipsecPolicy.SALifeTimeSeconds 27000
	  Assert-AreEqual $ipsecPolicy.SADataSizeKilobytes 102400000 
	  $ipsecPolicy = New-AzIpsecPolicy -SALifeTimeSeconds 3000 -SADataSizeKilobytes 10000 -IpsecEncryption "GCMAES256" -IpsecIntegrity "GCMAES256" -IkeEncryption "AES256" -IkeIntegrity "SHA256" -DhGroup "DHGroup14" -PfsGroup "PFS2048"

      # Create & Get VirtualNetworkGatewayConnection w/ policy based TS
      $job = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -EnableBgp $false -UsePolicyBasedTrafficSelectors $true -IpsecPolicies $ipsecPolicy -DpdTimeoutInSeconds 30 -AsJob
      $job | Wait-Job
	  $actual = $job | Receive-Job
	  $connection = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      
	  # Verify IpsecPolicies and policy-based TS
	  Assert-AreEqual $connection.UsePolicyBasedTrafficSelectors $actual.UsePolicyBasedTrafficSelectors
	  Assert-AreEqual $connection.IpsecPolicies.Count $actual.IpsecPolicies.Count
	  Assert-AreEqual $connection.IpsecPolicies[0].SALifeTimeSeconds $actual.IpsecPolicies[0].SALifeTimeSeconds
	  Assert-AreEqual $connection.IpsecPolicies[0].SADataSizeKilobytes $actual.IpsecPolicies[0].SADataSizeKilobytes
	  Assert-AreEqual $connection.IpsecPolicies[0].IpsecEncryption $actual.IpsecPolicies[0].IpsecEncryption
	  Assert-AreEqual $connection.IpsecPolicies[0].IpsecIntegrity $actual.IpsecPolicies[0].IpsecIntegrity
	  Assert-AreEqual $connection.IpsecPolicies[0].IkeEncryption $actual.IpsecPolicies[0].IkeEncryption
	  Assert-AreEqual $connection.IpsecPolicies[0].IkeIntegrity $actual.IpsecPolicies[0].IkeIntegrity
	  Assert-AreEqual $connection.IpsecPolicies[0].DhGroup $actual.IpsecPolicies[0].DhGroup
	  Assert-AreEqual $connection.IpsecPolicies[0].PfsGroup $actual.IpsecPolicies[0].PfsGroup
      Assert-AreEqual 30 $connection.DpdTimeoutSeconds
    
	  # Set & Get VirtualNetworkGatewayConnection with policy cleared
      $job = Set-AzVirtualNetworkGatewayConnection -VirtualNetworkGatewayConnection $connection -UsePolicyBasedTrafficSelectors $false -IpsecPolicies @() -DpdTimeoutInSeconds 10 -Force -AsJob
	  $job | Wait-Job
	  $actual = $job | Receive-Job
	  $connection = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName

	  # Verify cleared policies
	  Assert-AreEqual false $connection.UsePolicyBasedTrafficSelectors
	  Assert-AreEqual 0 $connection.IpsecPolicies.Count
      Assert-AreEqual 10 $connection.DpdTimeoutSeconds

      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
	  Assert-AreEqual true $delete
     }
     finally
     {
      # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway connection test with Active-Active feature enabled virtual network gateway
#>
function Test-VirtualNetworkGatewayConnectionWithActiveActiveGateway
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname1 = Get-ResourceName
	$rname2 = Get-ResourceName
    $domainNameLabel11 = Get-ResourceName
	$domainNameLabel12 = Get-ResourceName
	$domainNameLabel2 = Get-ResourceName
    $vnetName1 = Get-ResourceName
	$vnetName2 = Get-ResourceName
    $vnetConnectionName1 = Get-ResourceName
	$vnetConnectionName2 = Get-ResourceName
    $publicIpName11 = Get-ResourceName
	$publicIpName12 = Get-ResourceName
	$publicIpName2 = Get-ResourceName
    $vnetGatewayConfigName11 = Get-ResourceName
	$vnetGatewayConfigName12 = Get-ResourceName
	$vnetGatewayConfigName2 = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
        # Create the Virtual Network1
      $subnet1 = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet1 = New-AzVirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet1
      $vnet1 = Get-AzVirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname
      $subnet1 = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet1
	  	            
	  # Create Active-Active feature enabled virtualnetworkgateway1 & Get virtualnetworkgateway1
      $publicip11 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName11 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel11  
      $vnetIpConfig11 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName11 -PublicIpAddress $publicip11 -Subnet $subnet1

      $publicip12 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName12 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel12
      $vnetIpConfig12 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName12 -PublicIpAddress $publicip12 -Subnet $subnet1

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname1 -Location $location -IpConfigurations $vnetIpConfig11,$vnetIpConfig12 -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku HighPerformance -EnableActiveActiveFeature
      $vnetGateway1 = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname1

	  # Create the Virtual Network2
      $subnet2 = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 192.168.200.0/26
      $vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 192.168.0.0/16 -Subnet $subnet2
      $vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
      $subnet2 = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet2

      # Create the publicip2
      $publicip2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2

      # Create VirtualNetworkGateway2
      $vnetIpConfig2 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -PublicIpAddress $publicip2 -Subnet $subnet2

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2 -location $location -IpConfigurations $vnetIpConfig2 -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
      $vnetGateway2 = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2

      # Create & Get VirtualNetworkGatewayConnection1, VirtualNetworkGatewayConnection2
      $actual1 = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName1 -location $location -VirtualNetworkGateway1 $vnetGateway1 -VirtualNetworkGateway2 $vnetGateway2 -ConnectionType Vnet2Vnet -RoutingWeight 3 -SharedKey abc
	  $actual2 = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName2 -location $location -VirtualNetworkGateway1 $vnetGateway2 -VirtualNetworkGateway2 $vnetGateway1 -ConnectionType Vnet2Vnet -RoutingWeight 3 -SharedKey abc

      $connection1 = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName1      
	  Assert-NotNull $connection1.TunnelConnectionStatus
      
      # Delete VirtualNetworkGatewayConnections
      $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName1 -PassThru -Force
      Assert-AreEqual true $delete
	  $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName2 -PassThru -Force
      Assert-AreEqual true $delete
     }
     finally
     {
      # Cleanup
        Clean-ResourceGroup $rgname
     }
}

function Test-VirtualNetworkGatewayConnectionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $localnetName = Get-ResourceName
    $vnetConnectionName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      $vnetGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $vnetGateway.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
    
      # Create LocalNetworkGateway    
      $actual = New-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10
      $localnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.3.10" $localnetGateway.GatewayIpAddress  
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]
      $localnetGateway.Location = $location

      # Create & Get VirtualNetworkGatewayConnection
      $actual = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -ConnectionProtocol IKEv1 -ConnectionMode "Default"
      $expected = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "IPsec" $expected.ConnectionType
      Assert-AreEqual "3" $expected.RoutingWeight
	  Assert-AreEqual "IKEv1" $expected.ConnectionProtocol
      #Assert-AreEqual "abc" $expected.SharedKey
      Assert-AreEqual $expected.ConnectionMode $actual.ConnectionMode

      # List VirtualNetworkGatewayConnections
      $list = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $list[0].Name $actual.Name	
      # Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqual "IPsec" $list[0].ConnectionType
      Assert-AreEqual "3" $list[0].RoutingWeight
      #Assert-AreEqual "abc" $list[0].SharedKey

      # Set/Update VirtualNetworkGatewayConnection
      $expected.Location = $location
      $expected.VirtualNetworkGateway1.Location = $location
      $expected.LocalNetworkGateway2.Location = $location
      $expected.RoutingWeight = "4"
      $expected.SharedKey = "xyz"
      $expected.ConnectionMode = "ResponderOnly"

	  # Set/Update VirtualNetworkGatewayConnection Tags
      $actual = Set-AzVirtualNetworkGatewayConnection -VirtualNetworkGatewayConnection $expected -Tag @{ testtagKey="SomeTagKey"; testtagValue="SomeKeyValue" } -Force
      $expected = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName    
      Assert-AreEqual 2 $expected.Tag.Count
	  Assert-AreEqual $true $expected.Tag.Contains("testtagKey")
      Assert-AreEqual $expected.ConnectionMode $actual.ConnectionMode
      
      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
      Assert-AreEqual true $delete
    
      $list = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
     }
     finally
     {
      # Cleanup
        Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
Virtual network gateway connection shared key tests
#>
function Test-VirtualNetworkGatewayConnectionSharedKeyCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $localnetName = Get-ResourceName
    $vnetConnectionName = Get-ResourceName
    $publicIpName = Get-ResourceName    
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      Assert-AreEqual $rgname $actual.ResourceGroupName
      Assert-AreEqual $rname $actual.Name
      Assert-AreEqual "Vpn" $actual.GatewayType
      Assert-AreEqual "RouteBased" $actual.VpnType
      Assert-AreEqual $false $actual.EnableBgp

      $vnetGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $vnetGateway.Name $actual.Name
    
      # Create LocalNetworkGateway
      $actual = New-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.11
      $localnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.3.11" $localnetGateway.GatewayIpAddress
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]
      $localnetGateway.Location = $location

      # Create VirtualNetworkGatewayConnection
      $actual = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc
      $expected = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "IPsec" $expected.ConnectionType
      Assert-AreEqual "3" $expected.RoutingWeight
      Assert-AreEqual "abc" $expected.SharedKey

      # Set VirtualNetworkGatewayConnectionSharedKey
      $actual = Set-AzVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName -Value "TestSharedKeyValue" -Force
      Assert-AreEqual "TestSharedKeyValue" $actual

      # Get VirtualNetworkGatewayConnectionSharedKey
      $expected = Get-AzVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual "TestSharedKeyValue" $expected

      # Wait to avoid conflict
      Start-TestSleep 60000

      # Reset VirtualNetworkGatewayConnectionSharedKey
      $actual = Reset-AzVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName -KeyLength 50 -Force
      Assert-AreNotEqual "TestSharedKeyValue" $actual

      # Get VirtualNetworkGatewayConnectionSharedKey after Reset-VirtualNetworkGatewayConnectionSharedKey
      $expected = Get-AzVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreNotEqual "TestSharedKeyValue" $expected
    }
    finally
    {
      # Cleanup
      Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Virtual network gateway vpn device configuration tests
#>
function Test-VirtualNetworkGatewayConnectionVpnDeviceConfigurations
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $localnetName = Get-ResourceName
    $vnetConnectionName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent

	try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
      $vnetGateway = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

      # Create LocalNetworkGateway    
      $actual = New-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10
      $localnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName

	  # Create IpsecPolicy and test defaults creation
	  $ipsecPolicy = New-AzIpsecPolicy -IpsecEncryption "GCMAES256" -IpsecIntegrity "GCMAES256" -IkeEncryption "AES256" -IkeIntegrity "SHA256" -DhGroup "DHGroup14" -PfsGroup "PFS2048"
	  Assert-AreEqual $ipsecPolicy.SALifeTimeSeconds 27000
	  Assert-AreEqual $ipsecPolicy.SADataSizeKilobytes 102400000 
	  $ipsecPolicy = New-AzIpsecPolicy -SALifeTimeSeconds 3000 -SADataSizeKilobytes 10000 -IpsecEncryption "GCMAES256" -IpsecIntegrity "GCMAES256" -IkeEncryption "AES256" -IkeIntegrity "SHA256" -DhGroup "DHGroup14" -PfsGroup "PFS2048"

      # Create & Get VirtualNetworkGatewayConnection w/ policy based TS
      $actual = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -EnableBgp $false -UsePolicyBasedTrafficSelectors $true -IpsecPolicies $ipsecPolicy
      $connection = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      
	  # List supported vpn devices
	  $supportedVpnDevices = Get-AzVirtualNetworkGatewaySupportedVpnDevice -ResourceGroupName $rgname -name $rname

	  $supportedDevicesXml = [xml]$supportedVpnDevices
	  $vendorNode = $supportedDevicesXml.SelectSingleNode("//Vendor")
      $deviceNode = $vendorNode.FirstChild
      $vendorName = $vendorNode.Attributes["name"].Value
      $deviceName = $deviceNode.Attributes["name"].Value
      $firmwareVersion = $deviceNode.FirstChild.Attributes["name"].Value

	  $vpnDeviceConfigurationScript = Get-AzVirtualNetworkGatewayConnectionVpnDeviceConfigScript -ResourceGroupName $rgname -name $vnetConnectionName -DeviceVendor $vendorName -DeviceFamily $deviceName -FirmwareVersion $firmwareVersion
	  Write-Host $vpnDeviceConfigurationScript
     }
     finally
     {
      # Cleanup
        Clean-ResourceGroup $rgname
     }
}

function Test-VirtualNetworkGatewayConnectionPacketCapture
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname1 = Get-ResourceName
    $rname2 = Get-ResourceName
    $domainNameLabel1 = Get-ResourceName
	$domainNameLabel2 = Get-ResourceName
    $vnetName1 = Get-ResourceName
	$vnetName2 = Get-ResourceName
    $vnetConnectionName1 = Get-ResourceName
	$vnetConnectionName2 = Get-ResourceName
    $publicIpName1 = Get-ResourceName
	$publicIpName2 = Get-ResourceName
    $vnetGatewayConfigName1 = Get-ResourceName
	$vnetGatewayConfigName2 = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "WestCentralUS"
    $resourceTypeParent = "Microsoft.Network/connections"
    $location = Get-ProviderLocation $resourceTypeParent "WestCentralUS"
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
      #create SAS URL
	   if ((Get-NetworkTestMode) -ne 'Playback')
	  {
	       $storetype = 'Standard_GRS'
           $containerName = "testcontainer"
           $storeName = 'sto' + $rgname;
           New-AzStorageAccount -ResourceGroupName $rgname -Name $storeName -Location $location -Type $storetype
           $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $storeName
           $context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
           New-AzStorageContainer -Name $containerName -Context $context
           $container = Get-AzStorageContainer -Name $containerName -Context $context
           $now=get-date
           $sasurl = New-AzureStorageContainerSASToken -Name $containerName -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri
	  }
	  else
	  {
	  	   $sasurl = "https://storage/test123?sp=racwdl&stvigopKcy"
	  }

      # Create the Virtual Network1
      $subnet1 = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet1 = New-AzVirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet1
      $vnet1 = Get-AzVirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname
      $subnet1 = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet1

      # Create virtualnetworkgateway1 & Get virtualnetworkgateway1
      $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName1 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel1
      $vnetIpConfig1 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName1 -PublicIpAddress $publicip1 -Subnet $subnet1

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname1 -Location $location -IpConfigurations $vnetIpConfig1 -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
      $vnetGateway1 = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname1

      # Create the Virtual Network2
      $subnet2 = New-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 192.168.200.0/26
      $vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 192.168.0.0/16 -Subnet $subnet2
      $vnet2 = Get-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
      $subnet2 = Get-AzVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet2

      # Create the publicip2
      $publicip2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2

      # Create VirtualNetworkGateway2
      $vnetIpConfig2 = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -PublicIpAddress $publicip2 -Subnet $subnet2

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2 -location $location -IpConfigurations $vnetIpConfig2 -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
      $vnetGateway2 = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2

      # Create & Get VirtualNetworkGatewayConnection1, VirtualNetworkGatewayConnection2
      $actual1 = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName1 -location $location -VirtualNetworkGateway1 $vnetGateway1 -VirtualNetworkGateway2 $vnetGateway2 -ConnectionType Vnet2Vnet -RoutingWeight 3 -SharedKey abc
      $actual2 = New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName2 -location $location -VirtualNetworkGateway1 $vnetGateway2 -VirtualNetworkGateway2 $vnetGateway1 -ConnectionType Vnet2Vnet -RoutingWeight 3 -SharedKey abc

      $connection = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName1  
      
      #StartPacketCapture on gateway with Name parameter
      $output = Start-AzVirtualNetworkGatewayConnectionPacketCapture -ResourceGroupName  $rgname -Name $vnetConnectionName1
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Name $output.Name
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      #StopPacketCapture on gateway connection with Name parameter
      $output = Stop-AzVirtualNetworkGatewayConnectionPacketCapture -ResourceGroupName  $rgname -Name $vnetConnectionName1 -SasUrl $sasurl
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Name $output.Name
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      #StartPacketCapture on gateway Connection object
	  $a="{`"TracingFlags`":11,`"MaxPacketBufferSize`":120,`"MaxFileSize`":500,`"Filters`":[{`"SourceSubnets`":[`"10.19.0.4/32`",`"10.20.0.4/32`"],`"DestinationSubnets`":[`"10.20.0.4/32`",`"10.19.0.4/32`"],`"IpSubnetValueAsAny`":true,`"TcpFlags`":-1,`"PortValueAsAny`":true,`"CaptureSingleDirectionTrafficOnly`":true}]}"
      $output = Start-AzVirtualNetworkGatewayConnectionPacketCapture -InputObject $connection -FilterData $a
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Name $output.Name
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      #StopPacketCapture on gateway Connection object
      $output = Stop-AzVirtualNetworkGatewayConnectionPacketCapture -InputObject $connection -SasUrl $sasurl
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Name $output.Name
      Assert-AreEqual $connection.ResourceGroupName $output.ResourceGroupName	
      Assert-AreEqual $connection.Location $output.Location
      Assert-AreEqual $output.Code "Succeeded"

      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $connection.ResourceGroupName -name $vnetConnectionName1 -PassThru -Force
      Assert-AreEqual true $delete

      $delete = Remove-AzVirtualNetworkGatewayConnection -ResourceGroupName $actual2.ResourceGroupName -name $vnetConnectionName2 -PassThru -Force
      Assert-AreEqual true $delete
    
      $list = Get-AzVirtualNetworkGatewayConnection -ResourceGroupName $connection.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
     }
     finally
     {
      # Cleanup
        Clean-ResourceGroup $rgname
     }
}
