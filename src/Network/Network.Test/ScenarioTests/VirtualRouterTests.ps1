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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

<#
.SYNOPSIS
Test creating new VirtualRouter
#>
function Test-VirtualRouterCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "southcentralus"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent "southcentralus"
	$virtualRouterName = Get-ResourceName

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

      # Create & Get virtualnetworkgateway
      $vnetIpConfig = New-AzVirtualNetworkGatewayIpConfig -Name $vnetGatewayConfigName -PublicIpAddress $publicip -Subnet $subnet

      $actual = New-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -IpConfigurations $vnetIpConfig -GatewayType ExpressRoute -GatewaySku HighPerformance -VpnType RouteBased -VpnGatewayGeneration None -Force 
      $expected = Get-AzVirtualNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "ExpressRoute" $expected.GatewayType
	  Assert-AreEqual "None" $expected.VpnGatewayGeneration

	  # Create Virtual Router
	  $actualvr = New-AzVirtualRouter -ResourceGroupName $rgname -location $location -Name $virtualRouterName -HostedGateway $expected 
	  $expectedvr = Get-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName
	  Assert-AreEqual $expectedvr.ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $expectedvr.Name $actualvr.Name

	  # List Virtual Routers
	  $list = Get-AzVirtualRouter -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actualvr.Name	
      Assert-AreEqual $list[0].Location $actualvr.Location

	  # Delete VR
	  $deletevR = Remove-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName -PassThru -Force
      Assert-AreEqual true $deletevR

      # Delete virtualNetworkGateway
      $delete = Remove-AzVirtualNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete

	  $list = Get-AzVirtualRouter -ResourceGroupName $rgname
	  Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

