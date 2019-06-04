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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create NetworkSecurityGroup
        $job = New-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgname -Location $location -AsJob
		$job | Wait-Job
		$nsg = $job | Receive-Job

        # Get NetworkSecurityGroup
        $getNsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        
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
        $list = Get-AzNetworkSecurityGroup -ResourceGroupName $rgname
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

        $list = Get-AzNetworkSecurityGroup -ResourceGroupName "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzNetworkSecurityGroup -Name "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzNetworkSecurityGroup -ResourceGroupName "*" -Name "*"
        Assert-True { $list.Count -ge 0 }

        # Add NSG to a subnet
        $vnet = $vnet | Set-AzVirtualNetworkSubnetConfig -name $subnetName -AddressPrefix "10.0.1.0/24" -NetworkSecurityGroup $nsg | Set-AzVirtualNetwork
        $getNsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        Assert-AreEqual $vnet.Subnets[0].NetworkSecurityGroup.Id $getNsg.Id
        Assert-AreEqual 1 @($getNsg.Subnets[0]).Count
        Assert-AreEqual $vnet.Subnets[0].Id $getNsg.Subnets[0].Id

        # Create NetworkInterface with NSG
        $nic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -NetworkSecurityGroup $nsg
        Assert-AreEqual $nic.NetworkSecurityGroup.Id $nsg.Id
        $getNsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        Assert-AreEqual 1 @($getNsg.NetworkInterfaces[0]).Count
        Assert-AreEqual $nic.Id $getNsg.NetworkInterfaces[0].Id

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete NetworkSecurityGroup
        $job = Remove-AzNetworkSecurityGroup -ResourceGroupName $rgname -name $nsgName -PassThru -Force -AsJob
		$job | Wait-Job
		$delete = $job | Receive-Job
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkSecurityGroup -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

        $list = Get-AzNetworkSecurityGroup | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $nsgName }
        Assert-AreEqual 0 @($list).Count

        # Test error handling
        Assert-ThrowsContains { Set-AzNetworkSecurityGroup -NetworkSecurityGroup $nsg } "not found"
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecurityRule
        $securityRule = New-AzNetworkSecurityRuleConfig -Name $securityRule1Name -Description "desciption" -Protocol Tcp -SourcePortRange "23-45" -DestinationPortRange "46-56" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Allow -Priority 123 -Direction Inbound

        # Create NetworkSecurityGroup
        $nsg = New-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgname -Location $location -SecurityRule $securityRule

        # Get NetworkSecurityGroup
        $getNsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        
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
        $list = Get-AzNetworkSecurityGroup -ResourceGroupName $rgname
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
        $job = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName | Add-AzNetworkSecurityRuleConfig  -Name $securityRule2Name -Description "desciption2" -Protocol Tcp -SourcePortRange "26-43" -DestinationPortRange "45-53" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Deny -Priority 122 -Direction Outbound | Set-AzNetworkSecurityGroup -AsJob
		$job | Wait-Job
		$nsg = $job | Receive-Job
		Assert-AreEqual 2 @($nsg.SecurityRules).Count
		Assert-NotNull $nsg.SecurityRules[1].Etag
		Assert-AreEqual $securityRule1Name $nsg.SecurityRules[0].Name
		Assert-AreEqual $securityRule2Name $nsg.SecurityRules[1].Name

        # Test error handling
        Assert-ThrowsContains { Add-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $securityRule2Name } "Rule with the specified name already exists"

		# Get security rule
		$securityRule2 = $nsg | Get-AzNetworkSecurityRuleConfig -name $securityRule2Name 
		Assert-AreEqual $securityRule2.Name $nsg.SecurityRules[1].Name
		Assert-AreEqual "Deny" $securityRule2.Access

	    # List security rule
		$securityRules = $nsg | Get-AzNetworkSecurityRuleConfig
		Assert-AreEqual 2 @($securityRules).Count
		Assert-AreEqual $securityRules[0].Name $nsg.SecurityRules[0].Name
		Assert-AreEqual $securityRules[1].Name $nsg.SecurityRules[1].Name
		
		# Set security rule
		$nsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName | Set-AzNetworkSecurityRuleConfig  -Name $securityRule2Name -Description "desciption2" -Protocol Tcp -SourcePortRange "26-43" -DestinationPortRange "45-53" -SourceAddressPrefix * -DestinationAddressPrefix * -Access Allow -Priority 122 -Direction Outbound | Set-AzNetworkSecurityGroup
		$securityRule2 = $nsg | Get-AzNetworkSecurityRuleConfig -name $securityRule2Name
		Assert-AreEqual "Allow" $securityRule2.Access

		# Remove security rule
		$nsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName | Remove-AzNetworkSecurityRuleConfig  -Name $securityRule2Name | Set-AzNetworkSecurityGroup
		$securityRules = $nsg | Get-AzNetworkSecurityRuleConfig
		Assert-AreEqual 1 @($securityRules).Count
		Assert-AreEqual $securityRule1Name $securityRules[0].Name

        # Delete NetworkSecurityGroup
        $delete = Remove-AzNetworkSecurityGroup -ResourceGroupName $rgname -name $nsgName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkSecurityGroup -ResourceGroupName $rgname
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
Tests NetworkSecurityRule for multi valued rules.
#>
function Test-NetworkSecurityGroup-MultiValuedRules
{
    # Setup
    $rgname = Get-ResourceGroupName
    $nsgName = Get-ResourceName
    $securityRule1Name = Get-ResourceName
    $securityRule2Name = Get-ResourceName
    $securityRule3Name = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/NetworkSecurityGroups"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecurityRule
        $securityRule1 = New-AzNetworkSecurityRuleConfig -Name $securityRule1Name -Description "desciption" -Protocol Tcp -SourcePortRange 23-45,80-90 -DestinationPortRange 46-56,70-80 -SourceAddressPrefix 10.10.20.0/24,192.168.0.0/24 -DestinationAddressPrefix 10.10.30.0/24,192.168.2.0/24 -Access Allow -Priority 123 -Direction Inbound
		$securityRule2 = New-AzNetworkSecurityRuleConfig -Name $securityRule2Name -Description "desciption" -Protocol Tcp -SourcePortRange 10-20,30-40 -DestinationPortRange 10-20,30-40 -SourceAddressPrefix Storage -DestinationAddressPrefix Storage -Access Allow -Priority 120 -Direction Inbound

        # Create NetworkSecurityGroup
        $nsg = New-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgname -Location $location -SecurityRules $securityRule1,$securityRule2

        # Get NetworkSecurityGroup
        $getNsg = Get-AzNetworkSecurityGroup -name $nsgName -ResourceGroupName $rgName
        
        #verification
        Assert-AreEqual $rgName $getNsg.ResourceGroupName
        Assert-AreEqual $nsgName $getNsg.Name
        Assert-NotNull $getNsg.Location
        Assert-NotNull $getNsg.Etag
        Assert-AreEqual 2 @($getNsg.SecurityRules).Count
        Assert-AreEqual 6 @($getNsg.DefaultSecurityRules).Count
        Assert-AreEqual "AllowVnetInBound" $getNsg.DefaultSecurityRules[0].Name
        Assert-AreEqual "AllowAzureLoadBalancerInBound" $getNsg.DefaultSecurityRules[1].Name
        Assert-AreEqual "DenyAllInBound" $getNsg.DefaultSecurityRules[2].Name
        Assert-AreEqual "AllowVnetOutBound" $getNsg.DefaultSecurityRules[3].Name
        Assert-AreEqual "AllowInternetOutBound" $getNsg.DefaultSecurityRules[4].Name
        Assert-AreEqual "DenyAllOutBound" $getNsg.DefaultSecurityRules[5].Name

		# verify rule 1.
        Assert-AreEqual $securityRule1Name $getNsg.SecurityRules[0].Name
        Assert-NotNull $getNsg.SecurityRules[0].Etag
        Assert-AreEqual "desciption" $getNsg.SecurityRules[0].Description
        Assert-AreEqual "Tcp" $getNsg.SecurityRules[0].Protocol
        Assert-AreEqual 2 @($getNsg.SecurityRules[0].SourcePortRange).Count
        Assert-AreEqual "23-45" $getNsg.SecurityRules[0].SourcePortRange[0]
        Assert-AreEqual "80-90" $getNsg.SecurityRules[0].SourcePortRange[1]
        Assert-AreEqual 2 @($getNsg.SecurityRules[0].DestinationPortRange).Count
        Assert-AreEqual "46-56" $getNsg.SecurityRules[0].DestinationPortRange[0]
        Assert-AreEqual "70-80" $getNsg.SecurityRules[0].DestinationPortRange[1]
        Assert-AreEqual 2 @($getNsg.SecurityRules[0].SourceAddressPrefix).Count
        Assert-AreEqual "10.10.20.0/24" $getNsg.SecurityRules[0].SourceAddressPrefix[0]
        Assert-AreEqual "192.168.0.0/24" $getNsg.SecurityRules[0].SourceAddressPrefix[1]
        Assert-AreEqual 2 @($getNsg.SecurityRules[0].DestinationAddressPrefix).Count
        Assert-AreEqual "10.10.30.0/24" $getNsg.SecurityRules[0].DestinationAddressPrefix[0]
        Assert-AreEqual "192.168.2.0/24" $getNsg.SecurityRules[0].DestinationAddressPrefix[1]
        Assert-AreEqual "Allow" $getNsg.SecurityRules[0].Access
        Assert-AreEqual "123" $getNsg.SecurityRules[0].Priority
        Assert-AreEqual "Inbound" $getNsg.SecurityRules[0].Direction

		# verify rule 2
		Assert-AreEqual "desciption" $getNsg.SecurityRules[1].Description
        Assert-AreEqual "Tcp" $getNsg.SecurityRules[1].Protocol
        Assert-AreEqual 2 @($getNsg.SecurityRules[1].SourcePortRange).Count
        Assert-AreEqual "10-20" $getNsg.SecurityRules[1].SourcePortRange[0]
        Assert-AreEqual "30-40" $getNsg.SecurityRules[1].SourcePortRange[1]
        Assert-AreEqual 2 @($getNsg.SecurityRules[1].DestinationPortRange).Count
        Assert-AreEqual "10-20" $getNsg.SecurityRules[1].DestinationPortRange[0]
        Assert-AreEqual "30-40" $getNsg.SecurityRules[1].DestinationPortRange[1]
        Assert-AreEqual 1 @($getNsg.SecurityRules[1].SourceAddressPrefix).Count
        Assert-AreEqual "Storage" $getNsg.SecurityRules[1].SourceAddressPrefix[0]
        Assert-AreEqual 1 @($getNsg.SecurityRules[1].DestinationAddressPrefix).Count
        Assert-AreEqual "Storage" $getNsg.SecurityRules[1].DestinationAddressPrefix[0]
        Assert-AreEqual "Allow" $getNsg.SecurityRules[1].Access
        Assert-AreEqual "120" $getNsg.SecurityRules[1].Priority
        Assert-AreEqual "Inbound" $getNsg.SecurityRules[1].Direction

        # list
        $list = Get-AzNetworkSecurityGroup -ResourceGroupName $rgname
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

        # Delete NetworkSecurityGroup
        $delete = Remove-AzNetworkSecurityGroup -ResourceGroupName $rgname -name $nsgName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkSecurityGroup -ResourceGroupName $rgname
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
Test NetworkSecurityRule argument validation
#>
function Test-NetworkSecurityRule-ArgumentValidation
{
    # Setup
    $rgname = Get-ResourceGroupName
    $asgName = Get-ResourceName
    $nsgName = Get-ResourceName
    $ruleName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/networkSecurityGroups"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ApplicationSecurityGroup
        $asg = New-AzApplicationSecurityGroup -ResourceGroupName $rgname -Name $asgName -Location $location

        # Create NetworkSecurityGroup
        $job = New-AzNetworkSecurityGroup -Name $nsgName -ResourceGroupName $rgname -Location $location -AsJob
        $job | Wait-Job
        $nsg = $job | Receive-Job

        # Test error handling for New
        Assert-ThrowsContains { New-AzNetworkSecurityRuleConfig -Name $ruleName -SourceAddressPrefix * -SourceApplicationSecurityGroup $asg } "cannot be used simultaneously";
        Assert-ThrowsContains { New-AzNetworkSecurityRuleConfig -Name $ruleName -SourceAddressPrefix * -SourceApplicationSecurityGroupId $asg.Id } "cannot be used simultaneously";
        Assert-ThrowsContains { New-AzNetworkSecurityRuleConfig -Name $ruleName -DestinationAddressPrefix * -DestinationApplicationSecurityGroup $asg } "cannot be used simultaneously";
        Assert-ThrowsContains { New-AzNetworkSecurityRuleConfig -Name $ruleName -DestinationAddressPrefix * -DestinationApplicationSecurityGroupId $asg.Id } "cannot be used simultaneously";

        # Test error handling for Add
        Assert-ThrowsContains { Add-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -SourceAddressPrefix * -SourceApplicationSecurityGroup $asg } "cannot be used simultaneously";
        Assert-ThrowsContains { Add-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -SourceAddressPrefix * -SourceApplicationSecurityGroupId $asg.Id } "cannot be used simultaneously";
        Assert-ThrowsContains { Add-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -DestinationAddressPrefix * -DestinationApplicationSecurityGroup $asg } "cannot be used simultaneously";
        Assert-ThrowsContains { Add-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -DestinationAddressPrefix * -DestinationApplicationSecurityGroupId $asg.Id } "cannot be used simultaneously";

        # Test error handling for Set
        Assert-ThrowsContains { Set-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -SourceAddressPrefix * -SourceApplicationSecurityGroup $asg } "cannot be used simultaneously";
        Assert-ThrowsContains { Set-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -SourceAddressPrefix * -SourceApplicationSecurityGroupId $asg.Id } "cannot be used simultaneously";
        Assert-ThrowsContains { Set-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -DestinationAddressPrefix * -DestinationApplicationSecurityGroup $asg } "cannot be used simultaneously";
        Assert-ThrowsContains { Set-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName -DestinationAddressPrefix * -DestinationApplicationSecurityGroupId $asg.Id } "cannot be used simultaneously";
        Assert-ThrowsContains { Set-AzNetworkSecurityRuleConfig -NetworkSecurityGroup $nsg -Name $ruleName } "Rule with the specified name does not exist";

        # Delete NetworkSecurityGroup
        $job = Remove-AzNetworkSecurityGroup -ResourceGroupName $rgname -name $nsgName -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
