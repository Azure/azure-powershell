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
Tests NetworkSecurityGroupCRUD.
#>
function Test-NetworkSecurityGroupCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $nsgName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/NetworkSecurityGroups"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create NetworkSecurityGroup
        $nsg = New-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgname -Location $location

        # Get NetworkSecurityGroup
        $getNsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        
        #verification
        Assert-AreEqual $rgName $getNsg.ResourceGroupName
        Assert-AreEqual $nsgName $getNsg.Name
        Assert-NotNull $getNsg.Location
        Assert-NotNull $getNsg.ResourceGuid
        Assert-NotNull $getNsg.Etag
        Assert-AreEqual 0 @($getNsg.SecurityRules).Count
        Assert-AreEqual 6 @($getNsg.DefaultSecurityRules).Count
        Assert-AreEqual "AllowVnetInBound" $getNsg.DefaultSecurityRules[0].Name
        Assert-AreEqual "AllowAzureLoadBalancerInBound" $getNsg.DefaultSecurityRules[1].Name
        Assert-AreEqual "DenyAllInBound" $getNsg.DefaultSecurityRules[2].Name
        Assert-AreEqual "AllowVnetOutBound" $getNsg.DefaultSecurityRules[3].Name
        Assert-AreEqual "AllowInternetOutBound" $getNsg.DefaultSecurityRules[4].Name
        Assert-AreEqual "DenyAllOutBound" $getNsg.DefaultSecurityRules[5].Name

        # list
        $list = Get-AzureRmNetworkSecurityGroup -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getNsg.ResourceGroupName
        Assert-AreEqual $list[0].Name $getNsg.Name
        Assert-AreEqual $list[0].Location $getNsg.Location
        Assert-AreEqual $list[0].Etag $getNsg.Etag
        Assert-AreEqual @($list[0].SecurityRules).Count @($getNsg.SecurityRules).Count
        Assert-AreEqual @($list[0].DefaultSecurityRules).Count @($getNsg.DefaultSecurityRules).Count
        Assert-AreEqual $list[0].DefaultSecurityRules[0].Name $getNsg.DefaultSecurityRules[0].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[1].Name $getNsg.DefaultSecurityRules[1].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[2].Name $getNsg.DefaultSecurityRules[2].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[3].Name $getNsg.DefaultSecurityRules[3].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[4].Name $getNsg.DefaultSecurityRules[4].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[5].Name $getNsg.DefaultSecurityRules[5].Name


        # Add NSG to a subnet
        $vnet = $vnet | Set-AzureRmVirtualNetworkSubnetConfig -name $subnetName -AddressPrefix "10.0.1.0/24" -NetworkSecurityGroup $nsg | Set-AzureRmVirtualNetwork
        $getNsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        Assert-AreEqual $vnet.Subnets[0].NetworkSecurityGroup.Id $getNsg.Id
        Assert-AreEqual 1 @($getNsg.Subnets[0]).Count
        Assert-AreEqual $vnet.Subnets[0].Id $getNsg.Subnets[0].Id

        # Create NetworkInterface with NSG
        $nic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -NetworkSecurityGroup $nsg
        Assert-AreEqual $nic.NetworkSecurityGroup.Id $nsg.Id
        $getNsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        Assert-AreEqual 1 @($getNsg.NetworkInterfaces[0]).Count
        Assert-AreEqual $nic.Id $getNsg.NetworkInterfaces[0].Id

        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete NetworkSecurityGroup
        $delete = Remove-AzureRmNetworkSecurityGroup -ResourceGroupName $rgname -name $nsgName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkSecurityGroup -ResourceGroupName $rgname
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
Tests NetworkSecurityRuleCRUD.
#>
function Test-NetworkSecurityGroup-SecurityRuleCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $nsgName = Get-ResourceName
    $securityRule1Name = Get-ResourceName
    $securityRule2Name = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/NetworkSecurityGroups"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecurityRule
        $securityRule = New-AzureRmNetworkSecurityRuleConfig -Name $securityRule1Name -Description "desciption" -Protocol Tcp -SourcePortRange "23-45" -DestinationPortRange "46-56" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Allow -Priority 123 -Direction Inbound

        # Create NetworkSecurityGroup
        $nsg = New-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgname -Location $location -SecurityRule $securityRule

        # Get NetworkSecurityGroup
        $getNsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        
        #verification
        Assert-AreEqual $rgName $getNsg.ResourceGroupName
        Assert-AreEqual $nsgName $getNsg.Name
        Assert-NotNull $getNsg.Location
        Assert-NotNull $getNsg.Etag
        Assert-AreEqual 1 @($getNsg.SecurityRules).Count
        Assert-AreEqual 6 @($getNsg.DefaultSecurityRules).Count
        Assert-AreEqual "AllowVnetInBound" $getNsg.DefaultSecurityRules[0].Name
        Assert-AreEqual "AllowAzureLoadBalancerInBound" $getNsg.DefaultSecurityRules[1].Name
        Assert-AreEqual "DenyAllInBound" $getNsg.DefaultSecurityRules[2].Name
        Assert-AreEqual "AllowVnetOutBound" $getNsg.DefaultSecurityRules[3].Name
        Assert-AreEqual "AllowInternetOutBound" $getNsg.DefaultSecurityRules[4].Name
        Assert-AreEqual "DenyAllOutBound" $getNsg.DefaultSecurityRules[5].Name
        Assert-AreEqual $securityRule1Name $getNsg.SecurityRules[0].Name
        Assert-NotNull $getNsg.SecurityRules[0].Etag
        Assert-AreEqual "desciption" $getNsg.SecurityRules[0].Description
        Assert-AreEqual "Tcp" $getNsg.SecurityRules[0].Protocol
        Assert-AreEqual "23-45" $getNsg.SecurityRules[0].SourcePortRange
        Assert-AreEqual "46-56" $getNsg.SecurityRules[0].DestinationPortRange
        Assert-AreEqual "*" $getNsg.SecurityRules[0].SourceAddressPrefix
        Assert-AreEqual "*" $getNsg.SecurityRules[0].DestinationAddressPrefix
        Assert-AreEqual "Allow" $getNsg.SecurityRules[0].Access
        Assert-AreEqual "123" $getNsg.SecurityRules[0].Priority
        Assert-AreEqual "Inbound" $getNsg.SecurityRules[0].Direction

        # list
        $list = Get-AzureRmNetworkSecurityGroup -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getNsg.ResourceGroupName
        Assert-AreEqual $list[0].Name $getNsg.Name
        Assert-AreEqual $list[0].Location $getNsg.Location
        Assert-AreEqual $list[0].Etag $getNsg.Etag
        Assert-AreEqual @($list[0].SecurityRules).Count @($getNsg.SecurityRules).Count
        Assert-AreEqual @($list[0].DefaultSecurityRules).Count @($getNsg.DefaultSecurityRules).Count
        Assert-AreEqual $list[0].DefaultSecurityRules[0].Name $getNsg.DefaultSecurityRules[0].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[1].Name $getNsg.DefaultSecurityRules[1].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[2].Name $getNsg.DefaultSecurityRules[2].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[3].Name $getNsg.DefaultSecurityRules[3].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[4].Name $getNsg.DefaultSecurityRules[4].Name
        Assert-AreEqual $list[0].DefaultSecurityRules[5].Name $getNsg.DefaultSecurityRules[5].Name
        Assert-AreEqual $list[0].SecurityRules[0].Name $getNsg.SecurityRules[0].Name
        Assert-AreEqual $list[0].SecurityRules[0].Etag $getNsg.SecurityRules[0].Etag

        # Add a network security rule
        $nsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName | Add-AzureRmNetworkSecurityRuleConfig  -Name $securityRule2Name -Description "desciption2" -Protocol Tcp -SourcePortRange "26-43" -DestinationPortRange "45-53" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Deny -Priority 122 -Direction Outbound | Set-AzureRmNetworkSecurityGroup
		Assert-AreEqual 2 @($nsg.SecurityRules).Count
		Assert-NotNull $nsg.SecurityRules[1].Etag
		Assert-AreEqual $securityRule1Name $nsg.SecurityRules[0].Name
		Assert-AreEqual $securityRule2Name $nsg.SecurityRules[1].Name
		
		# Get security rule
		$securityRule2 = $nsg | Get-AzureRmNetworkSecurityRuleConfig -name $securityRule2Name 
		Assert-AreEqual $securityRule2.Name $nsg.SecurityRules[1].Name
		Assert-AreEqual "Deny" $securityRule2.Access

	    # List security rule
		$securityRules = $nsg | Get-AzureRmNetworkSecurityRuleConfig
		Assert-AreEqual 2 @($securityRules).Count
		Assert-AreEqual $securityRules[0].Name $nsg.SecurityRules[0].Name
		Assert-AreEqual $securityRules[1].Name $nsg.SecurityRules[1].Name
		
		# Set security rule
		$nsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName | Set-AzureRmNetworkSecurityRuleConfig  -Name $securityRule2Name -Description "desciption2" -Protocol Tcp -SourcePortRange "26-43" -DestinationPortRange "45-53" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Allow -Priority 122 -Direction Outbound | Set-AzureRmNetworkSecurityGroup
		$securityRule2 = $nsg | Get-AzureRmNetworkSecurityRuleConfig -name $securityRule2Name
		Assert-AreEqual "Allow" $securityRule2.Access

		# Remove security rule
		$nsg = Get-AzureRmNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName | Remove-AzureRmNetworkSecurityRuleConfig  -Name $securityRule2Name | Set-AzureRmNetworkSecurityGroup
		$securityRules = $nsg | Get-AzureRmNetworkSecurityRuleConfig
		Assert-AreEqual 1 @($securityRules).Count
		Assert-AreEqual $securityRule1Name $securityRules[0].Name

        # Delete NetworkSecurityGroup
        $delete = Remove-AzureRmNetworkSecurityGroup -ResourceGroupName $rgname -name $nsgName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkSecurityGroup -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}