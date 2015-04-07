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
Tests querying for a Batch vm by name
#>
function Test-GetVMByName
{
	param([string]$accountName, [string]$poolName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$vmName = (Get-AzureBatchVM_ST -PoolName $poolName -BatchContext $context)[0].Name

	$vm = Get-AzureBatchVM_ST -PoolName $poolName -Name $vmName -BatchContext $context

	Assert-AreEqual $vmName $vm.Name

	# Verify positional parameters also work
	$vm = Get-AzureBatchVM_ST $poolName $vmName -BatchContext $context

	Assert-AreEqual $vmName $vm.Name
}

<#
.SYNOPSIS
Tests querying for Batch vms using a filter
#>
function Test-ListVMsByFilter
{
	param([string]$accountName, [string]$poolName, [string]$state, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "state eq '" + "$state" + "'"

	$vms = Get-AzureBatchVM_ST -PoolName $poolName -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $vms.Length
	foreach($vm in $vms)
	{
		Assert-AreEqual $state $vm.State.ToString().ToLower()
	}

	# Verify parent object parameter set also works
	$pool = Get-AzureBatchPool_ST $poolName -BatchContext $context
	$vms = Get-AzureBatchVM_ST -Pool $pool -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $vms.Length
	foreach($vm in $vms)
	{
		Assert-AreEqual $state $vm.State.ToString().ToLower()
	}
}

<#
.SYNOPSIS
Tests querying for Batch vms and supplying a max count
#>
function Test-ListVMsWithMaxCount
{
	param([string]$accountName, [string]$poolName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$vms = Get-AzureBatchVM_ST -PoolName $poolName -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $vms.Length

	# Verify parent object parameter set also works
	$pool = Get-AzureBatchPool_ST $poolName -BatchContext $context
	$vms = Get-AzureBatchVM_ST -Pool $pool -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $vms.Length
}

<#
.SYNOPSIS
Tests querying for all vms under a pool
#>
function Test-ListAllVMs
{
	param([string]$accountName, [string]$poolName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$vms = Get-AzureBatchVM_ST -PoolName $poolName -BatchContext $context

	Assert-AreEqual $count $vms.Length

	# Verify parent object parameter set also works
	$pool = Get-AzureBatchPool_ST $poolName -BatchContext $context
	$vms = Get-AzureBatchVM_ST -Pool $pool -BatchContext $context

	Assert-AreEqual $count $vms.Length
}

<#
.SYNOPSIS
Tests piping Get-AzureBatchPool into Get-AzureBatchVM
#>
function Test-ListVMPipeline
{
	param([string]$accountName, [string]$poolName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$vms = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context | Get-AzureBatchVM_ST -BatchContext $context

	Assert-AreEqual $count $vms.Count
}