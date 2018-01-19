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
	Tests for checking virtual network rule core functionalities. This includes - create, update, delete, list and get operations
#>
function Test-CreateAndUpdateVirtualNetworkRule
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName

	$vnetName1 = "vnet1"
	$virtualNetwork1 = CreateAndGetVirtualNetwork $rg $vnetName1 $location
	$virtualNetworkSubnetId1 = $virtualNetwork1.Subnets[0].Id

	$vnetName2 = "vnet2"
	$virtualNetwork2 = CreateAndGetVirtualNetwork $rg $vnetName2 $location
	$virtualNetworkSubnetId2 = $virtualNetwork2.Subnets[0].Id

	try
	{
		# Create rule
		$job = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId1 -IgnoreMissingVnetServiceEndpoint `
			-AsJob
		$job | Wait-Job
		$virtualNetworkRule = $job.Output

		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId1

		# Update existing rule
		$job = Set-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId2 -IgnoreMissingVnetServiceEndpoint `
			-AsJob
		$job | Wait-Job
		$virtualNetworkRule = $job.Output

		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId2
	}
	finally
	{
		# Clean the enviroment
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName
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
	$virtualNetwork1 = CreateAndGetVirtualNetwork $rg $vnetName1 $location
	$virtualNetworkSubnetId1 = $virtualNetwork1.Subnets[0].Id

	$virtualNetworkRuleName2 = Get-VirtualNetworkRuleName
	$vnetName2 = "vnet2"
	$virtualNetwork2 = CreateAndGetVirtualNetwork $rg $vnetName2 $location
	$virtualNetworkSubnetId2 = $virtualNetwork2.Subnets[0].Id

	try
	{
		# Create rule 1
		$virtualNetworkRule1 = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		-VirtualNetworkRuleName $virtualNetworkRuleName1 -VirtualNetworkSubnetId $virtualNetworkSubnetId1 -IgnoreMissingVnetServiceEndpoint
		Assert-AreEqual $virtualNetworkRule1.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkRuleName $virtualNetworkRuleName1
		Assert-AreEqual $virtualNetworkRule1.VirtualNetworkSubnetId $virtualNetworkSubnetId1

		# Create rule 2
		$virtualNetworkRule2 = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		-VirtualNetworkRuleName $virtualNetworkRuleName2 -VirtualNetworkSubnetId $virtualNetworkSubnetId2 -IgnoreMissingVnetServiceEndpoint
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
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName1
		Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -VirtualNetworkRuleName $virtualNetworkRuleName2
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

	$virtualNetworkRuleName = Get-VirtualNetworkRuleName
	$vnetName = "vnet1"
	$virtualNetwork = CreateAndGetVirtualNetwork $rg $vnetName $location
	$virtualNetworkSubnetId = $virtualNetwork.Subnets[0].Id

	$server = Create-ServerForTest $rg $location

	try
	{
		# Create rule
		$virtualNetworkRule = New-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
		-VirtualNetworkRuleName $virtualNetworkRuleName -VirtualNetworkSubnetId $virtualNetworkSubnetId -IgnoreMissingVnetServiceEndpoint
		Assert-AreEqual $virtualNetworkRule.ServerName $server.ServerName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkRuleName $virtualNetworkRuleName
		Assert-AreEqual $virtualNetworkRule.VirtualNetworkSubnetId $virtualNetworkSubnetId

		# Remove rule and check if rule is deleted
		$job = Remove-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-VirtualNetworkRuleName $virtualNetworkRuleName -AsJob
		$job | Wait-Job
		$resp = $job.Output

		$all = Get-AzureRmSqlServerVirtualNetworkRule -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Create a virtual network
#>
function CreateAndGetVirtualNetwork ($resourceGroup, $vnetName, $location = "westcentralus")
{
	$subnetName = "Public"

	$addressPrefix = "10.0.0.0/24"
	$serviceEndpoint = "Microsoft.Sql"

	$subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $addressPrefix -ServiceEndpoint $serviceEndpoint
	$vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

	$getVnet = Get-AzureRmVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroup.ResourceGroupName

	return $getVnet
}
