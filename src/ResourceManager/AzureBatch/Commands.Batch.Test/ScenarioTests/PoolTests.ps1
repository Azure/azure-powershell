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
Tests CRUD operations on Batch Pools
#>
function Test-PoolCRUD
{
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    
    $poolId1 = "pool1"
    $poolId2 = "pool2"

    try
    {
        # Create 2 pools
        $osFamily = "4"
        $targetOSVersion = "*"
        $targetDedicated = 0
        $vmSize = "small"
        $paasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @($osFamily, $targetOSVersion)
        New-AzureBatchPool $poolId1 -CloudServiceConfiguration $paasConfiguration -TargetDedicated $targetDedicated -VirtualMachineSize $vmSize -BatchContext $context

        $vmSize = "standard_a1"
        $publisher = "Canonical"
        $offer = "UbuntuServer"
        $osSKU = "16.04.0-LTS"
        $nodeAgent = "batch.node.ubuntu 16.04"
        $imageRef = New-Object Microsoft.Azure.Commands.Batch.Models.PSImageReference -ArgumentList @($offer, $publisher, $osSKU)
        $iaasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSVirtualMachineConfiguration -ArgumentList @($imageRef, $nodeAgent)
        New-AzureBatchPool $poolId2 -VirtualMachineConfiguration $iaasConfiguration -TargetDedicated $targetDedicated -VirtualMachineSize $vmSize -BatchContext $context

        # List the pools to ensure they were created
        $pools = Get-AzureBatchPool -Filter "id eq '$poolId1' or id eq '$poolId2'" -BatchContext $context
        $pool1 = $pools | Where-Object { $_.Id -eq $poolId1 }
        $pool2 = $pools | Where-Object { $_.Id -eq $poolId2 }
        Assert-NotNull $pool1
        Assert-NotNull $pool2

        # Update a pool
        $startTaskCmd = "/bin/bash -c 'echo start task'"
        $startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask -ArgumentList @($startTaskCmd)
        $pool2.StartTask = $startTask
        $pool2 | Set-AzureBatchPool -BatchContext $context
        $updatedPool = Get-AzureBatchPool $poolId2 -BatchContext $context
        Assert-AreEqual $startTaskCmd $updatedPool.StartTask.CommandLine
    }
    finally
    {
        # Delete the pools
        Remove-AzureBatchPool -Id $poolId1 -Force -BatchContext $context
        Remove-AzureBatchPool -Id $poolId2 -Force -BatchContext $context

        # Verify the pools were deleted
        foreach ($p in Get-AzureBatchPool -BatchContext $context)
        {
            Assert-True { ($p.Id -ne $poolId1 -and $p.Id -ne $poolId2) -or ($p.State.ToString().ToLower() -eq 'deleting') }
        }
    }
}

<#
.SYNOPSIS
Tests resizing a pool and stopping the resize
#>
function Test-ResizeAndStopResizePool
{
    param([string]$poolId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Get the initial TargetDedicated count
    $pool = Get-AzureBatchPool -Id $poolId -BatchContext $context
    $initialTargetDedicated = $pool.TargetDedicatedComputeNodes

    $newTargetDedicated = $initialTargetDedicated + 1
    Start-AzureBatchPoolResize -Id $poolId -TargetDedicatedComputeNodes $newTargetDedicated -BatchContext $context

    # Verify the TargetDedicatedComputeNodes property was updated
    $pool = Get-AzureBatchPool -Id $poolId -BatchContext $context
    Assert-AreEqual $newTargetDedicated $pool.TargetDedicatedComputeNodes

    # Stop the resize
    $pool | Stop-AzureBatchPoolResize -BatchContext $context

    # Verify the AllocationState changed to Stopping
    $pool = Get-AzureBatchPool -Id $poolId -BatchContext $context
    Assert-AreEqual 'Stopping' $pool.AllocationState
}

<#
.SYNOPSIS
Tests autoscale actions
#>
function Test-AutoScaleActions
{
    param([string]$poolId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $formula = '$TargetDedicatedNodes=0'
    $interval = ([TimeSpan]::FromMinutes(8))

    # Verify pool starts with autoscale disabled
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    Assert-False { $pool.AutoScaleEnabled }

    $pool | Enable-AzureBatchAutoScale -AutoScaleFormula $formula -AutoScaleEvaluationInterval $interval -BatchContext $context

    # Verify that autoscale was enabled. 
    # Use a filter because it seems that the recorder sometimes gets confused when two identical URLs are sent too close together
    $pool = Get-AzureBatchPool -Filter "id eq '$poolId'" -BatchContext $context
    Assert-True { $pool.AutoScaleEnabled }
    Assert-AreEqual $interval $pool.AutoScaleEvaluationInterval

    # Try to evaluate a test formula
    $testFormula = '$TargetDedicatedNodes=1'
    $evalResult = Test-AzureBatchAutoScale $poolId $testFormula -BatchContext $context

    # Verify that the evaluation result matches expectation
    Assert-True { $evalResult.Results.Contains($testFormula) }

    # Disable autoscale
    $pool | Disable-AzureBatchAutoScale -BatchContext $context

    # Verify that autoscale was disabled
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    Assert-False { $pool.AutoScaleEnabled }
}

<#
.SYNOPSIS
Tests changing the pool OS version
#>
function Test-ChangeOSVersion
{
    param([string]$poolId, [string]$specificOSVersion)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Pool should be using the default target OS version
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    Assert-AreNotEqual $specificOSVersion $pool.CloudServiceConfiguration.TargetOSVersion

    $pool | Set-AzureBatchPoolOSVersion -TargetOSVersion $specificOSVersion -BatchContext $context
    
    # Verify the target OS version changed
    $pool = Get-AzureBatchPool $poolId -BatchContext $context
    Assert-AreEqual $specificOSVersion $pool.CloudServiceConfiguration.TargetOSVersion
}