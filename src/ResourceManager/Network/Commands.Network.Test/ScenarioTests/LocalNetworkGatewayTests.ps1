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
Local network gateway tests
#>
function Test-LocalNetworkGatewayCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/localNetworkGateways"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
     {
      # Create the resource group
      $resourceGroup = New-AzureRMResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"}             

      # Create & Get LocalNetworkGateway      
      $actual = New-AzureRMLocalNetworkGateway -ResourceGroupName $rgname -name $rname -location $location -AddressPrefix 192.168.0.0/16 -GatewayIpAddress 192.168.3.4
      $expected = Get-AzureRMLocalNetworkGateway -ResourceGroupName $rgname -name $rname
      Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $expected.Name $actual.Name	
      Assert-AreEqual "192.168.3.4" $expected.GatewayIpAddress
      Assert-AreEqual "192.168.0.0/16" $expected.LocalNetworkAddressSpace.AddressPrefixes[0]
      $expected.Location = $location

      # List LocalNetworkGateways
      $list = Get-AzureRMLocalNetworkGateway -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actual.Name	
      Assert-AreEqual $list[0].Location $actual.Location
      Assert-AreEqual "192.168.3.4" $list[0].GatewayIpAddress
      
      # Set/Update LocalNetworkGateway
      $actual = Set-AzureRMLocalNetworkGateway -LocalNetworkGateway $expected -AddressPrefix "200.168.0.0/16"
      $expected = Get-AzureRMLocalNetworkGateway -ResourceGroupName $rgname -name $rname    
      Assert-AreEqual "200.168.0.0/16" $expected.LocalNetworkAddressSpace.AddressPrefixes[0]

      # Delete LocalNetworkGateway
      $delete = Remove-AzureRMLocalNetworkGateway -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force
      Assert-AreEqual true $delete
      
      $list = Get-AzureRMLocalNetworkGateway -ResourceGroupName $actual.ResourceGroupName
      Assert-AreEqual 0 @($list).Count
     }
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}