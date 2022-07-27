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
$instanceLocation = "eastus"

<#
	.SYNOPSIS
	Tests Getting a managedInstance operation
	.DESCRIPTION
	SmokeTest
#>
function Test-GetManagedInstanceOperation
{
	# Setup
	$rg = Create-ResourceGroupForTest
	# Initiate sync create of managed instance.
	$managedInstance = Create-ManagedInstanceForTest $rg

	try
	{
		# Get all operations on managed instance.
		$all = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual 1 $all.Count

		# Get single operation on managed instance.
		$firstOperation = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name ($all | Select-Object -index 0).Name
		Assert-AreEqual $firstOperation.OperationFriendlyName "CREATE MANAGED SERVER"
		Assert-AreEqual $firstOperation.PercentComplete 100
		Assert-StartsWith $firstOperation.State "Succeeded"
		Assert-AreEqual $firstOperation.IsCancellable $false

		# Initiate sync update of storage (this operation can not be canceled nor during its execution or after it has finsihed).
		$updatedManagedInstance = Update-ManagedInstanceStorageForTest $rg $managedInstance

		# Get all operations on managed instance.
		$all = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName
		while($all.Count -ne 2) { $all = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName }

		# Get single operation on managed instance.
		$secondOperation = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name ($all | Select-Object -index 1).Name
		Assert-AreEqual $secondOperation.OperationFriendlyName "UPDATE MANAGED SERVER"
		Assert-AreEqual $secondOperation.PercentComplete 100
		Assert-StartsWith $firstOperation.State "Succeeded"
		Assert-AreEqual $secondOperation.IsCancellable $false
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Removing a managedInstance
	.DESCRIPTION
	SmokeTest
#>
function Test-StopManagedInstanceOperation
{
	# Setup
	$rg = Create-ResourceGroupForTest
	# Initiate sync create of managed instance.
	$managedInstance = Create-ManagedInstanceForTest $rg

	try
	{
		# Get all operations on managed instance.
		$all = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName
		Assert-AreEqual 1 $all.Count

		# Verify that create operation has finished.
		$firstOperation = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name ($all | Select-Object -index 0).Name
		Assert-AreEqual $firstOperation.OperationFriendlyName "CREATE MANAGED SERVER"
		Assert-AreEqual $firstOperation.PercentComplete 100
		Assert-StartsWith $firstOperation.State "Succeeded"
		Assert-AreEqual $firstOperation.IsCancellable $false

		# Verify that cancel is not allowed on finished operations.
		Assert-Throws { Stop-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name $firstOperation.Name -Force }

		# Initiate async update of hardware generation (this operation is cancelable).
		$updatedManagedInstance = Update-ManagedInstanceGenerationForTest $rg $managedInstance

		# Get all operations on managed instance.
		$all = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName

		# Wait for second operation to be cancelable, then initate cancel.
		while($all.Count -ne 2) { $all = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName }
		$secondOperation = $all | Select-Object -index 1
		while($secondOperation.IsCancellable -eq $false) { $secondOperation = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name $secondOperation.Name }
		Stop-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name $secondOperation.Name -Force

		# Wait for second operaiton to be cancelled and verify fields.
		while($secondOperation.State -ne "Cancelled") { $secondOperation = Get-AzSqlInstanceOperation -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -Name $secondOperation.Name }
		Assert-AreEqual $secondOperation.OperationFriendlyName "UPDATE MANAGED SERVER"
		Assert-AreEqual $secondOperation.PercentComplete 100
		Assert-AreEqual $secondOperation.IsCancellable $false
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}