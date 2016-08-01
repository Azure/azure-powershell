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
      $actual = New-AzureRmVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -EnableBgp true
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