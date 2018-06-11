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
Tests AzureFirewallCRUD.
#>
function Test-AzureFirewallCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = "joanna-firewall"
    # $location = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$publicIpName = Get-ResourceName
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
		# Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

        # Create AzureFirewall
        $azureFirewall = New-AzureRmFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgname
        $azureFirewallIpConfiguration = $getAzureFirewall.IpConfiguration

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.ResourceGuid
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 1 @($getAzureFirewall.IpConfiguration).Count
		Assert-NotNull $azureFirewallIpConfiguration[0].Subnet.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PublicIpAddress.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PrivateIpAddress
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollection).Count
		Assert-AreEqual 0 @($getAzureFirewall.NetworkRuleCollection).Count

        # list all Azure Firewalls in the resource group
        $list = Get-AzureRmFirewall -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $list[0].Name $getAzureFirewall.Name
        Assert-AreEqual $list[0].Location $getAzureFirewall.Location
        Assert-AreEqual $list[0].Etag $getAzureFirewall.Etag
        Assert-AreEqual @($list[0].IpConfiguration).Count @($getAzureFirewall.IpConfiguration).Count
		Assert-AreEqual @($list[0].IpConfiguration)[0].Subnet.Id $azureFirewallIpConfiguration[0].Subnet.Id
		Assert-AreEqual @($list[0].IpConfiguration)[0].PublicIpAddress.Id $azureFirewallIpConfiguration[0].PublicIpAddress.Id
		Assert-AreEqual @($list[0].IpConfiguration)[0].PrivateIpAddress $azureFirewallIpConfiguration[0].PrivateIpAddress
        Assert-AreEqual @($list[0].ApplicationRuleCollection).Count @($getAzureFirewall.ApplicationRuleCollection).Count
		Assert-AreEqual @($list[0].NetworkRuleCollection).Count @($getAzureFirewall.NetworkRuleCollection).Count

        # list all Azure Firewalls in the subscription
        $list = Get-AzureRmFirewall 
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $list[0].Name $getAzureFirewall.Name
        Assert-AreEqual $list[0].Location $getAzureFirewall.Location
        Assert-AreEqual $list[0].Etag $getAzureFirewall.Etag
        Assert-AreEqual @($list[0].IpConfiguration).Count @($getAzureFirewall.IpConfiguration).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollection).Count @($getAzureFirewall.ApplicationRuleCollection).Count

        # Update the Firewall
        Set-AzureRmFirewall -AzureFirewall $azureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgName

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.ResourceGuid
        Assert-NotNull $getAzureFirewall.Etag
        Assert-NotNull $getAzureFirewall.IpConfiguration
        Assert-AreEqual 1 $getAzureFirewall.IpConfiguration.Count
        Assert-NotNull $getAzureFirewall.IpConfiguration[0].Subnet
        Assert-AreEqual $vnet.Subnets[0].Id $getAzureFirewall.IpConfiguration[0].Subnet.Id
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollection).Count

        # Delete VirtualNetwork - should fail
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual false $delete

        # Delete AzureFirewall
        $delete = Remove-AzureRmFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork again - this time it should succeed
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
