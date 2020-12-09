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
		$rg = Create-ResourceGroupForTest "westeurope"
		$vnetName = "vnet-pcresizeandcreate"
		$subnetName = "ManagedInstance"

		# Setup VNET
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location "toki"
		$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

		# Initiate sync create of managed instance.
		$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

		$job = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -AsJob
		$job | Wait-Job

		try
		{
			Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -AsJob
		}
		catch
		{
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("There was a recent failover on the managed instance")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Tests Managed Instance failover with passthru.
#>
function Test-FailoverManagedInstancePassThru
{
	try
	{
		# Setup
		$rg = Create-ResourceGroupForTest "westeurope"
		$vnetName = "vnet-pcresizeandcreate"
		$subnetName = "ManagedInstance"

		# Setup VNET
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location "toki"
		$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

		# Initiate sync create of managed instance.
		$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

		$output = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -PassThru
		Assert-True { $output }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Tests Managed Instance failover using piping.
#>
function Test-FailoverManagedInstancePiping
{
	try
	{
		# Setup
		$rg = Create-ResourceGroupForTest "westeurope"
		$vnetName = "vnet-pcresizeandcreate"
		$subnetName = "ManagedInstance"

		# Setup VNET
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location "toki"
		$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

		# Initiate sync create of managed instance.
		$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

		Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName | Invoke-AzSqlInstanceFailover
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
.SYNOPSIS
Tests Managed Instance failover secondary readable replica.

Managed instance has 3 replicas and intiating failover does not specify which one to failover, so we run test
with -PassThru and assert on the output.
#>
function Test-FailoverManagedInstanceReadableSecondary
{
	try
	{
		# Setup
		$rg = Create-ResourceGroupForTest "westeurope"
		$vnetName = "vnet-pcresizeandcreate"
		$subnetName = "ManagedInstance"

		# Setup VNET
		$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location "toki"
		$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

		# Initiate sync create of managed instance.
		$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

		# Change instance edition to BusinessCritical to get secondary replicas to failover
		$credentials = Get-ServerCredential
		$edition = "BusinessCritical"

		$managedInstance1 = Set-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName `
			-Edition $edition -Force

		$output = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -ReadableSecondary -PassThru
		Assert-True { $output }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

