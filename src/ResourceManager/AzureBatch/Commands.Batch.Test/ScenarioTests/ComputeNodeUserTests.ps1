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
Tests creating a compute node user
#>
function Test-CreateComputeNodeUser
{
    param([string]$poolId, [string]$computeNodeId, [string]$userName, [string]$usePipeline)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $password = "Password1234!"

    # Create a user
    if ($usePipeline -eq '1')
    {
        $expiryTime = New-Object DateTime -ArgumentList @(2020,01,01)
        $computeNode = Get-AzureBatchComputeNode $poolId $computeNodeId -BatchContext $context
        $computeNode | New-AzureBatchComputeNodeUser -Name $userName -Password $password -ExpiryTime $expiryTime -IsAdmin -BatchContext $context
    }
    else
    {
        New-AzureBatchComputeNodeUser -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -Password $password -BatchContext $context
    }

    # Verify that a user was created 
    # There is currently no Get/List user API, so verify by calling the delete operation. 
    # If the user account was created, it will succeed; otherwsie, it will throw a 404 error.
    Remove-AzureBatchComputeNodeUser -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -BatchContext $context
}

<#
.SYNOPSIS
Tests updating a compute node user
#>
function Test-UpdateComputeNodeUser
{
    param([string]$poolId, [string]$computeNodeId, [string]$userName)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Basically just validating that we can set the parameters and execute the cmdlet without error. 
    # If a Get user API is added, we can validate that the properties were actually updated.
    Set-AzureBatchComputeNodeUser $poolId $computeNodeId $userName "Abcdefghijk1234!" -ExpiryTime ([DateTime]::Now.AddDays(5)) -BatchContext $context
}

<#
.SYNOPSIS
Tests deleting a compute node user
#>
function Test-DeleteComputeNodeUser
{
    param([string]$poolId, [string]$computeNodeId, [string]$userName)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    Remove-AzureBatchComputeNodeUser -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -BatchContext $context

    # Verify the user was deleted
    # There is currently no Get/List user API, so try to delete the user again and verify that it fails.
    Assert-Throws { Remove-AzureBatchComputeNodeUser -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -BatchContext $context }
}