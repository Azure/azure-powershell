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
	$location = "westus"
    try 
     {
        # Get the resource group
        $resourceGroup = Get-AzureRmResourceGroup -Name $rgname  
        Assert-NotNull $resourceGroup
        # Get Gateway
        $gw = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname
        Assert-AreEqual 1 @($gw).Count
        # Get Circuit
        $circuit = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
        Assert-AreEqual 1 @($circuit).Count
	
        # Create & Get VirtualNetworkGatewayConnection
        $actual = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $gw  -ConnectionType ExpressRoute -RoutingWeight 3 -PeerId $circuit.Id
        $expected = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Name $actual.Name	
        Assert-AreEqual "ExpressRoute" $expected.ConnectionType
        Assert-AreEqual "3" $expected.RoutingWeight

		#get routes 
		Get-AzureRmExpressRouteCircuitARPTable -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary

        # Delete VirtualNetworkGatewayConnection
        $delete = Remove-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
        Assert-AreEqual true $delete
        $list = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName
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
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

	  # Also test overriding the gateway ASN
      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard -Asn 55000
      $vnetGateway = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.BgpSettings.Asn $actual.BgpSettings.Asn	
    
      # Create LocalNetworkGateway    
      $actual = New-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10 -Asn 1337 -BgpPeeringAddress "192.168.1.1" -PeerWeight 5
      $localnetGateway = Get-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.BgpSettings.Asn $actual.BgpSettings.Asn
	  Assert-AreEqual $localnetGateway.BgpSettings.BgpPeeringAddress $actual.BgpSettings.BgpPeeringAddress
      Assert-AreEqual $localnetGateway.BgpSettings.PeerWeight $actual.BgpSettings.PeerWeight

      # Create & Get VirtualNetworkGatewayConnection
      $actual = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -EnableBgp $true
      $connection = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $connection.EnableBgp $actual.EnableBgp
    
      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
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
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet
      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
      $vnetGateway = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname

      # Create LocalNetworkGateway    
      $actual = New-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10
      $localnetGateway = Get-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName

	  # Create IpsecPolicy and test defaults creation
	  $ipsecPolicy = New-AzureRmIpsecPolicy -IpsecEncryption "GCMAES256" -IpsecIntegrity "GCMAES256" -IkeEncryption "AES256" -IkeIntegrity "SHA256" -DhGroup "DHGroup14" -PfsGroup "PFS2048"
	  Assert-AreEqual $ipsecPolicy.SALifeTimeSeconds 27000
	  Assert-AreEqual $ipsecPolicy.SADataSizeKilobytes 102400000 
	  $ipsecPolicy = New-AzureRmIpsecPolicy -SALifeTimeSeconds 3000 -SADataSizeKilobytes 10000 -IpsecEncryption "GCMAES256" -IpsecIntegrity "GCMAES256" -IkeEncryption "AES256" -IkeIntegrity "SHA256" -DhGroup "DHGroup14" -PfsGroup "PFS2048"

      # Create & Get VirtualNetworkGatewayConnection w/ policy based TS
      $actual = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -EnableBgp $false -UsePolicyBasedTrafficSelectors $true -IpsecPolicies $ipsecPolicy
      $connection = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      
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
    
	  # Set & Get VirtualNetworkGatewayConnection with policy cleared
      $actual = Set-AzureRmVirtualNetworkGatewayConnection -VirtualNetworkGatewayConnection $connection -UsePolicyBasedTrafficSelectors $false -IpsecPolicies @() -Force
	  $connection = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName

	  # Verify cleared policies
	  Assert-AreEqual false $connection.UsePolicyBasedTrafficSelectors
	  Assert-AreEqual 0 $connection.IpsecPolicies.Count

      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
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
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
        # Create the Virtual Network1
      $subnet1 = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet1 = New-AzureRmvirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet1
      $vnet1 = Get-AzureRmvirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname
      $subnet1 = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet1
	  	            
	  # Create Active-Active feature enabled virtualnetworkgateway1 & Get virtualnetworkgateway1
      $publicip11 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName11 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel11  
      $vnetIpConfig11 = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName11 -PublicIpAddress $publicip11 -Subnet $subnet1

      $publicip12 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName12 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel12
      $vnetIpConfig12 = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName12 -PublicIpAddress $publicip12 -Subnet $subnet1

      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname1 -Location $location -IpConfigurations $vnetIpConfig11,$vnetIpConfig12 -GatewayType Vpn -VpnType RouteBased -EnableBgp $false -GatewaySku HighPerformance -EnableActiveActiveFeature
      $vnetGateway1 = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname1

	  # Create the Virtual Network2
      $subnet2 = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 192.168.200.0/26
      $vnet2 = New-AzureRmvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 192.168.0.0/16 -Subnet $subnet2
      $vnet2 = Get-AzureRmvirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname
      $subnet2 = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet2

      # Create the publicip2
      $publicip2 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2

      # Create VirtualNetworkGateway2
      $vnetIpConfig2 = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName2 -PublicIpAddress $publicip2 -Subnet $subnet2

      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2 -location $location -IpConfigurations $vnetIpConfig2 -GatewayType Vpn -VpnType RouteBased -GatewaySku Standard
      $vnetGateway2 = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname2

      # Create & Get VirtualNetworkGatewayConnection1, VirtualNetworkGatewayConnection2
      $actual1 = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName1 -location $location -VirtualNetworkGateway1 $vnetGateway1 -VirtualNetworkGateway2 $vnetGateway2 -ConnectionType Vnet2Vnet -RoutingWeight 3 -SharedKey abc
	  $actual2 = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName2 -location $location -VirtualNetworkGateway1 $vnetGateway2 -VirtualNetworkGateway2 $vnetGateway1 -ConnectionType Vnet2Vnet -RoutingWeight 3 -SharedKey abc

      $connection1 = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName1      
	  Assert-NotNull $connection1.TunnelConnectionStatus
      
      # Delete VirtualNetworkGatewayConnections
      $delete = Remove-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName1 -PassThru -Force
      Assert-AreEqual true $delete
	  $delete = Remove-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName2 -PassThru -Force
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
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      $vnetGateway = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $vnetGateway.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
    
      # Create LocalNetworkGateway    
      $actual = New-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10
      $localnetGateway = Get-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.3.10" $localnetGateway.GatewayIpAddress  
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]
      $localnetGateway.Location = $location

      # Create & Get VirtualNetworkGatewayConnection
      $actual = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc
      $expected = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "IPsec" $expected.ConnectionType
      Assert-AreEqual "3" $expected.RoutingWeight
      #Assert-AreEqual "abc" $expected.SharedKey

      # List VirtualNetworkGatewayConnections
      $list = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname
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

      $actual = Set-AzureRmVirtualNetworkGatewayConnection -VirtualNetworkGatewayConnection $expected -Force
      $expected = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName    
      Assert-AreEqual "4" $expected.RoutingWeight      
      #Assert-AreEqual "xyz" $expected.SharedKey     
    
      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
      Assert-AreEqual true $delete
    
      $list = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName
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
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
    
      # Create the Virtual Network
      $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzureRmVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      $vnetGateway = Get-AzureRmVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $vnetGateway.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
    
      # Create LocalNetworkGateway
      $actual = New-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.11
      $localnetGateway = Get-AzureRmLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.3.11" $localnetGateway.GatewayIpAddress
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]
      $localnetGateway.Location = $location

      # Create VirtualNetworkGatewayConnection
      $actual = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc
      $expected = Get-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "IPsec" $expected.ConnectionType
      Assert-AreEqual "3" $expected.RoutingWeight
      #Assert-AreEqual "abc" $expected.SharedKey

      # Set VirtualNetworkGatewayConnectionSharedKey
      $actual = Set-AzureRmVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName -Value "TestSharedKeyValue" -Force
	  #Assert-AreEqual "TestSharedKeyValue" $actual

      # Get VirtualNetworkGatewayConnectionSharedKey
      $expected = Get-AzureRmVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName
      #Assert-AreEqual "TestSharedKeyValue" $expected

      # Reset VirtualNetworkGatewayConnectionSharedKey
      #$actual = Reset-AzureRmVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName -KeyLength 50 -Force   
	  #Assert-AreNotEqual "TestSharedKeyValue" $actual

      # Get VirtualNetworkGatewayConnectionSharedKey after Reset-VirtualNetworkGatewayConnectionSharedKey
      #$expected = Get-AzureRmVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName
	  #Assert-AreNotEqual "TestSharedKeyValue" $actual
    }
    finally
    {
      # Cleanup
      Clean-ResourceGroup $rgname
    }
}