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
Tests creating a User
#>
function Test-CreateUser
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$userName, [string]$usePipeline)

	$context = Get-AzureBatchAccountKeys -Name $accountName
	$password = "Password1234!"

	# Create a user
	if ($usePipeline -eq '1')
	{
		$expiryTime = [DateTime]::Now.AddDays(5)
		$vm = Get-AzureBatchVM_ST $poolName $vmName -BatchContext $context
		$vm | New-AzureBatchVMUser_ST -Name $userName -Password $password -ExpiryTime $expiryTime -IsAdmin -BatchContext $context
	}
	else
	{
		New-AzureBatchVMUser_ST -PoolName $poolName -VMName $vmName -Name $userName -Password $password -BatchContext $context
	}

	# Verify that a user was created 
	# There is currently no Get/List user API, so try to create the user again and verify that it fails.
	Assert-Throws { New-AzureBatchVMUser_ST -PoolName $poolName -VMName $vmName -Name $userName -Password $password -BatchContext $context }
}

<#
.SYNOPSIS
Tests deleting a user
#>
function Test-DeleteUser
{
	param([string]$accountName, [string]$poolName, [string]$vmName, [string]$userName)

	$context = Get-AzureBatchAccountKeys -Name $accountName

	Remove-AzureBatchVMUser_ST -PoolName $poolName -VMName $vmName -Name $userName -Force -BatchContext $context

	# Verify the user was deleted
	# There is currently no Get/List user API, so try to delete the user again and verify that it fails.
	Assert-Throws { Remove-AzureBatchUser_ST -PoolName $poolName -VMName $vmName -Name $userName -Force -BatchContext $context }
}