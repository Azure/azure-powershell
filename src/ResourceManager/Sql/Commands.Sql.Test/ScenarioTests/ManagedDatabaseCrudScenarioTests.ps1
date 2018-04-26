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
	Tests creating a managed database
#>
function Test-CreateManagedDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg

	try
	{
		# Create with default values
		$managedDatabaseName = Get-ManagedDatabaseName
		$job1 = New-AzureRmSqlManagedDatabase -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -ManagedDatabaseName $managedDatabaseName -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Collation
		Assert-NotNull $db.CreationDate

		# Create with default values via piping
		$managedDatabaseName = Get-ManagedDatabaseName
		$db = $managedInstance | New-AzureRmSqlManagedDatabase -ManagedDatabaseName $managedDatabaseName
		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Collation
		Assert-NotNull $db.CreationDate
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a managed database
#>
function Test-GetManagedDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg
	
	# Create with default values
	$managedDatabaseName = Get-ManagedDatabaseName
	$db1 = New-AzureRmSqlManagedDatabase -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -ManagedDatabaseName $managedDatabaseName
	Assert-AreEqual $db1.Name $managedDatabaseName

	try
	{
        $gdb1 = Get-AzureRmSqlManagedDatabase -ResourceGroupName $managedInstance.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -ManagedDatabaseName $db1.Name
        Assert-NotNull $gdb1
        Assert-AreEqual $db1.Name $gdb1.Name
        Assert-AreEqual $db1.Collation $gdb1.Collation
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Deleting a managed database
#>
function Test-RemoveManagedDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$managedInstance = Create-ManagedInstanceForTest $rg
	
	# Create with default values
	$managedDatabaseName = Get-ManagedDatabaseName
	$db1 = New-AzureRmSqlManagedDatabase -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -ManagedDatabaseName $managedDatabaseName
	Assert-AreEqual $db1.Name $managedDatabaseName

	$managedDatabaseName = Get-ManagedDatabaseName
	$db2 = New-AzureRmSqlManagedDatabase -ResourceGroupName $rg.ResourceGroupName -ManagedInstanceName $managedInstance.ManagedInstanceName -ManagedDatabaseName $managedDatabaseName
	Assert-AreEqual $db2.Name $managedDatabaseName

	$all = $managedInstance | Get-AzureRmSqlManagedDatabase
	Assert-AreEqual $all.Count 2

	try
	{
		Remove-AzureRmSqlManagedDatabase -ResourceGroupName $managedInstance.ResourceGroupname -ManagedInstanceName $managedInstance.ManagedInstanceName -ManagedDatabaseName $db.Name -Force
		
		$all = $managedInstance | Get-AzureRmSqlManagedDatabase
		Assert-AreEqual $all.Count 1

		$db2 | Remove-AzureRmSqlManagedDatabase -Force

		$all = $managedInstance | Get-AzureRmSqlManagedDatabase
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}