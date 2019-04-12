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
	Tests Getting a VirtualCluster
	.DESCRIPTION
	SmokeTest
#>
function Test-GetVirtualCluster
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Sql/virtualclusters"
	$rg = Create-ResourceGroupForTest $location

	$rgName = $rg.ResourceGroupName
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $location $rgName
	$subnetId = $virtualNetwork.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

	try
	{
		# Test using all parameters
		$virtualClusterList = Get-AzSqlVirtualCluster
		$virtualCluster = $virtualClusterList.where({$_.SubnetId -eq $subnetId})
		Assert-AreEqual $rgName $virtualCluster.ResourceGroupName
		$virtualClusterName = $virtualCluster.VirtualClusterName

		$virtualClusterList = Get-AzSqlVirtualCluster -ResourceGroupName $rgName
		$virtualCluster = $virtualClusterList.where({$_.SubnetId -eq $subnetId})
		Assert-AreEqual $rgName $virtualCluster.ResourceGroupName
		Assert-AreEqual $virtualClusterName $virtualCluster.VirtualClusterName

		$virtualCluster = Get-AzSqlVirtualCluster -ResourceGroupName $rgName -Name $virtualClusterName
		Assert-AreEqual $rgName $virtualCluster.ResourceGroupName
		Assert-AreEqual $virtualClusterName $virtualCluster.VirtualClusterName
		Assert-AreEqual $subnetId $virtualCluster.SubnetId
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Removing a VirtualCluster
	.DESCRIPTION
	SmokeTest
#>
function Test-RemoveVirtualCluster
{
	# Setup
	$location = Get-ProviderLocation "Microsoft.Sql/virtualclusters"
	$rg = Create-ResourceGroupForTest $location

	$rgName = $rg.ResourceGroupName
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $location $rgName
	$subnetId = $virtualNetwork.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

	try
	{
		$virtualClusterList = Get-AzSqlVirtualCluster -ResourceGroupName $rgName
		$virtualCluster = $virtualClusterList.where({$_.SubnetId -eq $subnetId})
		$virtualClusterName = $virtualCluster.VirtualClusterName

		# Remove the managed instance first
		$managedInstance | Remove-AzSqlInstance -Force

		# Remove virtual cluster
		$virtualCluster | Remove-AzSqlVirtualCluster

		$all = Get-AzSqlVirtualCluster -ResourceGroupName $rgName
		$virtualCluster = $all.where({$_.VirtualClusterName -eq $virtualClusterName})
		Assert-AreEqual $virtualCluster.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
