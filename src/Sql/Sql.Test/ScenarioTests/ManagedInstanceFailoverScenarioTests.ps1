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

# Location to use for provisioning test managed instances
$instanceLocation = "westcentralus"

<#
.SYNOPSIS
Tests Managed Instance failover.
#>
function Test-FailoverManagedInstance
{
	try
	{
		# Setup
		$rg = Create-ResourceGroupForTest
		$vnetName = "cl_initial"
		$subnetName = "CooL"

		# Setup VNET
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
		$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

		# Initiate sync create of managed instance.
		$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

		$job = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -AsJob
		$job | Wait-Job

		try
		{
			Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -AsJob
		}
		catch
		{
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("There was a recent failover")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

