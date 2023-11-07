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
	Tests creating a job private endpoint
#>
function Test-CreateJobPrivateEndpoint
{
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		$peName = Get-JobPrivateEndpointName 
		$s1 = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
		# Be aware, to successfully re-record this test you will have to go approve the private endpoint in the server's Networking blade. Otherwise, it will not complete or will timeout.
		$pe1AsJob = New-AzSqlElasticJobPrivateEndpoint -ElasticJobAgentObject $a1 -Name $peName -TargetServerAzureResourceId $s1.ResourceId -AsJob
		$pe1AsJob | Wait-Job

		# Give the backend a chance to persist the private endpoint before running Get
		Start-TestSleep 10

		$pe1 = Get-AzSqlElasticJobPrivateEndpoint -ElasticJobAgentObject $a1 -Name $peName

		# valide agent level properties
		Assert-AreEqual $pe1.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $pe1.ServerName $a1.ServerName
		Assert-AreEqual $pe1.AgentName $a1.AgentName

		# validate private endpoint properties
		Assert-AreEqual $pe1.PrivateEndpointName $peName
		Assert-AreEqual $pe1.TargetServerAzureResourceId $s1.ResourceId
		
		Assert-NotNullOrEmpty $pe1.PrivateEndpointId
		Assert-True {$pe1.PrivateEndpointId.Contains("EJ")} "PrivateEndpointId is missing substring 'EJ'"
		Assert-True {$pe1.PrivateEndpointId.Contains($peName)} "PrivateEndpointId is missing private endpoint name: $peName"
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests retrieving a job private endpoint
#>
function Test-GetJobPrivateEndpoint
{
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		$peName = Get-JobPrivateEndpointName 
		$s1 = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
		# Be aware, to successfully re-record this test you will have to go approve the private endpoint in the server's Networking blade. Otherwise, it will not complete or will timeout.
		$pe1AsJob = New-AzSqlElasticJobPrivateEndpoint -ElasticJobAgentObject $a1 -Name $peName -TargetServerAzureResourceId $s1.ResourceId -AsJob
		$pe1AsJob | Wait-Job

		# Give the backend a chance to persist the private endpoint before running Get
		Start-TestSleep 10

		# Validate with Default set
		$pe1 = Get-AzSqlElasticJobPrivateEndpoint -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $peName

		## valide agent level properties
		Assert-AreEqual $pe1.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $pe1.ServerName $a1.ServerName
		Assert-AreEqual $pe1.AgentName $a1.AgentName

		## validate private endpoint properties
		Assert-AreEqual $pe1.PrivateEndpointName $peName
		Assert-AreEqual $pe1.TargetServerAzureResourceId $s1.ResourceId
		
		Assert-NotNullOrEmpty $pe1.PrivateEndpointId
		Assert-True {$pe1.PrivateEndpointId.Contains("EJ")} "PrivateEndpointId is missing substring 'EJ'"
		Assert-True {$pe1.PrivateEndpointId.Contains($peName)} "PrivateEndpointId is missing private endpoint name: $peName"

		# Validate with Parent object
		$pe1 = Get-AzSqlElasticJobPrivateEndpoint -ElasticJobAgentObject $a1 -Name $peName

		## valide agent level properties
		Assert-AreEqual $pe1.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $pe1.ServerName $a1.ServerName
		Assert-AreEqual $pe1.AgentName $a1.AgentName

		## validate private endpoint properties
		Assert-AreEqual $pe1.PrivateEndpointName $peName
		Assert-AreEqual $pe1.TargetServerAzureResourceId $s1.ResourceId
		
		Assert-NotNullOrEmpty $pe1.PrivateEndpointId
		Assert-True {$pe1.PrivateEndpointId.Contains("EJ")} "PrivateEndpointId is missing substring 'EJ'"
		Assert-True {$pe1.PrivateEndpointId.Contains($peName)} "PrivateEndpointId is missing private endpoint name: $peName"

		# Validate with Piping 
		$pe1 = $a1 | Get-AzSqlElasticJobPrivateEndpoint -Name $peName

		## valide agent level properties
		Assert-AreEqual $pe1.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $pe1.ServerName $a1.ServerName
		Assert-AreEqual $pe1.AgentName $a1.AgentName

		## validate private endpoint properties
		Assert-AreEqual $pe1.PrivateEndpointName $peName
		Assert-AreEqual $pe1.TargetServerAzureResourceId $s1.ResourceId
		
		Assert-NotNullOrEmpty $pe1.PrivateEndpointId
		Assert-True {$pe1.PrivateEndpointId.Contains("EJ")} "PrivateEndpointId is missing substring 'EJ'"
		Assert-True {$pe1.PrivateEndpointId.Contains($peName)} "PrivateEndpointId is missing private endpoint name: $peName"

	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests removing a job private endpoint
#>
function Test-RemoveJobPrivateEndpoint
{
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		$peName = Get-JobPrivateEndpointName 
		$s1 = Get-AzSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
		# Be aware, to successfully re-record this test you will have to go approve the private endpoint in the server's Networking blade. Otherwise, it will not complete or will timeout.
		$pe1AsJob = New-AzSqlElasticJobPrivateEndpoint -ElasticJobAgentObject $a1 -Name $peName -TargetServerAzureResourceId $s1.ResourceId -AsJob
		$pe1AsJob | Wait-Job

		# Give the backend a chance to persist the private endpoint before running Get
		Start-TestSleep 10

		$pe1 = Get-AzSqlElasticJobPrivateEndpoint -ElasticJobAgentObject $a1 -Name $peName

		# valide agent level properties
		Assert-AreEqual $pe1.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $pe1.ServerName $a1.ServerName
		Assert-AreEqual $pe1.AgentName $a1.AgentName

		# validate private endpoint properties
		Assert-AreEqual $pe1.PrivateEndpointName $peName
		Assert-AreEqual $pe1.TargetServerAzureResourceId $s1.ResourceId
		
		Assert-NotNullOrEmpty $pe1.PrivateEndpointId
		Assert-True {$pe1.PrivateEndpointId.Contains("EJ")} "PrivateEndpointId is missing substring 'EJ'"
		Assert-True {$pe1.PrivateEndpointId.Contains($peName)} "PrivateEndpointId is missing private endpoint name: $peName"

		$pe1 = Remove-AzSqlElasticJobPrivateEndpoint -ElasticJobAgentObject $a1 -Name $peName -Force

		# valide agent level properties
		Assert-AreEqual $pe1.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $pe1.ServerName $a1.ServerName
		Assert-AreEqual $pe1.AgentName $a1.AgentName

		# validate private endpoint properties
		Assert-AreEqual $pe1.PrivateEndpointName $peName
		Assert-AreEqual $pe1.TargetServerAzureResourceId $s1.ResourceId
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}