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
Virtual network gateway connection tests
#>
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
      $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
      
      # Create the Virtual Network
      $subnet = New-AzureVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzureVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzureVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      $vnetGateway = Get-AzureVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $vnetGateway.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
      
      # Create LocalNetworkGateway      
      $actual = New-AzureLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.10
      $localnetGateway = Get-AzureLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.3.10" $localnetGateway.GatewayIpAddress  
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]
      $localnetGateway.Location = $location

      # Create & Get VirtualNetworkGatewayConnection
      $actual = New-AzureVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc
      $expected = Get-AzureVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "IPsec" $expected.ConnectionType
      Assert-AreEqual "3" $expected.RoutingWeight
      Assert-AreEqual "abc" $expected.SharedKey

      # List VirtualNetworkGatewayConnections
      $list = Get-AzureVirtualNetworkGatewayConnection -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $list[0].Name $actual.Name	
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqual "IPsec" $list[0].ConnectionType
      Assert-AreEqual "3" $list[0].RoutingWeight
      Assert-AreEqual "abc" $list[0].SharedKey

      # Set/Update VirtualNetworkGatewayConnection
      $expected.Location = $location
      $expected.VirtualNetworkGateway1.Location = $location
      $expected.LocalNetworkGateway2.Location = $location
      $expected.RoutingWeight = "4"
      $expected.SharedKey = "xyz"

      $actual = Set-AzureVirtualNetworkGatewayConnection -VirtualNetworkGatewayConnection $expected -Force
      $expected = Get-AzureVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName    
      Assert-AreEqual "4" $expected.RoutingWeight        
      Assert-AreEqual "xyz" $expected.SharedKey     
      
      # Delete VirtualNetworkGatewayConnection
      $delete = Remove-AzureVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName -name $vnetConnectionName -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureVirtualNetworkGatewayConnection -ResourceGroupName $actual.ResourceGroupName
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
      $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
      
      # Create the Virtual Network
      $subnet = New-AzureVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create VirtualNetworkGateway
      $vnetIpConfig = New-AzureVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzureVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      $vnetGateway = Get-AzureVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $vnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $vnetGateway.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
      
      # Create LocalNetworkGateway
      $actual = New-AzureLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.11
      $localnetGateway = Get-AzureLocalNetworkGateway -ResourceGroupName $rgname -name $localnetName
      Assert-AreEqual $localnetGateway.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $localnetGateway.Name $actual.Name	
      Assert-AreEqual "192.168.3.11" $localnetGateway.GatewayIpAddress
      Assert-AreEqual "192.168.0.0/16" $localnetGateway.LocalNetworkAddressSpace.AddressPrefixes[0]
      $localnetGateway.Location = $location

      # Create VirtualNetworkGatewayConnection
      $actual = New-AzureVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc
      $expected = Get-AzureVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "IPsec" $expected.ConnectionType
      Assert-AreEqual "3" $expected.RoutingWeight
      Assert-AreEqual "abc" $expected.SharedKey

      # Set VirtualNetworkGatewayConnectionSharedKey
      $actual = Set-AzureVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName -Value "TestSharedKeyValue" -Force

      # Get VirtualNetworkGatewayConnectionSharedKey
      $expected = Get-AzureVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName
      
      # Reset VirtualNetworkGatewayConnectionSharedKey
      $actual = Reset-AzureVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $rname -KeyLength 50 -Force   

      # Get VirtualNetworkGatewayConnectionSharedKey after Reset-VirtualNetworkGatewayConnectionSharedKey
      $expected = Get-AzureVirtualNetworkGatewayConnectionSharedKey -ResourceGroupName $rgname -name $vnetConnectionName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}