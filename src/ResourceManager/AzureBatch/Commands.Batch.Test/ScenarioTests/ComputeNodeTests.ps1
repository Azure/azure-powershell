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
Tests querying for a Batch compute node by id
#>
function Test-GetComputeNodeById
{
	param([string]$accountName, [string]$poolId)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$computeNodeId = (Get-AzureBatchComputeNode_ST -PoolId $poolId -BatchContext $context)[0].Id

	$computeNode = Get-AzureBatchComputeNode_ST -PoolId $poolId -Id $computeNodeId -BatchContext $context

	Assert-AreEqual $computeNodeId $computeNode.Id

	# Verify positional parameters also work
	$computeNode = Get-AzureBatchComputeNode_ST $poolId $computeNodeId -BatchContext $context

	Assert-AreEqual $computeNodeId $computeNode.Id
}

<#
.SYNOPSIS
Tests querying for Batch compute nodes using a filter
#>
function Test-ListComputeNodesByFilter
{
	param([string]$accountName, [string]$poolId, [string]$state, [string]$matches)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$filter = "state eq '" + "$state" + "'"

	$computeNodes = Get-AzureBatchComputeNode_ST -PoolId $poolId -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $computeNodes.Length
	foreach($node in $computeNodes)
	{
		Assert-AreEqual $state $node.State.ToString().ToLower()
	}

	# Verify parent object parameter set also works
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	$computeNodes = Get-AzureBatchComputeNode_ST -Pool $pool -Filter $filter -BatchContext $context

	Assert-AreEqual $matches $computeNodes.Length
	foreach($node in $computeNodes)
	{
		Assert-AreEqual $state $node.State.ToString().ToLower()
	}
}

<#
.SYNOPSIS
Tests querying for Batch compute nodes and supplying a max count
#>
function Test-ListComputeNodesWithMaxCount
{
	param([string]$accountName, [string]$poolId, [string]$maxCount)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$computeNodes = Get-AzureBatchComputeNode_ST -PoolId $poolId -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $computeNodes.Length

	# Verify parent object parameter set also works
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	$computeNodes = Get-AzureBatchComputeNode_ST -Pool $pool -MaxCount $maxCount -BatchContext $context

	Assert-AreEqual $maxCount $computeNodes.Length
}

<#
.SYNOPSIS
Tests querying for all compute nodes under a pool
#>
function Test-ListAllComputeNodes
{
	param([string]$accountName, [string]$poolId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$computeNodes = Get-AzureBatchComputeNode_ST -PoolId $poolId -BatchContext $context

	Assert-AreEqual $count $computeNodes.Length

	# Verify parent object parameter set also works
	$pool = Get-AzureBatchPool_ST $poolId -BatchContext $context
	$computeNodes = Get-AzureBatchComputeNode_ST -Pool $pool -BatchContext $context

	Assert-AreEqual $count $computeNodes.Length
}

<#
.SYNOPSIS
Tests piping Get-AzureBatchPool into Get-AzureBatchComputeNode
#>
function Test-ListComputeNodePipeline
{
	param([string]$accountName, [string]$poolId, [string]$count)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$computeNodes = Get-AzureBatchPool_ST -Id $poolId -BatchContext $context | Get-AzureBatchComputeNode_ST -BatchContext $context

	Assert-AreEqual $count $computeNodes.Count
}

<#
.SYNOPSIS
Tests rebooting a compute node
#>
function Test-RebootComputeNode
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	$rebootOption = ([Microsoft.Azure.Batch.Common.ComputeNodeRebootOption]::Terminate)

	if ($usePipeline -eq '1')
	{
	    Get-AzureBatchComputeNode_ST $poolId $computeNodeId -BatchContext $context | Restart-AzureBatchComputeNode_ST -RebootOption $rebootOption -BatchContext $context
	}
	else
	{
	    Restart-AzureBatchComputeNode_ST $poolId $computeNodeId -RebootOption $rebootOption -BatchContext $context
	}

	$computeNode = Get-AzureBatchComputeNode_ST -PoolId $poolId -Filter "id eq '$computeNodeId'" -BatchContext $context

	Assert-AreEqual 'Rebooting' $computeNode.State
}

<#
.SYNOPSIS
Tests reimaging a compute node
#>
function Test-ReimageComputeNode
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	$reimageOption = ([Microsoft.Azure.Batch.Common.ComputeNodeReimageOption]::Terminate)

	if ($usePipeline -eq '1')
	{
	    Get-AzureBatchComputeNode_ST $poolId $computeNodeId -BatchContext $context | Reset-AzureBatchComputeNode_ST -ReimageOption $reimageOption -BatchContext $context
	}
	else
	{
	    Reset-AzureBatchComputeNode_ST $poolId $computeNodeId -ReimageOption $reimageOption -BatchContext $context
	}

	$computeNode = Get-AzureBatchComputeNode_ST -PoolId $poolId -Filter "id eq '$computeNodeId'" -BatchContext $context

	Assert-AreEqual 'Reimaging' $computeNode.State
}