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
Tests compute node user operations
#>
function Test-ComputeNodeUserEndToEnd
{
    param([string]$poolId, [string]$computeNodeId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $userName = "userendtoend"
    $password1 = ConvertTo-SecureString "Password1234!" -AsPlainText -Force

    # Create a user
    New-AzureBatchComputeNodeUser -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -Password $password1 -BatchContext $context

    # Update the user. Since there's no Get user API, this also validates that the create call worked (no 404 error).
    # Basically just validating that we can set the parameters and execute the cmdlet without error. 
    # If a Get user API is added, we can validate that the properties were actually updated.
    $password2 = ConvertTo-SecureString "Abcdefghijk1234!" -AsPlainText -Force
    Set-AzureBatchComputeNodeUser $poolId $computeNodeId $userName $password2 -ExpiryTime ([DateTime]::Now.AddDays(5)) -BatchContext $context

    # Delete the user
    Remove-AzureBatchComputeNodeUser -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -BatchContext $context

    # Verify the user was deleted
    # There is currently no Get/List user API, so try to delete the user again and verify that it fails.
    Assert-Throws { Remove-AzureBatchComputeNodeUser -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -BatchContext $context }
}