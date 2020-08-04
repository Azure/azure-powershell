﻿# ----------------------------------------------------------------------------------
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
Test creating new HubBgpConnection
#>
function Test-HubBgpConnectionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
	$virtualRouterName = Get-ResourceName
    $virtualWanName = Get-ResourceName
    $subnetName = Get-ResourceName
    $peerName = Get-ResourceName

    try
    {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create virtual network and subnet
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet

	  # Create virtual router
	  $virtualRouter = New-AzVirtualRouter -ResourceGroupName $rgname -location $rglocation -Name $virtualRouterName -HostedSubnet $hostedsubnet.Id
	  $virtualRouter = Get-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName

	  # Create hub bgp connection
      $actualBgpConnection = Add-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName -PeerIp "192.168.1.5" -PeerAsn "20000"
      $expectedBgpConnection = Get-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName
      Assert-AreEqual $expectedBgpConnection.Peerings.PeerName $actualBgpConnection.PeerName
      Assert-AreEqual $expectedBgpConnection.PeerIp "192.168.1.5"
      Assert-AreEqual $expectedBgpConnection.PeerAsn "20000"

      #delete hub bgp connection
      $deleteBgpConnection = Remove-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName -Force
      Assert-AreEqual 0 @($deleteBgpConnection.Peerings).Count

	  # Delete virtual router
	  $deleteVirtualRouter = Remove-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName -PassThru -Force
      Assert-AreEqual true $deleteVirtualRouter

	  $list = Get-AzVirtualRouter -ResourceGroupName $rgname
	  Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

