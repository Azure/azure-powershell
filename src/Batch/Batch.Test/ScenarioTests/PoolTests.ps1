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
       
        $vmSize = "standard_d1_v2"
        $publisher = "microsoft-azure-batch"
        $offer = "ubuntu-server-container"
        $osSKU = "20-04-lts"
        $nodeAgent = "batch.node.ubuntu 20.04"
        $imageRef = New-Object Microsoft.Azure.Commands.Batch.Models.PSImageReference -ArgumentList @($offer, $publisher, $osSKU)
        $iaasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSVirtualMachineConfiguration -ArgumentList @($imageRef, $nodeAgent)
        $iaasConfiguration.ContainerConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSContainerConfiguration
        $iaasConfiguration.ContainerConfiguration.ContainerImageNames = New-Object System.Collections.Generic.List[string]
        $iaasConfiguration.ContainerConfiguration.ContainerImageNames.Add("test1")
        $iaasConfiguration.ContainerConfiguration.type = "dockerCompatible"
        
        New-AzBatchPool $poolId1 -VirtualMachineConfiguration $iaasConfiguration -TargetDedicated $targetDedicated -VirtualMachineSize $vmSize -BatchContext $context


        $vmSize = "standard_d1_v2"
        $publisher = "microsoft-azure-batch"
        $offer = "ubuntu-server-container"
        $osSKU = "20-04-lts"
        $nodeAgent = "batch.node.ubuntu 20.04"
        $imageRef = New-Object Microsoft.Azure.Commands.Batch.Models.PSImageReference -ArgumentList @($offer, $publisher, $osSKU)
        $iaasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSVirtualMachineConfiguration -ArgumentList @($imageRef, $nodeAgent)
        $iaasConfiguration.ContainerConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSContainerConfiguration
        $iaasConfiguration.ContainerConfiguration.ContainerImageNames = New-Object System.Collections.Generic.List[string]
        $iaasConfiguration.ContainerConfiguration.ContainerImageNames.Add("test2")
        $iaasConfiguration.ContainerConfiguration.type = "dockerCompatible"

        New-AzBatchPool $poolId2 -VirtualMachineConfiguration $iaasConfiguration -TargetDedicated $targetDedicated -VirtualMachineSize $vmSize -BatchContext $context

        # List the pools to ensure they were created
        $pools = Get-AzBatchPool -Filter "id eq '$poolId1' or id eq '$poolId2'" -BatchContext $context
        $pool1 = $pools | Where-Object { $_.Id -eq $poolId1 }
        $pool2 = $pools | Where-Object { $_.Id -eq $poolId2 }
        Assert-NotNull $pool1
        Assert-NotNull $pool2

        # Ensure that some of the properties were set correctly
        Assert-NotNull $pool2.VirtualMachineConfiguration.ContainerConfiguration
        Assert-NotNull $pool2.VirtualMachineConfiguration.ContainerConfiguration.ContainerImageNames
        Assert-AreEqual "test2" $pool2.VirtualMachineConfiguration.ContainerConfiguration.ContainerImageNames[0]

        # Update a pool
        $startTaskCmd = "/bin/bash -c 'echo start task'"
        $startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask -ArgumentList @($startTaskCmd)
        $pool2.StartTask = $startTask
        $pool2 | Set-AzBatchPool -BatchContext $context
        $updatedPool = Get-AzBatchPool $poolId2 -BatchContext $context
        Assert-AreEqual $startTaskCmd $updatedPool.StartTask.CommandLine
    }
    finally
    {
        # Delete the pools
        Remove-AzBatchPool -Id $poolId1 -Force -BatchContext $context
        Remove-AzBatchPool -Id $poolId2 -Force -BatchContext $context

        # Verify the pools were deleted
        foreach ($p in Get-AzBatchPool -BatchContext $context)
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
    $pool = Get-AzBatchPool -Id $poolId -BatchContext $context
    $initialTargetDedicated = $pool.TargetDedicatedComputeNodes

    $newTargetDedicated = $initialTargetDedicated + 1
    Start-AzBatchPoolResize -Id $poolId -TargetDedicatedComputeNodes $newTargetDedicated -BatchContext $context

    # Verify the TargetDedicatedComputeNodes property was updated
    $pool = Get-AzBatchPool -Id $poolId -BatchContext $context
    Assert-AreEqual $newTargetDedicated $pool.TargetDedicatedComputeNodes

    # Stop the resize
    $pool | Stop-AzBatchPoolResize -BatchContext $context

    # Verify the AllocationState changed to Stopping
    $pool = Get-AzBatchPool -Id $poolId -BatchContext $context
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
    $pool = Get-AzBatchPool $poolId -BatchContext $context
    Assert-False { $pool.AutoScaleEnabled }

    $pool | Enable-AzBatchAutoScale -AutoScaleFormula $formula -AutoScaleEvaluationInterval $interval -BatchContext $context

    # Verify that autoscale was enabled. 
    # Use a filter because it seems that the recorder sometimes gets confused when two identical URLs are sent too close together
    $pool = Get-AzBatchPool -Filter "id eq '$poolId'" -BatchContext $context
    Assert-True { $pool.AutoScaleEnabled }
    Assert-AreEqual $interval $pool.AutoScaleEvaluationInterval

    # Try to evaluate a test formula
    $testFormula = '$TargetDedicatedNodes=1'
    $evalResult = Test-AzBatchAutoScale $poolId $testFormula -BatchContext $context

    # Verify that the evaluation result matches expectation
    Assert-True { $evalResult.Results.Contains($testFormula) }

    # Disable autoscale
    $pool | Disable-AzBatchAutoScale -BatchContext $context

    # Verify that autoscale was disabled
    $pool = Get-AzBatchPool $poolId -BatchContext $context
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
    $pool = Get-AzBatchPool $poolId -BatchContext $context
    Assert-AreNotEqual $specificOSVersion $pool.CloudServiceConfiguration.TargetOSVersion

    $pool | Set-AzBatchPoolOSVersion -TargetOSVersion $specificOSVersion -BatchContext $context
    
    # Verify the target OS version changed
    $pool = Get-AzBatchPool $poolId -BatchContext $context
    Assert-AreEqual $specificOSVersion $pool.CloudServiceConfiguration.TargetOSVersion
}