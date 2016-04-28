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
    param([string]$poolId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $computeNodeId = (Get-AzureBatchComputeNode -PoolId $poolId -BatchContext $context)[0].Id

    $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Id $computeNodeId -BatchContext $context

    Assert-AreEqual $computeNodeId $computeNode.Id

    # Verify positional parameters also work
    $computeNode = Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context

    Assert-AreEqual $computeNodeId $computeNode.Id
}

<#
.SYNOPSIS
Tests querying for Batch compute nodes using a filter
#>
function Test-ListComputeNodesByFilter
{
    param([string]$poolId, [string]$state, [string]$matches)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "state eq '" + "$state" + "'"

    $computeNodes = Get-AzureBatchComputeNode -PoolId $poolId -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $computeNodes.Length
    foreach($node in $computeNodes)
    {
        Assert-AreEqual $state $node.State.ToString().ToLower()
    }

    # Verify parent object parameter set also works
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    $computeNodes = Get-AzureBatchComputeNode -Pool $pool -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $computeNodes.Length
    foreach($node in $computeNodes)
    {
        Assert-AreEqual $state $node.State.ToString().ToLower()
    }
}

<#
.SYNOPSIS
Tests querying for compute nodes using a select clause
#>
function Test-GetAndListComputeNodesWithSelect
{
    param([string]$poolId, [string]$computeNodeId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $filter = "id eq '$computeNodeId'"
    $selectClause = "id,state"

    # Test with Get compute node API
    $computeNode = Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context
    Assert-AreNotEqual $null $computeNode.IPAddress
    Assert-AreEqual $computeNodeId $computeNode.Id

    $computeNode = Get-AzureBatchComputeNode $poolId $computeNodeId -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $computeNode.IPAddress
    Assert-AreEqual $computeNodeId $computeNode.Id

    # Test with List compute nodes API
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    $computeNode = $pool | Get-AzureBatchComputeNode -Filter $filter -BatchContext $context
    Assert-AreNotEqual $null $computeNode.IPAddress
    Assert-AreEqual $computeNodeId $computeNode.Id

    $computeNode = $pool | Get-AzureBatchComputeNode -Filter $filter -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $computeNode.IPAddress
    Assert-AreEqual $computeNodeId $computeNode.Id
}

<#
.SYNOPSIS
Tests querying for Batch compute nodes and supplying a max count
#>
function Test-ListComputeNodesWithMaxCount
{
    param([string]$poolId, [string]$maxCount)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $computeNodes = Get-AzureBatchComputeNode -PoolId $poolId -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $computeNodes.Length

    # Verify parent object parameter set also works
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    $computeNodes = Get-AzureBatchComputeNode -Pool $pool -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $computeNodes.Length
}

<#
.SYNOPSIS
Tests querying for all compute nodes under a pool
#>
function Test-ListAllComputeNodes
{
    param([string]$poolId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $computeNodes = Get-AzureBatchComputeNode -PoolId $poolId -BatchContext $context

    Assert-AreEqual $count $computeNodes.Length

    # Verify parent object parameter set also works
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    $computeNodes = Get-AzureBatchComputeNode -Pool $pool -BatchContext $context

    Assert-AreEqual $count $computeNodes.Length
}

<#
.SYNOPSIS
Tests piping Get-AzureBatchPool into Get-AzureBatchComputeNode
#>
function Test-ListComputeNodePipeline
{
    param([string]$poolId, [string]$count)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $computeNodes = Get-AzureBatchPool -Id $poolId -BatchContext $context | Get-AzureBatchComputeNode -BatchContext $context

    Assert-AreEqual $count $computeNodes.Count
}

<#
.SYNOPSIS
Tests removing a compute node from a pool
#>
function Test-RemoveComputeNode
{
    param([string]$poolId, [string]$computeNodeId, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $deallocationOption = ([Microsoft.Azure.Batch.Common.ComputeNodeRebootOption]::Terminate)
    $resizeTimeout = ([TimeSpan]::FromMinutes(8))

    if ($usePipeline -eq '1')
    {
        Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context | Remove-AzureBatchComputeNode -DeallocationOption $deallocationOption -ResizeTimeout $resizeTimeout -Force -BatchContext $context
    }
    else
    {
        Remove-AzureBatchComputeNode $poolId $computeNodeId -DeallocationOption $deallocationOption -ResizeTimeout $resizeTimeout -Force -BatchContext $context
    }

    # State transition isn't immediate
    $filter = "id eq '$computeNodeId'"
    $select = "id,state"
    $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Filter $filter -Select $select -BatchContext $context
    $start = [DateTime]::Now
    $end = $start.AddSeconds(30)
    while ($computeNode.State -ne 'LeavingPool')
    {
        if ([DateTime]::Now -gt $end)
        {
            throw [System.TimeoutException] "Timed out waiting for compute node to enter LeavingPool state"
        }
        Start-TestSleep 1000
        $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Filter $filter -Select $select -BatchContext $context
    }
}

<#
.SYNOPSIS
Tests removing multiple compute nodes from a pool
#>
function Test-RemoveMultipleComputeNodes
{
    param([string]$poolId, [string]$computeNodeId, [string]$computeNodeId2)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    Remove-AzureBatchComputeNode $poolId @($computeNodeId, $computeNodeId2) -Force -BatchContext $context

    # State transition isn't immediate
    $filter = "(id eq '$computeNodeId') or (id eq '$computeNodeId2')"
    $select = "id,state"
    $computeNodes = Get-AzureBatchComputeNode -PoolId $poolId -Filter $filter -Select $select -BatchContext $context
    $start = [DateTime]::Now
    $end = $start.AddSeconds(30)
    while ($computeNodes[0].State -ne 'LeavingPool' -and $computeNodes[1].State -ne 'LeavingPool')
    {
        if ([DateTime]::Now -gt $end)
        {
            throw [System.TimeoutException] "Timed out waiting for compute nodes to enter LeavingPool state"
        }
        Start-TestSleep 1000
        $computeNodes = Get-AzureBatchComputeNode -PoolId $poolId -Filter $filter -Select $select -BatchContext $context
    }
}

<#
.SYNOPSIS
Tests rebooting a compute node
#>
function Test-RebootComputeNode
{
    param([string]$poolId, [string]$computeNodeId, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $rebootOption = ([Microsoft.Azure.Batch.Common.ComputeNodeRebootOption]::Terminate)

    if ($usePipeline -eq '1')
    {
        Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context | Restart-AzureBatchComputeNode -RebootOption $rebootOption -BatchContext $context
    }
    else
    {
        Restart-AzureBatchComputeNode $poolId $computeNodeId -RebootOption $rebootOption -BatchContext $context
    }

    $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Filter "id eq '$computeNodeId'" -BatchContext $context

    Assert-AreEqual 'Rebooting' $computeNode.State
}

<#
.SYNOPSIS
Tests reimaging a compute node
#>
function Test-ReimageComputeNode
{
    param([string]$poolId, [string]$computeNodeId, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $reimageOption = ([Microsoft.Azure.Batch.Common.ComputeNodeReimageOption]::Terminate)

    if ($usePipeline -eq '1')
    {
        Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context | Reset-AzureBatchComputeNode -ReimageOption $reimageOption -BatchContext $context
    }
    else
    {
        Reset-AzureBatchComputeNode $poolId $computeNodeId -ReimageOption $reimageOption -BatchContext $context
    }

    $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Filter "id eq '$computeNodeId'" -BatchContext $context

    Assert-AreEqual 'Reimaging' $computeNode.State
}

<#
.SYNOPSIS
Tests disabling and enabling compute node scheduling
#>
function Test-DisableAndEnableComputeNodeScheduling
{
    param([string]$poolId, [string]$computeNodeId, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $disableOption = ([Microsoft.Azure.Batch.Common.DisableComputeNodeSchedulingOption]::Terminate)
    if ($usePipeline -eq '1')
    {
        Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context | Disable-AzureBatchComputeNodeScheduling -DisableSchedulingOption $disableOption -BatchContext $context
    }
    else
    {
        Disable-AzureBatchComputeNodeScheduling $poolId $computeNodeId -DisableSchedulingOption $disableOption -BatchContext $context
    }
    $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Filter "id eq '$computeNodeId'" -Select "id,schedulingState" -BatchContext $context
    Assert-AreEqual 'Disabled' $computeNode.SchedulingState

    if ($usePipeline -eq '1')
    {
        Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context | Enable-AzureBatchComputeNodeScheduling -BatchContext $context
    }
    else
    {
        Enable-AzureBatchComputeNodeScheduling $poolId $computeNodeId -BatchContext $context
    }
    $computeNode = Get-AzureBatchComputeNode -PoolId $poolId -Filter "id eq '$computeNodeId'" -Select "id,schedulingState" -BatchContext $context
    Assert-AreEqual 'Enabled' $computeNode.SchedulingState
}

<#
.SYNOPSIS
Tests getting remote login settings from compute node 
#>
function Test-GetRemoteLoginSettings
{
	param([string]$poolId, [string]$computeNodeId, [string]$usePipeline)
	
	$context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
	$remoteLoginSettings = $null

	if ($usePipeline -eq '1')
    {
        $remoteLoginSettings = Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context | Get-AzureBatchRemoteLoginSettings -BatchContext $context
    }
    else
    {
        $remoteLoginSettings = Get-AzureBatchRemoteLoginSettings $poolId $computeNodeId -BatchContext $context
    }

	Assert-AreNotEqual $null $remoteLoginSettings.IPAddress
	Assert-AreNotEqual $null $remoteLoginSettings.Port
}

