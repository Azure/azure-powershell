﻿# ----------------------------------------------------------------------------------
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
Tests removing compute nodes from a pool
#>
function Test-RemoveComputeNodes
{
    param([string]$poolId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $deallocationOption = ([Microsoft.Azure.Batch.Common.ComputeNodeRebootOption]::Terminate)
    $resizeTimeout = ([TimeSpan]::FromMinutes(8))

    # Remove nodes
    $computeNodes = Get-AzBatchComputeNode -PoolId $poolId -BatchContext $context
    $computeNodeId = $computeNodes[0].Id
    $computeNodeId2 = $computeNodes[1].Id
    Remove-AzBatchComputeNode -PoolId $poolId @($computeNodeId, $computeNodeId2) -Force -BatchContext $context

    # State transition isn't immediate
    $select = "id,state"
    $computeNodes = Get-AzBatchComputeNode -PoolId $poolId -Select $select -BatchContext $context
    $start = [DateTime]::Now
    $timeout = Compute-TestTimeout 30
    $end = $start.AddSeconds($timeout)
    while ($computeNodes[0].State -ne 'LeavingPool' -and $computeNodes[1].State -ne 'LeavingPool')
    {
        if ([DateTime]::Now -gt $end)
        {
            throw [System.TimeoutException] "Timed out waiting for compute nodes to enter LeavingPool state"
        }
        Start-TestSleep 1000
        $computeNodes = Get-AzBatchComputeNode -PoolId $poolId -Select $select -BatchContext $context
    }
}

<#
.SYNOPSIS
Tests rebooting and reimaging a compute node
#>
function Test-RebootAndReimageComputeNode
{
    param([string]$poolId, [string]$computeNodeId, [string]$computeNodeId2)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $rebootOption = ([Microsoft.Azure.Batch.Common.ComputeNodeRebootOption]::Terminate)
    $reimageOption = ([Microsoft.Azure.Batch.Common.ComputeNodeReimageOption]::Terminate)

    # Reboot a node
    Get-AzBatchComputeNode $poolId $computeNodeId -BatchContext $context | Restart-AzBatchComputeNode -RebootOption $rebootOption -BatchContext $context
    $computeNode = Get-AzBatchComputeNode -PoolId $poolId $computeNodeId -BatchContext $context
    Assert-AreEqual 'Rebooting' $computeNode.State

    # Reimage a node
    Get-AzBatchComputeNode $poolId $computeNodeId2 -BatchContext $context | Reset-AzBatchComputeNode -ReimageOption $reimageOption -BatchContext $context
    $computeNode2 = Get-AzBatchComputeNode -PoolId $poolId $computeNodeId2 -BatchContext $context
    Assert-AreEqual 'Reimaging' $computeNode2.State
}

<#
.SYNOPSIS
Tests disabling and enabling compute node scheduling
#>
function Test-DisableAndEnableComputeNodeScheduling
{
    param([string]$poolId, [string]$computeNodeId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $disableOption = ([Microsoft.Azure.Batch.Common.DisableComputeNodeSchedulingOption]::Terminate)
    Get-AzBatchComputeNode $poolId $computeNodeId -BatchContext $context | Disable-AzBatchComputeNodeScheduling -DisableSchedulingOption $disableOption -BatchContext $context

    $computeNode = Get-AzBatchComputeNode -PoolId $poolId $computeNodeId -Select "id,schedulingState" -BatchContext $context
    Assert-AreEqual 'Disabled' $computeNode.SchedulingState

    $computeNode | Enable-AzBatchComputeNodeScheduling -BatchContext $context

    $computeNode = Get-AzBatchComputeNode -PoolId $poolId $computeNodeId -Select "id,schedulingState" -BatchContext $context
    Assert-AreEqual 'Enabled' $computeNode.SchedulingState
}

<#
.SYNOPSIS
Tests getting remote login settings from compute node 
#>
function Test-GetRemoteLoginSettings
{
    param([string]$poolId, [string]$computeNodeId)
    
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $remoteLoginSettings = Get-AzBatchComputeNode $poolId $computeNodeId -BatchContext $context | Get-AzBatchRemoteLoginSettings -BatchContext $context

    Assert-AreNotEqual $null $remoteLoginSettings.IPAddress
    Assert-AreNotEqual $null $remoteLoginSettings.Port
}

