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
Tests querying for a Batch Pool by name
#>
function Test-GetPoolByName
{
	param([string]$accountName, [string]$poolName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$pool = Get-AzureBatchPool_ST -Name $poolName -BatchContext $context

	Assert-AreEqual $poolName $pool.Name
}

<#
.SYNOPSIS
Tests querying for Batch Pools using a filter
#>
function Test-ListPoolsByFilter
{
	param([string]$accountName, [string]$poolPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$poolFilter = "startswith(name,'" + "$poolPrefix" + "')"
	$pools = Get-AzureBatchPool_ST -Filter $poolFilter -BatchContext $context

	Assert-AreEqual $matches $pools.Length
	foreach($pool in $pools)
	{
		Assert-True { $pool.Name.StartsWith("$poolPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch Pools and supplying a max count
#>
function Test-ListPoolsWithMaxCount
{
	param([string]$accountName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$pools = Get-AzureBatchPool_ST -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $pools.Length
}

<#
.SYNOPSIS
Tests querying for all Pools under an account
#>
function Test-ListAllPools
{
	param([string]$accountName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$workItems = Get-AzureBatchPool_ST -BatchContext $context

	Assert-AreEqual $count $workItems.Length
}