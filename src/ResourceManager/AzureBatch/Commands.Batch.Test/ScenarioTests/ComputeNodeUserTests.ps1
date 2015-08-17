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
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$userName, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$password = "Password1234!"

	# Create a user
	if ($usePipeline -eq '1')
	{
		$expiryTime = New-Object DateTime -ArgumentList @(2020,01,01)
		$computeNode = Get-AzureBatchComputeNode_ST $poolId $computeNodeId -BatchContext $context
		$computeNode | New-AzureBatchComputeNodeUser_ST -Name $userName -Password $password -ExpiryTime $expiryTime -IsAdmin -BatchContext $context
	}
	else
	{
		New-AzureBatchComputeNodeUser_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -Password $password -BatchContext $context
	}

	# Verify that a user was created 
	# There is currently no Get/List user API, so verify by calling the delete operation. 
	# If the user account was created, it will succeed; otherwsie, it will throw a 404 error.
	Remove-AzureBatchComputeNodeUser_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -Force -BatchContext $context
}

<#
.SYNOPSIS
Tests deleting a compute node user
#>
function Test-DeleteComputeNodeUser
{
	param([string]$accountName, [string]$poolId, [string]$computeNodeId, [string]$userName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	Remove-AzureBatchComputeNodeUser_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -Force -BatchContext $context

	# Verify the user was deleted
	# There is currently no Get/List user API, so try to delete the user again and verify that it fails.
	Assert-Throws { Remove-AzureBatchComputeNodeUser_ST -PoolId $poolId -ComputeNodeId $computeNodeId -Name $userName -Force -BatchContext $context }
}