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
Virtual network gateway tests
#>
function Test-VirtualNetworkGatewayCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRMResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
      
      # Create the Virtual Network
      $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name "GatewaySubnet" -AddressPrefix 10.0.0.0/24
      $vnet = New-AzureRMvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzureRMvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzureRMVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet

      # Create the publicip
      $publicip = New-AzureRMPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel    

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzureRMVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzureRMVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -EnableBgp $false
      $expected = Get-AzureRMVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      #Assert-AreEqual "Vpn" $expected.GatewayType
      #Assert-AreEqual "RouteBased" $expected.VpnType
      
      # List virtualNetworkGateways
      $list = Get-AzureRMVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actual.Name	
      Assert-AreEqual $list[0].Location $actual.Location
      
      # Reset/Reboot virtualNetworkGateway primary
      $actual = Reset-AzureRMVirtualNetworkGateway -VirtualNetworkGateway $expected
      $list = Get-AzureRMVirtualNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count

      # Delete virtualNetworkGateway
      $delete = Remove-AzureRMVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRMVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}