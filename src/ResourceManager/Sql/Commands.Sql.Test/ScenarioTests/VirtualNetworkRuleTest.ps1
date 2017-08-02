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
	Tests creating and updating a virtual network rule
#>
function Test-CreateAndUpdateVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName

	$vnetName1 = "vnet1"
	$virtualNetworkSubnetId1 = Get-VirtualNetworkSubnetId $vnetName1

	$vnetName2 = "vnet2"
	$virtualNetworkSubnetId2 = Get-VirtualNetworkSubnetId $vnetName2

	try
	{
		# Create rule
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId1
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId1
		
		# Update existing rule
		$virtualNetworkRule = Set-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId2
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId2
	}
	finally
	{
		# Clean the enviroment 
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -Force
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
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$virtualNetworkRuleName1 = Get-VirtualNetworkRuleName
	$vnetName1 = "vnet1"
	$virtualNetworkSubnetId1 = Get-VirtualNetworkSubnetId $vnetName1

	$virtualNetworkRuleName2 = Get-VirtualNetworkRuleName
	$vnetName2 = "vnet2"
	$virtualNetworkSubnetId2 = Get-VirtualNetworkSubnetId $vnetName2

	try
	{
		# Create rule 1
		$virtualNetworkRule1 = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName1 -VirtualNetworkSubnetId $virtualNetworkSubnetId1
		Assert-AreEqual $virtualNetworkRule1.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkRuleName $virtualNetworkRuleName1
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkSubnetId $virtualNetworkSubnetId1

		# Create rule 2
		$virtualNetworkRule2 = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName2 -VirtualNetworkSubnetId $virtualNetworkSubnetId2
		Assert-AreEqual $virtualNetworkRule2.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule2.VirtualNetworkRuleName $virtualNetworkRuleName2
		Assert-AreEqual $virtualNetworkRule2.VirtualNetworkSubnetId $virtualNetworkSubnetId2
		
		# Get rule
		$resp = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName1
		Assert-AreEqual $resp.VirtualNetworkSubnetId $virtualNetworkSubnetId1

		# Get list of rules
		$resp = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $resp.Count 2
	}
	finally
	{
		# Clean the enviroment 
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName1 -Force
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName2 -Force
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
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName
	$vnetName = "vnet1"
	$virtualNetworkSubnetId = Get-VirtualNetworkSubnetId $vnetName

	try
	{
		# Create rule
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId
		
		# Remove rule and check if rule is deleted
		$resp = Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName -Force
		$all = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $all.Count 0

	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}