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
	Tests creating a job credential
#>
function Test-CreateJobCredential
{
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-CreateJobCredentialWithDefaultParam $a1
		Test-CreateJobCredentialWithAgentObject $a1
		Test-CreateJobCredentialWithAgentResourceId $a1
		Test-CreateJobCredentialWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}


<#
	.SYNOPSIS
	Tests getting job credential
#>
function Test-GetJobCredential
{
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-GetJobCredentialWithDefaultParam $a1
		Test-GetJobCredentialWithAgentObject $a1
		Test-GetJobCredentialWithAgentResourceId $a1
		Test-GetJobCredentialWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests updating job credential
#>
function Test-UpdateJobCredential
{
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-UpdateJobCredentialWithDefaultParam $a1
		Test-UpdateJobCredentialWithInputObject $a1
		Test-UpdateJobCredentialWithResourceId $a1
		Test-UpdateJobCredentialWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests removing job credential
#>
function Test-RemoveJobCredential
{
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-RemoveJobCredentialWithDefaultParam $a1
		Test-RemoveJobCredentialWithInputObject $a1
		Test-RemoveJobCredentialWithResourceId $a1
		Test-RemoveJobCredentialWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests creating a job credential
#>
function Test-CreateJobCredentialWithDefaultParam ($a1)
{
	# Setup
	$cn1 = Get-JobCredentialName
	$c1 = Get-ServerCredential

	# Create using default params
	$resp = New-AzureRmSqlElasticJobCredential -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $cn1 -Credential $c1
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.CredentialName $cn1
	Assert-AreEqual $resp.UserName $c1.UserName
}

<#
	.SYNOPSIS
	Tests creating a job credential with agent object
#>
function Test-CreateJobCredentialWithAgentObject ($a1)
{
	# Setup
	$cn1 = Get-JobCredentialName
	$c1 = Get-ServerCredential

	# Create using agent input object
	$resp = New-AzureRmSqlElasticJobCredential -AgentObject $a1 -Name $cn1 -Credential $c1
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.CredentialName $cn1
	Assert-AreEqual $resp.UserName $c1.UserName
}

<#
	.SYNOPSIS
	Tests creating a job credential with resource id
#>
function Test-CreateJobCredentialWithAgentResourceId ($a1)
{
	# Setup
	$cn1 = Get-JobCredentialName
	$c1 = Get-ServerCredential

	# Create using agent resource id
	$resp = New-AzureRmSqlElasticJobCredential -AgentResourceId $a1.ResourceId -Name $cn1 -Credential $c1
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.CredentialName $cn1
	Assert-AreEqual $resp.UserName $c1.UserName
}

<#
	.SYNOPSIS
	Tests creating a job credential with piping
#>
function Test-CreateJobCredentialWithPiping ($a1)
{
	# Setup
	$cn1 = Get-JobCredentialName
	$c1 = Get-ServerCredential

	# Tests using piping
	$resp = $a1 | New-AzureRmSqlElasticJobCredential -Name $cn1 -Credential $c1
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.CredentialName $cn1
	Assert-AreEqual $resp.UserName $c1.UserName
}

<#
	.SYNOPSIS
	Tests updating a job credential with default param
#>
function Test-UpdateJobCredentialWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1

	# Test default parameters
	$newCred = Get-Credential
	$resp = Set-AzureRmSqlElasticJobCredential -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $jc1.CredentialName -Credential $newCred
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $newCred.UserName
}

<#
	.SYNOPSIS
	Tests updating a job credential with input object
#>
function Test-UpdateJobCredentialWithInputObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1

	# Test job credential input object
	$newCred = Get-Credential
	$resp = Set-AzureRmSqlElasticJobCredential -InputObject $jc1 -Credential $newCred
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $newCred.UserName
}

<#
	.SYNOPSIS
	Tests updating a job credential with resource id
#>
function Test-UpdateJobCredentialWithResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1

	# Test job credential resource id
	$newCred = Get-Credential
	$resp = Set-AzureRmSqlElasticJobCredential -ResourceId $jc1.ResourceId -Credential $newCred
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $newCred.UserName
}

<#
	.SYNOPSIS
	Tests updating a job credential with piping
#>
function Test-UpdateJobCredentialWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1

	# Test piping
	$newCred = Get-Credential
	$resp = $jc1 | Set-AzureRmSqlElasticJobCredential -Credential $newCred
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $newCred.UserName
}

<#
	.SYNOPSIS
	Tests getting a job credential
#>
function Test-GetJobCredentialWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1

	# Test default parameters - get specific credential
	$resp = Get-AzureRmSqlElasticJobCredential -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $jc1.CredentialName
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName

	# Test default parameters - get credentials
	$resp = Get-AzureRmSqlElasticJobCredential -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName
	Assert-True { $resp.Count -ge 2 }
}

<#
	.SYNOPSIS
	Tests getting a job credential with agent object
#>
function Test-GetJobCredentialWithAgentObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1

	# Test job credential input object
	$resp = Get-AzureRmSqlElasticJobCredential -AgentObject $a1 -Name $jc1.CredentialName

	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName

	# Test job credential input object - get credentials
	$resp = Get-AzureRmSqlElasticJobCredential -AgentObject $a1
	Assert-True { $resp.Count -ge 2 }
}

<#
	.SYNOPSIS
	Tests getting a job credential with agent resource id
#>
function Test-GetJobCredentialWithAgentResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1

		# Test job credential resource id
	$resp = Get-AzureRmSqlElasticJobCredential -AgentResourceId $a1.ResourceId -Name $jc1.CredentialName
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName

	# Test job credential resource id - get credentials
	$resp = Get-AzureRmSqlElasticJobCredential -AgentResourceId $a1.ResourceId
	Assert-True { $resp.Count -ge 2 }
}

<#
	.SYNOPSIS
	Tests getting a job credential with piping
#>
function Test-GetJobCredentialWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1

		# Test piping - get job credential
	$resp = $a1 | Get-AzureRmSqlElasticJobCredential -Name $jc1.CredentialName
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName

	# Test piping - get all credentials - should have at least 2
	$resp = $a1 | Get-AzureRmSqlElasticJobCredential
	Assert-True { $resp.Count -ge 2 }
}

<#
	.SYNOPSIS
	Tests removing a job credential with default param
#>
function Test-RemoveJobCredentialWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1

	# Test default parameters - Remove credential
	$resp = Remove-AzureRmSqlElasticJobCredential -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $jc1.CredentialName
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName
}

<#
	.SYNOPSIS
	Tests removing a job credential with input object
#>
function Test-RemoveJobCredentialWithInputObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1

	# Test input object
	$resp = Remove-AzureRmSqlElasticJobCredential -InputObject $jc1
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName
}

<#
	.SYNOPSIS
	Tests removing a job credential with resource id
#>
function Test-RemoveJobCredentialWithResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1

	# Test resource id
	$resp = Remove-AzureRmSqlElasticJobCredential -ResourceId $jc1.ResourceId
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName
}

<#
	.SYNOPSIS
	Tests removing a job credential with piping
#>
function Test-RemoveJobCredentialWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1

	# Test piping
	$resp = $jc1 | Remove-AzureRmSqlElasticJobCredential
	Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $a1.ServerName
	Assert-AreEqual $resp.AgentName $a1.AgentName
	Assert-AreEqual $resp.CredentialName $jc1.CredentialName
	Assert-AreEqual $resp.UserName $jc1.UserName

	# Test remove all - should have removed at least 1
	$all = $a1 | Get-AzureRmSqlElasticJobCredential
	$resp = $all | Remove-AzureRmSqlElasticJobCredential
	Assert-True { $resp.Count -ge 1 }
}