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
		$pe1AsJob = New-AzSqlElasticJobPrivateEndpoint -ParentObject $a1 -Name $peName -TargetServerAzureResourceId $s1.ResourceId -AsJob

		# Give the backend a chance to persist the private endpoint before running Get
		Start-TestSleep -Seconds 30

		$pe1 = Get-AzSqlElasticJobPrivateEndpoint -ParentObject $a1 -Name $peName

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

		# will need three total scenarios for the diff parameter sets: default param, parentobject, and resourceid 
		# you will have to drop and re-create and use the -AsJob + Get resource to confirm
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}