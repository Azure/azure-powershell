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

function Test-ServerTrustGroup()
{
	$stgName = "stg-ps-test"
	$location = "westeurope"
	
	# Setup
	$rg = Create-ResourceGroupForTest $location
	$vnetName = "cl_initial"
	$subnetName = "Cool" 

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $location $rg.ResourceGroupName
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	# Setup Managed Instances
	$managedInstance1 = Create-ManagedInstanceForTest $rg $subnetId
	$managedInstance2 = Create-ManagedInstanceForTest $rg $subnetId
	$managedInstance3 = Create-ManagedInstanceForTest $rg $subnetId

	try
	{
		# Verify Server Trust Group does not exist.
		$serverTrustGroup = $null
		try
		{
			$serverTrustGroup = Get-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName
		}
		catch { }
		Assert-Null $serverTrustGroup "Server Trust Group with name $stgName exists."

		# Create new Server Trust Group
		$serverTrustGroup = Set-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName -GroupMember $managedInstance1,$managedInstance2,$managedInstance3 -TrustScope GlobalTransactions
		Assert-NotNull $serverTrustGroup "Server Trust Group is not created."

		# Get specified Server Trust Group
		$serverTrustGroup = Get-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName
		Assert-NotNull $serverTrustGroup "Server Trust Group $stgName does not exist."
		Assert-AreEqual $serverTrustGroup.Name $stgName "Got unexpected name."
		Assert-AreEqual $serverTrustGroup.TrustScope.Count 1 "Got unexpected trust scope."
		Assert-AreEqual $serverTrustGroup.GroupMember.Count 3 "Got unexpected number of group members."

		# Get Server Trust Group in specified locaiton
		$serverTrustGroups = Get-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location
		Assert-NotNull $serverTrustGroups
		Assert-AreEqual $serverTrustGroups.Count 1 "Unexpected number of Server Trust Groups in location $location. ($($serverTrustGroups.Count))."

		# Get Server Trust Group for specified instance
		$serverTrustGroups = Get-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance1.ManagedInstanceName
		Assert-NotNull $serverTrustGroups
		Assert-AreEqual $serverTrustGroups.Count 1 "Unexpected number of Server Trust Groups for instance. ($($serverTrustGroup.Count))."

		# Update Server Trust Group
		$serverTrustGroup = Set-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName -GroupMember $managedInstance1,$managedInstance2 -TrustScope GlobalTransactions
		Assert-NotNull $serverTrustGroup "Server Trust Group is not created."

		# Remove Server Trust Group
		Remove-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName
		Assert-NotNull $serverTrustGroups
		Assert-AreEqual $serverTrustGroups.Count 1 "Unexpected number of Server Trust Groups, it should have been removed. ($($serverTrustGroups.Count))"

		# Verify Server Trust Group is removed.
		$serverTrustGroup = $null
		try
		{
			$serverTrustGroup = Get-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName
		}
		catch { }
		Assert-Null $serverTrustGroup "Server Trust Group with name $stgName exists."

		# Create new Server Trust Group with Group Member Resource Id
		$serverTrustGroup = New-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName -GroupMemberResourceId $managedInstance1.Id,$managedInstance2.Id -TrustScope GlobalTransactions
		Assert-NotNull $serverTrustGroup "Server Trust Group is not created."

		Remove-AzSqlServerTrustGroup -ResourceGroupName $rg.ResourceGroupName -Location $location -Name $stgName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}