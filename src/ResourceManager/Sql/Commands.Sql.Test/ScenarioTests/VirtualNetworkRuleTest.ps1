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
	Tests creating a virtual network rule
#>

function Test-CreateVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $serverVersion $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName
	$virtualNetworkSubnetId = "/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/naduttacvnetrg/providers/Microsoft.Network/virtualNetworks/vnetND2/subnets/subnet1"

	try
	{
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a virtual network rule
#>
function Test-UpdateVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $serverVersion $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName
	$virtualNetworkSubnetId1 = "/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/naduttacvnetrg/providers/Microsoft.Network/virtualNetworks/vnetND2/subnets/subnet1"
	$virtualNetworkSubnetId2 = "/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/naduttacvnetrg/providers/Microsoft.Network/virtualNetworks/vnetND3/subnets/subnet1"

	try
	{
		# Create rule
		$virtualNetworkRule1 = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId1
		Assert-AreEqual $virtualNetworkRule1.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkSubnetId $virtualNetworkSubnetId1
		
		# Update existing rule
		$virtualNetworkRule2 = Set-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId2
		Assert-AreEqual $virtualNetworkRule2.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule2.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule2.VirtualNetworkSubnetId $virtualNetworkSubnetId2
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a virtual network rule
#>
function Test-GetVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $serverVersion $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName
	$virtualNetworkSubnetId = "/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/naduttacvnetrg/providers/Microsoft.Network/virtualNetworks/vnetND2/subnets/subnet1"

	try
	{
		# Create rule
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId
		
		# Get rule
		$resp = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $resp.VirtualNetworkSubnetId $virtualNetworkSubnetId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Removing a server
#>
function Test-RemoveVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $serverVersion $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName
	$virtualNetworkSubnetId = "/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/naduttacvnetrg/providers/Microsoft.Network/virtualNetworks/vnetND2/subnets/subnet1"

	try
	{
		# Create rule
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId
		
		# Remove rule
		$resp = Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -Force
		$all = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $all.Count 0

	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}