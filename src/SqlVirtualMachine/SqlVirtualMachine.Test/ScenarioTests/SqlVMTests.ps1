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
	Create tests for sql virtual machine
#>
function Test-CreateSqlVirtualMachine
{
	# Setup
	$location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location
	$vmName = 'vm'
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"

	try
	{
		Create-VM $rg.ResourceGroupName $vmName $location
		
		# Create Sql VM with parameters
		New-AzSqlVM -ResourceGroupName $rg.ResourceGroupName -Name $vmName -LicenseType "PAYG" -Location $location -Sku Enterprise
		$sqlvm = Get-AzSqlVM -ResourceGroupName $rg.ResourceGroupName -Name $vmName
		
		Assert-NotNull $sqlvm
		$sqlvm | Remove-AzSqlVM

		# Create Sql VM from config
		$config = New-AzSqlVMConfig -LicenseType "PAYG"
		New-AzSqlVM $rg.ResourceGroupName $vmName -SqlVM $config -Location $location
		$sqlvm = Get-AzSqlVM -ResourceGroupName $rg.ResourceGroupName -Name $vmName
		$sqlvm | Remove-AzSqlVM
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}

<#
	.SYNOPSIS
	Get\list tests for sql virtual machine
#>
function Test-GetSqlVirtualMachine
{
	#Setup
	$location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"
	
	try 
	{
		$sqlvm = Create-SqlVM $rg.ResourceGroupName 'vm' $location
	
		# Test using parameters
		$sqlvm1 = Get-AzSqlVM -ResourceGroupName $rg.ResourceGroupName -Name $sqlvm.Name
		Validate-SqlVirtualMachine $sqlvm $sqlvm1
		
		# Test using resource id
		$sqlvm = Get-AzSqlVM -ResourceId $sqlvm.ResourceId
		Validate-SqlVirtualMachine $sqlvm $sqlvm1

		# Test list by resource group
		$sqlvmList = Get-AzSqlVM -ResourceGroupName $sqlvm.ResourceGroupName
		Assert-True {$sqlvm.Name -in $sqlvmList.Name}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}

<#
	.SYNOPSIS
	Update tests for sql virtual machine
#>
function Test-UpdateSqlVirtualMachine
{
	#Setup
	$location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"

	try 
	{
		$sqlvm = Create-SqlVM $rg.ResourceGroupName 'vm' $location
		Assert-NotNull $sqlvm
	
		# Update tags
		$key = 'key'
		$value = 'value'
		$tags = @{$key=$value}
		$sqlvm1 = Update-AzSqlVM -ResourceGroupName $sqlvm.ResourceGroupName -Name $sqlvm.Name -Tag $tags
		$sqlvm1 = Get-AzSqlVM -ResourceGroupName $sqlvm.ResourceGroupName -Name $sqlvm.Name
		Assert-NotNull $sqlvm1
		
		Validate-SqlVirtualMachine $sqlvm $sqlvm1 

		Assert-AreEqual $sqlvm1.Tags.count 1 
		Assert-AreEqual $sqlvm1.Tags[$key] $value
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}

<#
	.SYNOPSIS
	Remove tests for sql virtual machine
#>
function Test-RemoveSqlVirtualMachine
{
	#Setup
	$location = Get-LocationForTest
	$rg = Create-ResourceGroupForTest $location
	$previousErrorActionPreferenceValue = $ErrorActionPreference
	$ErrorActionPreference = "SilentlyContinue"

	try 
	{
		$sqlvm = Create-SqlVM $rg.ResourceGroupName 'vm' $location
		Assert-NotNull $sqlvm
	
		Remove-AzSqlVM -ResourceId $sqlvm.ResourceId

		$sqlvmList = Get-AzSqlVM -ResourceGroupName $rg.ResourceGroupName
		Assert-False {$sqlvm.Name -in $sqlvmList.Name}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
		$ErrorActionPreference = $previousErrorActionPreferenceValue
	}
}
