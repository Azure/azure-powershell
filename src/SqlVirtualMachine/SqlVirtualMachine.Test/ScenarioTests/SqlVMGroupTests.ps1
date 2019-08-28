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
	Creates sql virtual machine group
#>
function Test-CreateSqlVirtualMachineGroup
{
    $location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location

	$groupName = Get-SqlVirtualMachineGroupName
	
	try 
	{
		$group = Create-SqlVMGroup $rg.ResourceGroupName $groupName $location
	
		Assert-NotNull $group
		Assert-AreEqual $group.Name $groupName
		Assert-AreEqual $group.ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $group.Location $location
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Gets\lists sql virtual machine group
#>
function Test-GetSqlVirtualMachineGroup
{
	$location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location

	$groupName = Get-SqlVirtualMachineGroupName
	
	try 
	{
		$group = Create-SqlVMGroup $rg.ResourceGroupName $groupName $location
	
		# Get using parameters
		$group1 = Get-AzSqlVMGroup -ResourceGroupName $group.ResourceGroupName -Name $group.Name
		Validate-SqlVirtualMachineGroup $group $group1
		
		# Get using resource id
		$group1 = Get-AzSqlVMGroup -ResourceId $group.ResourceId
		Validate-SqlVirtualMachineGroup $group $group1

		# List by resource group
		$groupList = Get-AzSqlVMGroup -ResourceGroupName $group.ResourceGroupName
		Assert-True {$group.Name -in $groupList.Name}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Updates sql virtual machine group
#>
function Test-UpdateSqlVirtualMachineGroup
{
	$location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location

	$groupName = Get-SqlVirtualMachineGroupName
	
	try 
	{
		$group = Create-SqlVMGroup $rg.ResourceGroupName $groupName $location
		
		# Update tags
		$key = 'key'
		$value = 'value'
		$tags = @{$key=$value}
		$group1 = Update-AzSqlVMGroup -InputObject $group -Tags $tags
		
		Validate-SqlVirtualMachineGroup $group $group1
		Assert-NotNull $group1.Tags
		Assert-AreEqual $group1.Tags.count 1
		Assert-AreEqual $group1.Tags[$key] $value
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Deletes sql virtual machine group
#>
function Test-RemoveSqlVirtualMachineGroup
{
	$location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location

	$groupName = Get-SqlVirtualMachineGroupName
	
	try 
	{
		# Test parameters
		$group = Create-SqlVMGroup $rg.ResourceGroupName $groupName $location		
		Remove-AzSqlVMGroup -ResourceGroupName $group.ResourceGroupName -Name $group.Name
		
		# Test resource id
		$group = Create-SqlVMGroup $rg.ResourceGroupName $groupName $location		
		Remove-AzSqlVMGroup -ResourceId $group.ResourceId
		
		# Test input object
		$group = Create-SqlVMGroup $rg.ResourceGroupName $groupName $location		
		Remove-AzSqlVMGroup -InputObject $group
		
		$groupList = Get-AzSqlVMGroup -ResourceGroupName $group.ResourceGroupName
		Assert-False {$group.Name -in $groupList.Name}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

