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
Tests querying for a Batch WorkItem by name
#>
function Test-GetWorkItemByName
{
	param([string]$accountName, [string]$wiName)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$workItem = Get-AzureBatchWorkItem_ST -Name $wiName -BatchContext $context

	Assert-AreEqual $wiName $workItem.Name
}

<#
.SYNOPSIS
Tests querying for Batch WorkItems using a filter
#>
function Test-ListWorkItemsByFilter
{
	param([string]$accountName, [string]$wiPrefix, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$wiFilter = "startswith(name,'" + "$wiPrefix" + "')"
	$workItems = Get-AzureBatchWorkItem_ST -Filter $wiFilter -BatchContext $context

	Assert-AreEqual $matches $workItems.Length
	foreach($workItem in $workItems)
	{
		Assert-True { $workItem.Name.StartsWith("$wiPrefix") }
	}
}

<#
.SYNOPSIS
Tests querying for Batch WorkItems and supplying a max count
#>
function Test-ListWorkItemsWithMaxCount
{
	param([string]$accountName, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$workItems = Get-AzureBatchWorkItem_ST -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $workItems.Length
}

<#
.SYNOPSIS
Tests querying for all WorkItems under an account
#>
function Test-ListAllWorkItems
{
	param([string]$accountName, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$workItems = Get-AzureBatchWorkItem_ST -BatchContext $context

	Assert-AreEqual $count $workItems.Length
}